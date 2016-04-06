using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Vuforia;

public class PromoView : MonoBehaviour {

    public static PromoView instance;
    public Texture2D photo;
    public GameObject promoPanel;
    GameObject selfiePanel;
    bool isFront;
    GameObject moon;
    GameObject promoText;
    GameObject openSelfieBut;

    


    void Awake() {
        if (instance == null)
        {
            instance = this;          
        }
        moon = transform.Find("moon_real").gameObject;
//        takeSelfieBut = promoPanel.transform.Find("Takeselfie").gameObject;
//        backBut = promoPanel.transform.Find("Back").gameObject;
//        face = promoPanel.transform.Find("Face").gameObject;
        promoText = promoPanel.transform.Find("PromoText").gameObject;
        openSelfieBut = promoPanel.transform.Find("OpenSelfiePanel").gameObject;
        selfiePanel = promoPanel.transform.Find("SelfiePanel").gameObject;
        //		promoText.GetComponent<Text> ();

    }

    public void OpenSelfiePanel() {
        CameraDevice.Instance.Stop();
        CameraDevice.Instance.Init(CameraDevice.CameraDirection.CAMERA_FRONT);
        CameraDevice.Instance.Start();
        isFront = true;
        openSelfieBut.SetActive(false);
        selfiePanel.SetActive(true);
        moon.SetActive(false);
        promoText.SetActive(false);
        
    }

    public void Back() {
        CameraDevice.Instance.Stop();
        CameraDevice.Instance.Init(CameraDevice.CameraDirection.CAMERA_DEFAULT);
        CameraDevice.Instance.Start();
        isFront = false;
        openSelfieBut.SetActive(true);
        selfiePanel.SetActive(false);
        moon.SetActive(true);
        promoText.SetActive(true);    
    }


    //public void swichCam() {
    //    CameraDevice.Instance.Stop();
    //    if (!isFront)
    //    {
    //        CameraDevice.Instance.Init(CameraDevice.CameraDirection.CAMERA_FRONT);
    //        isFront = true;
    //        selfiePanel.transform.Find("Face").gameObject.SetActive(true);
    //        selfiePanel.transform.Find("Takeselfie").gameObject.SetActive(true);
    //        moon.SetActive(false);
    //        promoText.SetActive(false);
    //    }
    //    else {
    //        CameraDevice.Instance.Init(CameraDevice.CameraDirection.CAMERA_DEFAULT);
    //        isFront = false;
    //        selfiePanel.transform.Find("Face").gameObject.SetActive(false);
    //        selfiePanel.transform.Find("Takeselfie").gameObject.SetActive(false);
    //        moon.SetActive(true);
    //        promoText.SetActive(true);
    //    }
    //    CameraDevice.Instance.Start();
    //}

    void OnDisable() {
        if (isFront) Back();  
    }

	public void Show () {
        promoPanel.SetActive(true);
//		promoText.SetActive(true);
    }
	
	public void Hide () {
        promoPanel.SetActive(false);
//		promoText.SetActive(false);

    }
}
