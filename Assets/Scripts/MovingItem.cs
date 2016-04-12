using UnityEngine;
using System.Collections;

public class MovingItem : MonoBehaviour {

    protected enum ExplosionType { InSpace, MoonContact }
    
	public enum ItemType {Asteroid, SpaceShip, FuelTank, Satellite }

	public ItemType type;

    GameScene gameManager;
    Rigidbody rig;
    Vector3 contactPosition;
    Vector3 originScale;
    

    void Start()
    {
        gameManager = GameScene.instance;
        rig = gameObject.GetComponent<Rigidbody>();
        originScale = transform.localScale;
    }

    void Update()
    {
        Vector3 gravity = gameManager.moon.transform.position - transform.position;
        gravity.Normalize();
        rig.AddForce(gravity * 0.02f, ForceMode.Impulse);
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag == "Moon")
        {
            gameManager.ChangeHealth(-1);
            contactPosition = collision.contacts[0].point;
            CrashOnMoon();
        }
    }

    public void Crash() {
        StartCoroutine(makeExplosion(ExplosionType.InSpace));
    }

    public void CrashOnMoon()
    {
        StartCoroutine(makeExplosion(ExplosionType.MoonContact));
    }

    IEnumerator makeExplosion(ExplosionType explType)
    {
        if (explType == ExplosionType.InSpace)
        {
            GameObject b = (GameObject) Instantiate(gameManager.spaceCrash, transform.position, Quaternion.identity);
            Destroy(b, 4);
            GetComponent<Collider>().enabled = false;

        }
        else {
            GameObject b = (GameObject)Instantiate(gameManager.moonCrash, contactPosition, Quaternion.LookRotation(gameManager.moon.transform.position - contactPosition));
            Destroy(b, 4);
            GetComponent<Collider>().enabled = false;
            if (type == ItemType.Asteroid) {
                gameObject.GetComponent<TrailRenderer>().enabled = false;
            }
        }
        Debug.Log("expl");
        while (transform.localScale.x > 0)
        {
            yield return new WaitForSeconds(0.005f);
            transform.localScale = new Vector3(transform.localScale.x - 0.001f, transform.localScale.y - 0.001f, transform.localScale.z - 0.001f);
        }
        transform.localScale = new Vector3(0, 0, 0);
        yield return new WaitForSeconds(4);
        GameScene.instance.listObjects.Enqueue(gameObject);
        gameObject.SetActive(false);
        GetComponent<Collider>().enabled = true;
        transform.localScale = new Vector3(originScale.x, originScale.y, originScale.z);
    }

}
