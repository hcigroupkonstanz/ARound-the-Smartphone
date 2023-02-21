using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LikertScale : MonoBehaviour
{
    public TMPro.TMP_Text[] Panels;
    public int QuestionID;
    private int _currentSelectedIndex;
    // Start is called before the first frame update
    void Start()
    {
        _currentSelectedIndex = -1;
    }

    // Update is called once per frame
    void Update() {
     
    }
    public void updateSelection(int index){
        for (int i = 0; i < Panels.Length; i++){
            Panels[i].text = "";
            if(i == index)
                Panels[i].text = "x";

        }
        _currentSelectedIndex = index;
        //Debug.Log(index);
    }

    public int[] getAnswer(){
        return new int[]{QuestionID,_currentSelectedIndex};
    }
    public void reset(){
         for (int i = 0; i < Panels.Length; i++){
            Panels[i].text = "";
        }
        _currentSelectedIndex = -1;
    }
    
}
