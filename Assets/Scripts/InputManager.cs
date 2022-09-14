using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.Interaction.Toolkit.AR;

public class InputManager : ARBaseGestureInteractable
/*public class InputManager : MonoBehaviour*/
{
    [SerializeField] private Camera arCam;
    [SerializeField] private ARRaycastManager _raycastManager;
    [SerializeField] private GameObject crosshair;

    private List<ARRaycastHit> _hits = new List<ARRaycastHit>();

    private Touch touch;
    private Pose pose;

    protected override bool CanStartManipulationForGesture(TapGesture gesture)
    {
        if (gesture.targetObject == null)
            return true;
        return false;
    }

    protected override void OnEndManipulation(TapGesture gesture)
    {
        if (gesture.isCanceled)
            return;

        if (gesture.targetObject != null || IsPointerOverUI(gesture))
            return;

        if (GestureTransformationUtility.Raycast(gesture.startPosition, _hits, trackableTypes: TrackableType.PlaneWithinPolygon))
        {
            GameObject placeObj = Instantiate(DataHandler.Instance.GetTreez(), pose.position, pose.rotation);

            var anchorObject = new GameObject("PlacementAnchor");
            anchorObject.transform.position = pose.position;
            anchorObject.transform.rotation = pose.rotation;
            placeObj.transform.parent = anchorObject.transform;
        }
    }

    void FixedUpdate()
    {
        CrosshairCalculation();
    }

    bool IsPointerOverUI(TapGesture touch)
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current); //get current eventsystem from different UI components
        eventData.position = new Vector2(touch.startPosition.x, touch.startPosition.y); //get position of the UI components
        List<RaycastResult> results = new List<RaycastResult>(); 
        EventSystem.current.RaycastAll(eventData, results); //do raycasting on UI components
        return results.Count > 0; //if any UI components hit by raycast, ie, if touch done on UI component, return true
    }

    
    void CrosshairCalculation()
    {
        Vector3 origin = arCam.ViewportToScreenPoint(new Vector3(0.5f, 0.5f, 0));
        
        if (GestureTransformationUtility.Raycast(origin, _hits, trackableTypes: TrackableType.PlaneWithinPolygon))
        {
            pose = _hits[0].pose;
            crosshair.transform.position = pose.position;
            crosshair.transform.eulerAngles = new Vector3(90, 0, 0);
        }
        
    }

}
