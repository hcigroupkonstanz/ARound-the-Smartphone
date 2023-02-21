using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class TargetManager : MonoBehaviour
{
    public GameObject targetMarker;
    public draggable map;

    public Sprite[] spriteStudyMaps;

    public Sprite[] spriteSetMapIntro;
    public Vector2[] targetPositionsMapIntro;

    public Sprite[] spriteSetMap1;
    public Vector2[] targetPositionsMap1;

    public Sprite[] spriteSetMap2;
    public Vector2[] targetPositionsMap2;

    public Sprite[] spriteSetMap3;
    public Vector2[] targetPositionsMap3;

    public Sprite[] spriteSetMap4;
    public Vector2[] targetPositionsMap4;


    public StudyManager StudyMgr;
    public SetupManager SetManager;

    public GameObject centerBaseline;

    public GameObject pauseScreen;
    public LoggingSystem Logger;
    public bool Demo;



    private SpriteRenderer targetSprite;
    private int maxItemCount = 6;
    private int rotations = 1;
   // private bool tutorial;
    private int setsCompleted;

    private bool _mapThreadRunning;
    private bool _iconThreadRunning;
    private int[,] _sets;

    


    // Start is called before the first frame update
    void Start(){
        targetSprite = targetMarker.GetComponent<SpriteRenderer>();
        targetSprite.sprite = spriteSetMapIntro[StudyMgr.iconCount];
        setsCompleted = 0;
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
    void Update(){
        if (!_mapThreadRunning){
            _mapThreadRunning= true;
            updateMap();
        }
        if(!_iconThreadRunning){
            _iconThreadRunning = true;
            updateIcon();
        }
        

        map.targetPos = centerBaseline.transform.position;

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended || Input.GetMouseButtonUp(0)) {
            // correct icon selected 
            if (checkMarker()) {
                Logger.writeMessageWithTimestampToLog("Found Icon: "+ StudyMgr.iconCount.ToString());
                Logger.writeMapToLog("x: 0.0 y: 0.0 z: 0.0");
                if (StudyMgr.iconCount < maxItemCount - 1)
                    StudyMgr.iconCount++;
                else {
                    StudyMgr.iconCount = 0;
                    setsCompleted++;
                    if (setsCompleted == rotations)
                        completeStage();
                }

                loadCurrentSprite();

                map.resetPosition();
            }
        }
    }


    /*
    Takes a GameObject go, which is a child of the main map and returns the square of the map which is at the position of go.
    Coordinates start at bottom left of map with 0,0.
    */
    private Vector2 calculateMapPosition(GameObject go){
        float widthBlocks = 46.0f;
        float heightBlocks = 27.0f;
        float posX = go.transform.localPosition.x;
        float posY = go.transform.localPosition.y;
        float tarX, tarY;

        if (posX < 0)
            tarX = -1 * (-((widthBlocks-1) / 2) - posX);
        else
            tarX = ((widthBlocks-1) / 2)  + posX;

        if (posY < 0)
            tarY = -1 * (-((heightBlocks-1) / 2)  - posY);
        else
            tarY = ((heightBlocks-1) / 2)  + posY;
        
       // Debug.Log(Mathf.Round(tarX)+" "+ Mathf.Round(tarY));
        //rounds to the next integer, if float is .5 the next even number is chosen instead
        return new Vector2(Mathf.Round(tarX), Mathf.Round(tarY));
    }

    public void startIntroduction(){
        unPauseMap();
       // tutorial = true;
        map.GetComponent<SpriteRenderer>().sprite = spriteStudyMaps[0];
    }

    //Triggered through button of Condition Startup Screen
    public void startScenario(){
        
        StudyMgr.studySet = _sets[StudyMgr.participantID%24,StudyMgr.SetIndex];
        StudyMgr.SetIndex++;

        //target position stays in the middle of the phone
        map.targetPos = centerBaseline.transform.position;
        
        map.gameObject.GetComponent<SpriteRenderer>().sprite = spriteStudyMaps[StudyMgr.studySet];
        loadCurrentSprite();
        unPauseMap();
        setsCompleted = 0;
        SetManager.closePauseScreen();
    }
    public void restartIntro(){
        

        //target position stays in the middle of the phone
        map.targetPos = centerBaseline.transform.position;
        map.GetComponent<SpriteRenderer>().sprite = spriteStudyMaps[0];
       
        loadCurrentSprite();
        unPauseMap();
        setsCompleted = 0;
        SetManager.closePauseScreen();
        rotations = 1;
    }

    void completeStage(){
        if(rotations!= 4 && !Demo)
            rotations = 4;
        pauseScreen.SetActive(true);
        unPauseMap();
        SetManager.openPauseScreen();
    }
    public void quickstartSetRotations(){
        rotations = 4;
    }

    //pauses the draggable script if a canvas ui is open
    void unPauseMap(){
        if (map.enabled)
            map.enabled = false;
        else
            map.enabled = true;
    }

    //loads the current sprite of the active condition
    void loadCurrentSprite(){
        switch (StudyMgr.studySet){
            case 0: 
                targetSprite.sprite = spriteSetMapIntro[StudyMgr.iconCount];
                break;
            case 1:
                targetSprite.sprite = spriteSetMap1[StudyMgr.iconCount];
                break;
            case 2: 
                targetSprite.sprite = spriteSetMap2[StudyMgr.iconCount];
                break;
            case 3: 
                targetSprite.sprite = spriteSetMap3[StudyMgr.iconCount];
                break;
            case 4: 
                targetSprite.sprite = spriteSetMap4[StudyMgr.iconCount];
                break;  
            default: break;
        }
    }

    //checks if watermark is at the location of its icon
    private bool checkMarker(){
        switch(StudyMgr.studySet){
            case 0: 
                return targetPositionsMapIntro[StudyMgr.iconCount] == calculateMapPosition(targetMarker);
            case 1: 
                return targetPositionsMap1[StudyMgr.iconCount] == calculateMapPosition(targetMarker);
            case 2: 
                return targetPositionsMap2[StudyMgr.iconCount] == calculateMapPosition(targetMarker);
            case 3: 
                return targetPositionsMap3[StudyMgr.iconCount] == calculateMapPosition(targetMarker);
            case 4: 
                return targetPositionsMap4[StudyMgr.iconCount] == calculateMapPosition(targetMarker);
            default: 
                return false;
        }
    }

    async void updateMap(){
        int currentMap = StudyMgr.studySet;
        await UniTask.WaitUntil(() => StudyMgr.studySet != currentMap);
        map.gameObject.GetComponent<SpriteRenderer>().sprite = spriteStudyMaps[StudyMgr.studySet];
        loadCurrentSprite();
        Logger.writeMessageWithTimestampToLog("Load Map: "+ StudyMgr.studySet.ToString() +" with icon: "+ StudyMgr.iconCount);
        _mapThreadRunning = false;
    }

    async void updateIcon(){
        int currentIcon = StudyMgr.iconCount;
        await UniTask.WaitUntil(() => StudyMgr.iconCount != currentIcon);
        loadCurrentSprite();
        _iconThreadRunning = false;
    }
    
}
