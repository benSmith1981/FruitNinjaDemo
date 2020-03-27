using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CanvasScript: MonoBehaviour
{
    public Text gameMessage;
    public Text currentScore;
    public CanvasScript()//(Canvas theCanvas)
    {
        Debug.Log("InGameMessaging");

    }

    public void showInGameMessage(string message, Text textBox)
    {
        //showTextTime = 1.0f;
        textBox.text = message;
        textBox.enabled = true;
        Debug.Log("showText");
        Invoke("DisableText", 1f);//invoke after 5 seconds
    }

    void DisableText()
    {
        Debug.Log("DisableText");
        gameMessage.enabled = false;
    }
}