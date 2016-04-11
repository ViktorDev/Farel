using UnityEngine;
using System.Collections.Generic;

public class RotationInfo : MonoBehaviour 
{
	
	public List<GameObject> text;
	public Transform moon;

	LineRenderer line;


	GameObject arCam;

	void Start () 
	{
		arCam = GameObject.Find("ARCamera");

		foreach (var item in text) 
		{
			line = item.gameObject.AddComponent<LineRenderer>();
			line.material = Resources.Load("Buisness") as Material;
			line.SetWidth (0.1f, 0.1f);
			line.SetVertexCount (2);

		}
	}
	
	void Update () 
	{
		foreach (var item in text) {
			item.transform.rotation = Quaternion.LookRotation (transform.position - arCam.transform.position);
			line = item.gameObject.GetComponent<LineRenderer> ();
			line.SetPosition (0, moon.transform.position);
			line.SetPosition (1, item.transform.GetChild(1).position);
		}
		transform.rotation = moon.transform.rotation;
	}
}
