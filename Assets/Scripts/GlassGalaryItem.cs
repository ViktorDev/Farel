using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GlassGalaryItem : MonoBehaviour {

    
    public bool isButtonClicked;

	private bool isClicked;
    
	public void SetGlass() {
         if (isButtonClicked) {
            if (!isClicked)
            {
                Sprite im = gameObject.GetComponent<Image>().sprite;
                GameObject.Find("SelfieManager").GetComponent<CapturePhotoScene>().setGlass(im);
                isClicked = true;
            }
            else {
                isClicked = false;
            }
        }
        
    }
}
