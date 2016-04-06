using UnityEngine;
using System.Collections;

public class Asteroid : MonoBehaviour
{

    void OnEnable()
    {
        GetComponent<Rigidbody>().AddForce(new Vector3(Random.value, Random.value, Random.value) * 5, ForceMode.Impulse);
    }

}
