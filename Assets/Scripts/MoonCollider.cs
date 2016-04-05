using UnityEngine;
using System.Collections;

public class MoonCollider : MonoBehaviour {

	
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="SpaceShip")  other.gameObject.GetComponent<SpaceShip>().MakeShot();
    }
}
