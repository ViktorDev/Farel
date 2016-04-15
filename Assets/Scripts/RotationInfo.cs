﻿using UnityEngine;
using System.Collections.Generic;

public class RotationInfo : MonoBehaviour 
{
	
	public List<GameObject> text;
	public List<LineRenderer> lines;

	public Transform moon;

	LineRenderer line;

	GameObject arCam;

	void Start () 
	{
		arCam = GameObject.Find("ARCamera");
        if (SceneStateManager.instance.curentManager.name == "InfoManager")
        {
            foreach (var item in text)
            {
                line = item.gameObject.AddComponent<LineRenderer>();
                line.SetWidth(0.02f, 0.02f);
                line.SetVertexCount(2);
                lines.Add(line);
            }


//            lines[0].material = Resources.Load("Buisness") as Material;
 //           lines[1].material = Resources.Load("Education") as Material;
//            lines[2].material = Resources.Load("Fun") as Material;
 //           lines[3].material = Resources.Load("Promotion") as Material;
        }
           
	}
	
	void Update () 
	{
        if (SceneStateManager.instance.curentManager.name == "InfoManager") {
            foreach (var item in text)
            {
                item.transform.rotation = Quaternion.LookRotation(transform.position - arCam.transform.position);
                line = item.gameObject.GetComponent<LineRenderer>();
                line.SetPosition(0, moon.transform.position);
                line.SetPosition(1, item.transform.GetChild(1).position);
                line.material = Resources.Load("Education") as Material;
               
            }
        }
		transform.rotation = moon.transform.rotation;
	}
}
