using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePanelControl : MonoBehaviour
{
    //Time
    public Text TimeText;
    public float totalTime = 90f;
    private float remainingTime;

    //shadow Img
    public Button shadowThumbnail;
    public Image shadowImg;
    bool shadowImgVisible;

    //Volume Slider
    public AudioClip ac;
    public Slider volumeSlider;
    public float soundValue = 1;
    private AudioSource audioSource;

    //Room Panel
    public GameObject[] roomPanel;

    //Background img
    public Sprite[] images;
    private int currentImageIndex = 0;
    public Image imageComponent;

    //LR button
    public Button btnL;
    public Button btnR;

    // Start is called before the first frame update
    void Start()
    {
        //CountDown
        remainingTime = totalTime;

        //inactive all the item in the other room at the beginning
        for (int i = 0; i < roomPanel.Length; i++)
        {
            for (int j = 0; j < roomPanel[i].transform.childCount; j++)
            {
                roomPanel[i].transform.GetChild(j).gameObject.SetActive(false);
            }
        }

        //active everything in the first room at the beginning
        for (int j = 0; j < roomPanel[0].transform.childCount; j++)
        {
            roomPanel[0].transform.GetChild(j).gameObject.SetActive(true);
        }
        //inactive shadowThumbnail img
        shadowThumbnail.gameObject.SetActive(false);
        shadowImg.gameObject.SetActive(false);
        shadowImgVisible = false;

        btnL.onClick.AddListener(() =>
        {
            SwitchImageL();
            if (currentImageIndex != 0)
            {
                for (int j = 0; j < roomPanel[0].transform.childCount; j++)
                {
                    roomPanel[0].transform.GetChild(j).gameObject.SetActive(false);
                }
            }
            SwitchPanel();
        });
        btnR.onClick.AddListener(() =>
        {
            SwitchImageR();
            if (currentImageIndex != 0)
            {
                for (int j = 0; j < roomPanel[0].transform.childCount; j++)
                {
                    roomPanel[0].transform.GetChild(j).gameObject.SetActive(false);
                }
            }
            SwitchPanel();
        });

        //BGM
        audioSource = this.gameObject.AddComponent<AudioSource>();
        audioSource.clip = ac;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        //CountDown
        remainingTime -= Time.deltaTime;
        if(remainingTime >= 0)
        {
            TimeText.text = remainingTime.ToString("F2");
        }
        else
        {
            ResultPanelControl.Instance.gameObject.SetActive(true);
            ResultPanelControl.Instance.show(0);
        }


        //Control volumn
        volumeSlider.value = soundValue;
        volumeSlider.onValueChanged.AddListener((v) =>
        {
            soundValue = v;
        });
        audioSource.volume = soundValue;
    }

    public void SwitchImageL()
    {
        currentImageIndex--;
        if (currentImageIndex < 0)
        {
            currentImageIndex = images.Length - 1;
        }
        print(currentImageIndex);
        imageComponent.sprite = images[currentImageIndex];
    }
    public void SwitchImageR()
    {
        currentImageIndex++;
        if (currentImageIndex >= images.Length)
        {
            currentImageIndex = 0;
        }
        print(currentImageIndex);
        imageComponent.sprite = images[currentImageIndex];
    }

    public void SwitchPanel()
    {
        //start from the second room_1
        for (int i = 1; i < roomPanel.Length; i++)
        {
            for (int j = 0; j < roomPanel[i].transform.childCount; j++)
            {
                if (roomPanel[i].transform.GetChild(j).gameObject.GetComponent<DragDrop>().isInBag == false || roomPanel[i].transform.GetChild(j).gameObject.GetComponent<DragDrop>().isMatched == true)
                {
                    roomPanel[i].transform.GetChild(j).gameObject.SetActive(false);
                }
            }
        }
        //when it is not in the first room room0
        if (currentImageIndex != 0)
        {
            for (int i = 0; i < roomPanel[currentImageIndex].transform.childCount; i++)
            {
                //active all the item in the current room which is not shanped in the shadow img
                if (roomPanel[currentImageIndex].transform.GetChild(i).gameObject.GetComponent<DragDrop>().isMatched == false)
                {
                    roomPanel[currentImageIndex].transform.GetChild(i).gameObject.SetActive(true);
                }
            }
            //active shadowThumbnail img
            shadowThumbnail.gameObject.SetActive(false);
            //shadowThumbnail.gameObject.SetActive(true);
        }
        //when switch back to the first room room0
        if (currentImageIndex == 0)
        {
            //active shadow img
            for (int i = 0; i < roomPanel[currentImageIndex].transform.childCount; i++)
            {
                roomPanel[currentImageIndex].transform.GetChild(i).gameObject.SetActive(true);
            }
            //active the item which is snaped in the shadow
            for (int i = 1; i < roomPanel.Length; i++)
            {
                for (int j = 0; j < roomPanel[i].transform.childCount; j++)
                {
                    if (roomPanel[i].transform.GetChild(j).gameObject.GetComponent<DragDrop>().isMatched == true)
                    {
                        roomPanel[i].transform.GetChild(j).gameObject.SetActive(true);
                    }
                }
            }
            //inactive shadowThumbnail img
            shadowThumbnail.gameObject.SetActive(false);
            shadowImg.gameObject.SetActive(false);
        }

    }

    public void shadowControl()
    {
        if(shadowImgVisible)
        {
            shadowImg.gameObject.SetActive(false);
            shadowImgVisible = false;
        }
        else
        {
            shadowImg.gameObject.SetActive(false);
            //shadowImg.gameObject.SetActive(true);
            shadowImgVisible = false;
            //shadowImgVisible = true;
        }
    }
}
