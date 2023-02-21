﻿#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

using System.Threading;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Cysharp.Threading.Tasks.Triggers
{
#region FixedUpdate

    public interface IAsyncFixedUpdateHandler
    {
        UniTask FixedUpdateAsync();
    }

    public partial class AsyncTriggerHandler<T> : IAsyncFixedUpdateHandler
    {
        UniTask IAsyncFixedUpdateHandler.FixedUpdateAsync()
        {
            core.Reset();
            return new UniTask((IUniTaskSource)(object)this, core.Version);
        }
    }

    public static partial class AsyncTriggerExtensions
    {
        public static AsyncFixedUpdateTrigger GetAsyncFixedUpdateTrigger(this GameObject gameObject)
        {
            return GetOrAddComponent<AsyncFixedUpdateTrigger>(gameObject);
        }
        
        public static AsyncFixedUpdateTrigger GetAsyncFixedUpdateTrigger(this Component component)
        {
            return component.gameObject.GetAsyncFixedUpdateTrigger();
        }
    }

    [DisallowMultipleComponent]
    public sealed class AsyncFixedUpdateTrigger : AsyncTriggerBase
    {
        TriggerEvent<AsyncUnit> fixedUpdateTriggerEvent;

        void FixedUpdate()
        {
            fixedUpdateTriggerEvent?.TrySetResult(AsyncUnit.Default);
        }

        public IAsyncFixedUpdateHandler GetFixedUpdateAsyncHandler()
        {
            return new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref fixedUpdateTriggerEvent), false);
        }

        public IAsyncFixedUpdateHandler GetFixedUpdateAsyncHandler(CancellationToken cancellationToken)
        {
            return new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref fixedUpdateTriggerEvent), cancellationToken, false);
        }

        public UniTask FixedUpdateAsync()
        {
            return ((IAsyncFixedUpdateHandler)new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref fixedUpdateTriggerEvent), true)).FixedUpdateAsync();
        }

        public UniTask FixedUpdateAsync(CancellationToken cancellationToken)
        {
            return ((IAsyncFixedUpdateHandler)new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref fixedUpdateTriggerEvent), cancellationToken, true)).FixedUpdateAsync();
        }
    }
#endregion

#region LateUpdate

    public interface IAsyncLateUpdateHandler
    {
        UniTask LateUpdateAsync();
    }

    public partial class AsyncTriggerHandler<T> : IAsyncLateUpdateHandler
    {
        UniTask IAsyncLateUpdateHandler.LateUpdateAsync()
        {
            core.Reset();
            return new UniTask((IUniTaskSource)(object)this, core.Version);
        }
    }

    public static partial class AsyncTriggerExtensions
    {
        public static AsyncLateUpdateTrigger GetAsyncLateUpdateTrigger(this GameObject gameObject)
        {
            return GetOrAddComponent<AsyncLateUpdateTrigger>(gameObject);
        }
        
        public static AsyncLateUpdateTrigger GetAsyncLateUpdateTrigger(this Component component)
        {
            return component.gameObject.GetAsyncLateUpdateTrigger();
        }
    }

    [DisallowMultipleComponent]
    public sealed class AsyncLateUpdateTrigger : AsyncTriggerBase
    {
        TriggerEvent<AsyncUnit> lateUpdateTriggerEvent;

        void LateUpdate()
        {
            lateUpdateTriggerEvent?.TrySetResult(AsyncUnit.Default);
        }

        public IAsyncLateUpdateHandler GetLateUpdateAsyncHandler()
        {
            return new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref lateUpdateTriggerEvent), false);
        }

        public IAsyncLateUpdateHandler GetLateUpdateAsyncHandler(CancellationToken cancellationToken)
        {
            return new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref lateUpdateTriggerEvent), cancellationToken, false);
        }

        public UniTask LateUpdateAsync()
        {
            return ((IAsyncLateUpdateHandler)new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref lateUpdateTriggerEvent), true)).LateUpdateAsync();
        }

        public UniTask LateUpdateAsync(CancellationToken cancellationToken)
        {
            return ((IAsyncLateUpdateHandler)new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref lateUpdateTriggerEvent), cancellationToken, true)).LateUpdateAsync();
        }
    }
#endregion

#region AnimatorIK

    public interface IAsyncOnAnimatorIKHandler
    {
        UniTask<int> OnAnimatorIKAsync();
    }

    public partial class AsyncTriggerHandler<T> : IAsyncOnAnimatorIKHandler
    {
        UniTask<int> IAsyncOnAnimatorIKHandler.OnAnimatorIKAsync()
        {
            core.Reset();
            return new UniTask<int>((IUniTaskSource<int>)(object)this, core.Version);
        }
    }

    public static partial class AsyncTriggerExtensions
    {
        public static AsyncAnimatorIKTrigger GetAsyncAnimatorIKTrigger(this GameObject gameObject)
        {
            return GetOrAddComponent<AsyncAnimatorIKTrigger>(gameObject);
        }
        
        public static AsyncAnimatorIKTrigger GetAsyncAnimatorIKTrigger(this Component component)
        {
            return component.gameObject.GetAsyncAnimatorIKTrigger();
        }
    }

    [DisallowMultipleComponent]
    public sealed class AsyncAnimatorIKTrigger : AsyncTriggerBase
    {
        TriggerEvent<int> onAnimatorIKTriggerEvent;

        void OnAnimatorIK(int layerIndex)
        {
            onAnimatorIKTriggerEvent?.TrySetResult((layerIndex));
        }

        public IAsyncOnAnimatorIKHandler GetOnAnimatorIKAsyncHandler()
        {
            return new AsyncTriggerHandler<int>(SetTriggerEvent(ref onAnimatorIKTriggerEvent), false);
        }

        public IAsyncOnAnimatorIKHandler GetOnAnimatorIKAsyncHandler(CancellationToken cancellationToken)
        {
            return new AsyncTriggerHandler<int>(SetTriggerEvent(ref onAnimatorIKTriggerEvent), cancellationToken, false);
        }

        public UniTask<int> OnAnimatorIKAsync()
        {
            return ((IAsyncOnAnimatorIKHandler)new AsyncTriggerHandler<int>(SetTriggerEvent(ref onAnimatorIKTriggerEvent), true)).OnAnimatorIKAsync();
        }

        public UniTask<int> OnAnimatorIKAsync(CancellationToken cancellationToken)
        {
            return ((IAsyncOnAnimatorIKHandler)new AsyncTriggerHandler<int>(SetTriggerEvent(ref onAnimatorIKTriggerEvent), cancellationToken, true)).OnAnimatorIKAsync();
        }
    }
#endregion

#region AnimatorMove

    public interface IAsyncOnAnimatorMoveHandler
    {
        UniTask OnAnimatorMoveAsync();
    }

    public partial class AsyncTriggerHandler<T> : IAsyncOnAnimatorMoveHandler
    {
        UniTask IAsyncOnAnimatorMoveHandler.OnAnimatorMoveAsync()
        {
            core.Reset();
            return new UniTask((IUniTaskSource)(object)this, core.Version);
        }
    }

    public static partial class AsyncTriggerExtensions
    {
        public static AsyncAnimatorMoveTrigger GetAsyncAnimatorMoveTrigger(this GameObject gameObject)
        {
            return GetOrAddComponent<AsyncAnimatorMoveTrigger>(gameObject);
        }
        
        public static AsyncAnimatorMoveTrigger GetAsyncAnimatorMoveTrigger(this Component component)
        {
            return component.gameObject.GetAsyncAnimatorMoveTrigger();
        }
    }

    [DisallowMultipleComponent]
    public sealed class AsyncAnimatorMoveTrigger : AsyncTriggerBase
    {
        TriggerEvent<AsyncUnit> onAnimatorMoveTriggerEvent;

        void OnAnimatorMove()
        {
            onAnimatorMoveTriggerEvent?.TrySetResult(AsyncUnit.Default);
        }

        public IAsyncOnAnimatorMoveHandler GetOnAnimatorMoveAsyncHandler()
        {
            return new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onAnimatorMoveTriggerEvent), false);
        }

        public IAsyncOnAnimatorMoveHandler GetOnAnimatorMoveAsyncHandler(CancellationToken cancellationToken)
        {
            return new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onAnimatorMoveTriggerEvent), cancellationToken, false);
        }

        public UniTask OnAnimatorMoveAsync()
        {
            return ((IAsyncOnAnimatorMoveHandler)new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onAnimatorMoveTriggerEvent), true)).OnAnimatorMoveAsync();
        }

        public UniTask OnAnimatorMoveAsync(CancellationToken cancellationToken)
        {
            return ((IAsyncOnAnimatorMoveHandler)new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onAnimatorMoveTriggerEvent), cancellationToken, true)).OnAnimatorMoveAsync();
        }
    }
#endregion

#region ApplicationFocus

    public interface IAsyncOnApplicationFocusHandler
    {
        UniTask<bool> OnApplicationFocusAsync();
    }

    public partial class AsyncTriggerHandler<T> : IAsyncOnApplicationFocusHandler
    {
        UniTask<bool> IAsyncOnApplicationFocusHandler.OnApplicationFocusAsync()
        {
            core.Reset();
            return new UniTask<bool>((IUniTaskSource<bool>)(object)this, core.Version);
        }
    }

    public static partial class AsyncTriggerExtensions
    {
        public static AsyncApplicationFocusTrigger GetAsyncApplicationFocusTrigger(this GameObject gameObject)
        {
            return GetOrAddComponent<AsyncApplicationFocusTrigger>(gameObject);
        }
        
        public static AsyncApplicationFocusTrigger GetAsyncApplicationFocusTrigger(this Component component)
        {
            return component.gameObject.GetAsyncApplicationFocusTrigger();
        }
    }

    [DisallowMultipleComponent]
    public sealed class AsyncApplicationFocusTrigger : AsyncTriggerBase
    {
        TriggerEvent<bool> onApplicationFocusTriggerEvent;

        void OnApplicationFocus(bool hasFocus)
        {
            onApplicationFocusTriggerEvent?.TrySetResult((hasFocus));
        }

        public IAsyncOnApplicationFocusHandler GetOnApplicationFocusAsyncHandler()
        {
            return new AsyncTriggerHandler<bool>(SetTriggerEvent(ref onApplicationFocusTriggerEvent), false);
        }

        public IAsyncOnApplicationFocusHandler GetOnApplicationFocusAsyncHandler(CancellationToken cancellationToken)
        {
            return new AsyncTriggerHandler<bool>(SetTriggerEvent(ref onApplicationFocusTriggerEvent), cancellationToken, false);
        }

        public UniTask<bool> OnApplicationFocusAsync()
        {
            return ((IAsyncOnApplicationFocusHandler)new AsyncTriggerHandler<bool>(SetTriggerEvent(ref onApplicationFocusTriggerEvent), true)).OnApplicationFocusAsync();
        }

        public UniTask<bool> OnApplicationFocusAsync(CancellationToken cancellationToken)
        {
            return ((IAsyncOnApplicationFocusHandler)new AsyncTriggerHandler<bool>(SetTriggerEvent(ref onApplicationFocusTriggerEvent), cancellationToken, true)).OnApplicationFocusAsync();
        }
    }
#endregion

#region ApplicationPause

    public interface IAsyncOnApplicationPauseHandler
    {
        UniTask<bool> OnApplicationPauseAsync();
    }

    public partial class AsyncTriggerHandler<T> : IAsyncOnApplicationPauseHandler
    {
        UniTask<bool> IAsyncOnApplicationPauseHandler.OnApplicationPauseAsync()
        {
            core.Reset();
            return new UniTask<bool>((IUniTaskSource<bool>)(object)this, core.Version);
        }
    }

    public static partial class AsyncTriggerExtensions
    {
        public static AsyncApplicationPauseTrigger GetAsyncApplicationPauseTrigger(this GameObject gameObject)
        {
            return GetOrAddComponent<AsyncApplicationPauseTrigger>(gameObject);
        }
        
        public static AsyncApplicationPauseTrigger GetAsyncApplicationPauseTrigger(this Component component)
        {
            return component.gameObject.GetAsyncApplicationPauseTrigger();
        }
    }

    [DisallowMultipleComponent]
    public sealed class AsyncApplicationPauseTrigger : AsyncTriggerBase
    {
        TriggerEvent<bool> onApplicationPauseTriggerEvent;

        void OnApplicationPause(bool pauseStatus)
        {
            onApplicationPauseTriggerEvent?.TrySetResult((pauseStatus));
        }

        public IAsyncOnApplicationPauseHandler GetOnApplicationPauseAsyncHandler()
        {
            return new AsyncTriggerHandler<bool>(SetTriggerEvent(ref onApplicationPauseTriggerEvent), false);
        }

        public IAsyncOnApplicationPauseHandler GetOnApplicationPauseAsyncHandler(CancellationToken cancellationToken)
        {
            return new AsyncTriggerHandler<bool>(SetTriggerEvent(ref onApplicationPauseTriggerEvent), cancellationToken, false);
        }

        public UniTask<bool> OnApplicationPauseAsync()
        {
            return ((IAsyncOnApplicationPauseHandler)new AsyncTriggerHandler<bool>(SetTriggerEvent(ref onApplicationPauseTriggerEvent), true)).OnApplicationPauseAsync();
        }

        public UniTask<bool> OnApplicationPauseAsync(CancellationToken cancellationToken)
        {
            return ((IAsyncOnApplicationPauseHandler)new AsyncTriggerHandler<bool>(SetTriggerEvent(ref onApplicationPauseTriggerEvent), cancellationToken, true)).OnApplicationPauseAsync();
        }
    }
#endregion

#region ApplicationQuit

    public interface IAsyncOnApplicationQuitHandler
    {
        UniTask OnApplicationQuitAsync();
    }

    public partial class AsyncTriggerHandler<T> : IAsyncOnApplicationQuitHandler
    {
        UniTask IAsyncOnApplicationQuitHandler.OnApplicationQuitAsync()
        {
            core.Reset();
            return new UniTask((IUniTaskSource)(object)this, core.Version);
        }
    }

    public static partial class AsyncTriggerExtensions
    {
        public static AsyncApplicationQuitTrigger GetAsyncApplicationQuitTrigger(this GameObject gameObject)
        {
            return GetOrAddComponent<AsyncApplicationQuitTrigger>(gameObject);
        }
        
        public static AsyncApplicationQuitTrigger GetAsyncApplicationQuitTrigger(this Component component)
        {
            return component.gameObject.GetAsyncApplicationQuitTrigger();
        }
    }

    [DisallowMultipleComponent]
    public sealed class AsyncApplicationQuitTrigger : AsyncTriggerBase
    {
        TriggerEvent<AsyncUnit> onApplicationQuitTriggerEvent;

        void OnApplicationQuit()
        {
            onApplicationQuitTriggerEvent?.TrySetResult(AsyncUnit.Default);
        }

        public IAsyncOnApplicationQuitHandler GetOnApplicationQuitAsyncHandler()
        {
            return new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onApplicationQuitTriggerEvent), false);
        }

        public IAsyncOnApplicationQuitHandler GetOnApplicationQuitAsyncHandler(CancellationToken cancellationToken)
        {
            return new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onApplicationQuitTriggerEvent), cancellationToken, false);
        }

        public UniTask OnApplicationQuitAsync()
        {
            return ((IAsyncOnApplicationQuitHandler)new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onApplicationQuitTriggerEvent), true)).OnApplicationQuitAsync();
        }

        public UniTask OnApplicationQuitAsync(CancellationToken cancellationToken)
        {
            return ((IAsyncOnApplicationQuitHandler)new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onApplicationQuitTriggerEvent), cancellationToken, true)).OnApplicationQuitAsync();
        }
    }
#endregion

#region AudioFilterRead

    public interface IAsyncOnAudioFilterReadHandler
    {
        UniTask<(float[] data, int channels)> OnAudioFilterReadAsync();
    }

    public partial class AsyncTriggerHandler<T> : IAsyncOnAudioFilterReadHandler
    {
        UniTask<(float[] data, int channels)> IAsyncOnAudioFilterReadHandler.OnAudioFilterReadAsync()
        {
            core.Reset();
            return new UniTask<(float[] data, int channels)>((IUniTaskSource<(float[] data, int channels)>)(object)this, core.Version);
        }
    }

    public static partial class AsyncTriggerExtensions
    {
        public static AsyncAudioFilterReadTrigger GetAsyncAudioFilterReadTrigger(this GameObject gameObject)
        {
            return GetOrAddComponent<AsyncAudioFilterReadTrigger>(gameObject);
        }
        
        public static AsyncAudioFilterReadTrigger GetAsyncAudioFilterReadTrigger(this Component component)
        {
            return component.gameObject.GetAsyncAudioFilterReadTrigger();
        }
    }

    [DisallowMultipleComponent]
    public sealed class AsyncAudioFilterReadTrigger : AsyncTriggerBase
    {
        TriggerEvent<(float[] data, int channels)> onAudioFilterReadTriggerEvent;

        void OnAudioFilterRead(float[] data, int channels)
        {
            onAudioFilterReadTriggerEvent?.TrySetResult((data, channels));
        }

        public IAsyncOnAudioFilterReadHandler GetOnAudioFilterReadAsyncHandler()
        {
            return new AsyncTriggerHandler<(float[] data, int channels)>(SetTriggerEvent(ref onAudioFilterReadTriggerEvent), false);
        }

        public IAsyncOnAudioFilterReadHandler GetOnAudioFilterReadAsyncHandler(CancellationToken cancellationToken)
        {
            return new AsyncTriggerHandler<(float[] data, int channels)>(SetTriggerEvent(ref onAudioFilterReadTriggerEvent), cancellationToken, false);
        }

        public UniTask<(float[] data, int channels)> OnAudioFilterReadAsync()
        {
            return ((IAsyncOnAudioFilterReadHandler)new AsyncTriggerHandler<(float[] data, int channels)>(SetTriggerEvent(ref onAudioFilterReadTriggerEvent), true)).OnAudioFilterReadAsync();
        }

        public UniTask<(float[] data, int channels)> OnAudioFilterReadAsync(CancellationToken cancellationToken)
        {
            return ((IAsyncOnAudioFilterReadHandler)new AsyncTriggerHandler<(float[] data, int channels)>(SetTriggerEvent(ref onAudioFilterReadTriggerEvent), cancellationToken, true)).OnAudioFilterReadAsync();
        }
    }
#endregion

#region BecameInvisible

    public interface IAsyncOnBecameInvisibleHandler
    {
        UniTask OnBecameInvisibleAsync();
    }

    public partial class AsyncTriggerHandler<T> : IAsyncOnBecameInvisibleHandler
    {
        UniTask IAsyncOnBecameInvisibleHandler.OnBecameInvisibleAsync()
        {
            core.Reset();
            return new UniTask((IUniTaskSource)(object)this, core.Version);
        }
    }

    public static partial class AsyncTriggerExtensions
    {
        public static AsyncBecameInvisibleTrigger GetAsyncBecameInvisibleTrigger(this GameObject gameObject)
        {
            return GetOrAddComponent<AsyncBecameInvisibleTrigger>(gameObject);
        }
        
        public static AsyncBecameInvisibleTrigger GetAsyncBecameInvisibleTrigger(this Component component)
        {
            return component.gameObject.GetAsyncBecameInvisibleTrigger();
        }
    }

    [DisallowMultipleComponent]
    public sealed class AsyncBecameInvisibleTrigger : AsyncTriggerBase
    {
        TriggerEvent<AsyncUnit> onBecameInvisibleTriggerEvent;

        void OnBecameInvisible()
        {
            onBecameInvisibleTriggerEvent?.TrySetResult(AsyncUnit.Default);
        }

        public IAsyncOnBecameInvisibleHandler GetOnBecameInvisibleAsyncHandler()
        {
            return new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onBecameInvisibleTriggerEvent), false);
        }

        public IAsyncOnBecameInvisibleHandler GetOnBecameInvisibleAsyncHandler(CancellationToken cancellationToken)
        {
            return new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onBecameInvisibleTriggerEvent), cancellationToken, false);
        }

        public UniTask OnBecameInvisibleAsync()
        {
            return ((IAsyncOnBecameInvisibleHandler)new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onBecameInvisibleTriggerEvent), true)).OnBecameInvisibleAsync();
        }

        public UniTask OnBecameInvisibleAsync(CancellationToken cancellationToken)
        {
            return ((IAsyncOnBecameInvisibleHandler)new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onBecameInvisibleTriggerEvent), cancellationToken, true)).OnBecameInvisibleAsync();
        }
    }
#endregion

