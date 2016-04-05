﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Vuforia;

public class PromoView : MonoBehaviour {

    public static PromoView instance;

	public GameObject promoText;
    public Texture2D photo;
    public GameObject selfiePanel;
    bool isFront;
    GameObject moon;

    void Awake() {
        if (instance == null)
        {
            instance = this;
        }
        moon = transform.Find("moon_real").gameObject;
		promoText.GetComponent<Text> ();

    }


    public void swichCam() {
        CameraDevice.Instance.Stop();
        if (!isFront)
        {
            CameraDevice.Instance.Init(CameraDevice.CameraDirection.CAMERA_FRONT);
            isFront = true;
            selfiePanel.transform.Find("Face").gameObject.SetActive(true);
            selfiePanel.transform.Find("Takeselfie").gameObject.SetActive(true);
            moon.SetActive(false);
        }
        else {
            CameraDevice.Instance.Init(CameraDevice.CameraDirection.CAMERA_DEFAULT);
            isFront = false;
            selfiePanel.transform.Find("Face").gameObject.SetActive(false);
            selfiePanel.transform.Find("Takeselfie").gameObject.SetActive(false);
            moon.SetActive(true);
        }
        CameraDevice.Instance.Start();
    }

	public void Show () {
        selfiePanel.SetActive(true);
		promoText.SetActive(true);
    }
	
	public void Hide () {
        selfiePanel.SetActive(false);
		promoText.SetActive(false);

    }
}
