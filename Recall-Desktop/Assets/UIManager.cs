using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject SetupScreen;
    public GameObject PauseScreen;
    public GameObject QuestionnaireScreen;
    public GameObject EndScreen;
    public GameObject Map;
    public GameObject QuestionnaireContent;
    public TMPro.TMP_Text ParticipantID;
    public int ParticipantId;
    public int StartingSet;
    public int CurrentSet;
    public LoggingSystem Logger;
    public LoggingSystemQuestionnaire LoggerQuestionnaire;

    public UnityEngine.UI.Toggle GermanText;
    public TMPro.TMP_Text PlacementText;
    public TMPro.TMP_Text InstructionText;
    public TMPro.TMP_Text InstructionButtonText;
    public TMPro.TMP_Text ConfirmText;
    public TMPro.TMP_Text BackText;
    public TMPro.TMP_Text FinishedText;
    private int[,] _sets;
    
    public int SetIndex  = 0;

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
        if (Input.GetKeyDown("k")){
            if(!PauseScreen.activeSelf)
                closeEndScreen();
        }
    }

    public void closeSetup(){
        ParticipantId = int.Parse(ParticipantID.text.Substring(0,ParticipantID.text.Length-1));
      
        StartingSet = _sets[ParticipantId%24,SetIndex];
        CurrentSet = StartingSet;
        SetupScreen.SetActive(false);
        Logger.writeMessageToLog("P: "+ParticipantId +" Starting:"+StartingSet);
        LoggerQuestionnaire.writeMessageToLog("P: "+ParticipantId +" Starting:"+StartingSet);
      
        showPause();

    }
    public void closePause(){
        PauseScreen.SetActive(false);
        CurrentSet = _sets[ParticipantId%24,SetIndex];
        Logger.writeMessageWithTimestampToLog("Started set: "+CurrentSet);
        LoggerQuestionnaire.writeMessageWithTimestampToLog("Started set: "+CurrentSet);
        Map.SetActive(true);
    }
    public void showPause(){
        PauseScreen.SetActive(true);
    }

    public void showQuestionnaireScreen(){
        QuestionnaireScreen.SetActive(true);
    }
    public void closeQuestionnaireScreen(){
        
        if(LoggerQuestionnaire.saveQuestionnaire()){
            QuestionnaireScreen.SetActive(false);
            QuestionnaireContent.transform.position = new Vector3(0,0,0);
            showEndScreen();
        }
    }
    public void showEndScreen(){
        EndScreen.SetActive(true);
    }
    public void closeEndScreen(){
        showPause();
        LoggerQuestionnaire.restartQuestionnaire();
        EndScreen.SetActive(false);

    }
    void changeLanguageToGerman() {
        InstructionText.text = "Dieser Teil der Studie zeigt eine leere Karte. Ihre Aufgabe ist es, die 6 Symbole die Sie gerade gesucht haben auf dieser Karte zu platzieren. ";
        InstructionButtonText.text = "Start";
        ConfirmText.text = "Bestätigen";
        PlacementText.text = "Platziere dieses Symbol:";
        BackText.text = "Rückgängig";
        FinishedText.text = "Dieser Aufgabenteil ist jetzt beendet. \n Bitte wende dich an den Studienleiter.";
    }
}
