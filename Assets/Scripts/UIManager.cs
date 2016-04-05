using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour 
{
    public static UIManager instance;
    public EducationView educ;
    public PromoView promo;
//    public GameObject selfiePanel;

    void Awake() {
        if (instance == null)
        {
            instance = this;
        }
    }

	public void BuisnessButtonClick()
	{
		SceneStateManager.instance.ChangeState (0);

		educ.Hide ();
		promo.Hide();

    }

	public void EducationButtonClick()
	{
		promo.Hide();

		SceneStateManager.instance.ChangeState (1);

		educ.Show ();
    }

	public void FunButtonClick()
	{
		
		SceneStateManager.instance.ChangeState (2);
		GameScene.instance.StartGame ();
		GameScene.instance.score.SetActive (true);
		GameScene.instance.ScoreImage.enabled = true;

		educ.Hide ();
		promo.Hide();
    }

	public void PromotionButtonClick()
	{
		promo.Show();

		SceneStateManager.instance.ChangeState (3);
		educ.Hide ();
        //        SceneManager.LoadScene(2);
    }

	public void Quit()
	{
		Application.Quit();
	}
}
