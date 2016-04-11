using UnityEngine;
using UnityEngine.UI;

public class BuisnessView : MonoBehaviour 
{
    public static BuisnessView instance;
    public GameObject lotPanel;
    public GameObject lotInfo;
	public GameObject signboard;
//    public Material onSale;
    public Material saled;
    public GameObject selectedLot;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
	void Update () 
	{
        UserInput();
    }

    void UserInput()
    {
		if (!Application.isEditor) 
		{
			if (Input.GetTouch(0).phase == TouchPhase.Began)
			{
				Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
				RaycastHit hit;
				if (Physics.Raycast(ray, out hit, 100))
				if (hit.transform.gameObject.tag == "Lot")
				{
					OpenLotInfo(hit.transform.gameObject);
					selectedLot = hit.transform.gameObject;
				}
			}
		}
       

		if (Application.isEditor) 
		{
			if (Input.GetMouseButtonDown(0))
			{
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				RaycastHit hit;

				if (Physics.Raycast(ray, out hit, 100))
				if (hit.transform.gameObject.tag == "Lot")
				{
					Debug.Log("Select");
					OpenLotInfo(hit.transform.gameObject);
					selectedLot = hit.transform.gameObject;
					signboard = hit.transform.FindChild("for sale").gameObject;
					signboard.SetActive (false);
				}
			}
		}
   } 

    void OpenLotInfo(GameObject lot) {
        lotPanel.SetActive(true);
        lotPanel.GetComponent<BuyLotPanel>().OpenPanel();
        lotInfo.GetComponent<Text>().text = "Area: 1000\nEnergy: yes\nWater: yes\nOther: Coal";
    }

    public void BuyLot() {
        selectedLot.GetComponent<MeshRenderer>().material = saled;
        selectedLot.tag = "SaledLot";
        lotPanel.GetComponent<BuyLotPanel>().ClosePanel();
    }
}
