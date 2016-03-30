using UnityEngine;

public class Asteroid : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Moon") {

        }
        
    }
}
