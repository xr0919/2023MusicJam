/* 
    ------------------- Code Monkey -------------------

    Thank you for downloading this package
    I hope you find it useful in your projects
    If you have any questions let me know
    Cheers!

               unitycodemonkey.com
    --------------------------------------------------
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragDropDialog : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler {

    [SerializeField] private Canvas canvas;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    public float item_height;
    public float item_width;

    public int item_name;

    public bool isInBag;
    public bool isMatched;
    public ItemSlotDialog bagSlot;
   

    private void Awake() {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        item_height = GetComponent<RectTransform>().rect.height;
        item_width = GetComponent<RectTransform>().rect.width;
        isInBag = false;
        isMatched = false;
        
    }

    public void OnBeginDrag(PointerEventData eventData) {
        Debug.Log("OnBeginDrag");

        if (!isMatched)
        {
            canvasGroup.alpha = .6f;
            canvasGroup.blocksRaycasts = false;

            float currentHeight = GetComponent<RectTransform>().rect.height;
            float currentWidth = GetComponent<RectTransform>().rect.width;
            if (currentHeight != item_height || currentWidth != item_width)
            {
                GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, item_height);
                GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, item_width);
            }
            isInBag = false;
        }

    }

    public void OnDrag(PointerEventData eventData) {
        Debug.Log("OnDrag");
        if (!isMatched)
        {
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }
    }

    public void OnEndDrag(PointerEventData eventData) {
        Debug.Log("OnEndDrag");
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }

    public void OnPointerDown(PointerEventData eventData) {
        Debug.Log("OnPointerDown");
        
    }

}
