using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBehavior2 : MonoBehaviour
{
    //int n;
    public void OnButtonPress()
    {
        //n++;
        //Debug.Log("Button clicked " + n + " times.");
        SceneManager.LoadScene("titlescreen");
        //Debug.Log("Button clicked!");
    }

}
