using UnityEngine;
using UnityEngine.EventSystems;


public class GlassMoving : MonoBehaviour, IDragHandler
{

    RectTransform rect;

    void Awake() {
        rect = GetComponent<RectTransform>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        var currentPosition = rect.position;
        currentPosition.x += eventData.delta.x;
        currentPosition.y += eventData.delta.y;
        rect.position = currentPosition;
    }
}
