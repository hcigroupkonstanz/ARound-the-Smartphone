using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Varjo.XR;

public class VarjoMarkerManager : MonoBehaviour
{
    // Serializable struct to make it easy to add tracked objects in the Inspector. 
    [System.Serializable] 
    public struct TrackedObject 
    { 
        public long id; 
        public GameObject gameObject; 
    } 

    public int mainId;
    public float moveThreshold;
    public float rotationThreshold;

    // An public array for all the tracked objects. 
    public TrackedObject[] trackedObjects = new TrackedObject[1];

    // A list for found markers.
    private List<VarjoMarker> markers = new List<VarjoMarker>();

    // A list for IDs of removed markers.
    private List<long> removedMarkerIds = new List<long>();

    private VarjoMarker mainMarker;
    private Vector3[] positionArray = new Vector3[50];
    private Quaternion[] rotationArray = new Quaternion[50];
    private int positionArrayIndex = 0;
    private int rotationArrayIndex = 0;
    public bool stableTracking;

    private void OnEnable()
    {
        // Enable Varjo Marker tracking.
        VarjoMarkers.EnableVarjoMarkers(true);
    }

    private void OnDisable()
    {
        // Disable Varjo Marker tracking.
        VarjoMarkers.EnableVarjoMarkers(false);
    }
    async void Update()
    {
        
        // Check if Varjo Marker tracking is enabled and functional.
        if (VarjoMarkers.IsVarjoMarkersEnabled())
        {
            // Get a list of markers with up-to-date data.
            VarjoMarkers.GetVarjoMarkers(out markers);

            // Loop through found markers and update gameobjects matching the marker ID in the array.
            foreach (var marker in markers)
            {
                

                for (var i = 0; i < trackedObjects.Length; i++)
                {
                    
                    if (trackedObjects[i].id == mainId){
                        mainMarker = marker;
                    }
                    
                    if (trackedObjects[i].id == marker.id)
                    {
                        if(trackedObjects[i].id == mainId){
                            

                            /*
                            if(positionArrayIndex ==50)
                                positionArrayIndex =0;

                            if(checkMoveThreshold(mainMarker.pose.position)){
                                positionArray[positionArrayIndex] = mainMarker.pose.position;
                                positionArrayIndex++;
                            }
*/  /*
                            if(rotationArrayIndex ==50)
                                rotationArrayIndex =0;

                            if(rotationArrayIndex > 0){
                                if(checkRotationThreshold(mainMarker.pose.rotation,rotationArray[rotationArrayIndex-1])){
                                    rotationArray[rotationArrayIndex] = mainMarker.pose.rotation;
                                    rotationArrayIndex++;
                                }
                            } else {
                                rotationArray[rotationArrayIndex] = mainMarker.pose.rotation;
                                rotationArrayIndex++;
                            }*/
                        }


                        // This simple marker manager controls only visibility and pose of the GameObjects.

                        trackedObjects[i].gameObject.SetActive(true);
                        
                        trackedObjects[i].gameObject.transform.localPosition = mainMarker.pose.position;
                        if(stableTracking)
                        trackedObjects[i].gameObject.transform.localRotation = mainMarker.pose.rotation;
                        

                      //  trackedObjects[i].gameObject.transform.localPosition = calculateArrayAverage(positionArray);
                      //  trackedObjects[i].gameObject.transform.localRotation = rotationArray[rotationArrayIndex-1];

                    }
                }
            }

            // Get a list of IDs of removed markers.
            VarjoMarkers.GetRemovedVarjoMarkerIds(out removedMarkerIds);

            // Loop through removed marker IDs and deactivate gameobjects matching the marker IDs in the array.
            foreach (var id in removedMarkerIds)
            {
                for (var i = 0; i < trackedObjects.Length; i++)
                {
                    if (trackedObjects[i].id == id)
                    {
                        trackedObjects[i].gameObject.SetActive(false);
                    }
                }
            }
        }
    }
    void Start(){
        // Start rendering the video see-through image
        VarjoMixedReality.StartRender();
    }

     Vector3 calculateArrayAverage(Vector3[] array){
        int count = 0;
        double resultX = 0, resultY = 0, resultZ = 0;
        for(int i = 0; i < array.Length ; i++){
            if(array[i].x != 0 && array[i].y != 0 && array[i].z != 0){
                count++;
                resultX += array[i].x;
                resultY += array[i].y;
                resultZ += array[i].z;
            }
        }
        if(count == 0)
            return new Vector3 (0,0,0);
        else
            return new Vector3((float) resultX /count, (float)resultY/count, (float) resultZ/count);
    }
    bool checkMoveThreshold(Vector3 toCheck){
        Vector3 currentPositionAverage = calculateArrayAverage(positionArray);
        if(currentPositionAverage == new Vector3(0,0,0))
            return true;
        if(Vector3.Distance(currentPositionAverage,toCheck) < moveThreshold)
            return true;
        return false;
    }
    bool checkRotationThreshold(Quaternion toCheck, Quaternion toCheck2){
     //   Vector3 currentRotationAverage = calculateArrayAverage(rotationArray);
      //  if(currentRotationAverage == new Vector3(0,0,0))
      //      return true;
        
        
        if(Quaternion.Angle(toCheck2,toCheck) < rotationThreshold)
            return true;
            
    
        
        return false;
    }

    float calculatePositiveDiff(float float1, float float2){
        float result = Mathf.Max(Mathf.Abs(float1),Mathf.Abs(float2))-Mathf.Min(Mathf.Abs(float1),Mathf.Abs(float2));
        if (result > 360-rotationThreshold)
            result = 360-result;
        Debug.Log(result);
        return result;
    }

}
