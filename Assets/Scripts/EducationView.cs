using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class EducationView : MonoBehaviour  
{
	public static EducationView instance;


	public GameObject Ipanel;
	public GameObject panelInfo;

	public List<GameObject> infoPanels;

	void Awake()
	{
		if (instance == null) 
		{
			instance = this;
		}



	/*	for (int i = 0; i < infoPanels.Count; i++) 
		{
			infoPanels [i].SetActive (true);	
		}*/
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
				if (hit.transform.gameObject.tag == "Lot") {
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

	/*public void Show()
	{
		//GameScene.instance.score.SetActive (false);
		StartCoroutine (ColorChengerUp ());
	}

	IEnumerator ColorChengerUp ()
	{
		float a = 0;
		while (a < 1) 
		{
			foreach (var item in infoPanels) 
			
			{
				item.SetActive (true);
				Color c = item.GetComponent<Image> ().color;
				item.GetComponent<Image> ().color = new Color (c.r, c.g, c.b, a);
			}
			a += 0.1f; 
			yield return new WaitForSeconds (0.03f);
		}
		a = 1;
	}

	public void Hide()
	{
		foreach (var item in infoPanels) 
		{
			item.SetActive (false);
		}
	}

	public void OpenInfo(Text panel) 
	{
		Hide ();
		Ipanel.SetActive(true);
		Ipanel.GetComponent<InfoPanel>().OpenPanel();
		panelInfo.GetComponent<Text> ().text = panel.text;
	}*/

	public void BackTo() 
	{
		Ipanel.GetComponent<InfoPanel>().ClosePanel();
		//Show ();
	}
}