#region BecameVisible

    public interface IAsyncOnBecameVisibleHandler
    {
        UniTask OnBecameVisibleAsync();
    }

    public partial class AsyncTriggerHandler<T> : IAsyncOnBecameVisibleHandler
    {
        UniTask IAsyncOnBecameVisibleHandler.OnBecameVisibleAsync()
        {
            core.Reset();
            return new UniTask((IUniTaskSource)(object)this, core.Version);
        }
    }

    public static partial class AsyncTriggerExtensions
    {
        public static AsyncBecameVisibleTrigger GetAsyncBecameVisibleTrigger(this GameObject gameObject)
        {
            return GetOrAddComponent<AsyncBecameVisibleTrigger>(gameObject);
        }
        
        public static AsyncBecameVisibleTrigger GetAsyncBecameVisibleTrigger(this Component component)
        {
            return component.gameObject.GetAsyncBecameVisibleTrigger();
        }
    }

    [DisallowMultipleComponent]
    public sealed class AsyncBecameVisibleTrigger : AsyncTriggerBase
    {
        TriggerEvent<AsyncUnit> onBecameVisibleTriggerEvent;

        void OnBecameVisible()
        {
            onBecameVisibleTriggerEvent?.TrySetResult(AsyncUnit.Default);
        }

        public IAsyncOnBecameVisibleHandler GetOnBecameVisibleAsyncHandler()
        {
            return new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onBecameVisibleTriggerEvent), false);
        }

        public IAsyncOnBecameVisibleHandler GetOnBecameVisibleAsyncHandler(CancellationToken cancellationToken)
        {
            return new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onBecameVisibleTriggerEvent), cancellationToken, false);
        }

        public UniTask OnBecameVisibleAsync()
        {
            return ((IAsyncOnBecameVisibleHandler)new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onBecameVisibleTriggerEvent), true)).OnBecameVisibleAsync();
        }

        public UniTask OnBecameVisibleAsync(CancellationToken cancellationToken)
        {
            return ((IAsyncOnBecameVisibleHandler)new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onBecameVisibleTriggerEvent), cancellationToken, true)).OnBecameVisibleAsync();
        }
    }
#endregion

#region BeforeTransformParentChanged

    public interface IAsyncOnBeforeTransformParentChangedHandler
    {
        UniTask OnBeforeTransformParentChangedAsync();
    }

    public partial class AsyncTriggerHandler<T> : IAsyncOnBeforeTransformParentChangedHandler
    {
        UniTask IAsyncOnBeforeTransformParentChangedHandler.OnBeforeTransformParentChangedAsync()
        {
            core.Reset();
            return new UniTask((IUniTaskSource)(object)this, core.Version);
        }
    }

    public static partial class AsyncTriggerExtensions
    {
        public static AsyncBeforeTransformParentChangedTrigger GetAsyncBeforeTransformParentChangedTrigger(this GameObject gameObject)
        {
            return GetOrAddComponent<AsyncBeforeTransformParentChangedTrigger>(gameObject);
        }
        
        public static AsyncBeforeTransformParentChangedTrigger GetAsyncBeforeTransformParentChangedTrigger(this Component component)
        {
            return component.gameObject.GetAsyncBeforeTransformParentChangedTrigger();
        }
    }

    [DisallowMultipleComponent]
    public sealed class AsyncBeforeTransformParentChangedTrigger : AsyncTriggerBase
    {
        TriggerEvent<AsyncUnit> onBeforeTransformParentChangedTriggerEvent;

        void OnBeforeTransformParentChanged()
        {
            onBeforeTransformParentChangedTriggerEvent?.TrySetResult(AsyncUnit.Default);
        }

        public IAsyncOnBeforeTransformParentChangedHandler GetOnBeforeTransformParentChangedAsyncHandler()
        {
            return new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onBeforeTransformParentChangedTriggerEvent), false);
        }

        public IAsyncOnBeforeTransformParentChangedHandler GetOnBeforeTransformParentChangedAsyncHandler(CancellationToken cancellationToken)
        {
            return new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onBeforeTransformParentChangedTriggerEvent), cancellationToken, false);
        }

        public UniTask OnBeforeTransformParentChangedAsync()
        {
            return ((IAsyncOnBeforeTransformParentChangedHandler)new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onBeforeTransformParentChangedTriggerEvent), true)).OnBeforeTransformParentChangedAsync();
        }

        public UniTask OnBeforeTransformParentChangedAsync(CancellationToken cancellationToken)
        {
            return ((IAsyncOnBeforeTransformParentChangedHandler)new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onBeforeTransformParentChangedTriggerEvent), cancellationToken, true)).OnBeforeTransformParentChangedAsync();
        }
    }
#endregion

#region OnCanvasGroupChanged

    public interface IAsyncOnCanvasGroupChangedHandler
    {
        UniTask OnCanvasGroupChangedAsync();
    }

    public partial class AsyncTriggerHandler<T> : IAsyncOnCanvasGroupChangedHandler
    {
        UniTask IAsyncOnCanvasGroupChangedHandler.OnCanvasGroupChangedAsync()
        {
            core.Reset();
            return new UniTask((IUniTaskSource)(object)this, core.Version);
        }
    }

    public static partial class AsyncTriggerExtensions
    {
        public static AsyncOnCanvasGroupChangedTrigger GetAsyncOnCanvasGroupChangedTrigger(this GameObject gameObject)
        {
            return GetOrAddComponent<AsyncOnCanvasGroupChangedTrigger>(gameObject);
        }
        
        public static AsyncOnCanvasGroupChangedTrigger GetAsyncOnCanvasGroupChangedTrigger(this Component component)
        {
            return component.gameObject.GetAsyncOnCanvasGroupChangedTrigger();
        }
    }

    [DisallowMultipleComponent]
    public sealed class AsyncOnCanvasGroupChangedTrigger : AsyncTriggerBase
    {
        TriggerEvent<AsyncUnit> onCanvasGroupChangedTriggerEvent;

        void OnCanvasGroupChanged()
        {
            onCanvasGroupChangedTriggerEvent?.TrySetResult(AsyncUnit.Default);
        }

        public IAsyncOnCanvasGroupChangedHandler GetOnCanvasGroupChangedAsyncHandler()
        {
            return new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onCanvasGroupChangedTriggerEvent), false);
        }

        public IAsyncOnCanvasGroupChangedHandler GetOnCanvasGroupChangedAsyncHandler(CancellationToken cancellationToken)
        {
            return new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onCanvasGroupChangedTriggerEvent), cancellationToken, false);
        }

        public UniTask OnCanvasGroupChangedAsync()
        {
            return ((IAsyncOnCanvasGroupChangedHandler)new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onCanvasGroupChangedTriggerEvent), true)).OnCanvasGroupChangedAsync();
        }

        public UniTask OnCanvasGroupChangedAsync(CancellationToken cancellationToken)
        {
            return ((IAsyncOnCanvasGroupChangedHandler)new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onCanvasGroupChangedTriggerEvent), cancellationToken, true)).OnCanvasGroupChangedAsync();
        }
    }
#endregion

#region CollisionEnter

    public interface IAsyncOnCollisionEnterHandler
    {
        UniTask<Collision> OnCollisionEnterAsync();
    }

    public partial class AsyncTriggerHandler<T> : IAsyncOnCollisionEnterHandler
    {
        UniTask<Collision> IAsyncOnCollisionEnterHandler.OnCollisionEnterAsync()
        {
            core.Reset();
            return new UniTask<Collision>((IUniTaskSource<Collision>)(object)this, core.Version);
        }
    }

    public static partial class AsyncTriggerExtensions
    {
        public static AsyncCollisionEnterTrigger GetAsyncCollisionEnterTrigger(this GameObject gameObject)
        {
            return GetOrAddComponent<AsyncCollisionEnterTrigger>(gameObject);
        }
        
        public static AsyncCollisionEnterTrigger GetAsyncCollisionEnterTrigger(this Component component)
        {
            return component.gameObject.GetAsyncCollisionEnterTrigger();
        }
    }

    [DisallowMultipleComponent]
    public sealed class AsyncCollisionEnterTrigger : AsyncTriggerBase
    {
        TriggerEvent<Collision> onCollisionEnterTriggerEvent;

        void OnCollisionEnter(Collision coll)
        {
            onCollisionEnterTriggerEvent?.TrySetResult((coll));
        }

        public IAsyncOnCollisionEnterHandler GetOnCollisionEnterAsyncHandler()
        {
            return new AsyncTriggerHandler<Collision>(SetTriggerEvent(ref onCollisionEnterTriggerEvent), false);
        }

        public IAsyncOnCollisionEnterHandler GetOnCollisionEnterAsyncHandler(CancellationToken cancellationToken)
        {
            return new AsyncTriggerHandler<Collision>(SetTriggerEvent(ref onCollisionEnterTriggerEvent), cancellationToken, false);
        }

        public UniTask<Collision> OnCollisionEnterAsync()
        {
            return ((IAsyncOnCollisionEnterHandler)new AsyncTriggerHandler<Collision>(SetTriggerEvent(ref onCollisionEnterTriggerEvent), true)).OnCollisionEnterAsync();
        }

        public UniTask<Collision> OnCollisionEnterAsync(CancellationToken cancellationToken)
        {
            return ((IAsyncOnCollisionEnterHandler)new AsyncTriggerHandler<Collision>(SetTriggerEvent(ref onCollisionEnterTriggerEvent), cancellationToken, true)).OnCollisionEnterAsync();
        }
    }
#endregion

#region CollisionEnter2D

    public interface IAsyncOnCollisionEnter2DHandler
    {
        UniTask<Collision2D> OnCollisionEnter2DAsync();
    }

    public partial class AsyncTriggerHandler<T> : IAsyncOnCollisionEnter2DHandler
    {
        UniTask<Collision2D> IAsyncOnCollisionEnter2DHandler.OnCollisionEnter2DAsync()
        {
            core.Reset();
            return new UniTask<Collision2D>((IUniTaskSource<Collision2D>)(object)this, core.Version);
        }
    }

    public static partial class AsyncTriggerExtensions
    {
        public static AsyncCollisionEnter2DTrigger GetAsyncCollisionEnter2DTrigger(this GameObject gameObject)
        {
            return GetOrAddComponent<AsyncCollisionEnter2DTrigger>(gameObject);
        }
        
        public static AsyncCollisionEnter2DTrigger GetAsyncCollisionEnter2DTrigger(this Component component)
        {
            return component.gameObject.GetAsyncCollisionEnter2DTrigger();
        }
    }

    [DisallowMultipleComponent]
    public sealed class AsyncCollisionEnter2DTrigger : AsyncTriggerBase
    {
        TriggerEvent<Collision2D> onCollisionEnter2DTriggerEvent;

        void OnCollisionEnter2D(Collision2D coll)
        {
            onCollisionEnter2DTriggerEvent?.TrySetResult((coll));
        }

        public IAsyncOnCollisionEnter2DHandler GetOnCollisionEnter2DAsyncHandler()
        {
            return new AsyncTriggerHandler<Collision2D>(SetTriggerEvent(ref onCollisionEnter2DTriggerEvent), false);
        }

        public IAsyncOnCollisionEnter2DHandler GetOnCollisionEnter2DAsyncHandler(CancellationToken cancellationToken)
        {
            return new AsyncTriggerHandler<Collision2D>(SetTriggerEvent(ref onCollisionEnter2DTriggerEvent), cancellationToken, false);
        }

        public UniTask<Collision2D> OnCollisionEnter2DAsync()
        {
            return ((IAsyncOnCollisionEnter2DHandler)new AsyncTriggerHandler<Collision2D>(SetTriggerEvent(ref onCollisionEnter2DTriggerEvent), true)).OnCollisionEnter2DAsync();
        }

        public UniTask<Collision2D> OnCollisionEnter2DAsync(CancellationToken cancellationToken)
        {
            return ((IAsyncOnCollisionEnter2DHandler)new AsyncTriggerHandler<Collision2D>(SetTriggerEvent(ref onCollisionEnter2DTriggerEvent), cancellationToken, true)).OnCollisionEnter2DAsync();
        }
    }
#endregion

#region CollisionExit

    public interface IAsyncOnCollisionExitHandler
    {
        UniTask<Collision> OnCollisionExitAsync();
    }

    public partial class AsyncTriggerHandler<T> : IAsyncOnCollisionExitHandler
    {
        UniTask<Collision> IAsyncOnCollisionExitHandler.OnCollisionExitAsync()
        {
            core.Reset();
            return new UniTask<Collision>((IUniTaskSource<Collision>)(object)this, core.Version);
        }
    }

    public static partial class AsyncTriggerExtensions
    {
        public static AsyncCollisionExitTrigger GetAsyncCollisionExitTrigger(this GameObject gameObject)
        {
            return GetOrAddComponent<AsyncCollisionExitTrigger>(gameObject);
        }
        
        public static AsyncCollisionExitTrigger GetAsyncCollisionExitTrigger(this Component component)
        {
            return component.gameObject.GetAsyncCollisionExitTrigger();
        }
    }

    [DisallowMultipleComponent]
    public sealed class AsyncCollisionExitTrigger : AsyncTriggerBase
    {
        TriggerEvent<Collision> onCollisionExitTriggerEvent;

        void OnCollisionExit(Collision coll)
        {
            onCollisionExitTriggerEvent?.TrySetResult((coll));
        }

        public IAsyncOnCollisionExitHandler GetOnCollisionExitAsyncHandler()
        {
            return new AsyncTriggerHandler<Collision>(SetTriggerEvent(ref onCollisionExitTriggerEvent), false);
        }

        public IAsyncOnCollisionExitHandler GetOnCollisionExitAsyncHandler(CancellationToken cancellationToken)
        {
            return new AsyncTriggerHandler<Collision>(SetTriggerEvent(ref onCollisionExitTriggerEvent), cancellationToken, false);
        }

        public UniTask<Collision> OnCollisionExitAsync()
        {
            return ((IAsyncOnCollisionExitHandler)new AsyncTriggerHandler<Collision>(SetTriggerEvent(ref onCollisionExitTriggerEvent), true)).OnCollisionExitAsync();
        }

        public UniTask<Collision> OnCollisionExitAsync(CancellationToken cancellationToken)
        {
            return ((IAsyncOnCollisionExitHandler)new AsyncTriggerHandler<Collision>(SetTriggerEvent(ref onCollisionExitTriggerEvent), cancellationToken, true)).OnCollisionExitAsync();
        }
    }
#endregion

#region CollisionExit2D

    public interface IAsyncOnCollisionExit2DHandler
    {
        UniTask<Collision2D> OnCollisionExit2DAsync();
    }

    public partial class AsyncTriggerHandler<T> : IAsyncOnCollisionExit2DHandler
    {
        UniTask<Collision2D> IAsyncOnCollisionExit2DHandler.OnCollisionExit2DAsync()
        {
            core.Reset();
            return new UniTask<Collision2D>((IUniTaskSource<Collision2D>)(object)this, core.Version);
        }
    }

    public static partial class AsyncTriggerExtensions
    {
        public static AsyncCollisionExit2DTrigger GetAsyncCollisionExit2DTrigger(this GameObject gameObject)
        {
            return GetOrAddComponent<AsyncCollisionExit2DTrigger>(gameObject);
        }
        
        public static AsyncCollisionExit2DTrigger GetAsyncCollisionExit2DTrigger(this Component component)
        {
            return component.gameObject.GetAsyncCollisionExit2DTrigger();
        }
    }

    [DisallowMultipleComponent]
    public sealed class AsyncCollisionExit2DTrigger : AsyncTriggerBase
    {
        TriggerEvent<Collision2D> onCollisionExit2DTriggerEvent;

        void OnCollisionExit2D(Collision2D coll)
        {
            onCollisionExit2DTriggerEvent?.TrySetResult((coll));
        }

        public IAsyncOnCollisionExit2DHandler GetOnCollisionExit2DAsyncHandler()
        {
            return new AsyncTriggerHandler<Collision2D>(SetTriggerEvent(ref onCollisionExit2DTriggerEvent), false);
        }

        public IAsyncOnCollisionExit2DHandler GetOnCollisionExit2DAsyncHandler(CancellationToken cancellationToken)
        {
            return new AsyncTriggerHandler<Collision2D>(SetTriggerEvent(ref onCollisionExit2DTriggerEvent), cancellationToken, false);
        }

        public UniTask<Collision2D> OnCollisionExit2DAsync()
        {
            return ((IAsyncOnCollisionExit2DHandler)new AsyncTriggerHandler<Collision2D>(SetTriggerEvent(ref onCollisionExit2DTriggerEvent), true)).OnCollisionExit2DAsync();
        }

        public UniTask<Collision2D> OnCollisionExit2DAsync(CancellationToken cancellationToken)
        {
            return ((IAsyncOnCollisionExit2DHandler)new AsyncTriggerHandler<Collision2D>(SetTriggerEvent(ref onCollisionExit2DTriggerEvent), cancellationToken, true)).OnCollisionExit2DAsync();
        }
    }
#endregion

#region CollisionStay

    public interface IAsyncOnCollisionStayHandler
    {
        UniTask<Collision> OnCollisionStayAsync();
    }

    public partial class AsyncTriggerHandler<T> : IAsyncOnCollisionStayHandler
    {
        UniTask<Collision> IAsyncOnCollisionStayHandler.OnCollisionStayAsync()
        {
            core.Reset();
            return new UniTask<Collision>((IUniTaskSource<Collision>)(object)this, core.Version);
        }
    }

    public static partial class AsyncTriggerExtensions
    {
        public static AsyncCollisionStayTrigger GetAsyncCollisionStayTrigger(this GameObject gameObject)
        {
            return GetOrAddComponent<AsyncCollisionStayTrigger>(gameObject);
        }
        
        public static AsyncCollisionStayTrigger GetAsyncCollisionStayTrigger(this Component component)
        {
            return component.gameObject.GetAsyncCollisionStayTrigger();
        }
    }

    [DisallowMultipleComponent]
    public sealed class AsyncCollisionStayTrigger : AsyncTriggerBase
    {
        TriggerEvent<Collision> onCollisionStayTriggerEvent;

        void OnCollisionStay(Collision coll)
        {
            onCollisionStayTriggerEvent?.TrySetResult((coll));
        }

        public IAsyncOnCollisionStayHandler GetOnCollisionStayAsyncHandler()
        {
            return new AsyncTriggerHandler<Collision>(SetTriggerEvent(ref onCollisionStayTriggerEvent), false);
        }

        public IAsyncOnCollisionStayHandler GetOnCollisionStayAsyncHandler(CancellationToken cancellationToken)
        {
            return new AsyncTriggerHandler<Collision>(SetTriggerEvent(ref onCollisionStayTriggerEvent), cancellationToken, false);
        }

        public UniTask<Collision> OnCollisionStayAsync()
        {
            return ((IAsyncOnCollisionStayHandler)new AsyncTriggerHandler<Collision>(SetTriggerEvent(ref onCollisionStayTriggerEvent), true)).OnCollisionStayAsync();
        }

        public UniTask<Collision> OnCollisionStayAsync(CancellationToken cancellationToken)
        {
            return ((IAsyncOnCollisionStayHandler)new AsyncTriggerHandler<Collision>(SetTriggerEvent(ref onCollisionStayTriggerEvent), cancellationToken, true)).OnCollisionStayAsync();
        }
    }
#endregion

#region CollisionStay2D

    public interface IAsyncOnCollisionStay2DHandler
    {
        UniTask<Collision2D> OnCollisionStay2DAsync();
    }

    public partial class AsyncTriggerHandler<T> : IAsyncOnCollisionStay2DHandler
    {
        UniTask<Collision2D> IAsyncOnCollisionStay2DHandler.OnCollisionStay2DAsync()
        {
            core.Reset();
            return new UniTask<Collision2D>((IUniTaskSource<Collision2D>)(object)this, core.Version);
        }
    }

    public static partial class AsyncTriggerExtensions
    {
        public static AsyncCollisionStay2DTrigger GetAsyncCollisionStay2DTrigger(this GameObject gameObject)
        {
            return GetOrAddComponent<AsyncCollisionStay2DTrigger>(gameObject);
        }
        
        public static AsyncCollisionStay2DTrigger GetAsyncCollisionStay2DTrigger(this Component component)
        {
            return component.gameObject.GetAsyncCollisionStay2DTrigger();
        }
    }

    [DisallowMultipleComponent]
    public sealed class AsyncCollisionStay2DTrigger : AsyncTriggerBase
    {
        TriggerEvent<Collision2D> onCollisionStay2DTriggerEvent;

        void OnCollisionStay2D(Collision2D coll)
        {
            onCollisionStay2DTriggerEvent?.TrySetResult((coll));
        }

        public IAsyncOnCollisionStay2DHandler GetOnCollisionStay2DAsyncHandler()
        {
            return new AsyncTriggerHandler<Collision2D>(SetTriggerEvent(ref onCollisionStay2DTriggerEvent), false);
        }

        public IAsyncOnCollisionStay2DHandler GetOnCollisionStay2DAsyncHandler(CancellationToken cancellationToken)
        {
            return new AsyncTriggerHandler<Collision2D>(SetTriggerEvent(ref onCollisionStay2DTriggerEvent), cancellationToken, false);
        }

        public UniTask<Collision2D> OnCollisionStay2DAsync()
        {
            return ((IAsyncOnCollisionStay2DHandler)new AsyncTriggerHandler<Collision2D>(SetTriggerEvent(ref onCollisionStay2DTriggerEvent), true)).OnCollisionStay2DAsync();
        }

        public UniTask<Collision2D> OnCollisionStay2DAsync(CancellationToken cancellationToken)
        {
            return ((IAsyncOnCollisionStay2DHandler)new AsyncTriggerHandler<Collision2D>(SetTriggerEvent(ref onCollisionStay2DTriggerEvent), cancellationToken, true)).OnCollisionStay2DAsync();
        }
    }
