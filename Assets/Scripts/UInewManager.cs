using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UInewManager : MonoBehaviour {

    public MinionStateChanger minion;

    public GameObject [] buttons;
    public GameObject buttonsPanel;
    public GameObject menuButton;
    public GameObject soundButton;
    public GameObject selfiePanel;
    public GameObject galaryPanel;

    public Sprite soundOn;
    public Sprite soundOff;
    public Sprite menu;
    public Sprite menuExit;
    AudioSource source;

	void Start () {
        source = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)) Application.Quit();
    }

    public void OpenInfoScene() {
        SceneStateManager.instance.ChangeState(1);
        minion.SetDefaultClothes();
        CloseButtons();
    }

    public void OpenGameScene() {
        SceneStateManager.instance.ChangeState(2);
        minion.SetGameClothes();
        CloseButtons();
    }

    public void OpenShopScene() {
        SceneStateManager.instance.ChangeState(3);
        minion.SetShopState();
        CloseButtons();
    }

    public void OpenSelfieScene() {
        SceneStateManager.instance.ChangeState(4);
        CloseButtons();
    }

    public void OpenGalaryscene() {
        selfiePanel.SetActive(false);
        galaryPanel.SetActive(true);
    }



    public void SwitchSound() {
        if (source.mute)
        {
            source.mute = false;
            soundButton.GetComponent<Image>().sprite = soundOn;
        }
        else {
            source.mute = true;
            soundButton.GetComponent<Image>().sprite = soundOff;
        }
    }

    public void SwitchMenu() {
        if (buttonsPanel.activeSelf)
        {
            StartCoroutine(Close());
            menuButton.GetComponent<Image>().sprite = menu;
        }
        else {
            StartCoroutine(Open());
            menuButton.GetComponent<Image>().sprite = menuExit;
        }
    }

    public void OpenButtons(){

       StartCoroutine(Open());
       menuButton.GetComponent<Image>().sprite = menuExit;
    }

    public void CloseButtons()
    {
        StartCoroutine(Close());
        menuButton.GetComponent<Image>().sprite = menu;
    }
    
    IEnumerator Open() {
        buttonsPanel.SetActive(true);
        menuButton.GetComponent<Button>().interactable = false;
        //        buttons[0].GetComponent<Button>().interactable = false;
        for (int i = 1; i < buttons.Length; i++) { 

                buttons[i].SetActive(true);
                buttons[i].GetComponent<UIButton>().OpenButton();
            yield return new WaitForSeconds(0.08f);
        }
        yield return new WaitForSeconds(0.2f);
        menuButton.GetComponent<Button>().interactable = true;
        buttons[0].GetComponent<Button>().interactable = true;
    }

    IEnumerator Close() {
        menuButton.GetComponent<Button>().interactable = false;
        buttons[0].GetComponent<Button>().interactable = false;

        for (int i = 1; i < buttons.Length; i++) {
            buttons[i].GetComponent<UIButton>().CloseButton();
            yield return new WaitForSeconds(0.08f);
        }

//        buttons[0].GetComponent<UIButton>().CloseButton();
        //foreach (GameObject g in buttons)
        //{   
        //    g.GetComponent<UIButton>().CloseButton();
        //    yield return new WaitForSeconds(0.1f);
        //}
        
        yield return new WaitForSeconds(0.2f);

        buttonsPanel.SetActive(false);
        menuButton.GetComponent<Button>().interactable = true;
//        buttons[0].GetComponent<Button>().interactable = true;
    }

   


}
