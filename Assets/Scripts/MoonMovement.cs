using UnityEngine;
using System.Collections;

public class MoonMovement : MonoBehaviour 
{

    GameObject arCam;
    GameObject shadow;
	void Start () 
	{
        arCam = GameObject.Find("ARCamera");
        shadow = transform.Find("Shadow").gameObject;
	}
	
	void Update () 
	{
		transform.Rotate(Vector3.up * Time.deltaTime * 3);
        shadow.transform.rotation = Quaternion.LookRotation(transform.position - arCam.transform.position);

    }
}
