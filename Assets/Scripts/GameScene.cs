using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameScene : MonoBehaviour

{
    public static GameScene instance;
    
	public Queue<GameObject> listObjects = new Queue<GameObject>();

	public GameObject moon;
	public GameObject score;
    public GameObject healthIm;
    public GameObject losePanel;
	public GameObject moonCrash;
    public GameObject spaceCrash;
    public GameObject[] spaceObjects;
    public GameObject crator;

    private Text healthText;
	private Text scoretext;

	public float spawnSpaceObjectTime = 2f;
	private bool isGame = true;
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
        scoretext = score.GetComponentInChildren<Text>();
        healthText = healthIm.GetComponentInChildren<Text>();
       
    }

	public void StartGame () 
	{   
		PlayerPrefs.GetInt ("points", points);
		PlayerPrefs.GetInt ("health", health);
        score.SetActive(true);
        healthIm.SetActive(true);
        for (int i = 0; i < 15; i++)
        {
            int itemType = Random.Range(0, 4);
            GameObject g = (GameObject)Instantiate(spaceObjects[itemType], new Vector3(100, 100, 100), Quaternion.identity);
            g.GetComponent<MovingItem>().type = (MovingItem.ItemType)itemType;
            listObjects.Enqueue(g);
            g.SetActive(false);
        }
        StartCoroutine(SpawnSpaceObject());
    }

    public void RestartGame() {
        losePanel.SetActive(false);
        points = 0;
        health = 100;
        isGame = true;
        StartGame();
    }

    void LoseGame() {
        score.SetActive(false);
        healthIm.SetActive(false);
        losePanel.SetActive(true);
        losePanel.transform.Find("GameInfo").GetComponent<Text>().text = "Your score: " + points;
        isGame = false;
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Moving_Item");
        foreach (GameObject obj in objs)
        {
            Destroy(obj);
        }
        while (listObjects.Count > 0)
        {
            GameObject g = listObjects.Dequeue();
            Destroy(g);
        }
    }

	void Update () 
	{
        scoretext.text = "" + points;
        healthText.text = "" + health;
        UserInput();

        if (health <= 0) LoseGame();
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
            dir *= 20;
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
        health += val*10;
    }

    void UserInput() 
	{

        if (Application.isEditor)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Click");
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 100))
                {
                    if (hit.transform.gameObject.tag == "Moving_Item")
                    {
                        switch (hit.transform.gameObject.GetComponent<MovingItem>().type) {
                            case MovingItem.ItemType.Asteroid:
                                ChangePoints(6);
                                break;
                            case MovingItem.ItemType.FuelTank:
                                ChangePoints(2);
                                break;
                            case MovingItem.ItemType.Satellite:
                                ChangePoints(4);
                                break;
                            case MovingItem.ItemType.SpaceShip:
                                ChangePoints(8);
                                break;
                        }
                        hit.transform.gameObject.GetComponent<MovingItem>().Crash();
                    }
                }

            }
        }
        else {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 100))
                    if (hit.transform.gameObject.tag == "Moving_Item")
                    {
                        switch (hit.transform.gameObject.GetComponent<MovingItem>().type)
                        {
                            case MovingItem.ItemType.Asteroid:
                                ChangePoints(6);
                                break;
                            case MovingItem.ItemType.FuelTank:
                                ChangePoints(2);
                                break;
                            case MovingItem.ItemType.Satellite:
                                ChangePoints(4);
                                break;
                            case MovingItem.ItemType.SpaceShip:
                                ChangePoints(8);
                                break;
                        }
                        hit.transform.gameObject.GetComponent<MovingItem>().Crash();
                    }
            }
        }
    }

    void OnDisable()
	{
		PlayerPrefs.SetInt ("points", points);
		PlayerPrefs.SetInt ("health",health);
		StopAllCoroutines ();
        losePanel.SetActive(false);
        score.SetActive(false);
        healthIm.SetActive(false);


        GameObject[] objs = GameObject.FindGameObjectsWithTag("Moving_Item");
        foreach (GameObject obj in objs){ 
            Destroy(obj);
            
        }
        while (listObjects.Count > 0) {
            GameObject g = listObjects.Dequeue();
            Destroy(g);
        }
    }
}
