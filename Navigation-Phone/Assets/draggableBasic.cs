using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class draggableBasic : MonoBehaviour
{
    public bool useMouse = true;
    private Vector2 startPos;
    private Vector3 currentPos;
    public Vector3 _velocity;
    private bool _underInertia;
    private Vector3 _prevPos;
    private float _time = 0.1f;
    public float SmoothTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {   
        //start
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began || Input.GetMouseButtonDown(0)) {
            if(useMouse)
                startPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            else
                startPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
                
            currentPos = transform.position;
            _underInertia = false;
        }

        //moving
        else if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetMouseButton(0)) {
             _prevPos = transform.position;
            // mouse input
            if(useMouse){

                transform.position = currentPos + new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x- startPos.x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y - startPos.y, transform.position.z);
            
            }
            // touch input 
            else
                transform.position = currentPos + new Vector3(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position).x - startPos.x, Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position).y - startPos.y, transform.position.z);
           updatePrevPos();
        }

        //stopped
        else if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended || Input.GetMouseButtonUp(0))
        {
           _underInertia = true;
        }

        //inertia movement after touch stopped
        if(_underInertia && _time <= SmoothTime)
        {
            transform.position += _velocity;
           
            _velocity = Vector3.Lerp(_velocity, Vector3.zero, _time);
            _time += Time.smoothDeltaTime;
        }
        else
        {
            _underInertia = false;
            _time = 0.0f;
        }
    }


    async void updatePrevPos(){
        await UniTask.WaitUntil(() => _prevPos != transform.position);
        if(transform.position != new Vector3(0,0,0))
        _velocity = transform.position -_prevPos;
    }
}
