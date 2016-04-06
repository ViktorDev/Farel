using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameScene : MonoBehaviour

{
    public static GameScene instance;
    public Queue<GameObject> listObjects = new Queue<GameObject>();
	public Image ScoreImage;
	public GameObject moon;
	public GameObject score;
	public GameObject moonCrash;
    public GameObject spaceCrash;
    public GameObject[] spaceObjects;

    public float spawnSpaceObjectTime = 2f;
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

    void OnEnable() {
        StartGame();
    }


    void Start()
	{
        ScoreImage.enabled = false;
        scoretext = score.GetComponent<Text>();
        ScoreImage.enabled = false;
        score.SetActive(false);
        for (int i = 0; i < 15; i++){
            int itemType = Random.Range(0, 5);
            GameObject g = (GameObject) Instantiate(spaceObjects[itemType], new Vector3(100, 100,100), Quaternion.identity);
            listObjects.Enqueue(g);
            g.SetActive(false);
        }
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
            CreateSpaceObject();
            yield return new WaitForSeconds(spawnSpaceObjectTime);
        }

    }

    void CreateSpaceObject() {
        if (listObjects.Count > 0) {
            Vector3 dir = new Vector3(Random.Range(-1f, 1f), Random.Range(0.1f, 1f), Random.Range(-1f, 1f));
            dir.Normalize();
            dir *= 25;
            GameObject g = listObjects.Dequeue();
            g.transform.position = new Vector3(dir.x, dir.y, dir.z);
            g.SetActive(true);
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
//                if (hit.transform.gameObject.tag == "Moving_Item" || hit.transform.gameObject.tag == "SpaceShip")
//                {
//                    hit.transform.gameObject.GetComponent<MovingItem>().Crash();
//                    //                    Destroy(hit.transform.gameObject);
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

            if (Physics.Raycast(ray, out hit, 100))
            {
                Debug.Log("ClickRay");
                if (hit.transform.gameObject.tag == "Moving_Item" || hit.transform.gameObject.tag == "SpaceShip")
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
            listObjects.Enqueue(obj);
            obj.SetActive(false);
        }
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("SpaceShip"))
        {
            listObjects.Enqueue(obj);
            obj.SetActive(false);
        }
    }
}
