using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARController : MonoBehaviour
{
    public GameObject MyObject;
    public ARRaycastManager RaycastManager;

    private void Update()
    {
        if(Input.touchCount>0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            List<ARRaycastHit> touchcs = new List<ARRaycastHit>();

            RaycastManager.Raycast(Input.GetTouch(0).position, touchcs, UnityEngine.XR.ARSubsystems.TrackableType.Planes);

            if (touchcs.Count > 0)
                GameObject.Instantiate(MyObject, touchcs[0].pose.position, touchcs[0].pose.rotation);
        }
    }



    /*[SerializeField] private float speed;

    public GameObject Player;
    public ARRaycastManager RaycastManager;

    private FloatingJoystick joystick;

    private void OnEnable()
    {
        joystick = FindObjectOfType<FloatingJoystick>();
    }

    private void FixedUpdate()
    {
        float xValue = joystick.Horizontal;
        float yValue = joystick.Vertical;

        Vector3 movement = new Vector3 (xValue, 0, yValue) * speed * Time.deltaTime;
        Player.transform.Translate(movement);
    }*/
}
