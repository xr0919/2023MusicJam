using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Say
{
    public string name;
    public string content;
    public string face;
    public string mouth;
}

public class DialogControl : MonoBehaviour
{
    public MsgBoxControl MsgBox;
    //public CharacterControl charC;
    Say[] says;
    //
    int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        //create content of MsgBox
        Say say1 = new Say() { name = "P", content = "Hi", face = "03", mouth = "02" };
        Say say2 = new Say() { name = "P", content = "23", face = "02", mouth = "03" };
        Say say3 = new Say() { name = "P", content = "MusicJam", face = "01", mouth = "04" };

        says = new Say[] { say1, say2, say3 };
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (index >= says.Length)
            {
                SceneManager.LoadScene(2);
            }
            if (index < says.Length)
            {
                print("before i= " + index);
                Say say = says[index];
                //MsgBox.ShowText(say.name, say.content);
                //charC.LoadFace(say.face);
                //charC.LoadMouth(say.mouth);
                index++;
            }
            
        }
    }
}
