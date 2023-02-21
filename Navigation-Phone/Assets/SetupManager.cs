using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class SetupManager : MonoBehaviour
{
    public StudyManager StudyMgr;
    public TargetManager TargetMgr;
    public TMPro.TMP_Text Id;
    public GameObject SetupScreen;
    public GameObject IntroScreen;
    public GameObject PauseScreen;
    public GameObject PauseButton;
    public GameObject ConditionStartupScreen;
    public GameObject RepeatPanel;
    public TMPro.TMP_Text CurrentConditionInfoText;
    public bool Demo;
    public LoggingSystem Logger;


    private int _delayButtonTimer = 15;
    private int[,] _sets;

    // Start is called before the first frame update
    void Start()
    {
       _sets = new int[24,4] { {1,2,3,4},
                                {1,2,4,3},
                                {1,3,2,4},
                                {1,3,4,2},
                                {1,4,2,3},
                                {1,4,3,2},

                                {2,1,3,4},
                                {2,1,4,3},
                                {2,3,1,4},
                                {2,3,4,1},
                                {2,4,1,3},
                                {2,4,3,1},

                                {3,1,2,4},
                                {3,1,4,2},
                                {3,2,1,4},
                                {3,2,4,1},
                                {3,4,2,1},
                                {3,4,1,2},

                                {4,1,2,3},
                                {4,1,3,2},
                                {4,2,1,3},
                                {4,2,3,1},
                                {4,3,1,2},
                                {4,3,2,1},

                                };

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*
     * called when pressing start button on setup screen. saves the participant id, calculates the order of conditions
     */
    public void saveParticipantID(){
        int _particID;
        
        //remove trailing whitespace
        int.TryParse(Id.text.Substring(0, Id.text.Length - 1), out _particID);
        StudyMgr.participantID = _particID;

        StudyMgr.startingCondition = _sets[StudyMgr.participantID%24,StudyMgr.SetIndex];

        //close setup, start intro
        SetupScreen.SetActive(false);
        IntroScreen.SetActive(true);
        
        //logging of participant id and condition started
        Logger.writeMessageWithTimestampToLog("ID: "+_particID.ToString());
        Logger.writeMessageWithTimestampToLog("Starting: "+StudyMgr.startingCondition.ToString());
        Logger.startMapLog();
        Logger.writeMapToLog("Map: " + StudyMgr.studySet);
        
    }
    public void quickstartScenario(int condition){
        int _particID;
        
        //remove trailing whitespace
        int.TryParse(Id.text.Substring(0, Id.text.Length - 1), out _particID);
        StudyMgr.participantID = _particID;

        StudyMgr.startingCondition = _sets[StudyMgr.participantID%24,StudyMgr.SetIndex];
        
        Logger.writeMessageWithTimestampToLog("ID: "+_particID.ToString());
        Logger.writeMessageWithTimestampToLog("Starting: "+StudyMgr.startingCondition.ToString());
        Logger.startMapLog();
        Logger.writeMapToLog("Map: " + StudyMgr.studySet);

        SetupScreen.SetActive(false);
        
        //search for condition instead
        /*for (int i = 0 ; i <4; i++){
            if(_sets[_particID%24,i] == condition)
                StudyMgr.SetIndex = i;
        }*/
        StudyMgr.SetIndex = condition;
        showConditionStartupScreen();
        TargetMgr.quickstartSetRotations();
        _delayButtonTimer = 30;
    }

    //closes the intro screen and enables the extended screen on the varjo
    public void closeIntroScreen(){
        IntroScreen.SetActive(false);
        if( StudyMgr.startingCondition == 1)
            StudyMgr.showScreen = false;
        else
            StudyMgr.showScreen = true;
    }

    //opens the pause screen with a delayed continue button
    public void openPauseScreen(){
        StudyMgr.showScreen = false;
        PauseScreen.SetActive(true);
        if(StudyMgr.startingCondition == 1){
            if(StudyMgr.studySet != 4)
                showDelayedButton();      
        }
        else{
            if(StudyMgr.studySet != 1)
                showDelayedButton(); 
        }    
    }


    public void closePauseScreen(){
        StudyMgr.showScreen = true;
        if( StudyMgr.startingCondition == 1)
            StudyMgr.showScreen = false;
        PauseScreen.SetActive(false);
        PauseButton.SetActive(false);
        RepeatPanel.SetActive(false);
        ConditionStartupScreen.SetActive(false);
        //log new set
        Logger.writeMessageWithTimestampToLog("Started set: "+ (StudyMgr.studySet).ToString());
        Logger.writeMapToLog("Switched to map: " + StudyMgr.studySet);
        Logger.writeMapToLog("Map: " + StudyMgr.studySet);
    }


    // Called from button of pause screen
    public void showConditionStartupScreen(){
        switch (_sets[StudyMgr.participantID%24,StudyMgr.SetIndex]){
            case 1: CurrentConditionInfoText.text = "Im folgenden Szenario wird die Bildschirmgröße <color=#2fe0e0>nicht</color> in AR vergrößert. ";
                break;
            case 2: CurrentConditionInfoText.text = "Im folgenden Szenario wird die Bildschirmgröße in AR auf die Größe eines <color=#2fe0e0>Tablets</color> vergrößert.";
                break;
            case 3: CurrentConditionInfoText.text = "Im folgenden Szenario wird die Bildschirmgröße in AR auf die Größe eines <color=#2fe0e0>PC Monitors</color> vergrößert."; 
                break;
            case 4: CurrentConditionInfoText.text = "Im folgenden Szenario wird die Bildschirmgröße in AR auf die Größe eines <color=#2fe0e0>Fernsehers</color> vergrößert.";
                break;
            default: break;
        }
        
        PauseScreen.SetActive(false);
        ConditionStartupScreen.SetActive(true);

    }
    public void repeatIntroduction(){

    }

    //uses a separate thread in order to wait 30 sec and display the button after the time has elapsed
    async void showDelayedButton(){
        if(Demo)
            await UniTask.Delay(TimeSpan.FromSeconds(2), ignoreTimeScale: false);
        else
            await UniTask.Delay(TimeSpan.FromSeconds(_delayButtonTimer), ignoreTimeScale: false);

        if(_delayButtonTimer != 30)
            _delayButtonTimer = 30;
        if(StudyMgr.studySet == 0)
            RepeatPanel.SetActive(true);
        else
            PauseButton.SetActive(true);
    }
}
