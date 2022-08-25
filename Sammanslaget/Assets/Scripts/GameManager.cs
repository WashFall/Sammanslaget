using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager INSTANCE { get { return _instance; } }

    public GameObject slider;
    public GameObject sky;
    public GameObject sun;
    private SpriteRenderer sunRend;
    private MeshRenderer skyRend;
    public string[] endTexts = new string[3] 
    { EndScreenTexts.text1, EndScreenTexts.text2, EndScreenTexts.text3 };
    public float timer;

    private bool sliderActive = true;

    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        skyRend = sky.GetComponent<MeshRenderer>();
        sunRend = sun.GetComponent<SpriteRenderer>();
        timer = Time.time;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            slider.SetActive(sliderActive);
            sliderActive = sliderActive ? false : true;
            print(sliderActive);
        }

        if(WorldState.Value == 5 && PickUpsScore.Bottle >= 10)
        {
            SceneManager.LoadScene("WinScreen");
        }
        else if(WorldState.Value == -5 && PickUpsScore.Cherry >= 10)
        {
            SceneManager.LoadScene("LoseScreen");
        }
        else if (Time.time > timer + 120)
        {
            SceneManager.LoadScene("LoseScreen");
        }
    }

    public void OnPickUp(GameObject pickUp)
    {
        PickUp temp = pickUp.GetComponent<PickUp>();

        if(temp.objectType == "Cherry")
        {
            PickUpsScore.Cherry++;
        }
        else if(temp.objectType == "Bottle")
        {
            PickUpsScore.Bottle++;
        }

        int clampCheck = pickUp.GetComponent<PickUp>().worldStateValue;
        if(clampCheck == 1)
        {
            if(WorldState.Value == 5)
            {
                return;
            }
            else
            {
                WorldState.Value += clampCheck;
            }
        }
        else if(clampCheck == -1)
        {
            if(WorldState.Value == -5)
            {
                return;
            }
            else
            {
                WorldState.Value += clampCheck;
            }
        }
    }

    public void SkyColorChange()
    {
        if(WorldState.Value <= -4)
        {
            skyRend.material.color = SkyColors.level5;
            sunRend.material.color = SkyColors.level5;
        }
        else if(WorldState.Value == -3)
        {
            skyRend.material.color = SkyColors.level4;
            sunRend.material.color = SkyColors.level4;
        }
        else if (WorldState.Value == -2)
        {
            skyRend.material.color = SkyColors.level3;
            sunRend.material.color = SkyColors.level3;
        }
        else if (WorldState.Value == -1)
        {
            skyRend.material.color = SkyColors.level2;
            sunRend.material.color = SkyColors.level2;
        }
        else if(WorldState.Value >= 0)
        {
            skyRend.material.color = SkyColors.level1;
            sunRend.material.color = SkyColors.level1;
        }
    }

    public void OnMissedPickUp(int itemValue)
    {
        if (itemValue == 1)
        {
            if (WorldState.Value == -5)
            {
                return;
            }
            else
            {
                WorldState.Value -= itemValue;
            }
        }
    }
}
