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

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler {
    //
    private Vector3 originalPosition;

    [SerializeField] private Canvas canvas;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    public float item_height;
    public float item_width;

    public int item_name;

    //check if the item is matched with the corresponding shadow
    public bool isMatched = false;
    private Canvas canvasSort;

    //check if item is in bag
    public bool isInBag = false;
    public static DragDrop instance;    

    private void Awake() {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        item_height = GetComponent<RectTransform>().rect.height;
        item_width = GetComponent<RectTransform>().rect.width;
        instance = this;
        originalPosition = transform.localPosition;
    }

    public void OnBeginDrag(PointerEventData eventData) {
        Debug.Log("OnBeginDrag");
        if (isInBag)
        {
            isInBag = false;
        }
        if (!isMatched)
        {
            //destroy all item's Canvas component before start
            DragDrop[] item = FindObjectsOfType<DragDrop>();
            foreach (DragDrop d in item) {
                if(d.canvas != null)
                {
                    Destroy(d.gameObject.GetComponent<Canvas>());
                }
            }
            //create canvas component on the start of Drag and change its sortingOrder
            /*canvasSort = gameObject.AddComponent<Canvas>();
            canvasSort.overrideSorting = true;
            canvasSort.sortingOrder = 1;*/
            transform.SetAsLastSibling();

            canvasGroup.alpha = .6f;
            canvasGroup.blocksRaycasts = false;

            float currentHeight = GetComponent<RectTransform>().rect.height;
            float currentWidth = GetComponent<RectTransform>().rect.width;
            if (currentHeight != item_height || currentWidth != item_width)
            {
                GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, item_height);
                GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, item_width);
            }
        }
    }

    public void OnDrag(PointerEventData eventData) {
        //Debug.Log("OnDrag");
        if (!isMatched)
        {
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }
    }

    public void OnEndDrag(PointerEventData eventData) {
        Debug.Log("OnEndDrag");
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;

        ItemSlot[] shadows = FindObjectsOfType<ItemSlot>();
        foreach(ItemSlot shadow in shadows) 
        {
            if (shadow.slot_name == item_name 
                && Vector2.Distance(shadow.gameObject.GetComponent<RectTransform>().anchoredPosition, GetComponent<RectTransform>().anchoredPosition) < 50)
            {
                //when the item is matched, set raycastTarget to be false
                isMatched = true;

                float shadowHeight = shadow.gameObject.GetComponent<RectTransform>().rect.height;
                float shadowWidth = shadow.gameObject.GetComponent<RectTransform>().rect.width;
                GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, shadowHeight);
                GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, shadowWidth);

                this.GetComponent<Image>().raycastTarget = false;
               

                //destory Canvas component after drag
                /*if (canvasSort != null)
                {
                    Destroy(canvasSort);
                }*/

                GetComponent<RectTransform>().anchoredPosition = shadow.gameObject.GetComponent<RectTransform>().anchoredPosition;
                break;
            }
        }

        //
        //if (!isInBag) { }

        //GetComponent<RectTransform>().anchoredPosition = originalPosition;
    }

    public void OnPointerDown(PointerEventData eventData) {
        Debug.Log("OnPointerDown");
    }

}
