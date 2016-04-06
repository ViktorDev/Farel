using UnityEngine;
using System.Collections.Generic;

public class RotationInfo : MonoBehaviour 
{
	
	public List<GameObject> text;

	public Transform moon;

	GameObject arCam;

	void Start () 
	{
		arCam = GameObject.Find("ARCamera");

	}
	
	void Update () 
	{
		foreach (var item in text) {
			item.transform.rotation = Quaternion.LookRotation (transform.position - arCam.transform.position);
		}
		transform.rotation = moon.transform.rotation;
	}
}
