using UnityEngine;
using System.Collections;

public class MovingItem : MonoBehaviour {

    protected enum ExplosionType { InSpace, MoonContact }
//    public Vector3 dir;
    GameScene gameManager;
    Rigidbody rig;
    Vector3 contactPosition;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameScene>();
        rig = gameObject.GetComponent<Rigidbody>();
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

    IEnumerator makeExplosion(ExplosionType type)
    {
        GetComponent<Rigidbody>().isKinematic = true;
        GameObject bang;
        if (type == ExplosionType.InSpace)
        {
            bang = transform.Find("Explosion").gameObject;
            bang.SetActive(true);
            GetComponent<Collider>().enabled = false;

        }
        else {
            bang = transform.Find("MoonExplosion").gameObject;     
            bang.transform.position = contactPosition;
            bang.transform.rotation = Quaternion.LookRotation(gameManager.moon.transform.position - contactPosition);
            bang.SetActive(true);
        }
        Debug.Log("expl");
        bang.transform.parent = null;
        while (transform.localScale.x > 0)
        {
            yield return new WaitForSeconds(0.005f);
            transform.localScale = new Vector3(transform.localScale.x - 0.001f, transform.localScale.y - 0.001f, transform.localScale.z - 0.001f);
        }
        transform.localScale = new Vector3(0, 0, 0);
        Destroy(gameObject);
    }

}
