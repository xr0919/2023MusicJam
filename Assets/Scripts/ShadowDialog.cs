using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShadowDialog : MonoBehaviour, IDropHandler
{
    public int slot_name;
    public DragDropDialog dialog_item;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        if (eventData.pointerDrag != null 
            && Vector2.Distance(eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition,GetComponent<RectTransform>().anchoredPosition) < 40)
        {
            
            Debug.Log("a before:" + eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition);
            Debug.Log("a after:" + GetComponent<RectTransform>().anchoredPosition);
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            
            dialog_item.isMatched = true;
        }
    }
}
