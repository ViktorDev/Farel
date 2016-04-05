using UnityEngine;
using System.Collections;

public class SpaceShip : MonoBehaviour
{
    GameScene gameManager;
    Rigidbody bulletRig;
    bool makeShot;
    Rigidbody rig;
    Vector3 awayDir;
    float force = 0.15f;

    void Start() {
        bulletRig = transform.Find("Bullet").gameObject.GetComponent<Rigidbody>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameScene>();
        rig = GetComponent<Rigidbody>();
    }

    void Update() {
        transform.localRotation = Quaternion.LookRotation(rig.velocity);       
        if (makeShot) {
            Vector3 gravity = gameManager.moon.transform.position - transform.position;
            gravity.Normalize();
            rig.AddForce(-gravity * force, ForceMode.Impulse);
            rig.AddForce(awayDir*force, ForceMode.Impulse);
            force += 0.0001f;
            //           rig.AddForce(transform.righ)
        } 
    }

    public void MakeShot() {
        StartCoroutine(shot());
    }

    IEnumerator shot() {
//        gameObject.GetComponent<MovingItem>().enabled = false;
        makeShot = true;
        awayDir = transform.right;
        //        rig.AddForce((transform.position - gameManager.moon.transform.position) *30f, ForceMode.Force);
        //        rig.AddForce((transform.position + Vector3.right).normalized * 30f, ForceMode.Force);
        yield return new WaitForSeconds(0.7f);
        bulletRig.gameObject.SetActive(true);
        bulletRig.gameObject.transform.parent = null;
        //        bulletRig.isKinematic = false;
        bulletRig.AddForce((gameManager.moon.transform.position - transform.position), ForceMode.Impulse);
        Destroy(gameObject, 4);
 //       rig.AddForce((transform.position + Vector3.right).normalized * 100f, ForceMode.Force);
    }
}
