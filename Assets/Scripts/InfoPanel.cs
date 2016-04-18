using UnityEngine;
using System.Collections;

public class InfoPanel : MonoBehaviour 
{
    //	public RectTransform panel;
    EducationView manager;

    void Start() {
        manager = GameObject.Find("InfoManager").GetComponent<EducationView>();
    }

   public void OpenPanel() 
	{
        
        StartCoroutine(Open());
    }

	public void ClosePanel() 
	{
        StartCoroutine(Close(false));      
    }

    public void ShowVideo() {
        StartCoroutine(Close(true));
    }

	IEnumerator Open() {
        
        while (transform.localScale.y < 1f) {
            transform.localScale = new Vector3(1, transform.localScale.y + 0.05f, 1);
			yield return new WaitForSeconds(0.01f);
		}
        transform.localScale = new Vector3(1, 1f, 1);

        
    }

	IEnumerator Close(bool video)
	{
        while (transform.localScale.y > 0)
		{
            transform.localScale = new Vector3(1, transform.localScale.y - 0.05f, 1);
			yield return new WaitForSeconds(0.01f);
		}
        transform.localScale = new Vector3(1, 0, 1);       
        gameObject.SetActive(false);
        manager.tv.SetActive(true);

        if (video) manager.tv.GetComponent<TV>().ShowTv();
        else manager.infoPanels.SetActive(true);
    }
}
