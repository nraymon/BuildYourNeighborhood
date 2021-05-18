using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private Transform target;
    [SerializeField] private float distanceToTarget = 10;
    [SerializeField] [Range(0, 360)] private int maxRotationInOneSwipe = 180;

    private Vector3 previousPosition;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            float dist = Vector3.Distance(target.position, cam.transform.position);
            Debug.Log("distance: " + dist);
            // true only in the 1st frame in which it detects a tap
            previousPosition = cam.ScreenToViewportPoint(Input.mousePosition);
        }
        else if (Input.GetMouseButton(1))
        {

            float dist = Vector3.Distance(target.position, cam.transform.position);
            Debug.Log("distance: " + dist);
            //true as long as touch is happening
            Vector3 newPosition = cam.ScreenToViewportPoint(Input.mousePosition);
            Vector3 direction = previousPosition - newPosition;

            float rotationAroundYAxis = -direction.x * maxRotationInOneSwipe;
            float rotationAroundXAxis = direction.y * maxRotationInOneSwipe;

            cam.transform.position = target.position;

            cam.transform.Rotate(new Vector3(1, 0, 0), rotationAroundXAxis);

            // Limits the roation around x axis - can't go under grid
            Vector3 curRotation = cam.transform.localRotation.eulerAngles;
            curRotation.x = Mathf.Clamp(curRotation.x, 22, 30);
            cam.transform.localRotation = Quaternion.Euler(curRotation);

            cam.transform.Rotate(new Vector3(0, 1, 0), rotationAroundYAxis, Space.World);

            //cam.transform.Translate(new Vector3(0, 0, -distanceToTarget));
            cam.transform.Translate(new Vector3(0, 0, -dist));

            previousPosition = newPosition;
        }
    }
}
