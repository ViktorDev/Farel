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
        SceneManager.LoadScene(1);
        UIManager.instance.BuisnessButtonClick();
    }

    public void OpenEducationView()
    {
        SceneManager.LoadScene(1);
        UIManager.instance.EducationButtonClick();
    }
    public void OpenGameView()
    {
        SceneManager.LoadScene(1);
        UIManager.instance.FunButtonClick();
    }
    public void OpenAdvertsView()
    {
        SceneManager.LoadScene(1);
        UIManager.instance.PromotionButtonClick();
    }

    public void setGlass(Sprite glassIm)
    {
        glassImage.SetActive(true);
        glassImage.GetComponent<Image>().sprite = glassIm;
    }
}
