using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FPSCameraController : MonoBehaviour {
    //    bool setbalancehorizontal;
    //    bool setbalancevertical;

    //	public enum RotationAxis
    //    {
    //        MouseX = 1,
    //        MouseY = 2,
    //    }
    //    public RotationAxis axes = RotationAxis.MouseX;
    //    public float minimumvert = -45;
    //    public float maximumvert = 45;
    //    public float sensHorizontal = .000001f;
    //    public float sensVertical = 2.0f;
    //    Vector3 mousepos;
    //    public float _rotationX = 0;
    //    Quaternion initialview;


    //    double leftscreenadd;
    //    // Update is called once per frame
    //    private void Start()
    //    {


    //        setbalancehorizontal = false;
    //        setbalancevertical = false;
    //        initialview = transform.rotation;

    //    }
    //    void FixedUpdate() {



    //        if (axes == RotationAxis.MouseX)
    //        {
    //            if (!(Input.mousePosition.x >= Screen.width - Screen.width * .45 || Input.mousePosition.x <= Screen.width - Screen.width * .55))
    //            {
    //                setbalancehorizontal = true;
    //            }
    //            else if (!(Input.mousePosition.x >= Screen.width - 1) && !(Input.mousePosition.x <= Screen.width - Screen.width + 1)
    //                && setbalancehorizontal && (Input.mousePosition.x >= Screen.width - Screen.width * .45 || Input.mousePosition.x <= Screen.width - Screen.width * .65))
    //            {
    //                transform.Rotate(0,Input.GetAxis("Mouse X"),0);



    //            }





    //        }
    //        if (axes == RotationAxis.MouseY)
    //        {
    //            if (!(Input.mousePosition.y >= Screen.height - Screen.height * .45 || Input.mousePosition.y <= Screen.height - Screen.height * .65))
    //            {
    //                setbalancevertical = true;
    //            }


    //            else if (!(Input.mousePosition.y >= Screen.height - 1) && !(Input.mousePosition.y <= Screen.height - Screen.height + 1) && setbalancevertical &&
    //                (Input.mousePosition.y >= Screen.height - Screen.height * .45 || Input.mousePosition.y <= Screen.height - Screen.height * .65))
    //            {
    //                _rotationX -= Input.GetAxis("Mouse Y") * sensVertical;
    //                _rotationX = Mathf.Clamp(_rotationX, minimumvert, maximumvert);//clamps vertical angle within min and max limits
    //                float rotationY = transform.localEulerAngles.y;

    //                transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
    //            }
    //        }
    //    }
    //}

    //public GameObject target;
    //public float rotateSpeed = 5;
    //Vector3 offset;

    //void Start()
    //{
    //    offset = target.transform.position - transform.position;
    //}

    //void LateUpdate()
    //{
    //    float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
    //    target.transform.Rotate(0, horizontal, 0);

    //    float desiredAngle = target.transform.eulerAngles.y;
    //    Quaternion rotation = Quaternion.Euler(0, desiredAngle, 0);
    //    transform.position = target.transform.position - (rotation * offset);

    //    transform.LookAt(target.transform);
    //}

    public float speedH = 2.0f;
    public float speedV = 2.0f;
    private float yaw = 0.0f;
    private float pitch = 0.0f;

    private void Update()
    {
        
        pitch += speedV * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    }
}




