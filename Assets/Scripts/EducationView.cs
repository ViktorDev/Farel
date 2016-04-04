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
	}

	public void Show()
	{
		GameScene.instance.ScoreImage.enabled = false;
		GameScene.instance.score.SetActive (false);
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
	}

	public void BackTo() 
	{
		Ipanel.GetComponent<InfoPanel>().ClosePanel();
		Show ();
	}
}
