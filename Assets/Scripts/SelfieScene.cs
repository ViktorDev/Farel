using UnityEngine;
using Vuforia;

public class SelfieScene : MonoBehaviour {

    public static SelfieScene instance;
    
//	public GameObject promoPanel;

	public GameObject selfiePanel;
//    GameObject moon;
 //   GameObject promoText;
//    GameObject openSelfieBut;
   // GameObject target;
    
    void Awake() {
        if (instance == null)
        {
            instance = this;          
        }
//		moon = transform.Find("moon_real_hd_atlas").gameObject;
//        promoText = promoPanel.transform.Find("PromoText").gameObject;
 //       openSelfieBut = promoPanel.transform.Find("OpenSelfiePanel").gameObject;
//        selfiePanel = promoPanel.transform.Find("SelfiePanel").gameObject;
       // target = GameObject.Find("ImageTarget");
    }

    void OnEnable() {
        CameraDevice.Instance.Stop();
        CameraDevice.Instance.Init(CameraDevice.CameraDirection.CAMERA_FRONT);
        CameraDevice.Instance.Start();
        SceneStateManager.instance.isSelfieMode = true;
//        openSelfieBut.SetActive(false);
        selfiePanel.SetActive(true);
//        moon.SetActive(false);
//        promoText.SetActive(false);
    }


    //public void OpenSelfiePanel() {
    //    CameraDevice.Instance.Stop();
    //    CameraDevice.Instance.Init(CameraDevice.CameraDirection.CAMERA_FRONT);
    //    CameraDevice.Instance.Start();
    //    SceneStateManager.instance.isSelfieMode = true;
    //    openSelfieBut.SetActive(false);
    //    selfiePanel.SetActive(true);
    //    moon.SetActive(false);
    //    promoText.SetActive(false);
    //}

    //public void Back() {
    //    CameraDevice.Instance.Stop();
    //    CameraDevice.Instance.Init(CameraDevice.CameraDirection.CAMERA_DEFAULT);
    //    CameraDevice.Instance.Start();
    //    SceneStateManager.instance.isSelfieMode = false;
    //    openSelfieBut.SetActive(true);
    //    selfiePanel.SetActive(false);
    //    moon.SetActive(true);
    //    promoText.SetActive(true);
    //}

    void OnDisable()
    {
        CameraDevice.Instance.Stop();
        CameraDevice.Instance.Init(CameraDevice.CameraDirection.CAMERA_DEFAULT);
        CameraDevice.Instance.Start();
        SceneStateManager.instance.isSelfieMode = false;
 //       openSelfieBut.SetActive(true);
        selfiePanel.SetActive(false);
//        moon.SetActive(true);
//        promoText.SetActive(true);
    }

 //   public void Show () {
 //       promoPanel.SetActive(true);
 //   }
	
	//public void Hide () {
 //       promoPanel.SetActive(false);
 //   }
}
