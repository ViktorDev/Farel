using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameScene : MonoBehaviour

{
    public static GameScene instance;
    
	public Image ScoreImage;
	public GameObject moon;
	public GameObject score;
	public GameObject asteroid;
    public GameObject spaceShip;

    public float spawnSpaceObjectTime = 1f;
	bool isGame = true;
    
	private Text scoretext;
	private int points = 0;
	private int health = 100;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }


    }

    void Start()
	{
		
		ScoreImage.enabled = false;

		scoretext = score.GetComponent<Text>();
		ScoreImage.enabled = false;
		score.SetActive (false);


	}

	public void StartGame () 

	{   
		Debug.Log ("StartGame");

        StartCoroutine(SpawnSpaceObject());
		ScoreImage.enabled = true;
    }
	
	void Update () 
	{
        scoretext.text = "" + points;
        
		UserInput();
    }

    IEnumerator SpawnSpaceObject() 
	{
        while (isGame) {
            Vector3 dir = new Vector3(Random.Range(-1f,1f), Random.Range(0.1f,1f), Random.Range(-1f,1f));
            dir.Normalize();
            dir *= 25;

            int itemType = Random.Range(0,5);
            GameObject item;
            switch (itemType) {
                case 0:
                    item = (GameObject)Instantiate(asteroid, dir, Quaternion.identity);
                    break;
                case 1:
                    item = (GameObject)Instantiate(spaceShip, dir, Quaternion.identity);
                    item.transform.localRotation = Quaternion.LookRotation(moon.transform.position - dir);
                    break;
                case 2:
                    item = (GameObject)Instantiate(asteroid, dir, Quaternion.identity);
                    break;
                case 3:
                    item = (GameObject)Instantiate(spaceShip, dir, Quaternion.identity);
                    break;
                case 4:
                    item = (GameObject)Instantiate(asteroid, dir, Quaternion.identity);
                    break;
                default:
                    item = (GameObject)Instantiate(spaceShip, dir, Quaternion.identity);
                    break;
            }

            
            item.GetComponent<MovingItem>().dir = moon.transform.position - dir;
 //           item.GetComponent<Rigidbody>().AddForce((moon.transform.position - dir)*0.1f, ForceMode.Impulse);
            
            yield return new WaitForSeconds(spawnSpaceObjectTime);
        }

    }

    public void ChangePoints(int val) 
	{
        points += val;
    }

    public void ChangeHealth(int val) 
	{
        health += val;
    }

    void UserInput() 
	{
        //#if UNITY_ANDROID
        //        if (Input.GetTouch(0).phase == TouchPhase.Began)
        //        {
        //            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
        //            RaycastHit hit;

        //            if (Physics.Raycast(ray, out hit, 100))
        //                if (hit.transform.gameObject.tag == "Moving_Item"|| hit.transform.gameObject.tag == "SpaceShip")
        //                {
        //                    hit.transform.gameObject.GetComponent<Asteroid>().Crash();
        ////                    Destroy(hit.transform.gameObject);
        //                    ChangePoints(1);
        //                }
        //        }
        //#endif
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
		{
            Debug.Log("Click");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100)) {
                Debug.Log("ClickRay");
                if (hit.transform.gameObject.tag == "Moving_Item"|| hit.transform.gameObject.tag == "SpaceShip")
                {
                    
                    hit.transform.gameObject.GetComponent<MovingItem>().Crash();
                    ChangePoints(1);
                }
            }
			
		}
		#endif

    }

	void OnDisable()
	{
		StopAllCoroutines ();
        
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Moving_Item")) {
            Destroy(obj);
        }
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("SpaceShip"))
        {
            Destroy(obj);
        }
    }
}
