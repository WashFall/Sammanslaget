using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextChanger : MonoBehaviour
{
    void Start()
    {
        GetComponent<TMP_Text>().text = GameManager.INSTANCE.endTexts[GameManager.INSTANCE.textIndex];
        if(GameManager.INSTANCE.textIndex < 2)
            GameManager.INSTANCE.textIndex++;
        else if(GameManager.INSTANCE.textIndex == 2)
            GameManager.INSTANCE.textIndex = 0;
    }
}
