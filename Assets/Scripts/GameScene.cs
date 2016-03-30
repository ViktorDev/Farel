using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameScene : MonoBehaviour

{
    public static GameScene instance;
    
	public GameObject moon;
	public GameObject score;
	public GameObject asteroid;

	public float spawnAsteroidTime = 1f;
	bool isGame = true;
    
	private Text scoretext;
	private int points = 0;
	private int health = 100;

	void Start()
	{
		if (instance == null) {
			instance = this;
		}

		scoretext = score.GetComponent<Text>();
		score.SetActive (false);


	}

	public void StartGame () 

	{   
        StartCoroutine(SpawnAsteroid());
    }
	
	void Update () 
	{
        scoretext.text = "Points: " + points + "\nHealth: " + health;
        
		UserInput();
    }

    IEnumerator SpawnAsteroid() 
	{
        while (isGame) {
            Vector3 dir = new Vector3(Random.Range(-1f,1f), Random.Range(0.1f,1f), Random.Range(-1f,1f));
            dir.Normalize();
            dir *= 25;
            GameObject ast = (GameObject) Instantiate(asteroid, dir, Quaternion.identity);
            ast.GetComponent<Rigidbody>().AddForce((moon.transform.position - dir)*0.1f, ForceMode.Impulse);
            yield return new WaitForSeconds(spawnAsteroidTime);
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
		#if UNITY_ANDROID
        if (Input.GetTouch(0).phase == TouchPhase.Began) {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
                if (hit.transform.gameObject.tag == "Asteroid")
                {
				
                    Destroy(hit.transform.gameObject);
                    ChangePoints(1);
                }
        }
		#endif
		#if UNITY_EDITOR
		if (Input.GetMouseButtonDown(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast(ray, out hit, 100))
			if (hit.transform.gameObject.tag == "Asteroid")
			{
				Destroy(hit.transform.gameObject);
				ChangePoints(1);
			}
		}
		#endif

    }
}
