using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSetting : MonoBehaviour
{
    //master BTN: display Setting Subpanel
    public Button MasterBtn;
    //Setting Subpanel
    public GameObject SettingPanel;

    //Switch to MainMenu Scene
    public Button MenuBtn;
    //Switch to first Game Scene
    public Button StartBtn;

    //quit game
    public Button QuitBtn;

    //Volume Slider
    public AudioClip ac;
    public Slider volumeSlider;
    public float soundValue = 1;
    private AudioSource audioSource;
    //public ManageMusic manageMusic;

    // Start is called before the first frame update
    void Start()
    {
        SettingPanel.SetActive(false);

        //BGM
        audioSource = ManageMusic.instance.gameObject.GetComponent<AudioSource>();
        /*audioSource = this.gameObject.AddComponent<AudioSource>();
        audioSource.clip = ac;
        audioSource.loop = true;
        audioSource.Play();*/

        //display Setting Subpanel
        MasterBtn.onClick.AddListener(() =>{
            SettingPanel.SetActive(true);
            //after clicking inactive MasterBtn
            MasterBtn.gameObject.SetActive(false);
        });

        //Switch to MainMenu Scene
        MenuBtn.onClick.AddListener(SwitchSceneMainMenu);
        //Switch to first Game Scene
        StartBtn.onClick.AddListener(SwitchScene);

        //Quit game
        QuitBtn.onClick.AddListener(() =>
        {
            Application.Quit();
        });
    }

    // Update is called once per frame
    void Update()
    {
        //Control BGM Volumn
        volumeSlider.value = soundValue;
        volumeSlider.onValueChanged.AddListener((v) =>
        {
            soundValue = v;
        });
        audioSource.volume = soundValue;
    }

    public void SwitchSceneMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void SwitchScene()
    {
        print("1");
        SceneManager.LoadScene(1);
    }
}
