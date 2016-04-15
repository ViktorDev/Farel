using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIButton : MonoBehaviour {

    public float angle;
    public float radius = 300;
    float currentRadius = 0;
    float scale = 0;
//    public bool isCenter;
    public float scaleStep;
    public float moveStep;
    // Use this for initialization
    void Start () {
//        gameObject.GetComponent<RectTransform>().localPosition = new Vector3(currentRadius * Mathf.Sin(angle*Mathf.Deg2Rad), currentRadius * Mathf.Cos(angle * Mathf.Deg2Rad), 0);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OpenButton() {
       StartCoroutine(Open());
    }

    public void CloseButton()
    {
        StartCoroutine(Close());
    }
    
    IEnumerator Open() {
        
        while (scale < 1) {
            if(moveStep!=0) gameObject.GetComponent<RectTransform>().localPosition = new Vector3(currentRadius * Mathf.Sin(angle * Mathf.Deg2Rad), currentRadius * Mathf.Cos(angle * Mathf.Deg2Rad), 0);
            transform.localScale = new Vector3(scale, scale, scale);
            currentRadius += moveStep;
            scale += scaleStep;
            yield return new WaitForSeconds(0.01f);
        }

        if (moveStep != 0) gameObject.GetComponent<RectTransform>().localPosition = new Vector3(radius * Mathf.Sin(angle * Mathf.Deg2Rad), radius * Mathf.Cos(angle * Mathf.Deg2Rad), 0);
        gameObject.transform.localScale = new Vector3(1, 1, 1);
        scale = 1;
        GetComponent<Button>().interactable = true;
    }

    IEnumerator Close() {
        GetComponent<Button>().interactable = false;
        while (scale > 0)
        {
            if (moveStep != 0) gameObject.GetComponent<RectTransform>().localPosition = new Vector3(currentRadius * Mathf.Sin(angle * Mathf.Deg2Rad), currentRadius * Mathf.Cos(angle * Mathf.Deg2Rad), 0);
            transform.localScale = new Vector3(scale, scale, scale);
            currentRadius -= moveStep;
            scale -= scaleStep;
            yield return new WaitForSeconds(0.01f);
        }
        if (moveStep != 0) gameObject.GetComponent<RectTransform>().localPosition = new Vector3(0 , 0 , 0);
        gameObject.transform.localScale = new Vector3(0, 0, 0);
        scale = 0;
        gameObject.SetActive(false);
    }
}
