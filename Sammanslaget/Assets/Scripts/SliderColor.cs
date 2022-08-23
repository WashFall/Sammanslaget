using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderColor : MonoBehaviour
{
    Image sliderImage;

    void Start()
    {
        sliderImage = GetComponent<Image>();
    }

    void Update()
    {
        if (WorldState.Value == 0)
        {
            sliderImage.color = Color.blue;
        }
        else if (WorldState.Value > 5)
        {
            sliderImage.color = Color.green;
        }
        else if (WorldState.Value <= 5 && WorldState.Value > 0)
        {
            sliderImage.color = Color.cyan;
        }
        else if (WorldState.Value < 0 && WorldState.Value >= -5)
        {
            sliderImage.color = Color.magenta;
        }
        else if(WorldState.Value < -5)
        {
            sliderImage.color = Color.red;
        }
    }
}
