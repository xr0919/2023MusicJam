/* 
    ------------------- Code Monkey -------------------

    Thank you for downloading this package
    I hope you find it useful in your projects
    If you have any questions let me know
    Cheers!

               unitycodemonkey.com
    --------------------------------------------------
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler {

    public int slot_name;

    public void OnDrop(PointerEventData eventData) {
        Debug.Log("OnDrop");
        /*if (eventData.pointerDrag != null && eventData.pointerDrag.GetComponent<DragDrop>().item_name == slot_name
            && Vector2.Distance(eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition,GetComponent<RectTransform>().anchoredPosition) < 15)
        {
            
            Debug.Log("a before:" + eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition);
            Debug.Log("a after:" + GetComponent<RectTransform>().anchoredPosition);
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            
        }*/
    }

}
