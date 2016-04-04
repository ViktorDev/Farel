using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GlassGalaryItem : MonoBehaviour {


    bool isClicked;
    public bool isButtonClicked;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void setGlass() {
         if (isButtonClicked) {
            if (!isClicked)
            {
                Sprite im = gameObject.GetComponent<Image>().sprite;
                GameObject.Find("SceneManager").GetComponent<ChooseGlasses>().setGlass(im);
                isClicked = true;
            }
            else {
                isClicked = false;
            }
        }
        
    }
}
