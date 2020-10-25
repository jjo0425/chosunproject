using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.Experimental.XR;
using System;
using UnityEngine.EventSystems;

public class ARTapToPlaceObject : MonoBehaviour
{
    public GameObject objectToPlace;
    public GameObject placementIndicator;
    public Camera cam;
    public Button _onoffBtn;
    public CSelection selection;

    private ARRaycastManager manager;
    private Pose placementPose;
    private bool placementPoseIsValid = false;


    void Start()
    {
        manager = FindObjectOfType<ARRaycastManager>();
        _onoffBtn.interactable = false;
    }

    void Update()
    {
        UpdatePlacementIndicator();
        UpdatePlacementPose();
        if (placementPoseIsValid && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId) == false)
        {
            PlaceObject();
        }
    }

    private void PlaceObject()
    {
        if (selection.isVisible == false) selection.SetVisibleToggle();
        objectToPlace.transform.position = placementIndicator.transform.position;
        objectToPlace.transform.rotation = placementIndicator.transform.rotation;
        _onoffBtn.interactable = true;
    }

    private void UpdatePlacementIndicator()
    {
        if (placementPoseIsValid)
        {
            placementIndicator.SetActive(true);
            placementIndicator.transform.SetPositionAndRotation(placementPose.position, placementPose.rotation);
        }

        else
        {
            placementIndicator.SetActive(false);
        }
    }

    private void UpdatePlacementPose()
    {
        var screenCenter = cam.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        var hits = new List<ARRaycastHit>();
        manager.Raycast(screenCenter, hits, UnityEngine.XR.ARSubsystems.TrackableType.Planes);


        placementPoseIsValid = hits.Count > 0;
        if (placementPoseIsValid)
        {
            placementPose = hits[0].pose;

            var cameraForward = Camera.current.transform.forward;
            var cameraBearing = new Vector3(cameraForward.x, 0, cameraForward.z).normalized;
            placementPose.rotation = Quaternion.LookRotation(cameraBearing);
        }
    }        
}


