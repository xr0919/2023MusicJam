using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultPanelControl : MonoBehaviour
{
    public static ResultPanelControl Instance;
    public Text result;
    public Image ResultImg;
    public Button NextLvBtn;
    public Button RetryBtn;
    //private bool NextLv = false;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        this.gameObject.SetActive(false);
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        int sceneIndexLeng = SceneManager.sceneCountInBuildSettings;

        RetryBtn.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(sceneIndex);
        });

        NextLvBtn.onClick.AddListener(() =>
        {
            sceneIndex++;
            if (sceneIndex >= sceneIndexLeng)
            {
                SceneManager.LoadScene(0);
            }
            SceneManager.LoadScene(sceneIndex);
        });
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void show(float matchCountPercentage)
    {
        if(matchCountPercentage != 100)
        {
            //if it is not 100% matched, switch btn to RetryLevel, change BgImg
            //NextLv = true;
            NextLvBtn.gameObject.SetActive(false);
            RetryBtn.gameObject.SetActive(true);
            //ResultImg.sprite = Resources.Load<Sprite>("");
            result.text = "Not Matched";
        }

        if (matchCountPercentage == 100)
        {
            //if it is not 100% matched, switch btn to RetryLevel, change BgImg
            //NextLv = true;
            NextLvBtn.gameObject.SetActive(true);
            RetryBtn.gameObject.SetActive(false);
            //ResultImg.sprite = Resources.Load<Sprite>("");
            result.text = "Matched!";
            return;
        }
        //result.text = "Matched: " + matchCountPercentage.ToString("f1") + "%";
        result.text = "Not Matched!";
    }
    public void s()
    {
        print("1");

    }
}
