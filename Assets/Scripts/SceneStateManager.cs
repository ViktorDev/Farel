using UnityEngine;
using UnityEngine.UI;
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
        DontDestroyOnLoad(this);
	}

    //void OnEnable() {
    //    curentManager.SetActive(true);
    //}
	public void ChangeState(int stateID)
	{
		curentManager.SetActive (false);
		curentManager = managers [stateID];
		curentManager.SetActive (true);
	}

    void OnDisable()
    {
        curentManager.SetActive(false);
    }
	public void Show()
	{
		
	}

	public void Hide()
	{
		
	}
}
