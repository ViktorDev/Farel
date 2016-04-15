using UnityEngine;
using System.Collections;

public class UIShopPanel : MonoBehaviour {

    public GameObject[] modeButtons;
    public Sprite glassEnable;
    public Sprite glassDisable;
    public Sprite headEnable;
    public Sprite headDisable;
    public Sprite wearEnable;
    public Sprite wearDisable;
    public Sprite moustacheEnable;
    public Sprite moustacheDisable;
    GameObject selectedButton;
	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void Update () {
	
	}

    public void ShowButtons() {
        StartCoroutine(Show());
    }

    public void HideButtons() {
        StartCoroutine(Hide());
    }

    public void GlassSelect() {

    }

    public void HeadSelect() {

    }

    public void MoustacheSelect() {

    }

    public void WearSelect() {

    }

    IEnumerator Show() {

        foreach (GameObject g in modeButtons)
        {
            g.SetActive(true);
            g.GetComponent<UIButton>().OpenButton();
            yield return new WaitForSeconds(0.1f);
        }

    }

    IEnumerator Hide() {

        foreach (GameObject g in modeButtons)
        {
            g.GetComponent<UIButton>().CloseButton();
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
    }


}
