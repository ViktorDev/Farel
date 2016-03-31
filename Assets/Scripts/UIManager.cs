using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour 
{
	/*public Material buis;
	public Material educ;
	public Material fun;
	public Material promo;*/

	public MeshRenderer main;

    void Awake() {

      //  main = GameScene.instance.gameObject.transform.FindChild("moon").GetComponent<MeshRenderer>();
    }

	public void BuisnessButtonClick()
	{
		StateManager.instance.ChangeState (0);
	}

	public void EducationButtonClick()
	{
		StateManager.instance.ChangeState (1);
	}

	public void FunButtonClick()
	{
		StateManager.instance.ChangeState (2);
		GameScene.instance.StartGame ();
		GameScene.instance.score.SetActive (true);


	}

	public void PromotionButtonClick()
	{
		StateManager.instance.ChangeState (3);
	}

	public void Quit()
	{
		Application.Quit();
	}
}
