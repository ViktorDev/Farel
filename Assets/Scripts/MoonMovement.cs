using UnityEngine;
using System.Collections;

public class MoonMovement : MonoBehaviour 
{

    GameObject arCam;
    GameObject shadow;
    bool isChecked;
    Vector2 startSwipePos;
    Rigidbody rig;

    void Start () 
	{
        arCam = GameObject.Find("ARCamera");
        shadow = transform.Find("Shadow").gameObject;
        rig = GetComponent<Rigidbody>();

    }
	
	void Update () 
	{
//		transform.Rotate(Vector3.up * Time.deltaTime * 3);
        rig.AddTorque(arCam.transform.up * Time.deltaTime * 50, ForceMode.Impulse);
        shadow.transform.rotation = Quaternion.LookRotation(transform.position - arCam.transform.position);
        UserInput();
      }

    void UserInput()
    {
#if UNITY_ANDROID
        if (Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
                if (hit.transform.gameObject.tag == "Moon")
                {
                    isChecked = true;
                }
        }

        if (Input.GetTouch(0).phase == TouchPhase.Moved && isChecked)
        {
            rig.AddTorque(-arCam.transform.up * 10 * Input.GetTouch(0).deltaPosition.x, ForceMode.Impulse);
            rig.AddTorque(arCam.transform.right * 10 * Input.GetTouch(0).deltaPosition.y, ForceMode.Impulse);

            //           transform.RotateAround(transform.position, -arCam.transform.up, Input.GetTouch(0).deltaPosition.x);
            //           transform.RotateAround(transform.position, arCam.transform.right, Input.GetTouch(0).deltaPosition.y);
        }
        if (Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            isChecked = false;
        }

#endif
        //#if UNITY_EDITOR

        //        if (Input.GetMouseButtonDown(0))
        //        {
        //            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //            RaycastHit hit;

        //            if (Physics.Raycast(ray, out hit, 100))
        //                if (hit.transform.gameObject.tag == "Moon")
        //                {
        //                    isChecked = true;
        //                    startSwipePos = Input.mousePosition;
        //                }
        //        }

        //        if (Input.GetMouseButton(0) && isChecked)
        //        {
        //            rig.AddTorque(arCam.transform.up * 10 * (startSwipePos.x - Input.mousePosition.x), ForceMode.Impulse);
        //            rig.AddTorque(-arCam.transform.right * 10 * (startSwipePos.y - Input.mousePosition.y), ForceMode.Impulse);

        //            //          transform.RotateAround(transform.position, arCam.transform.up, (startSwipePos.x - Input.mousePosition.x));
        //            //           transform.RotateAround(transform.position, -arCam.transform.right, (startSwipePos.y - Input.mousePosition.y));
        //            startSwipePos = Input.mousePosition;
        //        }
        //        if (Input.GetMouseButtonUp(0))
        //        {
        //            isChecked = false;
        //        }
        //#endif

    }
}
