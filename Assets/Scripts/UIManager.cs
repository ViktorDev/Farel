using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour 
{
	public Material buis;
	public Material educ;
	public Material fun;
	public Material promo;

	public MeshRenderer main;

    void Start() {

        main = GameScene.instance.gameObject.transform.FindChild("Moon").GetComponent<MeshRenderer>();
    }

	public void BuisnessButtonClick()
	{
		main.material = buis;
	}

	public void EducationButtonClick()
	{
		main.material = educ;
	}

	public void FunButtonClick()
	{
		main.material = fun;
		GameScene.instance.StartGame ();
		GameScene.instance.score.SetActive (true);


	}

	public void PromotionButtonClick()
	{
		main.material = promo;
	}

	public void Quit()
	{
		Application.Quit();
	}
}
