using UnityEngine;
using System.Collections;

public class FuelTank : MonoBehaviour {

    void OnEnable()
    {
        GetComponent<Rigidbody>().AddTorque(Random.value, 0, Random.value, ForceMode.Impulse);
    }
}
