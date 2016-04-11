using UnityEngine;
using System.Collections;

public class MoonCollider : MonoBehaviour {

	
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag== "Moving_Item"&& other.gameObject.GetComponent<MovingItem>().type==MovingItem.ItemType.SpaceShip)  other.gameObject.GetComponent<SpaceShip>().MakeShot();
    }
}
