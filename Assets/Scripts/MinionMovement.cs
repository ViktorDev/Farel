using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MinionMovement : MonoBehaviour 
{
    
	GameObject arCam;
//    GameObject shadow;
 
    Vector2 startSwipePos;
    
	Rigidbody rig;

	bool isChecked;

    void Start () 
	{
        arCam = GameObject.Find("ARCamera");
///        shadow = transform.Find("Shadow").gameObject;
        rig = GetComponent<Rigidbody>();

    }
	
	void Update () 
	{
        rig.AddTorque(arCam.transform.up * Time.deltaTime * 50, ForceMode.Impulse);
 //       shadow.transform.rotation = Quaternion.LookRotation(transform.position - arCam.transform.position);

       UserInput();
      }

   public void UserInput()
    {
		if (!Application.isEditor) {
			if (Input.GetTouch (0).phase == TouchPhase.Began) {
				Ray ray = Camera.main.ScreenPointToRay (Input.GetTouch (0).position);
				RaycastHit hit;

				if (Physics.Raycast (ray, out hit, 100))
				{
					if (hit.transform.gameObject.tag == "Minion") {
						isChecked = true;
					}
				}

			}

			if (Input.GetTouch (0).phase == TouchPhase.Moved && isChecked) {
				rig.AddTorque (-arCam.transform.up * 10 * Input.GetTouch (0).deltaPosition.x, ForceMode.Impulse);
//				rig.AddTorque (arCam.transform.right * 10 * Input.GetTouch (0).deltaPosition.y, ForceMode.Impulse);

			}
			if (Input.GetTouch (0).phase == TouchPhase.Ended) {
				isChecked = false;
			}
		}

		if (Application.isEditor) {
			if (Input.GetMouseButtonDown (0)) {
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				RaycastHit hit;

				if (Physics.Raycast (ray, out hit, 100)) {
					if (hit.transform.gameObject.tag == "Minion") {
						isChecked = true;
						startSwipePos = Input.mousePosition;
					}
				}

			}

			if (Input.GetMouseButton (0) && isChecked) {
				rig.AddTorque (arCam.transform.up * 10 * (startSwipePos.x - Input.mousePosition.x), ForceMode.Impulse);
//				rig.AddTorque (-arCam.transform.right * 10 * (startSwipePos.y - Input.mousePosition.y), ForceMode.Impulse);

				startSwipePos = Input.mousePosition;
			}
			if (Input.GetMouseButtonUp (0)) {
				isChecked = false;
			}
		}

    }
}
