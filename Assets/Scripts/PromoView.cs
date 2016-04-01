using UnityEngine;
using System.Collections;
using Vuforia;

public class PromoView : MonoBehaviour {

    public static PromoView instance;
    public Texture2D photo;
    public GameObject selfiePanel;
    bool isFront;

    void Awake() {
        if (instance == null)
        {
            instance = this;
        }
        
    }

    void OnDisable()
    {
        
    }

    public void swichCam() {
        CameraDevice.Instance.Stop();
        if (!isFront)
        {
            CameraDevice.Instance.Init(CameraDevice.CameraDirection.CAMERA_FRONT);
            isFront = true;
            selfiePanel.transform.Find("Face").gameObject.SetActive(true);
            selfiePanel.transform.Find("Takeselfie").gameObject.SetActive(true);
        }
        else {
            CameraDevice.Instance.Init(CameraDevice.CameraDirection.CAMERA_DEFAULT);
            isFront = false;
            selfiePanel.transform.Find("Face").gameObject.SetActive(false);
            selfiePanel.transform.Find("Takeselfie").gameObject.SetActive(false);
        }
        CameraDevice.Instance.Start();
    }
	// Use this for initialization
	public void Show () {
        selfiePanel.SetActive(true);
    }
	
	// Update is called once per frame
	public void Hide () {
        selfiePanel.SetActive(false);
    }
}
