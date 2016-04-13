using UnityEngine;
using System.Collections;

public class Crator : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(Delete());
	}

    IEnumerator Delete() {
        while (transform.localScale.x > 0) {
            transform.localScale = new Vector3(transform.localScale.x-0.001f,
                                               transform.localScale.y - 0.001f,
                                               transform.localScale.z - 0.001f);
            yield return new WaitForSeconds(0.1f);
        }
        Destroy(gameObject);
    }
	
}
