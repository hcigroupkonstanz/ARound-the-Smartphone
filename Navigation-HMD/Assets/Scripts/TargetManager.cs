using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class TargetManager : MonoBehaviour
{
    public GameObject targetMarker;
    public GameObject map;
    public StudyManager studyManager;

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

    public GameObject ExtendedScreen;
    public GameObject smallScreen;
    public GameObject mediumScreen;
    public GameObject largeScreen;


    private int currentIconIndex = 0;
    private SpriteRenderer targetSprite;
    private int maxItemCount = 3;
    private bool mapThreadRunning;
    private bool iconThreadRunning;
    private int currentMap;
    private int currentIcon;
    private int[,] _sets;
    

    // Start is called before the first frame update
    void Start(){
        targetSprite = targetMarker.GetComponent<SpriteRenderer>();
    
        mapThreadRunning = false;
        iconThreadRunning = false;
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
        initializeMap();
        
    }

    // Update is called once per frame
    void Update() {

      if(!mapThreadRunning){
          
          mapThreadRunning= true;
          updateMap();
      }
      
     /* if(!iconThreadRunning){
          
          iconThreadRunning = true;
          updateIcon();
      }*/

    
      ExtendedScreen.SetActive(studyManager.showScreen);
    }

    /*
    Takes a GameObject go, which is a child of the main map and returns the square of the map which is at the position of go.
    Coordinates start at bottom left of map with 0,0.
    */
    private Vector2 calculateMapPosition(GameObject go){
      float posX = go.transform.localPosition.x;
      float posY = go.transform.localPosition.y;
      float tarX, tarY;
      
      if(posX < 0)
        tarX = -1*(-11.5f - posX);
      else
        tarX = 11.5f + posX;
      
      if(posY < 0)
        tarY = -1*(-8.5f - posY);
      else
        tarY = 8.5f + posY;
    
        
      //rounds to the next integer, if float is .5 the next even number is chosen instead
      return new Vector2(Mathf.Round(tarX), Mathf.Round(tarY));
    }

    /*
    launches a thread that waits until the current map is changed through the smartphone app. updates map sprite based on new map
    */
    async void updateMap(){
      currentMap = studyManager.studySet;
      // wait until variable is changed through sync manager
      await UniTask.WaitUntil(() => studyManager.studySet != currentMap);
    
      //activating the correct extended screen
      switch(studyManager.studySet){
        
        /*case 0: 
          map.GetComponent<SpriteRenderer>().sprite = spriteStudyMaps[0];
          
          if(studyManager.startingCondition == 4){
            ExtendedScreen.SetActive(true);
            smallScreen.SetActive(false);
            mediumScreen.SetActive(false);
            largeScreen.SetActive(true);
          }
          else {
             ExtendedScreen.SetActive(false);
              smallScreen.SetActive(false);
              mediumScreen.SetActive(false);
              largeScreen.SetActive(false);
          }
          break;*/
        case 1: 
          studyManager.showScreen = false;
          map.GetComponent<SpriteRenderer>().sprite = spriteStudyMaps[1];
          ExtendedScreen.SetActive(false);
          smallScreen.SetActive(false);
          mediumScreen.SetActive(false);
          largeScreen.SetActive(false);
          break;
        case 2:
          map.GetComponent<SpriteRenderer>().sprite = spriteStudyMaps[2];
          ExtendedScreen.SetActive(true);
          smallScreen.SetActive(true);
          mediumScreen.SetActive(false);
          largeScreen.SetActive(false); 
          break;
        case 3:
          map.GetComponent<SpriteRenderer>().sprite = spriteStudyMaps[3];
          ExtendedScreen.SetActive(true);
          smallScreen.SetActive(false);
          mediumScreen.SetActive(true);
          largeScreen.SetActive(false); 
          break;
        case 4:
          map.GetComponent<SpriteRenderer>().sprite = spriteStudyMaps[4];
          ExtendedScreen.SetActive(true);
          smallScreen.SetActive(false);
          mediumScreen.SetActive(false);
          largeScreen.SetActive(true); 
          break;
        default: break;
      }
      
      //old switch for if the screen is extended to the left side. in this case the watermark was visible on the extended screen.
      switch(studyManager.studySet){
        case 0: 
          targetSprite.sprite = spriteSetMapIntro[studyManager.iconCount];
          break;
        case 1: 
          targetSprite.sprite = spriteSetMap1[studyManager.iconCount];
          break;
        case 2:
          targetSprite.sprite = spriteSetMap2[studyManager.iconCount];
          break;
        case 3:
          targetSprite.sprite = spriteSetMap3[studyManager.iconCount];
          break;
        default: break;
    }

      //restart thread in update
      mapThreadRunning = false;

    }
    async void initializeMap(){
      // wait until variable is changed through sync manager
      await UniTask.WaitUntil(() => studyManager.participantID != 0);
      switch(_sets[studyManager.participantID % 24,studyManager.SetIndex]){
        case 1: 
          studyManager.showScreen = false;
          map.GetComponent<SpriteRenderer>().sprite = spriteStudyMaps[1];
          ExtendedScreen.SetActive(false);
          smallScreen.SetActive(false);
          mediumScreen.SetActive(false);
          largeScreen.SetActive(false);
          break;
        case 2:
          map.GetComponent<SpriteRenderer>().sprite = spriteStudyMaps[2];
          ExtendedScreen.SetActive(true);
          smallScreen.SetActive(true);
          mediumScreen.SetActive(false);
          largeScreen.SetActive(false); 
          break;
        case 3:
          map.GetComponent<SpriteRenderer>().sprite = spriteStudyMaps[3];
          ExtendedScreen.SetActive(true);
          smallScreen.SetActive(false);
          mediumScreen.SetActive(true);
          largeScreen.SetActive(false); 
          break;
        case 4:
          map.GetComponent<SpriteRenderer>().sprite = spriteStudyMaps[4];
          ExtendedScreen.SetActive(true);
          smallScreen.SetActive(false);
          mediumScreen.SetActive(false);
          largeScreen.SetActive(true); 
          break;
        default: break;
      }
      map.GetComponent<SpriteRenderer>().sprite = spriteStudyMaps[0];

    }

  /*
    launches a thread that waits until the current icon is changed through the smartphone app. updates target icon based on new map
    */
  async void updateIcon(){
    currentIcon = studyManager.iconCount;
    
    // wait until variable is changed through sync manager
    await UniTask.WaitUntil(() => studyManager.iconCount != currentIcon);

    switch(studyManager.studySet){
      case 0: 
         targetSprite.sprite = spriteSetMapIntro[studyManager.iconCount];
        break;
      case 1: 
        targetSprite.sprite = spriteSetMap1[studyManager.iconCount];
        break;
      case 2:
        targetSprite.sprite = spriteSetMap2[studyManager.iconCount];
        break;
      case 3:
        targetSprite.sprite = spriteSetMap3[studyManager.iconCount];
        break;
      default: break;
    }

    //restart thread in update
    iconThreadRunning = false;
  }
 
    
}
