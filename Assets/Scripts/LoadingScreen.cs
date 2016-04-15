using UnityEngine;
using System.Collections;
//using Facebook.Unity;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour {

    private AsyncOperation async = null;
    public GameObject progress;
	// Use this for initialization
	void Start () {
//        FB.Init(InitCallback, OnHideUnity);
        //       StartCoroutine(loadMenuScreen());
        StartCoroutine(LoadALevel(1));

	}
	
	// Update is called once per frame
	void Update () {
        if (async != null)
        {
            progress.GetComponent<RectTransform>().localScale = new Vector3(async.progress, 1,1);
//            GUI.DrawTexture(Rect(0, 0, 100, 50), emptyProgressBar);
//            GUI.DrawTexture(Rect(0, 0, 100 * async.progress, 50), fullProgressBar);
        }
	}

    //private void InitCallback()
    //{
    //    FB.ActivateApp();

    //}

    //private void OnHideUnity(bool isGameShown)
    //{
    //    if (!isGameShown)
    //    {
    //        Time.timeScale = 0;
    //    }
    //    else
    //    {
    //        Time.timeScale = 1;
    //    }
    //}

    IEnumerator loadMenuScreen()
    {
        yield return new WaitForSeconds(0.3f);
 //       Application.LoadLevel(1);
        SceneManager.LoadScene(1);
    }


    private IEnumerator LoadALevel(int levelName)
    {
        async = SceneManager.LoadSceneAsync(levelName);
        yield return async;
    }
}
