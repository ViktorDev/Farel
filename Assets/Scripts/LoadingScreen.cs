using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour {

	public Text loadText;
	public int counter = 0;     
	public AsyncOperation loadOp;



	void Start()    
	{   
		loadText.GetComponent<Text> ();
		loadOp = Application.LoadLevelAsync(1);    
	}
	void LateUpdate()    
	{    
		loadText.text =  "Loading " + (loadOp.progress * 100).ToString() + "%";    
		counter++;    
	}    
}
