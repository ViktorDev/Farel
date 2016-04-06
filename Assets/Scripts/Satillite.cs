using UnityEngine;
using System.Collections;

public class Satillite : MonoBehaviour {

    void OnEnable() {
        GetComponent<Rigidbody>().AddTorque(0, Random.value, Random.value, ForceMode.Impulse);
    }
    
}
