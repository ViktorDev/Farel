using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class EducationView : MonoBehaviour  
{
	public static EducationView instance;

    public GameObject [] Ipanels;
//	public Text info;
    public GameObject tv;
    public GameObject infoPanels;
	
	void Awake()
	{
		if (instance == null) {
			instance = this;
		}
        
    }

	void Update()
	{
		UserInput ();

	}

    public void UserInput()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
            

            if (Physics.Raycast (ray, out hit, 100)) {
				if (hit.transform.gameObject.tag == "Information"&& !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject()) {
					Debug.Log (hit.transform.name);

                    switch (hit.transform.name)
                    {
                        case "Info1":
                            OpenLotInfo(0);
                            break;
                        case "Info2":
                            OpenLotInfo(1);
                            break;
                        case "Info3":
                            OpenLotInfo(2);
                            break;
                        case "Info4":
                            OpenLotInfo(3);
                            break;
                        case "Video":
                            OpenLotInfo(4);
                            break;

                    }
					

				}
			}
		}
	}

	public void OpenLotInfo(int index)
	{
        Ipanels[index].SetActive(true);
        //Ipanel.SetActive(true);
        Ipanels[index].GetComponent<InfoPanel>().OpenPanel();
        infoPanels.SetActive(false);

    }

   
        //public void BackTo() 
        //{
        //	Ipanel.GetComponent<InfoPanel>().ClosePanel(false);
        //	Ipanel.GetComponent<PlayMovie> ().enabled = false;
        //	info.text = "";
        //}
    }
