using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour 
{

	public GameObject buisnessMoon;
	public GameObject educationMoon;
	public GameObject funMoon;
	public GameObject promotionMoon;

	private GameObject _curentObject = null;

	void Start()
	{
		_curentObject = buisnessMoon;
	}

	public void BuisnessButtonClick()
	{
		if (_curentObject != buisnessMoon ) 
		{
			_curentObject = buisnessMoon;
			_curentObject.SetActive (true);

			educationMoon.SetActive (false);
			funMoon.SetActive (false);
			promotionMoon.SetActive (false);
		}
	}

	public void EducationButtonClick()
	{
		if (_curentObject != educationMoon) 
		{
			_curentObject = educationMoon;
			_curentObject.SetActive (true);

			buisnessMoon.SetActive (false);
			funMoon.SetActive (false);
			promotionMoon.SetActive (false);
		}

	}

	public void FunButtonClick()
	{
		if (_curentObject != funMoon) 
		{
			GameScene.instance.StartGame ();
			GameScene.instance.score.SetActive (true);

			_curentObject = funMoon;
			_curentObject.SetActive (true);

			buisnessMoon.SetActive (false);
			educationMoon.SetActive (false);
			promotionMoon.SetActive (false);
		}
	}

	public void PromotionButtonClick()
	{
		if (_curentObject != promotionMoon) 
		{
			_curentObject = promotionMoon;
			_curentObject.SetActive (true);

			buisnessMoon.SetActive (false);
			educationMoon.SetActive (false);
			funMoon.SetActive (false);
		}
	}
}
