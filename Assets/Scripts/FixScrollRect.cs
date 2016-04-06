using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class FixScrollRect : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IScrollHandler
{
    ScrollRect MainScroll;
    CapturePhotoScene sceneController;
//    GameObject [] images;

    void Start() {
        sceneController = GameObject.Find("PromoManager").GetComponent<CapturePhotoScene>();
        MainScroll = sceneController.scrollPanel.GetComponent<ScrollRect>();
 //       images = GameObject.FindGameObjectsWithTag("Item");
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        MainScroll.OnBeginDrag(eventData);
        GetComponent<GlassGalaryItem>().isButtonClicked = false;
        //foreach (GameObject g in images) {
        //    g.GetComponent<GalaryItem>().isButtonClicked = false;
        //}
    }


    public void OnDrag(PointerEventData eventData)
    {
        MainScroll.OnDrag(eventData);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        MainScroll.OnEndDrag(eventData);
        GetComponent<GlassGalaryItem>().isButtonClicked = true;
        //foreach (GameObject g in images)
        //{
        //    g.GetComponent<GalaryItem>().isButtonClicked = true;
        //}
    }


    public void OnScroll(PointerEventData data)
    {
        MainScroll.OnScroll(data);
    }


}
