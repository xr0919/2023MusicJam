using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class MsgBoxControl : MonoBehaviour, IPointerClickHandler
{
    //ac
    public AudioClip ac;
    private AudioSource audioSource;

    public GameObject dragToBag;
    public GameObject expShadow;
    public GameObject DragableItem;

    public TMP_Text dialogText;
    string[] dialogs;
    int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        dialogs = new string[]{ "This is the last section I need to clean before I can go home. ",
                "Keep going!",
                "(Something shattered)",
                "Oh! NO!!!!!!",
        "Did I just break the centerpieces??",
        "Glad no one else is here. If I get caught, it's all over!",
        "Hmm... Seems like they are just random items pieced together...",
        "Maybe I can find items in the other rooms to substitute in. <color=red>(Click on items with the L mouse button, hold the button, and drag the item into the Inventory.)</color>",
        "By putting them together, I could pull off a seamless disguise! <color=red>(Click and hold the L mouse button to drag items from the Inventory to their original positions, try to make them fit perfectly.)</color>",
        "I'm running out of time! Gotta fix all these pieces before the museum opens tomorrow morning or I'll get fired!",
        "I got this!"};
    }

    // Update is called once per frame
    void Update()
    {
        

        
    }

    //Detect if a click occurs
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        if (index >= dialogs.Length)
        {
            SceneManager.LoadScene(2);
        }
        if (index < dialogs.Length)
        {
            print("before i= " + index);
            dialogText.text = dialogs[index];
            if(index == 2)
            {
                //AC
                audioSource = this.gameObject.AddComponent<AudioSource>();
                audioSource.clip = ac;
                audioSource.Play();
            }
            if (index == 7)
            {
                dragToBag.SetActive(true);
                //Debug.Log("isInBag:" + DragableItem.GetComponent<DragDropDialog>().isInBag);
                if(DragableItem.GetComponent<DragDropDialog>().isInBag)
                {
                    index++;
                }
            }
            if(index == 8)
            {
                expShadow.SetActive(true);
                dialogText.text = dialogs[index];
                //Debug.Log("isMatched: " + DragableItem.GetComponent<DragDropDialog>().isMatched);
                if (DragableItem.GetComponent<DragDropDialog>().isMatched)
                {
                    index++;
                }
            }
            if(index == 9)
            {
                dialogText.text = dialogs[index];
                index++;
            }
            if(index < 7 || index >9)
            {
                index++;
            }
        }
    }

    //change content of MsgBox
    /*public void ShowText(string content)
    {
        //this.transform.GetChild(0).GetComponent<Text>().text = name;
        this.transform.GetChild(0).GetComponent<TextMeshPro>().text = content;
    }*/


}
