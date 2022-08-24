using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager INSTANCE { get { return _instance; } }

    public List<AddScore> AddScoreList = new List<AddScore>();
    public GameObject slider;
    public GameObject sky;
    private MeshRenderer skyRend;

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
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            slider.SetActive(sliderActive);
            sliderActive = sliderActive ? false : true;
            print(sliderActive);
        }
    }

    public void OnPickUp(GameObject pickUp)
    {
        foreach(AddScore score in AddScoreList)
        {
            score.ScoreUp(pickUp.GetComponent<PickUp>().objectType);
        }
        int clampCheck = pickUp.GetComponent<PickUp>().worldStateValue;
        if(clampCheck == 1)
        {
            if(WorldState.Value == 10)
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
            if(WorldState.Value == -10)
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
        if(WorldState.Value <= -8)
        {
            skyRend.material.color = SkyColors.level5;
        }
        else if(WorldState.Value <= -6 && WorldState.Value > -8)
        {
            skyRend.material.color = SkyColors.level4;
        }
        else if (WorldState.Value <= -4 && WorldState.Value > -6)
        {
            skyRend.material.color = SkyColors.level3;
        }
        else if (WorldState.Value <= -2 && WorldState.Value > -4)
        {
            skyRend.material.color = SkyColors.level2;
        }
        else if(WorldState.Value >= 0)
        {
            skyRend.material.color = SkyColors.level1;
        }
    }

    public void OnMissedPickUp(int itemValue)
    {
        if (itemValue == 1)
        {
            if (WorldState.Value == -10)
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