#endregion

#region ControllerColliderHit

    public interface IAsyncOnControllerColliderHitHandler
    {
        UniTask<ControllerColliderHit> OnControllerColliderHitAsync();
    }

    public partial class AsyncTriggerHandler<T> : IAsyncOnControllerColliderHitHandler
    {
        UniTask<ControllerColliderHit> IAsyncOnControllerColliderHitHandler.OnControllerColliderHitAsync()
        {
            core.Reset();
            return new UniTask<ControllerColliderHit>((IUniTaskSource<ControllerColliderHit>)(object)this, core.Version);
        }
    }

    public static partial class AsyncTriggerExtensions
    {
        public static AsyncControllerColliderHitTrigger GetAsyncControllerColliderHitTrigger(this GameObject gameObject)
        {
            return GetOrAddComponent<AsyncControllerColliderHitTrigger>(gameObject);
        }
        
        public static AsyncControllerColliderHitTrigger GetAsyncControllerColliderHitTrigger(this Component component)
        {
            return component.gameObject.GetAsyncControllerColliderHitTrigger();
        }
    }

    [DisallowMultipleComponent]
    public sealed class AsyncControllerColliderHitTrigger : AsyncTriggerBase
    {
        TriggerEvent<ControllerColliderHit> onControllerColliderHitTriggerEvent;

        void OnControllerColliderHit(ControllerColliderHit hit)
        {
            onControllerColliderHitTriggerEvent?.TrySetResult((hit));
        }

        public IAsyncOnControllerColliderHitHandler GetOnControllerColliderHitAsyncHandler()
        {
            return new AsyncTriggerHandler<ControllerColliderHit>(SetTriggerEvent(ref onControllerColliderHitTriggerEvent), false);
        }

        public IAsyncOnControllerColliderHitHandler GetOnControllerColliderHitAsyncHandler(CancellationToken cancellationToken)
        {
            return new AsyncTriggerHandler<ControllerColliderHit>(SetTriggerEvent(ref onControllerColliderHitTriggerEvent), cancellationToken, false);
        }

        public UniTask<ControllerColliderHit> OnControllerColliderHitAsync()
        {
            return ((IAsyncOnControllerColliderHitHandler)new AsyncTriggerHandler<ControllerColliderHit>(SetTriggerEvent(ref onControllerColliderHitTriggerEvent), true)).OnControllerColliderHitAsync();
        }

        public UniTask<ControllerColliderHit> OnControllerColliderHitAsync(CancellationToken cancellationToken)
        {
            return ((IAsyncOnControllerColliderHitHandler)new AsyncTriggerHandler<ControllerColliderHit>(SetTriggerEvent(ref onControllerColliderHitTriggerEvent), cancellationToken, true)).OnControllerColliderHitAsync();
        }
    }
#endregion

#region Disable

    public interface IAsyncOnDisableHandler
    {
        UniTask OnDisableAsync();
    }

    public partial class AsyncTriggerHandler<T> : IAsyncOnDisableHandler
    {
        UniTask IAsyncOnDisableHandler.OnDisableAsync()
        {
            core.Reset();
            return new UniTask((IUniTaskSource)(object)this, core.Version);
        }
    }

    public static partial class AsyncTriggerExtensions
    {
        public static AsyncDisableTrigger GetAsyncDisableTrigger(this GameObject gameObject)
        {
            return GetOrAddComponent<AsyncDisableTrigger>(gameObject);
        }
        
        public static AsyncDisableTrigger GetAsyncDisableTrigger(this Component component)
        {
            return component.gameObject.GetAsyncDisableTrigger();
        }
    }

    [DisallowMultipleComponent]
    public sealed class AsyncDisableTrigger : AsyncTriggerBase
    {
        TriggerEvent<AsyncUnit> onDisableTriggerEvent;

        void OnDisable()
        {
            onDisableTriggerEvent?.TrySetResult(AsyncUnit.Default);
        }

        public IAsyncOnDisableHandler GetOnDisableAsyncHandler()
        {
            return new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onDisableTriggerEvent), false);
        }

        public IAsyncOnDisableHandler GetOnDisableAsyncHandler(CancellationToken cancellationToken)
        {
            return new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onDisableTriggerEvent), cancellationToken, false);
        }

        public UniTask OnDisableAsync()
        {
            return ((IAsyncOnDisableHandler)new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onDisableTriggerEvent), true)).OnDisableAsync();
        }

        public UniTask OnDisableAsync(CancellationToken cancellationToken)
        {
            return ((IAsyncOnDisableHandler)new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onDisableTriggerEvent), cancellationToken, true)).OnDisableAsync();
        }
    }
#endregion

#region DrawGizmos

    public interface IAsyncOnDrawGizmosHandler
    {
        UniTask OnDrawGizmosAsync();
    }

    public partial class AsyncTriggerHandler<T> : IAsyncOnDrawGizmosHandler
    {
        UniTask IAsyncOnDrawGizmosHandler.OnDrawGizmosAsync()
        {
            core.Reset();
            return new UniTask((IUniTaskSource)(object)this, core.Version);
        }
    }

    public static partial class AsyncTriggerExtensions
    {
        public static AsyncDrawGizmosTrigger GetAsyncDrawGizmosTrigger(this GameObject gameObject)
        {
            return GetOrAddComponent<AsyncDrawGizmosTrigger>(gameObject);
        }
        
        public static AsyncDrawGizmosTrigger GetAsyncDrawGizmosTrigger(this Component component)
        {
            return component.gameObject.GetAsyncDrawGizmosTrigger();
        }
    }

    [DisallowMultipleComponent]
    public sealed class AsyncDrawGizmosTrigger : AsyncTriggerBase
    {
        TriggerEvent<AsyncUnit> onDrawGizmosTriggerEvent;

        void OnDrawGizmos()
        {
            onDrawGizmosTriggerEvent?.TrySetResult(AsyncUnit.Default);
        }

        public IAsyncOnDrawGizmosHandler GetOnDrawGizmosAsyncHandler()
        {
            return new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onDrawGizmosTriggerEvent), false);
        }

        public IAsyncOnDrawGizmosHandler GetOnDrawGizmosAsyncHandler(CancellationToken cancellationToken)
        {
            return new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onDrawGizmosTriggerEvent), cancellationToken, false);
        }

        public UniTask OnDrawGizmosAsync()
        {
            return ((IAsyncOnDrawGizmosHandler)new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onDrawGizmosTriggerEvent), true)).OnDrawGizmosAsync();
        }

        public UniTask OnDrawGizmosAsync(CancellationToken cancellationToken)
        {
            return ((IAsyncOnDrawGizmosHandler)new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onDrawGizmosTriggerEvent), cancellationToken, true)).OnDrawGizmosAsync();
        }
    }
#endregion

#region DrawGizmosSelected

    public interface IAsyncOnDrawGizmosSelectedHandler
    {
        UniTask OnDrawGizmosSelectedAsync();
    }

    public partial class AsyncTriggerHandler<T> : IAsyncOnDrawGizmosSelectedHandler
    {
        UniTask IAsyncOnDrawGizmosSelectedHandler.OnDrawGizmosSelectedAsync()
        {
            core.Reset();
            return new UniTask((IUniTaskSource)(object)this, core.Version);
        }
    }

    public static partial class AsyncTriggerExtensions
    {
        public static AsyncDrawGizmosSelectedTrigger GetAsyncDrawGizmosSelectedTrigger(this GameObject gameObject)
        {
            return GetOrAddComponent<AsyncDrawGizmosSelectedTrigger>(gameObject);
        }
        
        public static AsyncDrawGizmosSelectedTrigger GetAsyncDrawGizmosSelectedTrigger(this Component component)
        {
            return component.gameObject.GetAsyncDrawGizmosSelectedTrigger();
        }
    }

    [DisallowMultipleComponent]
    public sealed class AsyncDrawGizmosSelectedTrigger : AsyncTriggerBase
    {
        TriggerEvent<AsyncUnit> onDrawGizmosSelectedTriggerEvent;

        void OnDrawGizmosSelected()
        {
            onDrawGizmosSelectedTriggerEvent?.TrySetResult(AsyncUnit.Default);
        }

        public IAsyncOnDrawGizmosSelectedHandler GetOnDrawGizmosSelectedAsyncHandler()
        {
            return new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onDrawGizmosSelectedTriggerEvent), false);
        }

        public IAsyncOnDrawGizmosSelectedHandler GetOnDrawGizmosSelectedAsyncHandler(CancellationToken cancellationToken)
        {
            return new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onDrawGizmosSelectedTriggerEvent), cancellationToken, false);
        }

        public UniTask OnDrawGizmosSelectedAsync()
        {
            return ((IAsyncOnDrawGizmosSelectedHandler)new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onDrawGizmosSelectedTriggerEvent), true)).OnDrawGizmosSelectedAsync();
        }

        public UniTask OnDrawGizmosSelectedAsync(CancellationToken cancellationToken)
        {
            return ((IAsyncOnDrawGizmosSelectedHandler)new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onDrawGizmosSelectedTriggerEvent), cancellationToken, true)).OnDrawGizmosSelectedAsync();
        }
    }
#endregion

#region Enable

    public interface IAsyncOnEnableHandler
    {
        UniTask OnEnableAsync();
    }

    public partial class AsyncTriggerHandler<T> : IAsyncOnEnableHandler
    {
        UniTask IAsyncOnEnableHandler.OnEnableAsync()
        {
            core.Reset();
            return new UniTask((IUniTaskSource)(object)this, core.Version);
        }
    }

    public static partial class AsyncTriggerExtensions
    {
        public static AsyncEnableTrigger GetAsyncEnableTrigger(this GameObject gameObject)
        {
            return GetOrAddComponent<AsyncEnableTrigger>(gameObject);
        }
        
        public static AsyncEnableTrigger GetAsyncEnableTrigger(this Component component)
        {
            return component.gameObject.GetAsyncEnableTrigger();
        }
    }

    [DisallowMultipleComponent]
    public sealed class AsyncEnableTrigger : AsyncTriggerBase
    {
        TriggerEvent<AsyncUnit> onEnableTriggerEvent;

        void OnEnable()
        {
            onEnableTriggerEvent?.TrySetResult(AsyncUnit.Default);
        }

        public IAsyncOnEnableHandler GetOnEnableAsyncHandler()
        {
            return new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onEnableTriggerEvent), false);
        }

        public IAsyncOnEnableHandler GetOnEnableAsyncHandler(CancellationToken cancellationToken)
        {
            return new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onEnableTriggerEvent), cancellationToken, false);
        }

        public UniTask OnEnableAsync()
        {
            return ((IAsyncOnEnableHandler)new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onEnableTriggerEvent), true)).OnEnableAsync();
        }

        public UniTask OnEnableAsync(CancellationToken cancellationToken)
        {
            return ((IAsyncOnEnableHandler)new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onEnableTriggerEvent), cancellationToken, true)).OnEnableAsync();
        }
    }
#endregion

#region GUI

    public interface IAsyncOnGUIHandler
    {
        UniTask OnGUIAsync();
    }

    public partial class AsyncTriggerHandler<T> : IAsyncOnGUIHandler
    {
        UniTask IAsyncOnGUIHandler.OnGUIAsync()
        {
            core.Reset();
            return new UniTask((IUniTaskSource)(object)this, core.Version);
        }
    }

    public static partial class AsyncTriggerExtensions
    {
        public static AsyncGUITrigger GetAsyncGUITrigger(this GameObject gameObject)
        {
            return GetOrAddComponent<AsyncGUITrigger>(gameObject);
        }
        
        public static AsyncGUITrigger GetAsyncGUITrigger(this Component component)
        {
            return component.gameObject.GetAsyncGUITrigger();
        }
    }

    [DisallowMultipleComponent]
    public sealed class AsyncGUITrigger : AsyncTriggerBase
    {
        TriggerEvent<AsyncUnit> onGUITriggerEvent;

        void OnGUI()
        {
            onGUITriggerEvent?.TrySetResult(AsyncUnit.Default);
        }

        public IAsyncOnGUIHandler GetOnGUIAsyncHandler()
        {
            return new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onGUITriggerEvent), false);
        }

        public IAsyncOnGUIHandler GetOnGUIAsyncHandler(CancellationToken cancellationToken)
        {
            return new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onGUITriggerEvent), cancellationToken, false);
        }

        public UniTask OnGUIAsync()
        {
            return ((IAsyncOnGUIHandler)new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onGUITriggerEvent), true)).OnGUIAsync();
        }

        public UniTask OnGUIAsync(CancellationToken cancellationToken)
        {
            return ((IAsyncOnGUIHandler)new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onGUITriggerEvent), cancellationToken, true)).OnGUIAsync();
        }
    }
#endregion

#region JointBreak

    public interface IAsyncOnJointBreakHandler
    {
        UniTask<float> OnJointBreakAsync();
    }

    public partial class AsyncTriggerHandler<T> : IAsyncOnJointBreakHandler
    {
        UniTask<float> IAsyncOnJointBreakHandler.OnJointBreakAsync()
        {
            core.Reset();
            return new UniTask<float>((IUniTaskSource<float>)(object)this, core.Version);
        }
    }

    public static partial class AsyncTriggerExtensions
    {
        public static AsyncJointBreakTrigger GetAsyncJointBreakTrigger(this GameObject gameObject)
        {
            return GetOrAddComponent<AsyncJointBreakTrigger>(gameObject);
        }
        
        public static AsyncJointBreakTrigger GetAsyncJointBreakTrigger(this Component component)
        {
            return component.gameObject.GetAsyncJointBreakTrigger();
        }
    }

    [DisallowMultipleComponent]
    public sealed class AsyncJointBreakTrigger : AsyncTriggerBase
    {
        TriggerEvent<float> onJointBreakTriggerEvent;

        void OnJointBreak(float breakForce)
        {
            onJointBreakTriggerEvent?.TrySetResult((breakForce));
        }

        public IAsyncOnJointBreakHandler GetOnJointBreakAsyncHandler()
        {
            return new AsyncTriggerHandler<float>(SetTriggerEvent(ref onJointBreakTriggerEvent), false);
        }

        public IAsyncOnJointBreakHandler GetOnJointBreakAsyncHandler(CancellationToken cancellationToken)
        {
            return new AsyncTriggerHandler<float>(SetTriggerEvent(ref onJointBreakTriggerEvent), cancellationToken, false);
        }

        public UniTask<float> OnJointBreakAsync()
        {
            return ((IAsyncOnJointBreakHandler)new AsyncTriggerHandler<float>(SetTriggerEvent(ref onJointBreakTriggerEvent), true)).OnJointBreakAsync();
        }

        public UniTask<float> OnJointBreakAsync(CancellationToken cancellationToken)
        {
            return ((IAsyncOnJointBreakHandler)new AsyncTriggerHandler<float>(SetTriggerEvent(ref onJointBreakTriggerEvent), cancellationToken, true)).OnJointBreakAsync();
        }
    }
#endregion

#region JointBreak2D

    public interface IAsyncOnJointBreak2DHandler
    {
        UniTask<Joint2D> OnJointBreak2DAsync();
    }

    public partial class AsyncTriggerHandler<T> : IAsyncOnJointBreak2DHandler
    {
        UniTask<Joint2D> IAsyncOnJointBreak2DHandler.OnJointBreak2DAsync()
        {
            core.Reset();
            return new UniTask<Joint2D>((IUniTaskSource<Joint2D>)(object)this, core.Version);
        }
    }

    public static partial class AsyncTriggerExtensions
    {
        public static AsyncJointBreak2DTrigger GetAsyncJointBreak2DTrigger(this GameObject gameObject)
        {
            return GetOrAddComponent<AsyncJointBreak2DTrigger>(gameObject);
        }
        
        public static AsyncJointBreak2DTrigger GetAsyncJointBreak2DTrigger(this Component component)
        {
            return component.gameObject.GetAsyncJointBreak2DTrigger();
        }
    }

    [DisallowMultipleComponent]
    public sealed class AsyncJointBreak2DTrigger : AsyncTriggerBase
    {
        TriggerEvent<Joint2D> onJointBreak2DTriggerEvent;

        void OnJointBreak2D(Joint2D brokenJoint)
        {
            onJointBreak2DTriggerEvent?.TrySetResult((brokenJoint));
        }

        public IAsyncOnJointBreak2DHandler GetOnJointBreak2DAsyncHandler()
        {
            return new AsyncTriggerHandler<Joint2D>(SetTriggerEvent(ref onJointBreak2DTriggerEvent), false);
        }

        public IAsyncOnJointBreak2DHandler GetOnJointBreak2DAsyncHandler(CancellationToken cancellationToken)
        {
            return new AsyncTriggerHandler<Joint2D>(SetTriggerEvent(ref onJointBreak2DTriggerEvent), cancellationToken, false);
        }

        public UniTask<Joint2D> OnJointBreak2DAsync()
        {
            return ((IAsyncOnJointBreak2DHandler)new AsyncTriggerHandler<Joint2D>(SetTriggerEvent(ref onJointBreak2DTriggerEvent), true)).OnJointBreak2DAsync();
        }

        public UniTask<Joint2D> OnJointBreak2DAsync(CancellationToken cancellationToken)
        {
            return ((IAsyncOnJointBreak2DHandler)new AsyncTriggerHandler<Joint2D>(SetTriggerEvent(ref onJointBreak2DTriggerEvent), cancellationToken, true)).OnJointBreak2DAsync();
        }
    }
#endregion

#region MouseDown

    public interface IAsyncOnMouseDownHandler
    {
        UniTask OnMouseDownAsync();
    }

    public partial class AsyncTriggerHandler<T> : IAsyncOnMouseDownHandler
    {
        UniTask IAsyncOnMouseDownHandler.OnMouseDownAsync()
        {
            core.Reset();
            return new UniTask((IUniTaskSource)(object)this, core.Version);
        }
    }

    public static partial class AsyncTriggerExtensions
    {
        public static AsyncMouseDownTrigger GetAsyncMouseDownTrigger(this GameObject gameObject)
        {
            return GetOrAddComponent<AsyncMouseDownTrigger>(gameObject);
        }
        
        public static AsyncMouseDownTrigger GetAsyncMouseDownTrigger(this Component component)
        {
            return component.gameObject.GetAsyncMouseDownTrigger();
        }
    }

    [DisallowMultipleComponent]
    public sealed class AsyncMouseDownTrigger : AsyncTriggerBase
    {
        TriggerEvent<AsyncUnit> onMouseDownTriggerEvent;

        void OnMouseDown()
        {
            onMouseDownTriggerEvent?.TrySetResult(AsyncUnit.Default);
        }

        public IAsyncOnMouseDownHandler GetOnMouseDownAsyncHandler()
        {
            return new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onMouseDownTriggerEvent), false);
        }

        public IAsyncOnMouseDownHandler GetOnMouseDownAsyncHandler(CancellationToken cancellationToken)
        {
            return new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onMouseDownTriggerEvent), cancellationToken, false);
        }

        public UniTask OnMouseDownAsync()
        {
            return ((IAsyncOnMouseDownHandler)new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onMouseDownTriggerEvent), true)).OnMouseDownAsync();
        }

        public UniTask OnMouseDownAsync(CancellationToken cancellationToken)
        {
            return ((IAsyncOnMouseDownHandler)new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onMouseDownTriggerEvent), cancellationToken, true)).OnMouseDownAsync();
        }
    }
#endregion

#region MouseDrag

    public interface IAsyncOnMouseDragHandler
    {
        UniTask OnMouseDragAsync();
    }

    public partial class AsyncTriggerHandler<T> : IAsyncOnMouseDragHandler
    {
        UniTask IAsyncOnMouseDragHandler.OnMouseDragAsync()
        {
            core.Reset();
            return new UniTask((IUniTaskSource)(object)this, core.Version);
        }
    }

    public static partial class AsyncTriggerExtensions
    {
        public static AsyncMouseDragTrigger GetAsyncMouseDragTrigger(this GameObject gameObject)
        {
            return GetOrAddComponent<AsyncMouseDragTrigger>(gameObject);
        }
        
        public static AsyncMouseDragTrigger GetAsyncMouseDragTrigger(this Component component)
        {
            return component.gameObject.GetAsyncMouseDragTrigger();
        }
    }

    [DisallowMultipleComponent]
    public sealed class AsyncMouseDragTrigger : AsyncTriggerBase
    {
        TriggerEvent<AsyncUnit> onMouseDragTriggerEvent;

        void OnMouseDrag()
        {
            onMouseDragTriggerEvent?.TrySetResult(AsyncUnit.Default);
        }

        public IAsyncOnMouseDragHandler GetOnMouseDragAsyncHandler()
        {
            return new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onMouseDragTriggerEvent), false);
        }

        public IAsyncOnMouseDragHandler GetOnMouseDragAsyncHandler(CancellationToken cancellationToken)
        {
            return new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onMouseDragTriggerEvent), cancellationToken, false);
        }

        public UniTask OnMouseDragAsync()
        {
            return ((IAsyncOnMouseDragHandler)new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onMouseDragTriggerEvent), true)).OnMouseDragAsync();
        }

        public UniTask OnMouseDragAsync(CancellationToken cancellationToken)
        {
            return ((IAsyncOnMouseDragHandler)new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onMouseDragTriggerEvent), cancellationToken, true)).OnMouseDragAsync();
        }
    }
