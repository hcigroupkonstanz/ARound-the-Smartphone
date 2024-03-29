﻿#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

using System;
using System.Linq;
using UnityEngine;
using Cysharp.Threading.Tasks.Internal;
using System.Threading;

#if UNITY_2019_3_OR_NEWER
using UnityEngine.LowLevel;
#else
using UnityEngine.Experimental.LowLevel;
#endif

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Cysharp.Threading.Tasks
{
    public static class UniTaskLoopRunners
    {
        public struct UniTaskLoopRunnerInitialization { };
        public struct UniTaskLoopRunnerEarlyUpdate { };
        public struct UniTaskLoopRunnerFixedUpdate { };
        public struct UniTaskLoopRunnerPreUpdate { };
        public struct UniTaskLoopRunnerUpdate { };
        public struct UniTaskLoopRunnerPreLateUpdate { };
        public struct UniTaskLoopRunnerPostLateUpdate { };

        // Last

        public struct UniTaskLoopRunnerLastInitialization { };
        public struct UniTaskLoopRunnerLastEarlyUpdate { };
        public struct UniTaskLoopRunnerLastFixedUpdate { };
        public struct UniTaskLoopRunnerLastPreUpdate { };
        public struct UniTaskLoopRunnerLastUpdate { };
        public struct UniTaskLoopRunnerLastPreLateUpdate { };
        public struct UniTaskLoopRunnerLastPostLateUpdate { };

        // Yield

        public struct UniTaskLoopRunnerYieldInitialization { };
        public struct UniTaskLoopRunnerYieldEarlyUpdate { };
        public struct UniTaskLoopRunnerYieldFixedUpdate { };
        public struct UniTaskLoopRunnerYieldPreUpdate { };
        public struct UniTaskLoopRunnerYieldUpdate { };
        public struct UniTaskLoopRunnerYieldPreLateUpdate { };
        public struct UniTaskLoopRunnerYieldPostLateUpdate { };

        // Yield Last

        public struct UniTaskLoopRunnerLastYieldInitialization { };
        public struct UniTaskLoopRunnerLastYieldEarlyUpdate { };
        public struct UniTaskLoopRunnerLastYieldFixedUpdate { };
        public struct UniTaskLoopRunnerLastYieldPreUpdate { };
        public struct UniTaskLoopRunnerLastYieldUpdate { };
        public struct UniTaskLoopRunnerLastYieldPreLateUpdate { };
        public struct UniTaskLoopRunnerLastYieldPostLateUpdate { };
    }

    public enum PlayerLoopTiming
    {
        Initialization = 0,
        LastInitialization = 1,

        EarlyUpdate = 2,
        LastEarlyUpdate = 3,

        FixedUpdate = 4,
        LastFixedUpdate = 5,

        PreUpdate = 6,
        LastPreUpdate = 7,

        Update = 8,
        LastUpdate = 9,

        PreLateUpdate = 10,
        LastPreLateUpdate = 11,

        PostLateUpdate = 12,
        LastPostLateUpdate = 13
    }

    public interface IPlayerLoopItem
    {
        bool MoveNext();
    }

    public static class PlayerLoopHelper
    {
        public static SynchronizationContext UnitySynchronizationContext => unitySynchronizationContetext;
        public static int MainThreadId => mainThreadId;

        static int mainThreadId;
        static SynchronizationContext unitySynchronizationContetext;
        static ContinuationQueue[] yielders;
        static PlayerLoopRunner[] runners;

        static PlayerLoopSystem[] InsertRunner(PlayerLoopSystem loopSystem,
            Type loopRunnerYieldType, ContinuationQueue cq, Type lastLoopRunnerYieldType, ContinuationQueue lastCq,
            Type loopRunnerType, PlayerLoopRunner runner, Type lastLoopRunnerType, PlayerLoopRunner lastRunner)
        {

#if UNITY_EDITOR
            EditorApplication.playModeStateChanged += (state) =>
            {
                if (state == PlayModeStateChange.EnteredEditMode || state == PlayModeStateChange.EnteredPlayMode)
                {
                    return;
                }

                if (runner != null)
                {
                    runner.Clear();
                }
                if (lastRunner != null)
                {
                    lastRunner.Clear();
                }

                if (cq != null)
                {
                    cq.Clear();
                }
                if (lastCq != null)
                {
                    lastCq.Clear();
                }
            };
#endif

            var yieldLoop = new PlayerLoopSystem
            {
                type = loopRunnerYieldType,
                updateDelegate = cq.Run
            };

            var lastYieldLoop = new PlayerLoopSystem
            {
                type = lastLoopRunnerYieldType,
                updateDelegate = lastCq.Run
            };

            var runnerLoop = new PlayerLoopSystem
            {
                type = loopRunnerType,
                updateDelegate = runner.Run
            };

            var lastRunnerLoop = new PlayerLoopSystem
            {
                type = lastLoopRunnerType,
                updateDelegate = lastRunner.Run
            };

            // Remove items from previous initializations.
            var source = loopSystem.subSystemList
                .Where(ls => ls.type != loopRunnerYieldType && ls.type != loopRunnerType && ls.type != lastLoopRunnerYieldType && ls.type != lastLoopRunnerType)
                .ToArray();

            var dest = new PlayerLoopSystem[source.Length + 4];

            Array.Copy(source, 0, dest, 2, source.Length);
            dest[0] = yieldLoop;
            dest[1] = runnerLoop;
            dest[dest.Length - 2] = lastYieldLoop;
            dest[dest.Length - 1] = lastRunnerLoop;

            return dest;
        }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        static void Init()
        {
            // capture default(unity) sync-context.
            unitySynchronizationContetext = SynchronizationContext.Current;
            mainThreadId = Thread.CurrentThread.ManagedThreadId;

#if UNITY_EDITOR && UNITY_2019_3_OR_NEWER
            // When domain reload is disabled, re-initialization is required when entering play mode; 
            // otherwise, pending tasks will leak between play mode sessions.
            var domainReloadDisabled = UnityEditor.EditorSettings.enterPlayModeOptionsEnabled &&
                UnityEditor.EditorSettings.enterPlayModeOptions.HasFlag(UnityEditor.EnterPlayModeOptions.DisableDomainReload);
            if (!domainReloadDisabled && runners != null) return;
#else
            if (runners != null) return; // already initialized
#endif

            var playerLoop =
#if UNITY_2019_3_OR_NEWER
                PlayerLoop.GetCurrentPlayerLoop();
#else
                PlayerLoop.GetDefaultPlayerLoop();
#endif

            Initialize(ref playerLoop);
        }


#if UNITY_EDITOR
        [InitializeOnLoadMethod]
        static void InitOnEditor()
        {
            //Execute the play mode init method
            Init();

            //register an Editor update delegate, used to forcing playerLoop update
            EditorApplication.update += ForceEditorPlayerLoopUpdate;
        }

        private static void ForceEditorPlayerLoopUpdate()
        {
            if (EditorApplication.isPlayingOrWillChangePlaymode || EditorApplication.isCompiling ||
                EditorApplication.isUpdating)
            {
                // Not in Edit mode, don't interfere
                return;
            }

            //force unity to update PlayerLoop callbacks
            EditorApplication.QueuePlayerLoopUpdate();
        }

#endif

        public static void Initialize(ref PlayerLoopSystem playerLoop)
        {
            yielders = new ContinuationQueue[14];
            runners = new PlayerLoopRunner[14];

            var copyList = playerLoop.subSystemList.ToArray();

            // Initialization
            copyList[0].subSystemList = InsertRunner(copyList[0], typeof(UniTaskLoopRunners.UniTaskLoopRunnerYieldInitialization), yielders[0] = new ContinuationQueue(),
                                                                  typeof(UniTaskLoopRunners.UniTaskLoopRunnerLastYieldInitialization), yielders[1] = new ContinuationQueue(),
                                                                  typeof(UniTaskLoopRunners.UniTaskLoopRunnerInitialization), runners[1] = new PlayerLoopRunner(),
                                                                  typeof(UniTaskLoopRunners.UniTaskLoopRunnerLastInitialization), runners[1] = new PlayerLoopRunner());
            // EarlyUpdate
            copyList[1].subSystemList = InsertRunner(copyList[1], typeof(UniTaskLoopRunners.UniTaskLoopRunnerYieldEarlyUpdate), yielders[2] = new ContinuationQueue(),
                                                                  typeof(UniTaskLoopRunners.UniTaskLoopRunnerLastYieldEarlyUpdate), yielders[3] = new ContinuationQueue(),
                                                                  typeof(UniTaskLoopRunners.UniTaskLoopRunnerEarlyUpdate), runners[2] = new PlayerLoopRunner(),
                                                                  typeof(UniTaskLoopRunners.UniTaskLoopRunnerLastEarlyUpdate), runners[3] = new PlayerLoopRunner());
            // FixedUpdate
            copyList[2].subSystemList = InsertRunner(copyList[2], typeof(UniTaskLoopRunners.UniTaskLoopRunnerYieldFixedUpdate), yielders[4] = new ContinuationQueue(),
                                                                  typeof(UniTaskLoopRunners.UniTaskLoopRunnerLastYieldFixedUpdate), yielders[5] = new ContinuationQueue(),
                                                                  typeof(UniTaskLoopRunners.UniTaskLoopRunnerFixedUpdate), runners[4] = new PlayerLoopRunner(),
                                                                  typeof(UniTaskLoopRunners.UniTaskLoopRunnerLastFixedUpdate), runners[5] = new PlayerLoopRunner());
            // PreUpdate
            copyList[3].subSystemList = InsertRunner(copyList[3], typeof(UniTaskLoopRunners.UniTaskLoopRunnerYieldPreUpdate), yielders[6] = new ContinuationQueue(),
                                                                  typeof(UniTaskLoopRunners.UniTaskLoopRunnerLastYieldPreUpdate), yielders[7] = new ContinuationQueue(),
                                                                  typeof(UniTaskLoopRunners.UniTaskLoopRunnerPreUpdate), runners[6] = new PlayerLoopRunner(),
                                                                  typeof(UniTaskLoopRunners.UniTaskLoopRunnerLastPreUpdate), runners[7] = new PlayerLoopRunner());
            // Update
            copyList[4].subSystemList = InsertRunner(copyList[4], typeof(UniTaskLoopRunners.UniTaskLoopRunnerYieldUpdate), yielders[8] = new ContinuationQueue(),
                                                                  typeof(UniTaskLoopRunners.UniTaskLoopRunnerLastYieldUpdate), yielders[9] = new ContinuationQueue(),
                                                                  typeof(UniTaskLoopRunners.UniTaskLoopRunnerUpdate), runners[8] = new PlayerLoopRunner(),
                                                                  typeof(UniTaskLoopRunners.UniTaskLoopRunnerLastUpdate), runners[9] = new PlayerLoopRunner());
            // PreLateUpdate
            copyList[5].subSystemList = InsertRunner(copyList[5], typeof(UniTaskLoopRunners.UniTaskLoopRunnerYieldPreLateUpdate), yielders[10] = new ContinuationQueue(),
                                                                  typeof(UniTaskLoopRunners.UniTaskLoopRunnerLastYieldPreLateUpdate), yielders[11] = new ContinuationQueue(),
                                                                  typeof(UniTaskLoopRunners.UniTaskLoopRunnerPreLateUpdate), runners[10] = new PlayerLoopRunner(),
                                                                  typeof(UniTaskLoopRunners.UniTaskLoopRunnerLastPreLateUpdate), runners[11] = new PlayerLoopRunner());
            // PostLateUpdate
            copyList[6].subSystemList = InsertRunner(copyList[6], typeof(UniTaskLoopRunners.UniTaskLoopRunnerYieldPostLateUpdate), yielders[12] = new ContinuationQueue(),
                                                                  typeof(UniTaskLoopRunners.UniTaskLoopRunnerLastYieldPostLateUpdate), yielders[13] = new ContinuationQueue(),
                                                                  typeof(UniTaskLoopRunners.UniTaskLoopRunnerPostLateUpdate), runners[12] = new PlayerLoopRunner(),
                                                                  typeof(UniTaskLoopRunners.UniTaskLoopRunnerLastPostLateUpdate), runners[13] = new PlayerLoopRunner());

            playerLoop.subSystemList = copyList;
            PlayerLoop.SetPlayerLoop(playerLoop);
        }

        public static void AddAction(PlayerLoopTiming timing, IPlayerLoopItem action)
        {
            runners[(int)timing].AddAction(action);
        }

        public static void AddContinuation(PlayerLoopTiming timing, Action continuation)
        {
            yielders[(int)timing].Enqueue(continuation);
        }
    }
}

