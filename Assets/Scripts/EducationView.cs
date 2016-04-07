using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class EducationView : MonoBehaviour  
{
	public static EducationView instance;


	public GameObject Ipanel;
	public GameObject panelInfo;


	void Awake()
	{
		if (instance == null) {
			instance = this;
		}
	}

	void Update()
	{
		UserInput ();

	}


	public void UserInput()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast (ray, out hit, 100)) {
				if (hit.transform.gameObject.tag == "Information") {
					Debug.Log (hit.transform.gameObject.tag);
					OpenLotInfo ();

				}
			}
		}
	}

	public void OpenLotInfo()
	{
		Ipanel.SetActive(true);
		Ipanel.GetComponent<InfoPanel>().OpenPanel();
	}


	public void BackTo() 
	{
		Ipanel.GetComponent<InfoPanel>().ClosePanel();
		//Ipanel.GetComponent<PlayMovie> ().StopCoroutine ("Start");
		Ipanel.GetComponent<PlayMovie> ().enabled = false;
	}
}
