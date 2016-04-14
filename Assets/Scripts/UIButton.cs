using UnityEngine;
using System.Collections;

public class UIButton : MonoBehaviour {

    public float angle;
    float radius = 120;
    float currentRadius = 0;
    float scale = 0;
    public bool isCenter;
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
        while (currentRadius < radius) {
            if(!isCenter) gameObject.GetComponent<RectTransform>().localPosition = new Vector3(currentRadius * Mathf.Sin(angle * Mathf.Deg2Rad), currentRadius * Mathf.Cos(angle * Mathf.Deg2Rad), 0);
            transform.localScale = new Vector3(scale, scale, scale);
            currentRadius += 5;
            scale += 0.042f;
            yield return new WaitForSeconds(0.01f);
        }

        if (!isCenter) gameObject.GetComponent<RectTransform>().localPosition = new Vector3(radius * Mathf.Sin(angle * Mathf.Deg2Rad), radius * Mathf.Cos(angle * Mathf.Deg2Rad), 0);
        gameObject.transform.localScale = new Vector3(1, 1, 1);
        scale = 1;
    }

    IEnumerator Close() {

        while (currentRadius>0)
        {
            if (!isCenter) gameObject.GetComponent<RectTransform>().localPosition = new Vector3(currentRadius * Mathf.Sin(angle * Mathf.Deg2Rad), currentRadius * Mathf.Cos(angle * Mathf.Deg2Rad), 0);
            transform.localScale = new Vector3(scale, scale, scale);
            currentRadius -= 5;
            scale -= 0.042f;
            yield return new WaitForSeconds(0.01f);
        }
        if (!isCenter) gameObject.GetComponent<RectTransform>().localPosition = new Vector3(0 , 0 , 0);
        gameObject.transform.localScale = new Vector3(0, 0, 0);
        scale = 0;
    }
}
