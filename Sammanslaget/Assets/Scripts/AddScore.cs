using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddScore : MonoBehaviour
{
    public string itemType;
    public int score = 0;

    private void Start()
    {
        GameManager.INSTANCE.AddScoreList.Add(this);
    }

    public void ScoreUp(string pickUp)
    {
        if(pickUp == itemType)
        {
            score++;
            GetComponent<Text>().text = score.ToString();
        }
    }
}
