using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextChanger : MonoBehaviour
{
    void Start()
    {
        GetComponent<TMP_Text>().text = GameManager.INSTANCE.endTexts[EndScreenTexts.textIndex];
        if(EndScreenTexts.textIndex < 2)
            EndScreenTexts.textIndex++;
        else if(EndScreenTexts.textIndex == 2)
            EndScreenTexts.textIndex = 0;
    }
}
