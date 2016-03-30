using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour {

	public GameObject progress;

    private AsyncOperation async = null;
    

	void Start () 
	{
        StartCoroutine(LoadALevel(1));
	}
	
	void Update () 
	{
        if (async != null)
        {
            progress.GetComponent<RectTransform>().localScale = new Vector3(async.progress, 1,1);
        }
	}


    IEnumerator loadMenuScreen()
    {
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadScene(1);
    }


    private IEnumerator LoadALevel(int levelName)
    {
        async = SceneManager.LoadSceneAsync(levelName);
        yield return async;
    }
}
