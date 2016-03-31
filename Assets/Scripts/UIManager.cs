using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour 
{
	public MeshRenderer main;

	public EducationView educ;

    void Awake() {

    }

	public void BuisnessButtonClick()
	{
		SceneStateManager.instance.ChangeState (0);
		educ.Hide ();
	}

	public void EducationButtonClick()
	{
		SceneStateManager.instance.ChangeState (1);
		educ.Show ();


	}

	public void FunButtonClick()
	{
		
		SceneStateManager.instance.ChangeState (2);
		GameScene.instance.StartGame ();
		GameScene.instance.score.SetActive (true);
		educ.Hide ();
	}

	public void PromotionButtonClick()
	{
		
		SceneStateManager.instance.ChangeState (3);
		educ.Hide ();
	}

	public void Quit()
	{
		Application.Quit();
	}
}
