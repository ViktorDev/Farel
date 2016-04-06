using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChooseGlasses : MonoBehaviour {

    public GameObject back;
    public GameObject glassImage;
    public GameObject scrollPanel;
    void Start()
    {
        back.GetComponent<MeshRenderer>().material.mainTexture = PromoView.instance.photo;
        back.GetComponent<MeshRenderer>().material.shader = Shader.Find("Sprites/Default");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) SceneManager.LoadScene(1);
       
    }

   public void OpenBuisnesView() {
        SceneStateManager.instance.curentManager = SceneStateManager.instance.managers[2];
        SceneManager.LoadScene(1);
       
    }

    public void OpenEducationView()
    {
        SceneStateManager.instance.curentManager = SceneStateManager.instance.managers[0];
        SceneManager.LoadScene(1);
        
    }
    public void OpenGameView()
    {
        SceneStateManager.instance.curentManager = SceneStateManager.instance.managers[1];
        SceneManager.LoadScene(1);
       
    }
    public void OpenAdvertsView()
    {
        SceneStateManager.instance.curentManager = SceneStateManager.instance.managers[3];
        SceneManager.LoadScene(1);
        
    }

    public void setGlass(Sprite glassIm)
    {
        glassImage.SetActive(true);
        glassImage.GetComponent<Image>().sprite = glassIm;
    }
}
