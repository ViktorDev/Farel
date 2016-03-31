using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class EducationView : MonoBehaviour 
{

	public List<GameObject> infoPanels;


	public void Show()
	{
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
}
