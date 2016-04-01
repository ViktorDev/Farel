using UnityEngine;
using System.Collections;

public class SpaceShip : MovingItem {

    enum ExplosionType { InSpace, MoonContact }

    GameScene gameManager;
    Vector3 contactPosition;
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
            gameManager.ChangeHealth(-1);
            contactPosition = collision.contacts[0].point;
            StartCoroutine(makeExplosion(ExplosionType.MoonContact));
            
 //           Destroy(gameObject);
        }
        
    }

    public override void Crash() {
        StartCoroutine(makeExplosion(ExplosionType.InSpace));
    }

    IEnumerator makeExplosion(ExplosionType type) {

            GetComponent<Rigidbody>().isKinematic = true;
            if (type == ExplosionType.InSpace) {
            transform.Find("Explosion").gameObject.SetActive(true);        
            GetComponent<Collider>().enabled = false;
            
        } 
        else {
            GameObject bang = transform.Find("MoonExplosion").gameObject;
            bang.transform.position = contactPosition;
            bang.transform.rotation = Quaternion.LookRotation(-dir);
            bang.SetActive(true);
        } 
        Debug.Log("expl");
        while (transform.localScale.x > 0) {
            yield return new WaitForSeconds(0.01f);
            transform.localScale = new Vector3(transform.localScale.x - 0.0003f, transform.localScale.y - 0.0003f, transform.localScale.z - 0.0003f);
        }
        GetComponent<TrailRenderer>().enabled = false;
        transform.localScale = new Vector3(0, 0, 0);
        Destroy(gameObject, 3f);
    }
}
