using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour 
{
	public MeshRenderer main;

    void Awake() {

    }

	public void BuisnessButtonClick()
	{
		SceneStateManager.instance.ChangeState (0);
	}

	public void EducationButtonClick()
	{
		SceneStateManager.instance.ChangeState (1);
		foreach (var item in SceneStateManager.instance.infoPanels) 
		{
			item.SetActive (true);	
		}
	}

	public void FunButtonClick()
	{
		SceneStateManager.instance.ChangeState (2);
		GameScene.instance.StartGame ();
		GameScene.instance.score.SetActive (true);
	}

	public void PromotionButtonClick()
	{
		SceneStateManager.instance.ChangeState (3);
	}

	public void Quit()
	{
		Application.Quit();
	}
}
