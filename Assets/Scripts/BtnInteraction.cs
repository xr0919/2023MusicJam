using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BtnInteraction : MonoBehaviour
{
    //eventtrigger
    public EventTrigger[] et;
    public EventTrigger[] et_short;
    public EventTrigger etPanel;
    private AudioSource audioSource;
    public GameSetting gameSetting;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = this.gameObject.AddComponent<AudioSource>();

        //Btn interaction onEnter/onClick
        //onEnter
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerEnter;
        entry.callback.AddListener((data) =>
        {
            audioSource.clip = Resources.Load<AudioClip>("UIonHover");
            audioSource.PlayOneShot(audioSource.clip);
        });
        for (int i = 0; i < et.Length; i++)
        {
            et[i].triggers.Add(entry);
        }
        //onClick
        entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerDown;
        entry.callback.AddListener((data) =>
        {
            audioSource.clip = Resources.Load<AudioClip>("UIonClick");
            audioSource.PlayOneShot(audioSource.clip);
        });
        for (int i = 0; i < et.Length; i++)
        {
            et[i].triggers.Add(entry);
        }

        //only for switching room Btn
        EventTrigger.Entry entryShort = new EventTrigger.Entry();
        entryShort.eventID = EventTriggerType.PointerDown;
        entryShort.callback.AddListener((data) =>
        {
            audioSource.clip = Resources.Load<AudioClip>("UI_ac_short");
            audioSource.PlayOneShot(audioSource.clip);
        });
        for (int i = 0; i < et_short.Length; i++)
        {
            et_short[i].triggers.Add(entryShort);
        }

        //Panel onMouseLeave
        EventTrigger.Entry entryPanel = new EventTrigger.Entry();
        entryPanel.eventID = EventTriggerType.PointerExit;
        entryPanel.callback.AddListener((data) =>
        {
            etPanel.gameObject.SetActive(false);
            //active MasterBtn after mouse leave
            gameSetting.MasterBtn.gameObject.SetActive(true);
        });
        etPanel.triggers.Add(entryPanel);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
