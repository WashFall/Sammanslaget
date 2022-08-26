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
    public GameObject grass;
    private SpriteRenderer sunRend;
    private SunChange sunChange;
    private MeshRenderer skyRend, grassRend;
    public string[] endTexts = new string[3] 
    { EndScreenTexts.text1, EndScreenTexts.text2, EndScreenTexts.text3 };
    public float timer;
    public GameObject infoText;

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
        grassRend = grass.GetComponent<MeshRenderer>();
        sunRend = sun.GetComponent<SpriteRenderer>();
        sunChange = sun.GetComponent<SunChange>();
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

        if(WorldState.Value == 5 && PickUpsScore.Bottle + PickUpsScore.Shirt >= 10)
        {
            SceneManager.LoadScene("WinScreen");
        }
        else if(WorldState.Value == -5 && PickUpsScore.Cherry + PickUpsScore.Bee >= 10)
        {
            SceneManager.LoadScene("LoseScreen");
        }
        else if (Time.time > timer + 120)
        {
            SceneManager.LoadScene("LoseScreen");
        }

        if (TextToggle.toggle)
        {
            infoText.SetActive(false);
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
        else if(temp.objectType == "Bee")
        {
            PickUpsScore.Bee++;
        }
        else if(temp.objectType == "Shirt")
        {
            PickUpsScore.Shirt++;
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

        if(clampCheck == 1)
        {
            sunChange.faces[0].SetActive(true);
            sunChange.faces[1].SetActive(false);
        }
        else if (clampCheck == -1)
        {
            sunChange.faces[1].SetActive(true);
            sunChange.faces[0].SetActive(false);
        }
    }

    public void SkyColorChange()
    {
        if (WorldState.Value <= -5)
        {
            skyRend.material.color = SkyColors.level05;
            //sunRend.material.color = SkyColors.level05;
            grassRend.material.color = GrassColors.level5;
        }
        else if (WorldState.Value <= -4)
        {
            skyRend.material.color = SkyColors.level04;
            //sunRend.material.color = SkyColors.level04;
            grassRend.material.color = GrassColors.level4;
        }
        else if(WorldState.Value == -3)
        {
            skyRend.material.color = SkyColors.level03;
            //sunRend.material.color = SkyColors.level03;
            grassRend.material.color = GrassColors.level3;
        }
        else if (WorldState.Value == -2)
        {
            skyRend.material.color = SkyColors.level02;
            //sunRend.material.color = SkyColors.level02;
            grassRend.material.color = GrassColors.level2;
        }
        else if (WorldState.Value == -1)
        {
            skyRend.material.color = SkyColors.level01;
            //sunRend.material.color = SkyColors.level01;
            grassRend.material.color = GrassColors.level1;
        }
        else if(WorldState.Value == 0)
        {
            skyRend.material.color = SkyColors.level0;
            //sunRend.material.color = SkyColors.level0;
            grassRend.material.color = GrassColors.level0;
        }
        else if (WorldState.Value == 1)
        {
            skyRend.material.color = SkyColors.level1;
        }
        else if (WorldState.Value == 2)
        {
            skyRend.material.color = SkyColors.level2;
        }
        else if (WorldState.Value == 3)
        {
            skyRend.material.color = SkyColors.level3;
        }
        else if (WorldState.Value == 4)
        {
            skyRend.material.color = SkyColors.level4;
        }
        else if (WorldState.Value == 5)
        {
            skyRend.material.color = SkyColors.level5;
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
            sunChange.faces[1].SetActive(true);
            sunChange.faces[0].SetActive(false);
        }
    }
}
