using UnityEngine;
using System.Collections;

public class SpaceShip : MonoBehaviour
{
    
    public GameObject bullet;
    public bool makeShot;
    
	Rigidbody rig;
    Vector3 awayDir;
	GameScene gameManager;
    
	float force = 0.15f;

    void Start() {
        gameManager = GameScene.instance;
    }

    void Update()
    {
        transform.localRotation = Quaternion.LookRotation(rig.velocity);
        if (makeShot)
        {
            Vector3 gravity = gameManager.moon.transform.position - transform.position;
            gravity.Normalize();
            rig.AddForce(-gravity * force, ForceMode.Impulse);
            rig.AddForce(awayDir * force, ForceMode.Impulse);
            force += 0.0001f;
        }
    }

    void OnEnable() {    
        rig = GetComponent<Rigidbody>();
        Reset();
    }

    void Reset() {
        force = 0.15f;
        makeShot = false;
        rig.velocity = Vector3.zero;
    }


    public void MakeShot() {
        StartCoroutine(shot());
    }

    IEnumerator shot() {
        makeShot = true;
        awayDir = transform.right;
        yield return new WaitForSeconds(0.7f);

        if (gameObject.GetComponent<Collider>().enabled) {
            GameObject bul = (GameObject)Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            bul.GetComponent<Rigidbody>().AddForce((gameManager.moon.transform.position - transform.position), ForceMode.Impulse);
        }
       
        StartCoroutine(deleteShip());
    }

    IEnumerator deleteShip() {
        yield return new WaitForSeconds(4);      
        GameScene.instance.listObjects.Enqueue(gameObject);
        gameObject.SetActive(false);
    }
}
