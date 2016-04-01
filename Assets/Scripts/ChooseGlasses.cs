using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChooseGlasses : MonoBehaviour {

    public GameObject back;
    void Start()
    {
        back.GetComponent<MeshRenderer>().material.mainTexture = PromoView.instance.photo;
        back.GetComponent<MeshRenderer>().material.shader = Shader.Find("Sprites/Default");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) SceneManager.LoadScene(1);
    }
}
