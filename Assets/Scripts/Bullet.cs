using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    GameObject par;
	// Use this for initialization
	void OnEnabled () {
        par = transform.parent.gameObject;
        transform.parent = null;
    }
	
	// Update is called once per frame
	void OnDisabled () {
        Vector3 pos = par.transform.position;
        transform.position = new Vector3(pos.x, pos.y, pos.z);
        transform.parent = par.transform;
    }
}
