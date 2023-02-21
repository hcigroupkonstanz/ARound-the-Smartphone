using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPlacer : MonoBehaviour
{
    public SpriteRenderer NextIcon;
    
    public Sprite[] Set1;
    public Sprite[] Set2;
    public Sprite[] Set3;
    public Sprite[] Set4;
    public UIManager UIM;

    public GameObject ConfirmButton;
    public GameObject BackButton;
    public GameObject PlacementText;

    public LoggingSystem Logger;

    private int _currentIcon;
    private GameObject[] _history;
    private bool _finished;
    private int _iconsPerSet = 6;
    private float _iconSize = 0.35f;
    private int _mapSquaresWidth = 47;
    private int _mapSquaresHeight = 26;
    private float _mapWidth, _mapHeight;


    public GameObject Icon;
    // Start is called before the first frame update
    void Start()
    {
        _currentIcon = 0;
        _history = new GameObject[8];
        _mapWidth = _mapSquaresWidth / 2 -1;
        _mapHeight = _mapSquaresHeight/ 2 -1;
    }

    // Update is called once per frame
    void Update() {

            NextIcon.sprite = getSpriteForCurrentSet();
            if(_currentIcon<_iconsPerSet && UIM.ParticipantId != 0){
                 
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began || Input.GetMouseButtonDown(0)) {
                Vector2 cubeRay = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D cubeHit = Physics2D.Raycast(cubeRay, Vector2.zero);

                if (cubeHit) {
                    Vector2 snapPosition;
                    
                    _history[_currentIcon]= Instantiate(Icon,cubeHit.point,Quaternion.identity);
                    _history[_currentIcon].transform.parent = this.transform;
                    _history[_currentIcon].transform.localScale= new Vector3 (_iconSize,_iconSize,1);
                    _history[_currentIcon].GetComponent<SpriteRenderer>().sprite = getSpriteForCurrentSet();
                    snapPosition = calculateMapPosition(_history[_currentIcon]);
                    _history[_currentIcon].transform.localPosition = new Vector3(snapPosition.x,snapPosition.y,0);
                    Logger.writeMessageWithTimestampToLog("CS: "+UIM.CurrentSet+"CI: "+_currentIcon +" x: "+_history[_currentIcon].transform.localPosition.x +" y: "+_history[_currentIcon].transform.localPosition.x);
                    _currentIcon++;
                }
            }
        }

        if(_currentIcon<_iconsPerSet){
            PlacementText.SetActive(true);
            ConfirmButton.SetActive(false);
        }
        else{
            PlacementText.SetActive(false);
            ConfirmButton.SetActive(true);
        }

        if(_currentIcon> 0)
            BackButton.SetActive(true);
        else
            BackButton.SetActive(false);
    }

    //calculate the position where the new icon is oging to be placed
    private Vector2 calculateMapPosition(GameObject go) {
        float posX = go.transform.localPosition.x;
        float posY = go.transform.localPosition.y;
        float tarX, tarY;

        if (posX < 0)
            tarX = -1 * (-_mapWidth- posX);
        else
            tarX = _mapWidth + posX;

        if(tarX % 1 > 0.49f)
            tarX -= 0.49f;

        if (posY < 0)
            tarY = -1 * (-_mapHeight - posY);
        else
            tarY = _mapHeight + posY;

        //rounds to the next integer, if float is .5 the next even number is chosen instead
        return new Vector2((Mathf.RoundToInt(tarX)+0.5f)-_mapWidth, Mathf.RoundToInt((Mathf.RoundToInt(tarY))-_mapHeight));
    }


    private Sprite getSpriteForCurrentSet(){
        if(_currentIcon == _iconsPerSet)
        return null;
        switch(UIM.CurrentSet){
            case 1: return Set1[_currentIcon];
            case 2: return Set2[_currentIcon];
            case 3: return Set3[_currentIcon];
            case 4: return Set4[_currentIcon];
            default: return null;
        }       
    }

    //submit button 
    public void finishSet(){

        UIM.SetIndex++;
        

        for (int i = 0; i < _iconsPerSet; i++)
        {
            GameObject.Destroy(_history[i]);
        }
        _currentIcon = 0;
        UIM.showQuestionnaireScreen();
        gameObject.SetActive(false);
    }

    //redo button
    public void goBack(){
        if(_currentIcon>0){
            _currentIcon--;
            GameObject.Destroy(_history[_currentIcon]);
        }
    }
}
