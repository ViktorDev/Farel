using UnityEngine;
using System.Collections;

public class BuyLotPanel : MonoBehaviour {

      public RectTransform panel;
 //   GameObject panel;
	// Use this for initialization
	void Start () {
 //       panel = GetComponentInChildren<RectTransform>();
    }

    //void Awake() {
    //    OpenPanel();
    //}

    public void OpenPanel() {
        StartCoroutine(Open());
    }

    public void ClosePanel() {
        StartCoroutine(Close());
    }

    IEnumerator Open() {
        while (panel.localScale.y < 1) {
            panel.localScale = new Vector3(1, panel.localScale.y+0.05f, 1);
            yield return new WaitForSeconds(0.01f);
        }
        panel.localScale = new Vector3(1, 1, 1);
    }

    IEnumerator Close()
    {
        while (panel.localScale.y>0)
        {
            panel.localScale = new Vector3(1, panel.localScale.y - 0.05f, 1);
            yield return new WaitForSeconds(0.01f);
        }
        panel.localScale = new Vector3(1, 0, 1);
        gameObject.SetActive(false);
    }
}
