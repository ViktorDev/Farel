using UnityEngine;

public class Asteroid : MonoBehaviour {

    GameScene gameManager;
	// Use this for initialization
	void Start () {
        gameManager = GameObject.Find("GameManager").GetComponent<GameScene>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag == "Moon") {
            gameManager.changeHealth(-1);
            Destroy(gameObject);
        }
        
    }
}