#endregion

#region MouseEnter

    public interface IAsyncOnMouseEnterHandler
    {
        UniTask OnMouseEnterAsync();
    }

    public partial class AsyncTriggerHandler<T> : IAsyncOnMouseEnterHandler
    {
        UniTask IAsyncOnMouseEnterHandler.OnMouseEnterAsync()
        {
            core.Reset();
            return new UniTask((IUniTaskSource)(object)this, core.Version);
        }
    }

    public static partial class AsyncTriggerExtensions
    {
        public static AsyncMouseEnterTrigger GetAsyncMouseEnterTrigger(this GameObject gameObject)
        {
            return GetOrAddComponent<AsyncMouseEnterTrigger>(gameObject);
        }
        
        public static AsyncMouseEnterTrigger GetAsyncMouseEnterTrigger(this Component component)
        {
            return component.gameObject.GetAsyncMouseEnterTrigger();
        }
    }

    [DisallowMultipleComponent]
    public sealed class AsyncMouseEnterTrigger : AsyncTriggerBase
    {
        TriggerEvent<AsyncUnit> onMouseEnterTriggerEvent;

        void OnMouseEnter()
        {
            onMouseEnterTriggerEvent?.TrySetResult(AsyncUnit.Default);
        }

        public IAsyncOnMouseEnterHandler GetOnMouseEnterAsyncHandler()
        {
            return new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onMouseEnterTriggerEvent), false);
        }

        public IAsyncOnMouseEnterHandler GetOnMouseEnterAsyncHandler(CancellationToken cancellationToken)
        {
            return new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onMouseEnterTriggerEvent), cancellationToken, false);
        }

        public UniTask OnMouseEnterAsync()
        {
            return ((IAsyncOnMouseEnterHandler)new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onMouseEnterTriggerEvent), true)).OnMouseEnterAsync();
        }

        public UniTask OnMouseEnterAsync(CancellationToken cancellationToken)
        {
            return ((IAsyncOnMouseEnterHandler)new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onMouseEnterTriggerEvent), cancellationToken, true)).OnMouseEnterAsync();
        }
    }
#endregion

#region MouseExit

    public interface IAsyncOnMouseExitHandler
    {
        UniTask OnMouseExitAsync();
    }

    public partial class AsyncTriggerHandler<T> : IAsyncOnMouseExitHandler
    {
        UniTask IAsyncOnMouseExitHandler.OnMouseExitAsync()
        {
            core.Reset();
            return new UniTask((IUniTaskSource)(object)this, core.Version);
        }
    }

    public static partial class AsyncTriggerExtensions
    {
        public static AsyncMouseExitTrigger GetAsyncMouseExitTrigger(this GameObject gameObject)
        {
            return GetOrAddComponent<AsyncMouseExitTrigger>(gameObject);
        }
        
        public static AsyncMouseExitTrigger GetAsyncMouseExitTrigger(this Component component)
        {
            return component.gameObject.GetAsyncMouseExitTrigger();
        }
    }

    [DisallowMultipleComponent]
    public sealed class AsyncMouseExitTrigger : AsyncTriggerBase
    {
        TriggerEvent<AsyncUnit> onMouseExitTriggerEvent;

        void OnMouseExit()
        {
            onMouseExitTriggerEvent?.TrySetResult(AsyncUnit.Default);
        }

        public IAsyncOnMouseExitHandler GetOnMouseExitAsyncHandler()
        {
            return new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onMouseExitTriggerEvent), false);
        }

        public IAsyncOnMouseExitHandler GetOnMouseExitAsyncHandler(CancellationToken cancellationToken)
        {
            return new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onMouseExitTriggerEvent), cancellationToken, false);
        }

        public UniTask OnMouseExitAsync()
        {
            return ((IAsyncOnMouseExitHandler)new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onMouseExitTriggerEvent), true)).OnMouseExitAsync();
        }

        public UniTask OnMouseExitAsync(CancellationToken cancellationToken)
        {
            return ((IAsyncOnMouseExitHandler)new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onMouseExitTriggerEvent), cancellationToken, true)).OnMouseExitAsync();
        }
    }
#endregion

#region MouseOver

    public interface IAsyncOnMouseOverHandler
    {
        UniTask OnMouseOverAsync();
    }

    public partial class AsyncTriggerHandler<T> : IAsyncOnMouseOverHandler
    {
        UniTask IAsyncOnMouseOverHandler.OnMouseOverAsync()
        {
            core.Reset();
            return new UniTask((IUniTaskSource)(object)this, core.Version);
        }
    }

    public static partial class AsyncTriggerExtensions
    {
        public static AsyncMouseOverTrigger GetAsyncMouseOverTrigger(this GameObject gameObject)
        {
            return GetOrAddComponent<AsyncMouseOverTrigger>(gameObject);
        }
        
        public static AsyncMouseOverTrigger GetAsyncMouseOverTrigger(this Component component)
        {
            return component.gameObject.GetAsyncMouseOverTrigger();
        }
    }

    [DisallowMultipleComponent]
    public sealed class AsyncMouseOverTrigger : AsyncTriggerBase
    {
        TriggerEvent<AsyncUnit> onMouseOverTriggerEvent;

        void OnMouseOver()
        {
            onMouseOverTriggerEvent?.TrySetResult(AsyncUnit.Default);
        }

        public IAsyncOnMouseOverHandler GetOnMouseOverAsyncHandler()
        {
            return new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onMouseOverTriggerEvent), false);
        }

        public IAsyncOnMouseOverHandler GetOnMouseOverAsyncHandler(CancellationToken cancellationToken)
        {
            return new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onMouseOverTriggerEvent), cancellationToken, false);
        }

        public UniTask OnMouseOverAsync()
        {
            return ((IAsyncOnMouseOverHandler)new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onMouseOverTriggerEvent), true)).OnMouseOverAsync();
        }

        public UniTask OnMouseOverAsync(CancellationToken cancellationToken)
        {
            return ((IAsyncOnMouseOverHandler)new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onMouseOverTriggerEvent), cancellationToken, true)).OnMouseOverAsync();
        }
    }
#endregion

#region MouseUp

    public interface IAsyncOnMouseUpHandler
    {
        UniTask OnMouseUpAsync();
    }

    public partial class AsyncTriggerHandler<T> : IAsyncOnMouseUpHandler
    {
        UniTask IAsyncOnMouseUpHandler.OnMouseUpAsync()
        {
            core.Reset();
            return new UniTask((IUniTaskSource)(object)this, core.Version);
        }
    }

    public static partial class AsyncTriggerExtensions
    {
        public static AsyncMouseUpTrigger GetAsyncMouseUpTrigger(this GameObject gameObject)
        {
            return GetOrAddComponent<AsyncMouseUpTrigger>(gameObject);
        }
        
        public static AsyncMouseUpTrigger GetAsyncMouseUpTrigger(this Component component)
        {
            return component.gameObject.GetAsyncMouseUpTrigger();
        }
    }

    [DisallowMultipleComponent]
    public sealed class AsyncMouseUpTrigger : AsyncTriggerBase
    {
        TriggerEvent<AsyncUnit> onMouseUpTriggerEvent;

        void OnMouseUp()
        {
            onMouseUpTriggerEvent?.TrySetResult(AsyncUnit.Default);
        }

        public IAsyncOnMouseUpHandler GetOnMouseUpAsyncHandler()
        {
            return new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onMouseUpTriggerEvent), false);
        }

        public IAsyncOnMouseUpHandler GetOnMouseUpAsyncHandler(CancellationToken cancellationToken)
        {
            return new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onMouseUpTriggerEvent), cancellationToken, false);
        }

        public UniTask OnMouseUpAsync()
        {
            return ((IAsyncOnMouseUpHandler)new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onMouseUpTriggerEvent), true)).OnMouseUpAsync();
        }

        public UniTask OnMouseUpAsync(CancellationToken cancellationToken)
        {
            return ((IAsyncOnMouseUpHandler)new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onMouseUpTriggerEvent), cancellationToken, true)).OnMouseUpAsync();
        }
    }
#endregion

#region MouseUpAsButton

    public interface IAsyncOnMouseUpAsButtonHandler
    {
        UniTask OnMouseUpAsButtonAsync();
    }

    public partial class AsyncTriggerHandler<T> : IAsyncOnMouseUpAsButtonHandler
    {
        UniTask IAsyncOnMouseUpAsButtonHandler.OnMouseUpAsButtonAsync()
        {
            core.Reset();
            return new UniTask((IUniTaskSource)(object)this, core.Version);
        }
    }

    public static partial class AsyncTriggerExtensions
    {
        public static AsyncMouseUpAsButtonTrigger GetAsyncMouseUpAsButtonTrigger(this GameObject gameObject)
        {
            return GetOrAddComponent<AsyncMouseUpAsButtonTrigger>(gameObject);
        }
        
        public static AsyncMouseUpAsButtonTrigger GetAsyncMouseUpAsButtonTrigger(this Component component)
        {
            return component.gameObject.GetAsyncMouseUpAsButtonTrigger();
        }
    }

    [DisallowMultipleComponent]
    public sealed class AsyncMouseUpAsButtonTrigger : AsyncTriggerBase
    {
        TriggerEvent<AsyncUnit> onMouseUpAsButtonTriggerEvent;

        void OnMouseUpAsButton()
        {
            onMouseUpAsButtonTriggerEvent?.TrySetResult(AsyncUnit.Default);
        }

        public IAsyncOnMouseUpAsButtonHandler GetOnMouseUpAsButtonAsyncHandler()
        {
            return new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onMouseUpAsButtonTriggerEvent), false);
        }

        public IAsyncOnMouseUpAsButtonHandler GetOnMouseUpAsButtonAsyncHandler(CancellationToken cancellationToken)
        {
            return new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onMouseUpAsButtonTriggerEvent), cancellationToken, false);
        }

        public UniTask OnMouseUpAsButtonAsync()
        {
            return ((IAsyncOnMouseUpAsButtonHandler)new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onMouseUpAsButtonTriggerEvent), true)).OnMouseUpAsButtonAsync();
        }

        public UniTask OnMouseUpAsButtonAsync(CancellationToken cancellationToken)
        {
            return ((IAsyncOnMouseUpAsButtonHandler)new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onMouseUpAsButtonTriggerEvent), cancellationToken, true)).OnMouseUpAsButtonAsync();
        }
    }
#endregion

#region ParticleCollision

    public interface IAsyncOnParticleCollisionHandler
    {
        UniTask<GameObject> OnParticleCollisionAsync();
    }

    public partial class AsyncTriggerHandler<T> : IAsyncOnParticleCollisionHandler
    {
        UniTask<GameObject> IAsyncOnParticleCollisionHandler.OnParticleCollisionAsync()
        {
            core.Reset();
            return new UniTask<GameObject>((IUniTaskSource<GameObject>)(object)this, core.Version);
        }
    }

    public static partial class AsyncTriggerExtensions
    {
        public static AsyncParticleCollisionTrigger GetAsyncParticleCollisionTrigger(this GameObject gameObject)
        {
            return GetOrAddComponent<AsyncParticleCollisionTrigger>(gameObject);
        }
        
        public static AsyncParticleCollisionTrigger GetAsyncParticleCollisionTrigger(this Component component)
        {
            return component.gameObject.GetAsyncParticleCollisionTrigger();
        }
    }

    [DisallowMultipleComponent]
    public sealed class AsyncParticleCollisionTrigger : AsyncTriggerBase
    {
        TriggerEvent<GameObject> onParticleCollisionTriggerEvent;

        void OnParticleCollision(GameObject other)
        {
            onParticleCollisionTriggerEvent?.TrySetResult((other));
        }

        public IAsyncOnParticleCollisionHandler GetOnParticleCollisionAsyncHandler()
        {
            return new AsyncTriggerHandler<GameObject>(SetTriggerEvent(ref onParticleCollisionTriggerEvent), false);
        }

        public IAsyncOnParticleCollisionHandler GetOnParticleCollisionAsyncHandler(CancellationToken cancellationToken)
        {
            return new AsyncTriggerHandler<GameObject>(SetTriggerEvent(ref onParticleCollisionTriggerEvent), cancellationToken, false);
        }

        public UniTask<GameObject> OnParticleCollisionAsync()
        {
            return ((IAsyncOnParticleCollisionHandler)new AsyncTriggerHandler<GameObject>(SetTriggerEvent(ref onParticleCollisionTriggerEvent), true)).OnParticleCollisionAsync();
        }

        public UniTask<GameObject> OnParticleCollisionAsync(CancellationToken cancellationToken)
        {
            return ((IAsyncOnParticleCollisionHandler)new AsyncTriggerHandler<GameObject>(SetTriggerEvent(ref onParticleCollisionTriggerEvent), cancellationToken, true)).OnParticleCollisionAsync();
        }
    }
#endregion

#region ParticleSystemStopped

    public interface IAsyncOnParticleSystemStoppedHandler
    {
        UniTask OnParticleSystemStoppedAsync();
    }

    public partial class AsyncTriggerHandler<T> : IAsyncOnParticleSystemStoppedHandler
    {
        UniTask IAsyncOnParticleSystemStoppedHandler.OnParticleSystemStoppedAsync()
        {
            core.Reset();
            return new UniTask((IUniTaskSource)(object)this, core.Version);
        }
    }

    public static partial class AsyncTriggerExtensions
    {
        public static AsyncParticleSystemStoppedTrigger GetAsyncParticleSystemStoppedTrigger(this GameObject gameObject)
        {
            return GetOrAddComponent<AsyncParticleSystemStoppedTrigger>(gameObject);
        }
        
        public static AsyncParticleSystemStoppedTrigger GetAsyncParticleSystemStoppedTrigger(this Component component)
        {
            return component.gameObject.GetAsyncParticleSystemStoppedTrigger();
        }
    }

    [DisallowMultipleComponent]
    public sealed class AsyncParticleSystemStoppedTrigger : AsyncTriggerBase
    {
        TriggerEvent<AsyncUnit> onParticleSystemStoppedTriggerEvent;

        void OnParticleSystemStopped()
        {
            onParticleSystemStoppedTriggerEvent?.TrySetResult(AsyncUnit.Default);
        }

        public IAsyncOnParticleSystemStoppedHandler GetOnParticleSystemStoppedAsyncHandler()
        {
            return new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onParticleSystemStoppedTriggerEvent), false);
        }

        public IAsyncOnParticleSystemStoppedHandler GetOnParticleSystemStoppedAsyncHandler(CancellationToken cancellationToken)
        {
            return new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onParticleSystemStoppedTriggerEvent), cancellationToken, false);
        }

        public UniTask OnParticleSystemStoppedAsync()
        {
            return ((IAsyncOnParticleSystemStoppedHandler)new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onParticleSystemStoppedTriggerEvent), true)).OnParticleSystemStoppedAsync();
        }

        public UniTask OnParticleSystemStoppedAsync(CancellationToken cancellationToken)
        {
            return ((IAsyncOnParticleSystemStoppedHandler)new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onParticleSystemStoppedTriggerEvent), cancellationToken, true)).OnParticleSystemStoppedAsync();
        }
    }
#endregion

#region ParticleTrigger

    public interface IAsyncOnParticleTriggerHandler
    {
        UniTask OnParticleTriggerAsync();
    }

    public partial class AsyncTriggerHandler<T> : IAsyncOnParticleTriggerHandler
    {
        UniTask IAsyncOnParticleTriggerHandler.OnParticleTriggerAsync()
        {
            core.Reset();
            return new UniTask((IUniTaskSource)(object)this, core.Version);
        }
    }

    public static partial class AsyncTriggerExtensions
    {
        public static AsyncParticleTriggerTrigger GetAsyncParticleTriggerTrigger(this GameObject gameObject)
        {
            return GetOrAddComponent<AsyncParticleTriggerTrigger>(gameObject);
        }
        
        public static AsyncParticleTriggerTrigger GetAsyncParticleTriggerTrigger(this Component component)
        {
            return component.gameObject.GetAsyncParticleTriggerTrigger();
        }
    }

    [DisallowMultipleComponent]
    public sealed class AsyncParticleTriggerTrigger : AsyncTriggerBase
    {
        TriggerEvent<AsyncUnit> onParticleTriggerTriggerEvent;

        void OnParticleTrigger()
        {
            onParticleTriggerTriggerEvent?.TrySetResult(AsyncUnit.Default);
        }

        public IAsyncOnParticleTriggerHandler GetOnParticleTriggerAsyncHandler()
        {
            return new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onParticleTriggerTriggerEvent), false);
        }

        public IAsyncOnParticleTriggerHandler GetOnParticleTriggerAsyncHandler(CancellationToken cancellationToken)
        {
            return new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onParticleTriggerTriggerEvent), cancellationToken, false);
        }

        public UniTask OnParticleTriggerAsync()
        {
            return ((IAsyncOnParticleTriggerHandler)new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onParticleTriggerTriggerEvent), true)).OnParticleTriggerAsync();
        }

        public UniTask OnParticleTriggerAsync(CancellationToken cancellationToken)
        {
            return ((IAsyncOnParticleTriggerHandler)new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onParticleTriggerTriggerEvent), cancellationToken, true)).OnParticleTriggerAsync();
        }
    }
#endregion

#region ParticleUpdateJobScheduled
#if UNITY_2019_3_OR_NEWER

    public interface IAsyncOnParticleUpdateJobScheduledHandler
    {
        UniTask<UnityEngine.ParticleSystemJobs.ParticleSystemJobData> OnParticleUpdateJobScheduledAsync();
    }

    public partial class AsyncTriggerHandler<T> : IAsyncOnParticleUpdateJobScheduledHandler
    {
        UniTask<UnityEngine.ParticleSystemJobs.ParticleSystemJobData> IAsyncOnParticleUpdateJobScheduledHandler.OnParticleUpdateJobScheduledAsync()
        {
            core.Reset();
            return new UniTask<UnityEngine.ParticleSystemJobs.ParticleSystemJobData>((IUniTaskSource<UnityEngine.ParticleSystemJobs.ParticleSystemJobData>)(object)this, core.Version);
        }
    }

    public static partial class AsyncTriggerExtensions
    {
        public static AsyncParticleUpdateJobScheduledTrigger GetAsyncParticleUpdateJobScheduledTrigger(this GameObject gameObject)
        {
            return GetOrAddComponent<AsyncParticleUpdateJobScheduledTrigger>(gameObject);
        }
        
        public static AsyncParticleUpdateJobScheduledTrigger GetAsyncParticleUpdateJobScheduledTrigger(this Component component)
        {
            return component.gameObject.GetAsyncParticleUpdateJobScheduledTrigger();
        }
    }

    [DisallowMultipleComponent]
    public sealed class AsyncParticleUpdateJobScheduledTrigger : AsyncTriggerBase
    {
        TriggerEvent<UnityEngine.ParticleSystemJobs.ParticleSystemJobData> onParticleUpdateJobScheduledTriggerEvent;

        void OnParticleUpdateJobScheduled(UnityEngine.ParticleSystemJobs.ParticleSystemJobData particles)
        {
            onParticleUpdateJobScheduledTriggerEvent?.TrySetResult((particles));
        }

        public IAsyncOnParticleUpdateJobScheduledHandler GetOnParticleUpdateJobScheduledAsyncHandler()
        {
            return new AsyncTriggerHandler<UnityEngine.ParticleSystemJobs.ParticleSystemJobData>(SetTriggerEvent(ref onParticleUpdateJobScheduledTriggerEvent), false);
        }

        public IAsyncOnParticleUpdateJobScheduledHandler GetOnParticleUpdateJobScheduledAsyncHandler(CancellationToken cancellationToken)
        {
            return new AsyncTriggerHandler<UnityEngine.ParticleSystemJobs.ParticleSystemJobData>(SetTriggerEvent(ref onParticleUpdateJobScheduledTriggerEvent), cancellationToken, false);
        }

        public UniTask<UnityEngine.ParticleSystemJobs.ParticleSystemJobData> OnParticleUpdateJobScheduledAsync()
        {
            return ((IAsyncOnParticleUpdateJobScheduledHandler)new AsyncTriggerHandler<UnityEngine.ParticleSystemJobs.ParticleSystemJobData>(SetTriggerEvent(ref onParticleUpdateJobScheduledTriggerEvent), true)).OnParticleUpdateJobScheduledAsync();
        }

        public UniTask<UnityEngine.ParticleSystemJobs.ParticleSystemJobData> OnParticleUpdateJobScheduledAsync(CancellationToken cancellationToken)
        {
            return ((IAsyncOnParticleUpdateJobScheduledHandler)new AsyncTriggerHandler<UnityEngine.ParticleSystemJobs.ParticleSystemJobData>(SetTriggerEvent(ref onParticleUpdateJobScheduledTriggerEvent), cancellationToken, true)).OnParticleUpdateJobScheduledAsync();
        }
    }
#endif
#endregion

