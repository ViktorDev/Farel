using UnityEngine;
using System.Collections;

public class GameScene : MonoBehaviour {

    public GameObject asteroid;
    bool isGame;
    public float spawnAsteroidTime = 1f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator spawnAsteroid() {
        while (isGame) {
            Instantiate(asteroid, new Vector3(), Quaternion.identity);
            yield return new WaitForSeconds(spawnAsteroidTime);
        }

    }
}
