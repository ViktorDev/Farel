using UnityEngine;
using System.Collections;

public class MovingItem : MonoBehaviour {

    protected enum ExplosionType { InSpace, MoonContact }
    public Vector3 dir;
    protected GameScene gameManager;
    protected Rigidbody rig;
    protected Vector3 contactPosition;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameScene>();
        rig = gameObject.GetComponent<Rigidbody>();
        rig.AddForce(new Vector3(Random.value, Random.value, Random.value) * 10, ForceMode.Impulse);
    }

    void Update()
    {
        Vector3 gravity = gameManager.moon.transform.position - transform.position;
        gravity.Normalize();
        rig.AddForce(gravity * 0.02f, ForceMode.Impulse);
        transform.localRotation = Quaternion.LookRotation(rig.velocity);
    }

    public virtual void Crash() {

    }
}
