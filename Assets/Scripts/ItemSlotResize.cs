using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlotResize : MonoBehaviour, IDropHandler
{
    public float slot_size;

    //Whether the item is in the bag
    public bool isInBag;

    public static ItemSlotResize Instance;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        slot_size = GetComponent<RectTransform>().rect.width;
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        if (eventData.pointerDrag != null)
        {
            RectTransform placedObj = eventData.pointerDrag.GetComponent<RectTransform>();
            float item_height = placedObj.rect.height;
            float item_width = placedObj.rect.width;
            if(item_height > item_width)
            {
                placedObj.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, slot_size);
                placedObj.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, slot_size / item_height * item_width);
            }
            else
            {
                placedObj.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, slot_size);
                placedObj.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, slot_size / item_width * item_height);
            }
            
            placedObj.localPosition = GetComponent<RectTransform>().localPosition;

            isInBag = true;
            placedObj.gameObject.GetComponent<DragDrop>().isInBag = true;
        }
    }
}
