using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgain : MonoBehaviour
{
    public void PlayAgainButton()
    {
        WorldState.Value = 0;
        PickUpsScore.Cherry = 0;
        PickUpsScore.Bottle = 0;
        PickUpsScore.Bee = 0;
        PickUpsScore.Shirt = 0;
        SceneManager.LoadScene("Game");
    }
}
