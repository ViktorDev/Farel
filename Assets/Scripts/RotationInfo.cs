using UnityEngine;
using System.Collections.Generic;

public class RotationInfo : MonoBehaviour 
{
	
	public List<GameObject> text;
	public Transform obj;
	public Transform obj1;
	public Transform obj2;
	public Transform obj3;

	public Transform moon;
	public LineRenderer line;
	public LineRenderer line1;
	public LineRenderer line2;
	public LineRenderer line3;

	GameObject arCam;

	void Start () 
	{
		line.SetVertexCount (2);
		line1.SetVertexCount (2);
		line2.SetVertexCount (2);
		line3.SetVertexCount (2);
		arCam = GameObject.Find("ARCamera");

	}
	
	void Update () 
	{
		foreach (var item in text) {
			item.transform.rotation = Quaternion.LookRotation (transform.position - arCam.transform.position);

		}
		transform.rotation = moon.transform.rotation;

		line.SetPosition (0,moon.transform.position);
		line.SetPosition (1, obj.transform.position);
		line1.SetPosition (0,moon.transform.position);
		line1.SetPosition (1,obj1.transform.position);
		line2.SetPosition (0,moon.transform.position);
		line2.SetPosition (1,obj2.transform.position);
		line3.SetPosition (0,moon.transform.position);
		line3.SetPosition (1,obj3.transform.position);
	}
}
