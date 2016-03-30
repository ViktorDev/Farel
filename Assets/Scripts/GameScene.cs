using UnityEngine;
using System.Collections;

public class GameScene : MonoBehaviour {

    public GameObject asteroid;
    bool isGame = true;
    public float spawnAsteroidTime = 1f;
    public GameObject moon;
	// Use this for initialization
	void Start () {
        StartCoroutine(spawnAsteroid());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator spawnAsteroid() {
        while (isGame) {
            Vector3 dir = new Vector3(Random.Range(-1f,1f), Random.Range(0.1f,1f), Random.Range(-1f,1f));
            dir.Normalize();
            dir *= 25;
            GameObject ast = (GameObject) Instantiate(asteroid, dir, Quaternion.identity);
            ast.GetComponent<Rigidbody>().AddForce((moon.transform.position - dir)*0.3f, ForceMode.Impulse);
            yield return new WaitForSeconds(spawnAsteroidTime);
        }

    }
}