#region PostRender

    public interface IAsyncOnPostRenderHandler
    {
        UniTask OnPostRenderAsync();
    }

    public partial class AsyncTriggerHandler<T> : IAsyncOnPostRenderHandler
    {
        UniTask IAsyncOnPostRenderHandler.OnPostRenderAsync()
        {
            core.Reset();
            return new UniTask((IUniTaskSource)(object)this, core.Version);
        }
    }

    public static partial class AsyncTriggerExtensions
    {
        public static AsyncPostRenderTrigger GetAsyncPostRenderTrigger(this GameObject gameObject)
        {
            return GetOrAddComponent<AsyncPostRenderTrigger>(gameObject);
        }
        
        public static AsyncPostRenderTrigger GetAsyncPostRenderTrigger(this Component component)
        {
            return component.gameObject.GetAsyncPostRenderTrigger();
        }
    }

    [DisallowMultipleComponent]
    public sealed class AsyncPostRenderTrigger : AsyncTriggerBase
    {
        TriggerEvent<AsyncUnit> onPostRenderTriggerEvent;

        void OnPostRender()
        {
            onPostRenderTriggerEvent?.TrySetResult(AsyncUnit.Default);
        }

        public IAsyncOnPostRenderHandler GetOnPostRenderAsyncHandler()
        {
            return new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onPostRenderTriggerEvent), false);
        }

        public IAsyncOnPostRenderHandler GetOnPostRenderAsyncHandler(CancellationToken cancellationToken)
        {
            return new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onPostRenderTriggerEvent), cancellationToken, false);
        }

        public UniTask OnPostRenderAsync()
        {
            return ((IAsyncOnPostRenderHandler)new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onPostRenderTriggerEvent), true)).OnPostRenderAsync();
        }

        public UniTask OnPostRenderAsync(CancellationToken cancellationToken)
        {
            return ((IAsyncOnPostRenderHandler)new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onPostRenderTriggerEvent), cancellationToken, true)).OnPostRenderAsync();
        }
    }
#endregion

#region PreCull

    public interface IAsyncOnPreCullHandler
    {
        UniTask OnPreCullAsync();
    }

    public partial class AsyncTriggerHandler<T> : IAsyncOnPreCullHandler
    {
        UniTask IAsyncOnPreCullHandler.OnPreCullAsync()
        {
            core.Reset();
            return new UniTask((IUniTaskSource)(object)this, core.Version);
        }
    }

    public static partial class AsyncTriggerExtensions
    {
        public static AsyncPreCullTrigger GetAsyncPreCullTrigger(this GameObject gameObject)
        {
            return GetOrAddComponent<AsyncPreCullTrigger>(gameObject);
        }
        
        public static AsyncPreCullTrigger GetAsyncPreCullTrigger(this Component component)
        {
            return component.gameObject.GetAsyncPreCullTrigger();
        }
    }

    [DisallowMultipleComponent]
    public sealed class AsyncPreCullTrigger : AsyncTriggerBase
    {
        TriggerEvent<AsyncUnit> onPreCullTriggerEvent;

        void OnPreCull()
        {
            onPreCullTriggerEvent?.TrySetResult(AsyncUnit.Default);
        }

        public IAsyncOnPreCullHandler GetOnPreCullAsyncHandler()
        {
            return new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onPreCullTriggerEvent), false);
        }

        public IAsyncOnPreCullHandler GetOnPreCullAsyncHandler(CancellationToken cancellationToken)
        {
            return new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onPreCullTriggerEvent), cancellationToken, false);
        }

        public UniTask OnPreCullAsync()
        {
            return ((IAsyncOnPreCullHandler)new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onPreCullTriggerEvent), true)).OnPreCullAsync();
        }

        public UniTask OnPreCullAsync(CancellationToken cancellationToken)
        {
            return ((IAsyncOnPreCullHandler)new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onPreCullTriggerEvent), cancellationToken, true)).OnPreCullAsync();
        }
    }
#endregion

#region PreRender

    public interface IAsyncOnPreRenderHandler
    {
        UniTask OnPreRenderAsync();
    }

    public partial class AsyncTriggerHandler<T> : IAsyncOnPreRenderHandler
    {
        UniTask IAsyncOnPreRenderHandler.OnPreRenderAsync()
        {
            core.Reset();
            return new UniTask((IUniTaskSource)(object)this, core.Version);
        }
    }

    public static partial class AsyncTriggerExtensions
    {
        public static AsyncPreRenderTrigger GetAsyncPreRenderTrigger(this GameObject gameObject)
        {
            return GetOrAddComponent<AsyncPreRenderTrigger>(gameObject);
        }
        
        public static AsyncPreRenderTrigger GetAsyncPreRenderTrigger(this Component component)
        {
            return component.gameObject.GetAsyncPreRenderTrigger();
        }
    }

    [DisallowMultipleComponent]
    public sealed class AsyncPreRenderTrigger : AsyncTriggerBase
    {
        TriggerEvent<AsyncUnit> onPreRenderTriggerEvent;

        void OnPreRender()
        {
            onPreRenderTriggerEvent?.TrySetResult(AsyncUnit.Default);
        }

        public IAsyncOnPreRenderHandler GetOnPreRenderAsyncHandler()
        {
            return new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onPreRenderTriggerEvent), false);
        }

        public IAsyncOnPreRenderHandler GetOnPreRenderAsyncHandler(CancellationToken cancellationToken)
        {
            return new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onPreRenderTriggerEvent), cancellationToken, false);
        }

        public UniTask OnPreRenderAsync()
        {
            return ((IAsyncOnPreRenderHandler)new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onPreRenderTriggerEvent), true)).OnPreRenderAsync();
        }

        public UniTask OnPreRenderAsync(CancellationToken cancellationToken)
        {
            return ((IAsyncOnPreRenderHandler)new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onPreRenderTriggerEvent), cancellationToken, true)).OnPreRenderAsync();
        }
    }
#endregion

#region RectTransformDimensionsChange

    public interface IAsyncOnRectTransformDimensionsChangeHandler
    {
        UniTask OnRectTransformDimensionsChangeAsync();
    }

    public partial class AsyncTriggerHandler<T> : IAsyncOnRectTransformDimensionsChangeHandler
    {
        UniTask IAsyncOnRectTransformDimensionsChangeHandler.OnRectTransformDimensionsChangeAsync()
        {
            core.Reset();
            return new UniTask((IUniTaskSource)(object)this, core.Version);
        }
    }

    public static partial class AsyncTriggerExtensions
    {
        public static AsyncRectTransformDimensionsChangeTrigger GetAsyncRectTransformDimensionsChangeTrigger(this GameObject gameObject)
        {
            return GetOrAddComponent<AsyncRectTransformDimensionsChangeTrigger>(gameObject);
        }
        
        public static AsyncRectTransformDimensionsChangeTrigger GetAsyncRectTransformDimensionsChangeTrigger(this Component component)
        {
            return component.gameObject.GetAsyncRectTransformDimensionsChangeTrigger();
        }
    }

    [DisallowMultipleComponent]
    public sealed class AsyncRectTransformDimensionsChangeTrigger : AsyncTriggerBase
    {
        TriggerEvent<AsyncUnit> onRectTransformDimensionsChangeTriggerEvent;

        void OnRectTransformDimensionsChange()
        {
            onRectTransformDimensionsChangeTriggerEvent?.TrySetResult(AsyncUnit.Default);
        }

        public IAsyncOnRectTransformDimensionsChangeHandler GetOnRectTransformDimensionsChangeAsyncHandler()
        {
            return new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onRectTransformDimensionsChangeTriggerEvent), false);
        }

        public IAsyncOnRectTransformDimensionsChangeHandler GetOnRectTransformDimensionsChangeAsyncHandler(CancellationToken cancellationToken)
        {
            return new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onRectTransformDimensionsChangeTriggerEvent), cancellationToken, false);
        }

        public UniTask OnRectTransformDimensionsChangeAsync()
        {
            return ((IAsyncOnRectTransformDimensionsChangeHandler)new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onRectTransformDimensionsChangeTriggerEvent), true)).OnRectTransformDimensionsChangeAsync();
        }

        public UniTask OnRectTransformDimensionsChangeAsync(CancellationToken cancellationToken)
        {
            return ((IAsyncOnRectTransformDimensionsChangeHandler)new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onRectTransformDimensionsChangeTriggerEvent), cancellationToken, true)).OnRectTransformDimensionsChangeAsync();
        }
    }
#endregion

#region RectTransformRemoved

    public interface IAsyncOnRectTransformRemovedHandler
    {
        UniTask OnRectTransformRemovedAsync();
    }

    public partial class AsyncTriggerHandler<T> : IAsyncOnRectTransformRemovedHandler
    {
        UniTask IAsyncOnRectTransformRemovedHandler.OnRectTransformRemovedAsync()
        {
            core.Reset();
            return new UniTask((IUniTaskSource)(object)this, core.Version);
        }
    }

    public static partial class AsyncTriggerExtensions
    {
        public static AsyncRectTransformRemovedTrigger GetAsyncRectTransformRemovedTrigger(this GameObject gameObject)
        {
            return GetOrAddComponent<AsyncRectTransformRemovedTrigger>(gameObject);
        }
        
        public static AsyncRectTransformRemovedTrigger GetAsyncRectTransformRemovedTrigger(this Component component)
        {
            return component.gameObject.GetAsyncRectTransformRemovedTrigger();
        }
    }

    [DisallowMultipleComponent]
    public sealed class AsyncRectTransformRemovedTrigger : AsyncTriggerBase
    {
        TriggerEvent<AsyncUnit> onRectTransformRemovedTriggerEvent;

        void OnRectTransformRemoved()
        {
            onRectTransformRemovedTriggerEvent?.TrySetResult(AsyncUnit.Default);
        }

        public IAsyncOnRectTransformRemovedHandler GetOnRectTransformRemovedAsyncHandler()
        {
            return new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onRectTransformRemovedTriggerEvent), false);
        }

        public IAsyncOnRectTransformRemovedHandler GetOnRectTransformRemovedAsyncHandler(CancellationToken cancellationToken)
        {
            return new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onRectTransformRemovedTriggerEvent), cancellationToken, false);
        }

        public UniTask OnRectTransformRemovedAsync()
        {
            return ((IAsyncOnRectTransformRemovedHandler)new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onRectTransformRemovedTriggerEvent), true)).OnRectTransformRemovedAsync();
        }

        public UniTask OnRectTransformRemovedAsync(CancellationToken cancellationToken)
        {
            return ((IAsyncOnRectTransformRemovedHandler)new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onRectTransformRemovedTriggerEvent), cancellationToken, true)).OnRectTransformRemovedAsync();
        }
    }
#endregion

#region RenderImage

    public interface IAsyncOnRenderImageHandler
    {
        UniTask<(RenderTexture source, RenderTexture destination)> OnRenderImageAsync();
    }

    public partial class AsyncTriggerHandler<T> : IAsyncOnRenderImageHandler
    {
        UniTask<(RenderTexture source, RenderTexture destination)> IAsyncOnRenderImageHandler.OnRenderImageAsync()
        {
            core.Reset();
            return new UniTask<(RenderTexture source, RenderTexture destination)>((IUniTaskSource<(RenderTexture source, RenderTexture destination)>)(object)this, core.Version);
        }
    }

    public static partial class AsyncTriggerExtensions
    {
        public static AsyncRenderImageTrigger GetAsyncRenderImageTrigger(this GameObject gameObject)
        {
            return GetOrAddComponent<AsyncRenderImageTrigger>(gameObject);
        }
        
        public static AsyncRenderImageTrigger GetAsyncRenderImageTrigger(this Component component)
        {
            return component.gameObject.GetAsyncRenderImageTrigger();
        }
    }

    [DisallowMultipleComponent]
    public sealed class AsyncRenderImageTrigger : AsyncTriggerBase
    {
        TriggerEvent<(RenderTexture source, RenderTexture destination)> onRenderImageTriggerEvent;

        void OnRenderImage(RenderTexture source, RenderTexture destination)
        {
            onRenderImageTriggerEvent?.TrySetResult((source, destination));
        }

        public IAsyncOnRenderImageHandler GetOnRenderImageAsyncHandler()
        {
            return new AsyncTriggerHandler<(RenderTexture source, RenderTexture destination)>(SetTriggerEvent(ref onRenderImageTriggerEvent), false);
        }

        public IAsyncOnRenderImageHandler GetOnRenderImageAsyncHandler(CancellationToken cancellationToken)
        {
            return new AsyncTriggerHandler<(RenderTexture source, RenderTexture destination)>(SetTriggerEvent(ref onRenderImageTriggerEvent), cancellationToken, false);
        }

        public UniTask<(RenderTexture source, RenderTexture destination)> OnRenderImageAsync()
        {
            return ((IAsyncOnRenderImageHandler)new AsyncTriggerHandler<(RenderTexture source, RenderTexture destination)>(SetTriggerEvent(ref onRenderImageTriggerEvent), true)).OnRenderImageAsync();
        }

        public UniTask<(RenderTexture source, RenderTexture destination)> OnRenderImageAsync(CancellationToken cancellationToken)
        {
            return ((IAsyncOnRenderImageHandler)new AsyncTriggerHandler<(RenderTexture source, RenderTexture destination)>(SetTriggerEvent(ref onRenderImageTriggerEvent), cancellationToken, true)).OnRenderImageAsync();
        }
    }
#endregion

#region RenderObject

    public interface IAsyncOnRenderObjectHandler
    {
        UniTask OnRenderObjectAsync();
    }

    public partial class AsyncTriggerHandler<T> : IAsyncOnRenderObjectHandler
    {
        UniTask IAsyncOnRenderObjectHandler.OnRenderObjectAsync()
        {
            core.Reset();
            return new UniTask((IUniTaskSource)(object)this, core.Version);
        }
    }

    public static partial class AsyncTriggerExtensions
    {
        public static AsyncRenderObjectTrigger GetAsyncRenderObjectTrigger(this GameObject gameObject)
        {
            return GetOrAddComponent<AsyncRenderObjectTrigger>(gameObject);
        }
        
        public static AsyncRenderObjectTrigger GetAsyncRenderObjectTrigger(this Component component)
        {
            return component.gameObject.GetAsyncRenderObjectTrigger();
        }
    }

    [DisallowMultipleComponent]
    public sealed class AsyncRenderObjectTrigger : AsyncTriggerBase
    {
        TriggerEvent<AsyncUnit> onRenderObjectTriggerEvent;

        void OnRenderObject()
        {
            onRenderObjectTriggerEvent?.TrySetResult(AsyncUnit.Default);
        }

        public IAsyncOnRenderObjectHandler GetOnRenderObjectAsyncHandler()
        {
            return new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onRenderObjectTriggerEvent), false);
        }

        public IAsyncOnRenderObjectHandler GetOnRenderObjectAsyncHandler(CancellationToken cancellationToken)
        {
            return new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onRenderObjectTriggerEvent), cancellationToken, false);
        }

        public UniTask OnRenderObjectAsync()
        {
            return ((IAsyncOnRenderObjectHandler)new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onRenderObjectTriggerEvent), true)).OnRenderObjectAsync();
        }

        public UniTask OnRenderObjectAsync(CancellationToken cancellationToken)
        {
            return ((IAsyncOnRenderObjectHandler)new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onRenderObjectTriggerEvent), cancellationToken, true)).OnRenderObjectAsync();
        }
    }
#endregion

#region ServerInitialized

    public interface IAsyncOnServerInitializedHandler
    {
        UniTask OnServerInitializedAsync();
    }

    public partial class AsyncTriggerHandler<T> : IAsyncOnServerInitializedHandler
    {
        UniTask IAsyncOnServerInitializedHandler.OnServerInitializedAsync()
        {
            core.Reset();
            return new UniTask((IUniTaskSource)(object)this, core.Version);
        }
    }

    public static partial class AsyncTriggerExtensions
    {
        public static AsyncServerInitializedTrigger GetAsyncServerInitializedTrigger(this GameObject gameObject)
        {
            return GetOrAddComponent<AsyncServerInitializedTrigger>(gameObject);
        }
        
        public static AsyncServerInitializedTrigger GetAsyncServerInitializedTrigger(this Component component)
        {
            return component.gameObject.GetAsyncServerInitializedTrigger();
        }
    }

    [DisallowMultipleComponent]
    public sealed class AsyncServerInitializedTrigger : AsyncTriggerBase
    {
        TriggerEvent<AsyncUnit> onServerInitializedTriggerEvent;

        void OnServerInitialized()
        {
            onServerInitializedTriggerEvent?.TrySetResult(AsyncUnit.Default);
        }

        public IAsyncOnServerInitializedHandler GetOnServerInitializedAsyncHandler()
        {
            return new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onServerInitializedTriggerEvent), false);
        }

        public IAsyncOnServerInitializedHandler GetOnServerInitializedAsyncHandler(CancellationToken cancellationToken)
        {
            return new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onServerInitializedTriggerEvent), cancellationToken, false);
        }

        public UniTask OnServerInitializedAsync()
        {
            return ((IAsyncOnServerInitializedHandler)new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onServerInitializedTriggerEvent), true)).OnServerInitializedAsync();
        }

        public UniTask OnServerInitializedAsync(CancellationToken cancellationToken)
        {
            return ((IAsyncOnServerInitializedHandler)new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onServerInitializedTriggerEvent), cancellationToken, true)).OnServerInitializedAsync();
        }
    }
#endregion

#region TransformChildrenChanged

    public interface IAsyncOnTransformChildrenChangedHandler
    {
        UniTask OnTransformChildrenChangedAsync();
    }

    public partial class AsyncTriggerHandler<T> : IAsyncOnTransformChildrenChangedHandler
    {
        UniTask IAsyncOnTransformChildrenChangedHandler.OnTransformChildrenChangedAsync()
        {
            core.Reset();
            return new UniTask((IUniTaskSource)(object)this, core.Version);
        }
    }

    public static partial class AsyncTriggerExtensions
    {
        public static AsyncTransformChildrenChangedTrigger GetAsyncTransformChildrenChangedTrigger(this GameObject gameObject)
        {
            return GetOrAddComponent<AsyncTransformChildrenChangedTrigger>(gameObject);
        }
        
        public static AsyncTransformChildrenChangedTrigger GetAsyncTransformChildrenChangedTrigger(this Component component)
        {
            return component.gameObject.GetAsyncTransformChildrenChangedTrigger();
        }
    }

    [DisallowMultipleComponent]
    public sealed class AsyncTransformChildrenChangedTrigger : AsyncTriggerBase
    {
        TriggerEvent<AsyncUnit> onTransformChildrenChangedTriggerEvent;

        void OnTransformChildrenChanged()
        {
            onTransformChildrenChangedTriggerEvent?.TrySetResult(AsyncUnit.Default);
        }

        public IAsyncOnTransformChildrenChangedHandler GetOnTransformChildrenChangedAsyncHandler()
        {
            return new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onTransformChildrenChangedTriggerEvent), false);
        }

        public IAsyncOnTransformChildrenChangedHandler GetOnTransformChildrenChangedAsyncHandler(CancellationToken cancellationToken)
        {
            return new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onTransformChildrenChangedTriggerEvent), cancellationToken, false);
        }

        public UniTask OnTransformChildrenChangedAsync()
        {
            return ((IAsyncOnTransformChildrenChangedHandler)new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onTransformChildrenChangedTriggerEvent), true)).OnTransformChildrenChangedAsync();
        }

        public UniTask OnTransformChildrenChangedAsync(CancellationToken cancellationToken)
        {
            return ((IAsyncOnTransformChildrenChangedHandler)new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onTransformChildrenChangedTriggerEvent), cancellationToken, true)).OnTransformChildrenChangedAsync();
        }
    }
#endregion

#region TransformParentChanged

    public interface IAsyncOnTransformParentChangedHandler
    {
        UniTask OnTransformParentChangedAsync();
    }

    public partial class AsyncTriggerHandler<T> : IAsyncOnTransformParentChangedHandler
    {
        UniTask IAsyncOnTransformParentChangedHandler.OnTransformParentChangedAsync()
        {
            core.Reset();
            return new UniTask((IUniTaskSource)(object)this, core.Version);
        }
    }

    public static partial class AsyncTriggerExtensions
    {
        public static AsyncTransformParentChangedTrigger GetAsyncTransformParentChangedTrigger(this GameObject gameObject)
        {
            return GetOrAddComponent<AsyncTransformParentChangedTrigger>(gameObject);
        }
        
        public static AsyncTransformParentChangedTrigger GetAsyncTransformParentChangedTrigger(this Component component)
        {
            return component.gameObject.GetAsyncTransformParentChangedTrigger();
        }
    }

    [DisallowMultipleComponent]
    public sealed class AsyncTransformParentChangedTrigger : AsyncTriggerBase
    {
        TriggerEvent<AsyncUnit> onTransformParentChangedTriggerEvent;

        void OnTransformParentChanged()
        {
            onTransformParentChangedTriggerEvent?.TrySetResult(AsyncUnit.Default);
        }

        public IAsyncOnTransformParentChangedHandler GetOnTransformParentChangedAsyncHandler()
        {
            return new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onTransformParentChangedTriggerEvent), false);
        }

        public IAsyncOnTransformParentChangedHandler GetOnTransformParentChangedAsyncHandler(CancellationToken cancellationToken)
        {
            return new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onTransformParentChangedTriggerEvent), cancellationToken, false);
        }

        public UniTask OnTransformParentChangedAsync()
        {
            return ((IAsyncOnTransformParentChangedHandler)new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onTransformParentChangedTriggerEvent), true)).OnTransformParentChangedAsync();
        }

        public UniTask OnTransformParentChangedAsync(CancellationToken cancellationToken)
        {
            return ((IAsyncOnTransformParentChangedHandler)new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onTransformParentChangedTriggerEvent), cancellationToken, true)).OnTransformParentChangedAsync();
        }
    }
