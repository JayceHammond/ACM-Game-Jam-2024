using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YouWin : MonoBehaviour
{
    public Text WinText;

    public void DisplayWinMessage()
    {
        WinText.gameObject.SetActive(true);
    }
}
