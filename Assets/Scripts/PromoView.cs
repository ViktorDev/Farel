using UnityEngine;
using Vuforia;

public class PromoView : MonoBehaviour {

    public static PromoView instance;
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
        promoText = promoPanel.transform.Find("PromoText").gameObject;
        openSelfieBut = promoPanel.transform.Find("OpenSelfiePanel").gameObject;
        selfiePanel = promoPanel.transform.Find("SelfiePanel").gameObject;
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

    void OnDisable() {
        if (isFront) Back();  
    }

	public void Show () {
        promoPanel.SetActive(true);
    }
	
	public void Hide () {
        promoPanel.SetActive(false);
    }
}