#endregion

#region TriggerEnter

    public interface IAsyncOnTriggerEnterHandler
    {
        UniTask<Collider> OnTriggerEnterAsync();
    }

    public partial class AsyncTriggerHandler<T> : IAsyncOnTriggerEnterHandler
    {
        UniTask<Collider> IAsyncOnTriggerEnterHandler.OnTriggerEnterAsync()
        {
            core.Reset();
            return new UniTask<Collider>((IUniTaskSource<Collider>)(object)this, core.Version);
        }
    }

    public static partial class AsyncTriggerExtensions
    {
        public static AsyncTriggerEnterTrigger GetAsyncTriggerEnterTrigger(this GameObject gameObject)
        {
            return GetOrAddComponent<AsyncTriggerEnterTrigger>(gameObject);
        }
        
        public static AsyncTriggerEnterTrigger GetAsyncTriggerEnterTrigger(this Component component)
        {
            return component.gameObject.GetAsyncTriggerEnterTrigger();
        }
    }

    [DisallowMultipleComponent]
    public sealed class AsyncTriggerEnterTrigger : AsyncTriggerBase
    {
        TriggerEvent<Collider> onTriggerEnterTriggerEvent;

        void OnTriggerEnter(Collider other)
        {
            onTriggerEnterTriggerEvent?.TrySetResult((other));
        }

        public IAsyncOnTriggerEnterHandler GetOnTriggerEnterAsyncHandler()
        {
            return new AsyncTriggerHandler<Collider>(SetTriggerEvent(ref onTriggerEnterTriggerEvent), false);
        }

        public IAsyncOnTriggerEnterHandler GetOnTriggerEnterAsyncHandler(CancellationToken cancellationToken)
        {
            return new AsyncTriggerHandler<Collider>(SetTriggerEvent(ref onTriggerEnterTriggerEvent), cancellationToken, false);
        }

        public UniTask<Collider> OnTriggerEnterAsync()
        {
            return ((IAsyncOnTriggerEnterHandler)new AsyncTriggerHandler<Collider>(SetTriggerEvent(ref onTriggerEnterTriggerEvent), true)).OnTriggerEnterAsync();
        }

        public UniTask<Collider> OnTriggerEnterAsync(CancellationToken cancellationToken)
        {
            return ((IAsyncOnTriggerEnterHandler)new AsyncTriggerHandler<Collider>(SetTriggerEvent(ref onTriggerEnterTriggerEvent), cancellationToken, true)).OnTriggerEnterAsync();
        }
    }
#endregion

#region TriggerEnter2D

    public interface IAsyncOnTriggerEnter2DHandler
    {
        UniTask<Collider2D> OnTriggerEnter2DAsync();
    }

    public partial class AsyncTriggerHandler<T> : IAsyncOnTriggerEnter2DHandler
    {
        UniTask<Collider2D> IAsyncOnTriggerEnter2DHandler.OnTriggerEnter2DAsync()
        {
            core.Reset();
            return new UniTask<Collider2D>((IUniTaskSource<Collider2D>)(object)this, core.Version);
        }
    }

    public static partial class AsyncTriggerExtensions
    {
        public static AsyncTriggerEnter2DTrigger GetAsyncTriggerEnter2DTrigger(this GameObject gameObject)
        {
            return GetOrAddComponent<AsyncTriggerEnter2DTrigger>(gameObject);
        }
        
        public static AsyncTriggerEnter2DTrigger GetAsyncTriggerEnter2DTrigger(this Component component)
        {
            return component.gameObject.GetAsyncTriggerEnter2DTrigger();
        }
    }

    [DisallowMultipleComponent]
    public sealed class AsyncTriggerEnter2DTrigger : AsyncTriggerBase
    {
        TriggerEvent<Collider2D> onTriggerEnter2DTriggerEvent;

        void OnTriggerEnter2D(Collider2D other)
        {
            onTriggerEnter2DTriggerEvent?.TrySetResult((other));
        }

        public IAsyncOnTriggerEnter2DHandler GetOnTriggerEnter2DAsyncHandler()
        {
            return new AsyncTriggerHandler<Collider2D>(SetTriggerEvent(ref onTriggerEnter2DTriggerEvent), false);
        }

        public IAsyncOnTriggerEnter2DHandler GetOnTriggerEnter2DAsyncHandler(CancellationToken cancellationToken)
        {
            return new AsyncTriggerHandler<Collider2D>(SetTriggerEvent(ref onTriggerEnter2DTriggerEvent), cancellationToken, false);
        }

        public UniTask<Collider2D> OnTriggerEnter2DAsync()
        {
            return ((IAsyncOnTriggerEnter2DHandler)new AsyncTriggerHandler<Collider2D>(SetTriggerEvent(ref onTriggerEnter2DTriggerEvent), true)).OnTriggerEnter2DAsync();
        }

        public UniTask<Collider2D> OnTriggerEnter2DAsync(CancellationToken cancellationToken)
        {
            return ((IAsyncOnTriggerEnter2DHandler)new AsyncTriggerHandler<Collider2D>(SetTriggerEvent(ref onTriggerEnter2DTriggerEvent), cancellationToken, true)).OnTriggerEnter2DAsync();
        }
    }
#endregion

#region TriggerExit

    public interface IAsyncOnTriggerExitHandler
    {
        UniTask<Collider> OnTriggerExitAsync();
    }

    public partial class AsyncTriggerHandler<T> : IAsyncOnTriggerExitHandler
    {
        UniTask<Collider> IAsyncOnTriggerExitHandler.OnTriggerExitAsync()
        {
            core.Reset();
            return new UniTask<Collider>((IUniTaskSource<Collider>)(object)this, core.Version);
        }
    }

    public static partial class AsyncTriggerExtensions
    {
        public static AsyncTriggerExitTrigger GetAsyncTriggerExitTrigger(this GameObject gameObject)
        {
            return GetOrAddComponent<AsyncTriggerExitTrigger>(gameObject);
        }
        
        public static AsyncTriggerExitTrigger GetAsyncTriggerExitTrigger(this Component component)
        {
            return component.gameObject.GetAsyncTriggerExitTrigger();
        }
    }

    [DisallowMultipleComponent]
    public sealed class AsyncTriggerExitTrigger : AsyncTriggerBase
    {
        TriggerEvent<Collider> onTriggerExitTriggerEvent;

        void OnTriggerExit(Collider other)
        {
            onTriggerExitTriggerEvent?.TrySetResult((other));
        }

        public IAsyncOnTriggerExitHandler GetOnTriggerExitAsyncHandler()
        {
            return new AsyncTriggerHandler<Collider>(SetTriggerEvent(ref onTriggerExitTriggerEvent), false);
        }

        public IAsyncOnTriggerExitHandler GetOnTriggerExitAsyncHandler(CancellationToken cancellationToken)
        {
            return new AsyncTriggerHandler<Collider>(SetTriggerEvent(ref onTriggerExitTriggerEvent), cancellationToken, false);
        }

        public UniTask<Collider> OnTriggerExitAsync()
        {
            return ((IAsyncOnTriggerExitHandler)new AsyncTriggerHandler<Collider>(SetTriggerEvent(ref onTriggerExitTriggerEvent), true)).OnTriggerExitAsync();
        }

        public UniTask<Collider> OnTriggerExitAsync(CancellationToken cancellationToken)
        {
            return ((IAsyncOnTriggerExitHandler)new AsyncTriggerHandler<Collider>(SetTriggerEvent(ref onTriggerExitTriggerEvent), cancellationToken, true)).OnTriggerExitAsync();
        }
    }
#endregion

#region TriggerExit2D

    public interface IAsyncOnTriggerExit2DHandler
    {
        UniTask<Collider2D> OnTriggerExit2DAsync();
    }

    public partial class AsyncTriggerHandler<T> : IAsyncOnTriggerExit2DHandler
    {
        UniTask<Collider2D> IAsyncOnTriggerExit2DHandler.OnTriggerExit2DAsync()
        {
            core.Reset();
            return new UniTask<Collider2D>((IUniTaskSource<Collider2D>)(object)this, core.Version);
        }
    }

    public static partial class AsyncTriggerExtensions
    {
        public static AsyncTriggerExit2DTrigger GetAsyncTriggerExit2DTrigger(this GameObject gameObject)
        {
            return GetOrAddComponent<AsyncTriggerExit2DTrigger>(gameObject);
        }
        
        public static AsyncTriggerExit2DTrigger GetAsyncTriggerExit2DTrigger(this Component component)
        {
            return component.gameObject.GetAsyncTriggerExit2DTrigger();
        }
    }

    [DisallowMultipleComponent]
    public sealed class AsyncTriggerExit2DTrigger : AsyncTriggerBase
    {
        TriggerEvent<Collider2D> onTriggerExit2DTriggerEvent;

        void OnTriggerExit2D(Collider2D other)
        {
            onTriggerExit2DTriggerEvent?.TrySetResult((other));
        }

        public IAsyncOnTriggerExit2DHandler GetOnTriggerExit2DAsyncHandler()
        {
            return new AsyncTriggerHandler<Collider2D>(SetTriggerEvent(ref onTriggerExit2DTriggerEvent), false);
        }

        public IAsyncOnTriggerExit2DHandler GetOnTriggerExit2DAsyncHandler(CancellationToken cancellationToken)
        {
            return new AsyncTriggerHandler<Collider2D>(SetTriggerEvent(ref onTriggerExit2DTriggerEvent), cancellationToken, false);
        }

        public UniTask<Collider2D> OnTriggerExit2DAsync()
        {
            return ((IAsyncOnTriggerExit2DHandler)new AsyncTriggerHandler<Collider2D>(SetTriggerEvent(ref onTriggerExit2DTriggerEvent), true)).OnTriggerExit2DAsync();
        }

        public UniTask<Collider2D> OnTriggerExit2DAsync(CancellationToken cancellationToken)
        {
            return ((IAsyncOnTriggerExit2DHandler)new AsyncTriggerHandler<Collider2D>(SetTriggerEvent(ref onTriggerExit2DTriggerEvent), cancellationToken, true)).OnTriggerExit2DAsync();
        }
    }
#endregion

#region TriggerStay

    public interface IAsyncOnTriggerStayHandler
    {
        UniTask<Collider> OnTriggerStayAsync();
    }

    public partial class AsyncTriggerHandler<T> : IAsyncOnTriggerStayHandler
    {
        UniTask<Collider> IAsyncOnTriggerStayHandler.OnTriggerStayAsync()
        {
            core.Reset();
            return new UniTask<Collider>((IUniTaskSource<Collider>)(object)this, core.Version);
        }
    }

    public static partial class AsyncTriggerExtensions
    {
        public static AsyncTriggerStayTrigger GetAsyncTriggerStayTrigger(this GameObject gameObject)
        {
            return GetOrAddComponent<AsyncTriggerStayTrigger>(gameObject);
        }
        
        public static AsyncTriggerStayTrigger GetAsyncTriggerStayTrigger(this Component component)
        {
            return component.gameObject.GetAsyncTriggerStayTrigger();
        }
    }

    [DisallowMultipleComponent]
    public sealed class AsyncTriggerStayTrigger : AsyncTriggerBase
    {
        TriggerEvent<Collider> onTriggerStayTriggerEvent;

        void OnTriggerStay(Collider other)
        {
            onTriggerStayTriggerEvent?.TrySetResult((other));
        }

        public IAsyncOnTriggerStayHandler GetOnTriggerStayAsyncHandler()
        {
            return new AsyncTriggerHandler<Collider>(SetTriggerEvent(ref onTriggerStayTriggerEvent), false);
        }

        public IAsyncOnTriggerStayHandler GetOnTriggerStayAsyncHandler(CancellationToken cancellationToken)
        {
            return new AsyncTriggerHandler<Collider>(SetTriggerEvent(ref onTriggerStayTriggerEvent), cancellationToken, false);
        }

        public UniTask<Collider> OnTriggerStayAsync()
        {
            return ((IAsyncOnTriggerStayHandler)new AsyncTriggerHandler<Collider>(SetTriggerEvent(ref onTriggerStayTriggerEvent), true)).OnTriggerStayAsync();
        }

        public UniTask<Collider> OnTriggerStayAsync(CancellationToken cancellationToken)
        {
            return ((IAsyncOnTriggerStayHandler)new AsyncTriggerHandler<Collider>(SetTriggerEvent(ref onTriggerStayTriggerEvent), cancellationToken, true)).OnTriggerStayAsync();
        }
    }
#endregion

#region TriggerStay2D

    public interface IAsyncOnTriggerStay2DHandler
    {
        UniTask<Collider2D> OnTriggerStay2DAsync();
    }

    public partial class AsyncTriggerHandler<T> : IAsyncOnTriggerStay2DHandler
    {
        UniTask<Collider2D> IAsyncOnTriggerStay2DHandler.OnTriggerStay2DAsync()
        {
            core.Reset();
            return new UniTask<Collider2D>((IUniTaskSource<Collider2D>)(object)this, core.Version);
        }
    }

    public static partial class AsyncTriggerExtensions
    {
        public static AsyncTriggerStay2DTrigger GetAsyncTriggerStay2DTrigger(this GameObject gameObject)
        {
            return GetOrAddComponent<AsyncTriggerStay2DTrigger>(gameObject);
        }
        
        public static AsyncTriggerStay2DTrigger GetAsyncTriggerStay2DTrigger(this Component component)
        {
            return component.gameObject.GetAsyncTriggerStay2DTrigger();
        }
    }

    [DisallowMultipleComponent]
    public sealed class AsyncTriggerStay2DTrigger : AsyncTriggerBase
    {
        TriggerEvent<Collider2D> onTriggerStay2DTriggerEvent;

        void OnTriggerStay2D(Collider2D other)
        {
            onTriggerStay2DTriggerEvent?.TrySetResult((other));
        }

        public IAsyncOnTriggerStay2DHandler GetOnTriggerStay2DAsyncHandler()
        {
            return new AsyncTriggerHandler<Collider2D>(SetTriggerEvent(ref onTriggerStay2DTriggerEvent), false);
        }

        public IAsyncOnTriggerStay2DHandler GetOnTriggerStay2DAsyncHandler(CancellationToken cancellationToken)
        {
            return new AsyncTriggerHandler<Collider2D>(SetTriggerEvent(ref onTriggerStay2DTriggerEvent), cancellationToken, false);
        }

        public UniTask<Collider2D> OnTriggerStay2DAsync()
        {
            return ((IAsyncOnTriggerStay2DHandler)new AsyncTriggerHandler<Collider2D>(SetTriggerEvent(ref onTriggerStay2DTriggerEvent), true)).OnTriggerStay2DAsync();
        }

        public UniTask<Collider2D> OnTriggerStay2DAsync(CancellationToken cancellationToken)
        {
            return ((IAsyncOnTriggerStay2DHandler)new AsyncTriggerHandler<Collider2D>(SetTriggerEvent(ref onTriggerStay2DTriggerEvent), cancellationToken, true)).OnTriggerStay2DAsync();
        }
    }
#endregion

#region Validate

    public interface IAsyncOnValidateHandler
    {
        UniTask OnValidateAsync();
    }

    public partial class AsyncTriggerHandler<T> : IAsyncOnValidateHandler
    {
        UniTask IAsyncOnValidateHandler.OnValidateAsync()
        {
            core.Reset();
            return new UniTask((IUniTaskSource)(object)this, core.Version);
        }
    }

    public static partial class AsyncTriggerExtensions
    {
        public static AsyncValidateTrigger GetAsyncValidateTrigger(this GameObject gameObject)
        {
            return GetOrAddComponent<AsyncValidateTrigger>(gameObject);
        }
        
        public static AsyncValidateTrigger GetAsyncValidateTrigger(this Component component)
        {
            return component.gameObject.GetAsyncValidateTrigger();
        }
    }

    [DisallowMultipleComponent]
    public sealed class AsyncValidateTrigger : AsyncTriggerBase
    {
        TriggerEvent<AsyncUnit> onValidateTriggerEvent;

        void OnValidate()
        {
            onValidateTriggerEvent?.TrySetResult(AsyncUnit.Default);
        }

        public IAsyncOnValidateHandler GetOnValidateAsyncHandler()
        {
            return new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onValidateTriggerEvent), false);
        }

        public IAsyncOnValidateHandler GetOnValidateAsyncHandler(CancellationToken cancellationToken)
        {
            return new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onValidateTriggerEvent), cancellationToken, false);
        }

        public UniTask OnValidateAsync()
        {
            return ((IAsyncOnValidateHandler)new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onValidateTriggerEvent), true)).OnValidateAsync();
        }

        public UniTask OnValidateAsync(CancellationToken cancellationToken)
        {
            return ((IAsyncOnValidateHandler)new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onValidateTriggerEvent), cancellationToken, true)).OnValidateAsync();
        }
    }
#endregion

#region WillRenderObject

    public interface IAsyncOnWillRenderObjectHandler
    {
        UniTask OnWillRenderObjectAsync();
    }

    public partial class AsyncTriggerHandler<T> : IAsyncOnWillRenderObjectHandler
    {
        UniTask IAsyncOnWillRenderObjectHandler.OnWillRenderObjectAsync()
        {
            core.Reset();
            return new UniTask((IUniTaskSource)(object)this, core.Version);
        }
    }

    public static partial class AsyncTriggerExtensions
    {
        public static AsyncWillRenderObjectTrigger GetAsyncWillRenderObjectTrigger(this GameObject gameObject)
        {
            return GetOrAddComponent<AsyncWillRenderObjectTrigger>(gameObject);
        }
        
        public static AsyncWillRenderObjectTrigger GetAsyncWillRenderObjectTrigger(this Component component)
        {
            return component.gameObject.GetAsyncWillRenderObjectTrigger();
        }
    }

    [DisallowMultipleComponent]
    public sealed class AsyncWillRenderObjectTrigger : AsyncTriggerBase
    {
        TriggerEvent<AsyncUnit> onWillRenderObjectTriggerEvent;

        void OnWillRenderObject()
        {
            onWillRenderObjectTriggerEvent?.TrySetResult(AsyncUnit.Default);
        }

        public IAsyncOnWillRenderObjectHandler GetOnWillRenderObjectAsyncHandler()
        {
            return new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onWillRenderObjectTriggerEvent), false);
        }

        public IAsyncOnWillRenderObjectHandler GetOnWillRenderObjectAsyncHandler(CancellationToken cancellationToken)
        {
            return new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onWillRenderObjectTriggerEvent), cancellationToken, false);
        }

        public UniTask OnWillRenderObjectAsync()
        {
            return ((IAsyncOnWillRenderObjectHandler)new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onWillRenderObjectTriggerEvent), true)).OnWillRenderObjectAsync();
        }

        public UniTask OnWillRenderObjectAsync(CancellationToken cancellationToken)
        {
            return ((IAsyncOnWillRenderObjectHandler)new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref onWillRenderObjectTriggerEvent), cancellationToken, true)).OnWillRenderObjectAsync();
        }
    }
#endregion

#region Reset

    public interface IAsyncResetHandler
    {
        UniTask ResetAsync();
    }

    public partial class AsyncTriggerHandler<T> : IAsyncResetHandler
    {
        UniTask IAsyncResetHandler.ResetAsync()
        {
            core.Reset();
            return new UniTask((IUniTaskSource)(object)this, core.Version);
        }
    }

    public static partial class AsyncTriggerExtensions
    {
        public static AsyncResetTrigger GetAsyncResetTrigger(this GameObject gameObject)
        {
            return GetOrAddComponent<AsyncResetTrigger>(gameObject);
        }
        
        public static AsyncResetTrigger GetAsyncResetTrigger(this Component component)
        {
            return component.gameObject.GetAsyncResetTrigger();
        }
    }

    [DisallowMultipleComponent]
    public sealed class AsyncResetTrigger : AsyncTriggerBase
    {
        TriggerEvent<AsyncUnit> resetTriggerEvent;

        void Reset()
        {
            resetTriggerEvent?.TrySetResult(AsyncUnit.Default);
        }

        public IAsyncResetHandler GetResetAsyncHandler()
        {
            return new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref resetTriggerEvent), false);
        }

        public IAsyncResetHandler GetResetAsyncHandler(CancellationToken cancellationToken)
        {
            return new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref resetTriggerEvent), cancellationToken, false);
        }

        public UniTask ResetAsync()
        {
            return ((IAsyncResetHandler)new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref resetTriggerEvent), true)).ResetAsync();
        }

        public UniTask ResetAsync(CancellationToken cancellationToken)
        {
            return ((IAsyncResetHandler)new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref resetTriggerEvent), cancellationToken, true)).ResetAsync();
        }
    }
