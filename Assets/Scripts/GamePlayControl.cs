using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    private DragDrop[] dragDropItems;
    private ItemSlot[] itemSlots;
    private int numDropItems;

    //match btn
    public Button matchBtn;
    private int matchCount;
    // Start is called before the first frame update
    void Start()
    {
        dragDropItems = FindObjectsOfType<DragDrop>();
        itemSlots = FindObjectsOfType<ItemSlot>();

        //show result
        numDropItems = 6;
        //numDropItems = dragDropItems.Length;
        matchBtn.onClick.AddListener(() =>
        {
            //show ResultPanel
            ResultPanelControl.Instance.gameObject.SetActive(true);
            CalculateMatchPercentage();
            float matchCountPercentage = (float)matchCount / 6 * 100;
            Debug.Log(matchCountPercentage);
            ResultPanelControl.Instance.show(matchCountPercentage);
        });
    }

    // Update is called once per frame
    void Update()
    {
        //print("Match: " + CalculateMatchPercentage() + "%");
    }

    private int CalculateMatchPercentage()
    {
        matchCount = 0;

        foreach (var item in dragDropItems)
        {
            foreach (var slot in itemSlots)
            {
                if (item.item_name == slot.slot_name
                    && Vector2.Distance(item.GetComponent<RectTransform>().anchoredPosition,
                                        slot.GetComponent<RectTransform>().anchoredPosition) < 30)
                {
                    matchCount++;
                    break;
                }
            }
        }
        //Debug.Log(matchCount);
        return matchCount;
    }

    /*private float CalculateMatchPercentage()
    {
        int matchCount = 0;

        foreach (var item in dragDropItems)
        {
            foreach (var slot in itemSlots)
            {
                if (item.item_name == slot.slot_name
                    && Vector2.Distance(item.GetComponent<RectTransform>().anchoredPosition,
                                        slot.GetComponent<RectTransform>().anchoredPosition) < 30)
                {
                    matchCount++;
                    break;
                }
            }
        }

        return (float)matchCount / dragDropItems.Length * 100;
    }*/
}
