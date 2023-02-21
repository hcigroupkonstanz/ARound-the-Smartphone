using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;


public class PositionLogging : MonoBehaviour
{
    public LoggingSystem Logger;
    public GameObject MainCamera;
    public GameObject Center;

    private bool _hmdThreadRunning;
    private bool _phoneThreadRunning;
    private Vector3 _oldHmdPosition;
    private Vector3 _oldPhonePosition;
    // Start is called before the first frame update
    void Start()
    {
        Logger.startPhoneLog();
        Logger.startHMDLog();
    }

    // Update is called once per frame
    void Update()
    {
        if(!_hmdThreadRunning){
            logHMDPosition();
            _hmdThreadRunning = true;
        }
        if(!_phoneThreadRunning){
            logPhonePosition();
            _phoneThreadRunning = true;
        }
    }

    async void logHMDPosition(){
        await UniTask.WaitUntil(() => _oldHmdPosition != MainCamera.transform.position);
        Vector3 currentCameraPosition = MainCamera.transform.position;
        Logger.writeHMDToLog("x: "+currentCameraPosition.x +" y:" + currentCameraPosition.y +" z:" +currentCameraPosition.z + " xRot: "+ MainCamera.transform.rotation.eulerAngles.x+ " yRot: "+ MainCamera.transform.rotation.eulerAngles.y +" zRot:"+  MainCamera.transform.rotation.eulerAngles.z);
        _oldHmdPosition = currentCameraPosition;
        _hmdThreadRunning = false;
    }

    async void logPhonePosition(){
        await UniTask.WaitUntil(() => _oldPhonePosition != Center.transform.position);
        Vector3 currentCenterPosition = Center.transform.position;
        Logger.writePhoneToLog("x: "+currentCenterPosition.x +" y: " + currentCenterPosition.y +" z: " +currentCenterPosition.z + " xRot: "+ Center.transform.rotation.eulerAngles.x+ " yRot: "+ Center.transform.rotation.eulerAngles.y +" zRot:"+  Center.transform.rotation.eulerAngles.z);
        _oldPhonePosition = currentCenterPosition;
        _phoneThreadRunning = false;
    }
}