#endregion

#region Update

    public interface IAsyncUpdateHandler
    {
        UniTask UpdateAsync();
    }

    public partial class AsyncTriggerHandler<T> : IAsyncUpdateHandler
    {
        UniTask IAsyncUpdateHandler.UpdateAsync()
        {
            core.Reset();
            return new UniTask((IUniTaskSource)(object)this, core.Version);
        }
    }

    public static partial class AsyncTriggerExtensions
    {
        public static AsyncUpdateTrigger GetAsyncUpdateTrigger(this GameObject gameObject)
        {
            return GetOrAddComponent<AsyncUpdateTrigger>(gameObject);
        }
        
        public static AsyncUpdateTrigger GetAsyncUpdateTrigger(this Component component)
        {
            return component.gameObject.GetAsyncUpdateTrigger();
        }
    }

    [DisallowMultipleComponent]
    public sealed class AsyncUpdateTrigger : AsyncTriggerBase
    {
        TriggerEvent<AsyncUnit> updateTriggerEvent;

        void Update()
        {
            updateTriggerEvent?.TrySetResult(AsyncUnit.Default);
        }

        public IAsyncUpdateHandler GetUpdateAsyncHandler()
        {
            return new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref updateTriggerEvent), false);
        }

        public IAsyncUpdateHandler GetUpdateAsyncHandler(CancellationToken cancellationToken)
        {
            return new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref updateTriggerEvent), cancellationToken, false);
        }

        public UniTask UpdateAsync()
        {
            return ((IAsyncUpdateHandler)new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref updateTriggerEvent), true)).UpdateAsync();
        }

        public UniTask UpdateAsync(CancellationToken cancellationToken)
        {
            return ((IAsyncUpdateHandler)new AsyncTriggerHandler<AsyncUnit>(SetTriggerEvent(ref updateTriggerEvent), cancellationToken, true)).UpdateAsync();
        }
    }
#endregion

#region BeginDrag

    public interface IAsyncOnBeginDragHandler
    {
        UniTask<PointerEventData> OnBeginDragAsync();
    }

    public partial class AsyncTriggerHandler<T> : IAsyncOnBeginDragHandler
    {
        UniTask<PointerEventData> IAsyncOnBeginDragHandler.OnBeginDragAsync()
        {
            core.Reset();
            return new UniTask<PointerEventData>((IUniTaskSource<PointerEventData>)(object)this, core.Version);
        }
    }

    public static partial class AsyncTriggerExtensions
    {
        public static AsyncBeginDragTrigger GetAsyncBeginDragTrigger(this GameObject gameObject)
        {
            return GetOrAddComponent<AsyncBeginDragTrigger>(gameObject);
        }
        
        public static AsyncBeginDragTrigger GetAsyncBeginDragTrigger(this Component component)
        {
            return component.gameObject.GetAsyncBeginDragTrigger();
        }
    }

    [DisallowMultipleComponent]
    public sealed class AsyncBeginDragTrigger : AsyncTriggerBase, IBeginDragHandler
    {
        TriggerEvent<PointerEventData> onBeginDragTriggerEvent;

        void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
        {
            onBeginDragTriggerEvent?.TrySetResult((eventData));
        }

        public IAsyncOnBeginDragHandler GetOnBeginDragAsyncHandler()
        {
            return new AsyncTriggerHandler<PointerEventData>(SetTriggerEvent(ref onBeginDragTriggerEvent), false);
        }

        public IAsyncOnBeginDragHandler GetOnBeginDragAsyncHandler(CancellationToken cancellationToken)
        {
            return new AsyncTriggerHandler<PointerEventData>(SetTriggerEvent(ref onBeginDragTriggerEvent), cancellationToken, false);
        }

        public UniTask<PointerEventData> OnBeginDragAsync()
        {
            return ((IAsyncOnBeginDragHandler)new AsyncTriggerHandler<PointerEventData>(SetTriggerEvent(ref onBeginDragTriggerEvent), true)).OnBeginDragAsync();
        }

        public UniTask<PointerEventData> OnBeginDragAsync(CancellationToken cancellationToken)
        {
            return ((IAsyncOnBeginDragHandler)new AsyncTriggerHandler<PointerEventData>(SetTriggerEvent(ref onBeginDragTriggerEvent), cancellationToken, true)).OnBeginDragAsync();
        }
    }
#endregion

#region Cancel

    public interface IAsyncOnCancelHandler
    {
        UniTask<BaseEventData> OnCancelAsync();
    }

    public partial class AsyncTriggerHandler<T> : IAsyncOnCancelHandler
    {
        UniTask<BaseEventData> IAsyncOnCancelHandler.OnCancelAsync()
        {
            core.Reset();
            return new UniTask<BaseEventData>((IUniTaskSource<BaseEventData>)(object)this, core.Version);
        }
    }

    public static partial class AsyncTriggerExtensions
    {
        public static AsyncCancelTrigger GetAsyncCancelTrigger(this GameObject gameObject)
        {
            return GetOrAddComponent<AsyncCancelTrigger>(gameObject);
        }
        
        public static AsyncCancelTrigger GetAsyncCancelTrigger(this Component component)
        {
            return component.gameObject.GetAsyncCancelTrigger();
        }
    }

    [DisallowMultipleComponent]
    public sealed class AsyncCancelTrigger : AsyncTriggerBase, ICancelHandler
    {
        TriggerEvent<BaseEventData> onCancelTriggerEvent;

        void ICancelHandler.OnCancel(BaseEventData eventData)
        {
            onCancelTriggerEvent?.TrySetResult((eventData));
        }

        public IAsyncOnCancelHandler GetOnCancelAsyncHandler()
        {
            return new AsyncTriggerHandler<BaseEventData>(SetTriggerEvent(ref onCancelTriggerEvent), false);
        }

        public IAsyncOnCancelHandler GetOnCancelAsyncHandler(CancellationToken cancellationToken)
        {
            return new AsyncTriggerHandler<BaseEventData>(SetTriggerEvent(ref onCancelTriggerEvent), cancellationToken, false);
        }

        public UniTask<BaseEventData> OnCancelAsync()
        {
            return ((IAsyncOnCancelHandler)new AsyncTriggerHandler<BaseEventData>(SetTriggerEvent(ref onCancelTriggerEvent), true)).OnCancelAsync();
        }

        public UniTask<BaseEventData> OnCancelAsync(CancellationToken cancellationToken)
        {
            return ((IAsyncOnCancelHandler)new AsyncTriggerHandler<BaseEventData>(SetTriggerEvent(ref onCancelTriggerEvent), cancellationToken, true)).OnCancelAsync();
        }
    }
#endregion

#region Deselect

    public interface IAsyncOnDeselectHandler
    {
        UniTask<BaseEventData> OnDeselectAsync();
    }

    public partial class AsyncTriggerHandler<T> : IAsyncOnDeselectHandler
    {
        UniTask<BaseEventData> IAsyncOnDeselectHandler.OnDeselectAsync()
        {
            core.Reset();
            return new UniTask<BaseEventData>((IUniTaskSource<BaseEventData>)(object)this, core.Version);
        }
    }

    public static partial class AsyncTriggerExtensions
    {
        public static AsyncDeselectTrigger GetAsyncDeselectTrigger(this GameObject gameObject)
        {
            return GetOrAddComponent<AsyncDeselectTrigger>(gameObject);
        }
        
        public static AsyncDeselectTrigger GetAsyncDeselectTrigger(this Component component)
        {
            return component.gameObject.GetAsyncDeselectTrigger();
        }
    }

    [DisallowMultipleComponent]
    public sealed class AsyncDeselectTrigger : AsyncTriggerBase, IDeselectHandler
    {
        TriggerEvent<BaseEventData> onDeselectTriggerEvent;

        void IDeselectHandler.OnDeselect(BaseEventData eventData)
        {
            onDeselectTriggerEvent?.TrySetResult((eventData));
        }

        public IAsyncOnDeselectHandler GetOnDeselectAsyncHandler()
        {
            return new AsyncTriggerHandler<BaseEventData>(SetTriggerEvent(ref onDeselectTriggerEvent), false);
        }

        public IAsyncOnDeselectHandler GetOnDeselectAsyncHandler(CancellationToken cancellationToken)
        {
            return new AsyncTriggerHandler<BaseEventData>(SetTriggerEvent(ref onDeselectTriggerEvent), cancellationToken, false);
        }

        public UniTask<BaseEventData> OnDeselectAsync()
        {
            return ((IAsyncOnDeselectHandler)new AsyncTriggerHandler<BaseEventData>(SetTriggerEvent(ref onDeselectTriggerEvent), true)).OnDeselectAsync();
        }

        public UniTask<BaseEventData> OnDeselectAsync(CancellationToken cancellationToken)
        {
            return ((IAsyncOnDeselectHandler)new AsyncTriggerHandler<BaseEventData>(SetTriggerEvent(ref onDeselectTriggerEvent), cancellationToken, true)).OnDeselectAsync();
        }
    }
#endregion

#region Drag

    public interface IAsyncOnDragHandler
    {
        UniTask<PointerEventData> OnDragAsync();
    }

    public partial class AsyncTriggerHandler<T> : IAsyncOnDragHandler
    {
        UniTask<PointerEventData> IAsyncOnDragHandler.OnDragAsync()
        {
            core.Reset();
            return new UniTask<PointerEventData>((IUniTaskSource<PointerEventData>)(object)this, core.Version);
        }
    }

    public static partial class AsyncTriggerExtensions
    {
        public static AsyncDragTrigger GetAsyncDragTrigger(this GameObject gameObject)
        {
            return GetOrAddComponent<AsyncDragTrigger>(gameObject);
        }
        
        public static AsyncDragTrigger GetAsyncDragTrigger(this Component component)
        {
            return component.gameObject.GetAsyncDragTrigger();
        }
    }

    [DisallowMultipleComponent]
    public sealed class AsyncDragTrigger : AsyncTriggerBase, IDragHandler
    {
        TriggerEvent<PointerEventData> onDragTriggerEvent;

        void IDragHandler.OnDrag(PointerEventData eventData)
        {
            onDragTriggerEvent?.TrySetResult((eventData));
        }

        public IAsyncOnDragHandler GetOnDragAsyncHandler()
        {
            return new AsyncTriggerHandler<PointerEventData>(SetTriggerEvent(ref onDragTriggerEvent), false);
        }

        public IAsyncOnDragHandler GetOnDragAsyncHandler(CancellationToken cancellationToken)
        {
            return new AsyncTriggerHandler<PointerEventData>(SetTriggerEvent(ref onDragTriggerEvent), cancellationToken, false);
        }

        public UniTask<PointerEventData> OnDragAsync()
        {
            return ((IAsyncOnDragHandler)new AsyncTriggerHandler<PointerEventData>(SetTriggerEvent(ref onDragTriggerEvent), true)).OnDragAsync();
        }

        public UniTask<PointerEventData> OnDragAsync(CancellationToken cancellationToken)
        {
            return ((IAsyncOnDragHandler)new AsyncTriggerHandler<PointerEventData>(SetTriggerEvent(ref onDragTriggerEvent), cancellationToken, true)).OnDragAsync();
        }
    }
#endregion

#region Drop

    public interface IAsyncOnDropHandler
    {
        UniTask<PointerEventData> OnDropAsync();
    }

    public partial class AsyncTriggerHandler<T> : IAsyncOnDropHandler
    {
        UniTask<PointerEventData> IAsyncOnDropHandler.OnDropAsync()
        {
            core.Reset();
            return new UniTask<PointerEventData>((IUniTaskSource<PointerEventData>)(object)this, core.Version);
        }
    }

    public static partial class AsyncTriggerExtensions
    {
        public static AsyncDropTrigger GetAsyncDropTrigger(this GameObject gameObject)
        {
            return GetOrAddComponent<AsyncDropTrigger>(gameObject);
        }
        
        public static AsyncDropTrigger GetAsyncDropTrigger(this Component component)
        {
            return component.gameObject.GetAsyncDropTrigger();
        }
    }

    [DisallowMultipleComponent]
    public sealed class AsyncDropTrigger : AsyncTriggerBase, IDropHandler
    {
        TriggerEvent<PointerEventData> onDropTriggerEvent;

        void IDropHandler.OnDrop(PointerEventData eventData)
        {
            onDropTriggerEvent?.TrySetResult((eventData));
        }

        public IAsyncOnDropHandler GetOnDropAsyncHandler()
        {
            return new AsyncTriggerHandler<PointerEventData>(SetTriggerEvent(ref onDropTriggerEvent), false);
        }

        public IAsyncOnDropHandler GetOnDropAsyncHandler(CancellationToken cancellationToken)
        {
            return new AsyncTriggerHandler<PointerEventData>(SetTriggerEvent(ref onDropTriggerEvent), cancellationToken, false);
        }

        public UniTask<PointerEventData> OnDropAsync()
        {
            return ((IAsyncOnDropHandler)new AsyncTriggerHandler<PointerEventData>(SetTriggerEvent(ref onDropTriggerEvent), true)).OnDropAsync();
        }

        public UniTask<PointerEventData> OnDropAsync(CancellationToken cancellationToken)
        {
            return ((IAsyncOnDropHandler)new AsyncTriggerHandler<PointerEventData>(SetTriggerEvent(ref onDropTriggerEvent), cancellationToken, true)).OnDropAsync();
        }
    }
#endregion

#region EndDrag

    public interface IAsyncOnEndDragHandler
    {
        UniTask<PointerEventData> OnEndDragAsync();
    }

    public partial class AsyncTriggerHandler<T> : IAsyncOnEndDragHandler
    {
        UniTask<PointerEventData> IAsyncOnEndDragHandler.OnEndDragAsync()
        {
            core.Reset();
            return new UniTask<PointerEventData>((IUniTaskSource<PointerEventData>)(object)this, core.Version);
        }
    }

    public static partial class AsyncTriggerExtensions
    {
        public static AsyncEndDragTrigger GetAsyncEndDragTrigger(this GameObject gameObject)
        {
            return GetOrAddComponent<AsyncEndDragTrigger>(gameObject);
        }
        
        public static AsyncEndDragTrigger GetAsyncEndDragTrigger(this Component component)
        {
            return component.gameObject.GetAsyncEndDragTrigger();
        }
    }

    [DisallowMultipleComponent]
    public sealed class AsyncEndDragTrigger : AsyncTriggerBase, IEndDragHandler
    {
        TriggerEvent<PointerEventData> onEndDragTriggerEvent;

        void IEndDragHandler.OnEndDrag(PointerEventData eventData)
        {
            onEndDragTriggerEvent?.TrySetResult((eventData));
        }

        public IAsyncOnEndDragHandler GetOnEndDragAsyncHandler()
        {
            return new AsyncTriggerHandler<PointerEventData>(SetTriggerEvent(ref onEndDragTriggerEvent), false);
        }

        public IAsyncOnEndDragHandler GetOnEndDragAsyncHandler(CancellationToken cancellationToken)
        {
            return new AsyncTriggerHandler<PointerEventData>(SetTriggerEvent(ref onEndDragTriggerEvent), cancellationToken, false);
        }

        public UniTask<PointerEventData> OnEndDragAsync()
        {
            return ((IAsyncOnEndDragHandler)new AsyncTriggerHandler<PointerEventData>(SetTriggerEvent(ref onEndDragTriggerEvent), true)).OnEndDragAsync();
        }

        public UniTask<PointerEventData> OnEndDragAsync(CancellationToken cancellationToken)
        {
            return ((IAsyncOnEndDragHandler)new AsyncTriggerHandler<PointerEventData>(SetTriggerEvent(ref onEndDragTriggerEvent), cancellationToken, true)).OnEndDragAsync();
        }
    }
#endregion

#region InitializePotentialDrag

    public interface IAsyncOnInitializePotentialDragHandler
    {
        UniTask<PointerEventData> OnInitializePotentialDragAsync();
    }

    public partial class AsyncTriggerHandler<T> : IAsyncOnInitializePotentialDragHandler
    {
        UniTask<PointerEventData> IAsyncOnInitializePotentialDragHandler.OnInitializePotentialDragAsync()
        {
            core.Reset();
            return new UniTask<PointerEventData>((IUniTaskSource<PointerEventData>)(object)this, core.Version);
        }
    }

    public static partial class AsyncTriggerExtensions
    {
        public static AsyncInitializePotentialDragTrigger GetAsyncInitializePotentialDragTrigger(this GameObject gameObject)
        {
            return GetOrAddComponent<AsyncInitializePotentialDragTrigger>(gameObject);
        }
        
        public static AsyncInitializePotentialDragTrigger GetAsyncInitializePotentialDragTrigger(this Component component)
        {
            return component.gameObject.GetAsyncInitializePotentialDragTrigger();
        }
    }

    [DisallowMultipleComponent]
    public sealed class AsyncInitializePotentialDragTrigger : AsyncTriggerBase, IInitializePotentialDragHandler
    {
        TriggerEvent<PointerEventData> onInitializePotentialDragTriggerEvent;

        void IInitializePotentialDragHandler.OnInitializePotentialDrag(PointerEventData eventData)
        {
            onInitializePotentialDragTriggerEvent?.TrySetResult((eventData));
        }

        public IAsyncOnInitializePotentialDragHandler GetOnInitializePotentialDragAsyncHandler()
        {
            return new AsyncTriggerHandler<PointerEventData>(SetTriggerEvent(ref onInitializePotentialDragTriggerEvent), false);
        }

        public IAsyncOnInitializePotentialDragHandler GetOnInitializePotentialDragAsyncHandler(CancellationToken cancellationToken)
        {
            return new AsyncTriggerHandler<PointerEventData>(SetTriggerEvent(ref onInitializePotentialDragTriggerEvent), cancellationToken, false);
        }

        public UniTask<PointerEventData> OnInitializePotentialDragAsync()
        {
            return ((IAsyncOnInitializePotentialDragHandler)new AsyncTriggerHandler<PointerEventData>(SetTriggerEvent(ref onInitializePotentialDragTriggerEvent), true)).OnInitializePotentialDragAsync();
        }

        public UniTask<PointerEventData> OnInitializePotentialDragAsync(CancellationToken cancellationToken)
        {
            return ((IAsyncOnInitializePotentialDragHandler)new AsyncTriggerHandler<PointerEventData>(SetTriggerEvent(ref onInitializePotentialDragTriggerEvent), cancellationToken, true)).OnInitializePotentialDragAsync();
        }
    }
#endregion

#region Move

    public interface IAsyncOnMoveHandler
    {
        UniTask<AxisEventData> OnMoveAsync();
    }

    public partial class AsyncTriggerHandler<T> : IAsyncOnMoveHandler
    {
        UniTask<AxisEventData> IAsyncOnMoveHandler.OnMoveAsync()
        {
            core.Reset();
            return new UniTask<AxisEventData>((IUniTaskSource<AxisEventData>)(object)this, core.Version);
        }
    }

    public static partial class AsyncTriggerExtensions
    {
        public static AsyncMoveTrigger GetAsyncMoveTrigger(this GameObject gameObject)
        {
            return GetOrAddComponent<AsyncMoveTrigger>(gameObject);
        }
        
        public static AsyncMoveTrigger GetAsyncMoveTrigger(this Component component)
        {
            return component.gameObject.GetAsyncMoveTrigger();
        }
    }

    [DisallowMultipleComponent]
    public sealed class AsyncMoveTrigger : AsyncTriggerBase, IMoveHandler
    {
        TriggerEvent<AxisEventData> onMoveTriggerEvent;

        void IMoveHandler.OnMove(AxisEventData eventData)
        {
            onMoveTriggerEvent?.TrySetResult((eventData));
        }

        public IAsyncOnMoveHandler GetOnMoveAsyncHandler()
        {
            return new AsyncTriggerHandler<AxisEventData>(SetTriggerEvent(ref onMoveTriggerEvent), false);
        }

        public IAsyncOnMoveHandler GetOnMoveAsyncHandler(CancellationToken cancellationToken)
        {
            return new AsyncTriggerHandler<AxisEventData>(SetTriggerEvent(ref onMoveTriggerEvent), cancellationToken, false);
        }

        public UniTask<AxisEventData> OnMoveAsync()
        {
            return ((IAsyncOnMoveHandler)new AsyncTriggerHandler<AxisEventData>(SetTriggerEvent(ref onMoveTriggerEvent), true)).OnMoveAsync();
        }

        public UniTask<AxisEventData> OnMoveAsync(CancellationToken cancellationToken)
        {
            return ((IAsyncOnMoveHandler)new AsyncTriggerHandler<AxisEventData>(SetTriggerEvent(ref onMoveTriggerEvent), cancellationToken, true)).OnMoveAsync();
        }
    }
#endregion

