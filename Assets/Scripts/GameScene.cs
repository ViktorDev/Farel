using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameScene : MonoBehaviour {

    public GameObject asteroid;
    bool isGame = true;
    public float spawnAsteroidTime = 1f;
    public GameObject moon;
    public GameObject scoreText;
    int points = 0;
    int health = 100;
	// Use this for initialization
	void Start () {
        StartCoroutine(spawnAsteroid());
	}
	
	// Update is called once per frame
	void Update () {
        scoreText.GetComponent<Text>().text = "Points: " + points + "\nHealth: " + health;
        //        mobileInput();
        editorInput();
    }

    IEnumerator spawnAsteroid() {
        while (isGame) {
            Vector3 dir = new Vector3(Random.Range(-1f,1f), Random.Range(0.1f,1f), Random.Range(-1f,1f));
            dir.Normalize();
            dir *= 25;
            GameObject ast = (GameObject) Instantiate(asteroid, dir, Quaternion.identity);
            ast.GetComponent<Rigidbody>().AddForce((moon.transform.position - dir)*0.1f, ForceMode.Impulse);
            yield return new WaitForSeconds(spawnAsteroidTime);
        }

    }

    public void changePoints(int val) {
        points += val;
    }

    public void changeHealth(int val) {
        health += val;
    }

    void mobileInput() {
        if (Input.GetTouch(0).phase == TouchPhase.Began) {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
                if (hit.transform.gameObject.tag == "Asteroid")
                {
                    Destroy(hit.transform.gameObject);
                    changePoints(1);
                }
        }
    }
    void editorInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
                if (hit.transform.gameObject.tag == "Asteroid")
                {
                    Destroy(hit.transform.gameObject);
                    changePoints(1);
                }
        }
    }
}
