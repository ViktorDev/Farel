using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EducationView : MonoBehaviour 
{
	public static EducationView instance1;

	public GameObject panel;

	void Start () 
	{
		if (instance1 == null) {
			instance1 = this;
		}

		//panel.SetActive (false);
	
	}
	
	public void Show ()
	{
	//	panel.SetActive (true);
	}
}
