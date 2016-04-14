using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UInewManager : MonoBehaviour {


    public GameObject [] buttons;
    public GameObject buttonsPanel;
    public GameObject menuButton;

	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)) Application.Quit();
    }

    public void OpenInfoScene() {
        SceneStateManager.instance.ChangeState(0);
        CloseButtons();
    }

    public void OpenGameScene() {
        SceneStateManager.instance.ChangeState(1);
        CloseButtons();
    }

    public void OpenShopScene() {
        SceneStateManager.instance.ChangeState(2);
        CloseButtons();
    }

    public void OpenSelfieScene() {
        SceneStateManager.instance.ChangeState(3);
        CloseButtons();
    }

    public void SwitchSound() {

    }

    public void OpenButtons(){
       StartCoroutine(Open());
    }

    public void CloseButtons()
    {
        StartCoroutine(Close());
    }
    
    IEnumerator Open() {
        buttonsPanel.SetActive(true);
        menuButton.GetComponent<Button>().interactable = false;
        buttons[0].GetComponent<Button>().interactable = false;
        foreach (GameObject g in buttons)
        {
            
            g.SetActive(true);
            g.GetComponent<UIButton>().OpenButton();
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(0.5f);
        menuButton.GetComponent<Button>().interactable = true;
        buttons[0].GetComponent<Button>().interactable = true;
    }

    IEnumerator Close() {
        menuButton.GetComponent<Button>().interactable = false;
        buttons[0].GetComponent<Button>().interactable = false;
        foreach (GameObject g in buttons)
        {   
            g.GetComponent<UIButton>().CloseButton();
            yield return new WaitForSeconds(0.1f);
        }
        
        yield return new WaitForSeconds(0.5f);

        foreach (GameObject g in buttons)
        {
            g.SetActive(false);
        }
        buttonsPanel.SetActive(false);
        menuButton.GetComponent<Button>().interactable = true;
        buttons[0].GetComponent<Button>().interactable = true;
    }

   


}
