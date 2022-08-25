using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AddScore : MonoBehaviour
{
    public string itemType;
    public int score = 0;

    private void Start()
    {
        if(itemType == "Cherry")
        {
            score = PickUpsScore.Cherry;
            GetComponent<TMP_Text>().text = score.ToString();
        }
        else if(itemType == "Bottle")
        {
            score = PickUpsScore.Bottle;
            GetComponent<TMP_Text>().text = score.ToString();
        }
        else if(itemType == "Bee")
        {
            score = PickUpsScore.Bee;
            GetComponent<TMP_Text>().text = score.ToString();
        }
        else if(itemType == "Shirt")
        {
            score = PickUpsScore.Shirt;
            GetComponent<TMP_Text>().text = score.ToString();
        }
    }
}
