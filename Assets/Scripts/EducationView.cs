﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class EducationView : MonoBehaviour  
{
	public static EducationView instance;
    Animator minion;
    public GameObject Ipanel;
	public Text info;
    public GameObject tv;
    public GameObject infoPanels;
	string info1 = "jdfnvkjdnflvjbslbvrfkbvfjsbvjk" +
		"jvnsdfkjvbndfkjvbndfkjbvnkjdnfv" +
		"fdvkljdfsbnkdgfjbnkjdgfbnkjdgnfbkj" +
		"dfnkjsbvdbnfsvkjdfbnkbjdgfkjbvjdfsb" +
		"nkidfjbvkdfjbvnkdfjbvnkdfjbvnkdfjbnkjsbdf" +
		"dnbfjdgfbnkjdgfnbkjdgfnbkjdgnfbkjndgfkjbngfnb" +
		"kbjdsfbkdgfbkjdkjbskjndfkjbkjdgfbjdgfkjbnldkjsnfb" +
		"sdfkjbndgfkjbkdjsnbkjsdbnkjnkdfjbnldfksnb" +
		"dfkljbvkdfjsbnkjdfbvkjdfsbkjdfkjbvdfkjsbv";

	void Awake()
	{
		if (instance == null) {
			instance = this;
		}
        minion = GameObject.Find("minion_full").GetComponent<Animator>();
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
					if (hit.transform.name == "Info_footnote") 
					{
						info.text = "" + info1;
					}
						
					OpenLotInfo ();

				}
			}
		}
	}

	public void OpenLotInfo()
	{
		Ipanel.SetActive(true);
		Ipanel.GetComponent<InfoPanel>().OpenPanel();
        infoPanels.SetActive(false);

    }

    void OnDisable()
    {
//        minion.SetTrigger("Idle1Stop");
    }
        //public void BackTo() 
        //{
        //	Ipanel.GetComponent<InfoPanel>().ClosePanel(false);
        //	Ipanel.GetComponent<PlayMovie> ().enabled = false;
        //	info.text = "";
        //}
    }
