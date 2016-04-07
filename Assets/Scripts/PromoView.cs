using UnityEngine;
using Vuforia;

public class PromoView : MonoBehaviour {

    public static PromoView instance;
    public GameObject promoPanel;
    GameObject selfiePanel;
///    public bool isFront;
    GameObject moon;
    GameObject promoText;
    GameObject openSelfieBut;
    GameObject target;
    
    void Awake() {
        if (instance == null)
        {
            instance = this;          
        }
        moon = transform.Find("moon_real").gameObject;
        promoText = promoPanel.transform.Find("PromoText").gameObject;
        openSelfieBut = promoPanel.transform.Find("OpenSelfiePanel").gameObject;
        selfiePanel = promoPanel.transform.Find("SelfiePanel").gameObject;
        target = GameObject.Find("ImageTarget");
    }

    public void OpenSelfiePanel() {
        CameraDevice.Instance.Stop();
        CameraDevice.Instance.Init(CameraDevice.CameraDirection.CAMERA_FRONT);
        CameraDevice.Instance.Start();
        SceneStateManager.instance.isSelfieMode = true;
 //       isFront = true;
        openSelfieBut.SetActive(false);
        selfiePanel.SetActive(true);
        moon.SetActive(false);
        promoText.SetActive(false);
//        target.SetActive(false);
    }

    public void Back() {
        CameraDevice.Instance.Stop();
        CameraDevice.Instance.Init(CameraDevice.CameraDirection.CAMERA_DEFAULT);
        CameraDevice.Instance.Start();
        SceneStateManager.instance.isSelfieMode = false;
 //       isFront = false;
        openSelfieBut.SetActive(true);
        selfiePanel.SetActive(false);
        moon.SetActive(true);
        promoText.SetActive(true);
 //       target.SetActive(true);
    }

    void OnDisable()
    {
        if (SceneStateManager.instance.isSelfieMode) {
            Back();
        }
    }

    public void Show () {
        promoPanel.SetActive(true);
    }
	
	public void Hide () {
        promoPanel.SetActive(false);
    }
}
