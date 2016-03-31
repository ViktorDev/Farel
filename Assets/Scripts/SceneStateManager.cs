using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SceneStateManager : MonoBehaviour 
{
	public static SceneStateManager instance;

	public List<GameObject> managers;

	public GameObject curentManager;

	void Awake () 
	{
		if (instance == null) 
		{
			instance = this;
		}
	}

	public void ChangeState(int stateID)
	{
		curentManager.SetActive (false);
		curentManager = managers [stateID];
		curentManager.SetActive (true);
	}

	public void Show()
	{
		
	}

	public void Hide()
	{
		
	}
}
