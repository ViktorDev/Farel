using UnityEngine;
using System.Collections;

public class PromoView : MonoBehaviour {

    public static PromoView instance;
    public Texture2D photo;

    void Awake() {
        if (instance == null)
        {
            instance = this;
        }
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