#region PointerClick

    public interface IAsyncOnPointerClickHandler
    {
        UniTask<PointerEventData> OnPointerClickAsync();
    }

    public partial class AsyncTriggerHandler<T> : IAsyncOnPointerClickHandler
    {
        UniTask<PointerEventData> IAsyncOnPointerClickHandler.OnPointerClickAsync()
        {
            core.Reset();
            return new UniTask<PointerEventData>((IUniTaskSource<PointerEventData>)(object)this, core.Version);
        }
    }

    public static partial class AsyncTriggerExtensions
    {
        public static AsyncPointerClickTrigger GetAsyncPointerClickTrigger(this GameObject gameObject)
        {
            return GetOrAddComponent<AsyncPointerClickTrigger>(gameObject);
        }
        
        public static AsyncPointerClickTrigger GetAsyncPointerClickTrigger(this Component component)
        {
            return component.gameObject.GetAsyncPointerClickTrigger();
        }
    }

    [DisallowMultipleComponent]
    public sealed class AsyncPointerClickTrigger : AsyncTriggerBase, IPointerClickHandler
    {
        TriggerEvent<PointerEventData> onPointerClickTriggerEvent;

        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            onPointerClickTriggerEvent?.TrySetResult((eventData));
        }

        public IAsyncOnPointerClickHandler GetOnPointerClickAsyncHandler()
        {
            return new AsyncTriggerHandler<PointerEventData>(SetTriggerEvent(ref onPointerClickTriggerEvent), false);
        }

        public IAsyncOnPointerClickHandler GetOnPointerClickAsyncHandler(CancellationToken cancellationToken)
        {
            return new AsyncTriggerHandler<PointerEventData>(SetTriggerEvent(ref onPointerClickTriggerEvent), cancellationToken, false);
        }

        public UniTask<PointerEventData> OnPointerClickAsync()
        {
            return ((IAsyncOnPointerClickHandler)new AsyncTriggerHandler<PointerEventData>(SetTriggerEvent(ref onPointerClickTriggerEvent), true)).OnPointerClickAsync();
        }

        public UniTask<PointerEventData> OnPointerClickAsync(CancellationToken cancellationToken)
        {
            return ((IAsyncOnPointerClickHandler)new AsyncTriggerHandler<PointerEventData>(SetTriggerEvent(ref onPointerClickTriggerEvent), cancellationToken, true)).OnPointerClickAsync();
        }
    }
#endregion

#region PointerDown

    public interface IAsyncOnPointerDownHandler
    {
        UniTask<PointerEventData> OnPointerDownAsync();
    }

    public partial class AsyncTriggerHandler<T> : IAsyncOnPointerDownHandler
    {
        UniTask<PointerEventData> IAsyncOnPointerDownHandler.OnPointerDownAsync()
        {
            core.Reset();
            return new UniTask<PointerEventData>((IUniTaskSource<PointerEventData>)(object)this, core.Version);
        }
    }

    public static partial class AsyncTriggerExtensions
    {
        public static AsyncPointerDownTrigger GetAsyncPointerDownTrigger(this GameObject gameObject)
        {
            return GetOrAddComponent<AsyncPointerDownTrigger>(gameObject);
        }
        
        public static AsyncPointerDownTrigger GetAsyncPointerDownTrigger(this Component component)
        {
            return component.gameObject.GetAsyncPointerDownTrigger();
        }
    }

    [DisallowMultipleComponent]
    public sealed class AsyncPointerDownTrigger : AsyncTriggerBase, IPointerDownHandler
    {
        TriggerEvent<PointerEventData> onPointerDownTriggerEvent;

        void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
        {
            onPointerDownTriggerEvent?.TrySetResult((eventData));
        }

        public IAsyncOnPointerDownHandler GetOnPointerDownAsyncHandler()
        {
            return new AsyncTriggerHandler<PointerEventData>(SetTriggerEvent(ref onPointerDownTriggerEvent), false);
        }

        public IAsyncOnPointerDownHandler GetOnPointerDownAsyncHandler(CancellationToken cancellationToken)
        {
            return new AsyncTriggerHandler<PointerEventData>(SetTriggerEvent(ref onPointerDownTriggerEvent), cancellationToken, false);
        }

        public UniTask<PointerEventData> OnPointerDownAsync()
        {
            return ((IAsyncOnPointerDownHandler)new AsyncTriggerHandler<PointerEventData>(SetTriggerEvent(ref onPointerDownTriggerEvent), true)).OnPointerDownAsync();
        }

        public UniTask<PointerEventData> OnPointerDownAsync(CancellationToken cancellationToken)
        {
            return ((IAsyncOnPointerDownHandler)new AsyncTriggerHandler<PointerEventData>(SetTriggerEvent(ref onPointerDownTriggerEvent), cancellationToken, true)).OnPointerDownAsync();
        }
    }
#endregion

#region PointerEnter

    public interface IAsyncOnPointerEnterHandler
    {
        UniTask<PointerEventData> OnPointerEnterAsync();
    }

    public partial class AsyncTriggerHandler<T> : IAsyncOnPointerEnterHandler
    {
        UniTask<PointerEventData> IAsyncOnPointerEnterHandler.OnPointerEnterAsync()
        {
            core.Reset();
            return new UniTask<PointerEventData>((IUniTaskSource<PointerEventData>)(object)this, core.Version);
        }
    }

    public static partial class AsyncTriggerExtensions
    {
        public static AsyncPointerEnterTrigger GetAsyncPointerEnterTrigger(this GameObject gameObject)
        {
            return GetOrAddComponent<AsyncPointerEnterTrigger>(gameObject);
        }
        
        public static AsyncPointerEnterTrigger GetAsyncPointerEnterTrigger(this Component component)
        {
            return component.gameObject.GetAsyncPointerEnterTrigger();
        }
    }

    [DisallowMultipleComponent]
    public sealed class AsyncPointerEnterTrigger : AsyncTriggerBase, IPointerEnterHandler
    {
        TriggerEvent<PointerEventData> onPointerEnterTriggerEvent;

        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
        {
            onPointerEnterTriggerEvent?.TrySetResult((eventData));
        }

        public IAsyncOnPointerEnterHandler GetOnPointerEnterAsyncHandler()
        {
            return new AsyncTriggerHandler<PointerEventData>(SetTriggerEvent(ref onPointerEnterTriggerEvent), false);
        }

        public IAsyncOnPointerEnterHandler GetOnPointerEnterAsyncHandler(CancellationToken cancellationToken)
        {
            return new AsyncTriggerHandler<PointerEventData>(SetTriggerEvent(ref onPointerEnterTriggerEvent), cancellationToken, false);
        }

        public UniTask<PointerEventData> OnPointerEnterAsync()
        {
            return ((IAsyncOnPointerEnterHandler)new AsyncTriggerHandler<PointerEventData>(SetTriggerEvent(ref onPointerEnterTriggerEvent), true)).OnPointerEnterAsync();
        }

        public UniTask<PointerEventData> OnPointerEnterAsync(CancellationToken cancellationToken)
        {
            return ((IAsyncOnPointerEnterHandler)new AsyncTriggerHandler<PointerEventData>(SetTriggerEvent(ref onPointerEnterTriggerEvent), cancellationToken, true)).OnPointerEnterAsync();
        }
    }
#endregion

#region PointerExit

    public interface IAsyncOnPointerExitHandler
    {
        UniTask<PointerEventData> OnPointerExitAsync();
    }

    public partial class AsyncTriggerHandler<T> : IAsyncOnPointerExitHandler
    {
        UniTask<PointerEventData> IAsyncOnPointerExitHandler.OnPointerExitAsync()
        {
            core.Reset();
            return new UniTask<PointerEventData>((IUniTaskSource<PointerEventData>)(object)this, core.Version);
        }
    }

    public static partial class AsyncTriggerExtensions
    {
        public static AsyncPointerExitTrigger GetAsyncPointerExitTrigger(this GameObject gameObject)
        {
            return GetOrAddComponent<AsyncPointerExitTrigger>(gameObject);
        }
        
        public static AsyncPointerExitTrigger GetAsyncPointerExitTrigger(this Component component)
        {
            return component.gameObject.GetAsyncPointerExitTrigger();
        }
    }

    [DisallowMultipleComponent]
    public sealed class AsyncPointerExitTrigger : AsyncTriggerBase, IPointerExitHandler
    {
        TriggerEvent<PointerEventData> onPointerExitTriggerEvent;

        void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
        {
            onPointerExitTriggerEvent?.TrySetResult((eventData));
        }

        public IAsyncOnPointerExitHandler GetOnPointerExitAsyncHandler()
        {
            return new AsyncTriggerHandler<PointerEventData>(SetTriggerEvent(ref onPointerExitTriggerEvent), false);
        }

        public IAsyncOnPointerExitHandler GetOnPointerExitAsyncHandler(CancellationToken cancellationToken)
        {
            return new AsyncTriggerHandler<PointerEventData>(SetTriggerEvent(ref onPointerExitTriggerEvent), cancellationToken, false);
        }

        public UniTask<PointerEventData> OnPointerExitAsync()
        {
            return ((IAsyncOnPointerExitHandler)new AsyncTriggerHandler<PointerEventData>(SetTriggerEvent(ref onPointerExitTriggerEvent), true)).OnPointerExitAsync();
        }

        public UniTask<PointerEventData> OnPointerExitAsync(CancellationToken cancellationToken)
        {
            return ((IAsyncOnPointerExitHandler)new AsyncTriggerHandler<PointerEventData>(SetTriggerEvent(ref onPointerExitTriggerEvent), cancellationToken, true)).OnPointerExitAsync();
        }
    }
#endregion

#region PointerUp

    public interface IAsyncOnPointerUpHandler
    {
        UniTask<PointerEventData> OnPointerUpAsync();
    }

    public partial class AsyncTriggerHandler<T> : IAsyncOnPointerUpHandler
    {
        UniTask<PointerEventData> IAsyncOnPointerUpHandler.OnPointerUpAsync()
        {
            core.Reset();
            return new UniTask<PointerEventData>((IUniTaskSource<PointerEventData>)(object)this, core.Version);
        }
    }

    public static partial class AsyncTriggerExtensions
    {
        public static AsyncPointerUpTrigger GetAsyncPointerUpTrigger(this GameObject gameObject)
        {
            return GetOrAddComponent<AsyncPointerUpTrigger>(gameObject);
        }
        
        public static AsyncPointerUpTrigger GetAsyncPointerUpTrigger(this Component component)
        {
            return component.gameObject.GetAsyncPointerUpTrigger();
        }
    }

    [DisallowMultipleComponent]
    public sealed class AsyncPointerUpTrigger : AsyncTriggerBase, IPointerUpHandler
    {
        TriggerEvent<PointerEventData> onPointerUpTriggerEvent;

        void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
        {
            onPointerUpTriggerEvent?.TrySetResult((eventData));
        }

        public IAsyncOnPointerUpHandler GetOnPointerUpAsyncHandler()
        {
            return new AsyncTriggerHandler<PointerEventData>(SetTriggerEvent(ref onPointerUpTriggerEvent), false);
        }

        public IAsyncOnPointerUpHandler GetOnPointerUpAsyncHandler(CancellationToken cancellationToken)
        {
            return new AsyncTriggerHandler<PointerEventData>(SetTriggerEvent(ref onPointerUpTriggerEvent), cancellationToken, false);
        }

        public UniTask<PointerEventData> OnPointerUpAsync()
        {
            return ((IAsyncOnPointerUpHandler)new AsyncTriggerHandler<PointerEventData>(SetTriggerEvent(ref onPointerUpTriggerEvent), true)).OnPointerUpAsync();
        }

        public UniTask<PointerEventData> OnPointerUpAsync(CancellationToken cancellationToken)
        {
            return ((IAsyncOnPointerUpHandler)new AsyncTriggerHandler<PointerEventData>(SetTriggerEvent(ref onPointerUpTriggerEvent), cancellationToken, true)).OnPointerUpAsync();
        }
    }
#endregion

#region Scroll

    public interface IAsyncOnScrollHandler
    {
        UniTask<PointerEventData> OnScrollAsync();
    }

    public partial class AsyncTriggerHandler<T> : IAsyncOnScrollHandler
    {
        UniTask<PointerEventData> IAsyncOnScrollHandler.OnScrollAsync()
        {
            core.Reset();
            return new UniTask<PointerEventData>((IUniTaskSource<PointerEventData>)(object)this, core.Version);
        }
    }

    public static partial class AsyncTriggerExtensions
    {
        public static AsyncScrollTrigger GetAsyncScrollTrigger(this GameObject gameObject)
        {
            return GetOrAddComponent<AsyncScrollTrigger>(gameObject);
        }
        
        public static AsyncScrollTrigger GetAsyncScrollTrigger(this Component component)
        {
            return component.gameObject.GetAsyncScrollTrigger();
        }
    }

    [DisallowMultipleComponent]
    public sealed class AsyncScrollTrigger : AsyncTriggerBase, IScrollHandler
    {
        TriggerEvent<PointerEventData> onScrollTriggerEvent;

        void IScrollHandler.OnScroll(PointerEventData eventData)
        {
            onScrollTriggerEvent?.TrySetResult((eventData));
        }

        public IAsyncOnScrollHandler GetOnScrollAsyncHandler()
        {
            return new AsyncTriggerHandler<PointerEventData>(SetTriggerEvent(ref onScrollTriggerEvent), false);
        }

        public IAsyncOnScrollHandler GetOnScrollAsyncHandler(CancellationToken cancellationToken)
        {
            return new AsyncTriggerHandler<PointerEventData>(SetTriggerEvent(ref onScrollTriggerEvent), cancellationToken, false);
        }

        public UniTask<PointerEventData> OnScrollAsync()
        {
            return ((IAsyncOnScrollHandler)new AsyncTriggerHandler<PointerEventData>(SetTriggerEvent(ref onScrollTriggerEvent), true)).OnScrollAsync();
        }

        public UniTask<PointerEventData> OnScrollAsync(CancellationToken cancellationToken)
        {
            return ((IAsyncOnScrollHandler)new AsyncTriggerHandler<PointerEventData>(SetTriggerEvent(ref onScrollTriggerEvent), cancellationToken, true)).OnScrollAsync();
        }
    }
#endregion

#region Select

    public interface IAsyncOnSelectHandler
    {
        UniTask<BaseEventData> OnSelectAsync();
    }

    public partial class AsyncTriggerHandler<T> : IAsyncOnSelectHandler
    {
        UniTask<BaseEventData> IAsyncOnSelectHandler.OnSelectAsync()
        {
            core.Reset();
            return new UniTask<BaseEventData>((IUniTaskSource<BaseEventData>)(object)this, core.Version);
        }
    }

    public static partial class AsyncTriggerExtensions
    {
        public static AsyncSelectTrigger GetAsyncSelectTrigger(this GameObject gameObject)
        {
            return GetOrAddComponent<AsyncSelectTrigger>(gameObject);
        }
        
        public static AsyncSelectTrigger GetAsyncSelectTrigger(this Component component)
        {
            return component.gameObject.GetAsyncSelectTrigger();
        }
    }

    [DisallowMultipleComponent]
    public sealed class AsyncSelectTrigger : AsyncTriggerBase, ISelectHandler
    {
        TriggerEvent<BaseEventData> onSelectTriggerEvent;

        void ISelectHandler.OnSelect(BaseEventData eventData)
        {
            onSelectTriggerEvent?.TrySetResult((eventData));
        }

        public IAsyncOnSelectHandler GetOnSelectAsyncHandler()
        {
            return new AsyncTriggerHandler<BaseEventData>(SetTriggerEvent(ref onSelectTriggerEvent), false);
        }

        public IAsyncOnSelectHandler GetOnSelectAsyncHandler(CancellationToken cancellationToken)
        {
            return new AsyncTriggerHandler<BaseEventData>(SetTriggerEvent(ref onSelectTriggerEvent), cancellationToken, false);
        }

        public UniTask<BaseEventData> OnSelectAsync()
        {
            return ((IAsyncOnSelectHandler)new AsyncTriggerHandler<BaseEventData>(SetTriggerEvent(ref onSelectTriggerEvent), true)).OnSelectAsync();
        }

        public UniTask<BaseEventData> OnSelectAsync(CancellationToken cancellationToken)
        {
            return ((IAsyncOnSelectHandler)new AsyncTriggerHandler<BaseEventData>(SetTriggerEvent(ref onSelectTriggerEvent), cancellationToken, true)).OnSelectAsync();
        }
    }
#endregion

#region Submit

    public interface IAsyncOnSubmitHandler
    {
        UniTask<BaseEventData> OnSubmitAsync();
    }

    public partial class AsyncTriggerHandler<T> : IAsyncOnSubmitHandler
    {
        UniTask<BaseEventData> IAsyncOnSubmitHandler.OnSubmitAsync()
        {
            core.Reset();
            return new UniTask<BaseEventData>((IUniTaskSource<BaseEventData>)(object)this, core.Version);
        }
    }

    public static partial class AsyncTriggerExtensions
    {
        public static AsyncSubmitTrigger GetAsyncSubmitTrigger(this GameObject gameObject)
        {
            return GetOrAddComponent<AsyncSubmitTrigger>(gameObject);
        }
        
        public static AsyncSubmitTrigger GetAsyncSubmitTrigger(this Component component)
        {
            return component.gameObject.GetAsyncSubmitTrigger();
        }
    }

    [DisallowMultipleComponent]
    public sealed class AsyncSubmitTrigger : AsyncTriggerBase, ISubmitHandler
    {
        TriggerEvent<BaseEventData> onSubmitTriggerEvent;

        void ISubmitHandler.OnSubmit(BaseEventData eventData)
        {
            onSubmitTriggerEvent?.TrySetResult((eventData));
        }

        public IAsyncOnSubmitHandler GetOnSubmitAsyncHandler()
        {
            return new AsyncTriggerHandler<BaseEventData>(SetTriggerEvent(ref onSubmitTriggerEvent), false);
        }

        public IAsyncOnSubmitHandler GetOnSubmitAsyncHandler(CancellationToken cancellationToken)
        {
            return new AsyncTriggerHandler<BaseEventData>(SetTriggerEvent(ref onSubmitTriggerEvent), cancellationToken, false);
        }

        public UniTask<BaseEventData> OnSubmitAsync()
        {
            return ((IAsyncOnSubmitHandler)new AsyncTriggerHandler<BaseEventData>(SetTriggerEvent(ref onSubmitTriggerEvent), true)).OnSubmitAsync();
        }

        public UniTask<BaseEventData> OnSubmitAsync(CancellationToken cancellationToken)
        {
            return ((IAsyncOnSubmitHandler)new AsyncTriggerHandler<BaseEventData>(SetTriggerEvent(ref onSubmitTriggerEvent), cancellationToken, true)).OnSubmitAsync();
        }
    }
#endregion

#region UpdateSelected

    public interface IAsyncOnUpdateSelectedHandler
    {
        UniTask<BaseEventData> OnUpdateSelectedAsync();
    }

    public partial class AsyncTriggerHandler<T> : IAsyncOnUpdateSelectedHandler
    {
        UniTask<BaseEventData> IAsyncOnUpdateSelectedHandler.OnUpdateSelectedAsync()
        {
            core.Reset();
            return new UniTask<BaseEventData>((IUniTaskSource<BaseEventData>)(object)this, core.Version);
        }
    }

    public static partial class AsyncTriggerExtensions
    {
        public static AsyncUpdateSelectedTrigger GetAsyncUpdateSelectedTrigger(this GameObject gameObject)
        {
            return GetOrAddComponent<AsyncUpdateSelectedTrigger>(gameObject);
        }
        
        public static AsyncUpdateSelectedTrigger GetAsyncUpdateSelectedTrigger(this Component component)
        {
            return component.gameObject.GetAsyncUpdateSelectedTrigger();
        }
    }

    [DisallowMultipleComponent]
    public sealed class AsyncUpdateSelectedTrigger : AsyncTriggerBase, IUpdateSelectedHandler
    {
        TriggerEvent<BaseEventData> onUpdateSelectedTriggerEvent;

        void IUpdateSelectedHandler.OnUpdateSelected(BaseEventData eventData)
        {
            onUpdateSelectedTriggerEvent?.TrySetResult((eventData));
        }

        public IAsyncOnUpdateSelectedHandler GetOnUpdateSelectedAsyncHandler()
        {
            return new AsyncTriggerHandler<BaseEventData>(SetTriggerEvent(ref onUpdateSelectedTriggerEvent), false);
        }

        public IAsyncOnUpdateSelectedHandler GetOnUpdateSelectedAsyncHandler(CancellationToken cancellationToken)
        {
            return new AsyncTriggerHandler<BaseEventData>(SetTriggerEvent(ref onUpdateSelectedTriggerEvent), cancellationToken, false);
        }

        public UniTask<BaseEventData> OnUpdateSelectedAsync()
        {
            return ((IAsyncOnUpdateSelectedHandler)new AsyncTriggerHandler<BaseEventData>(SetTriggerEvent(ref onUpdateSelectedTriggerEvent), true)).OnUpdateSelectedAsync();
        }

        public UniTask<BaseEventData> OnUpdateSelectedAsync(CancellationToken cancellationToken)
        {
            return ((IAsyncOnUpdateSelectedHandler)new AsyncTriggerHandler<BaseEventData>(SetTriggerEvent(ref onUpdateSelectedTriggerEvent), cancellationToken, true)).OnUpdateSelectedAsync();
        }
    }
#endregion

}