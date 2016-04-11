using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour 
{
    public static UIManager instance;

	public EducationView educ;
    public PromoView promo;

    void Awake() {
        if (instance == null)
        {
            instance = this;
        }
    }

	public void BuisnessButtonClick()
	{
		SceneStateManager.instance.ChangeState (0);

		promo.Hide();

    }

	public void EducationButtonClick()
	{
		promo.Hide();

		SceneStateManager.instance.ChangeState (1);

    }

	public void FunButtonClick()
	{
		
		SceneStateManager.instance.ChangeState (2);

		promo.Hide();
    }

	public void PromotionButtonClick()
	{
		promo.Show();

		SceneStateManager.instance.ChangeState (3);
    }

	public void Quit()
	{
		Application.Quit();
	}
}
