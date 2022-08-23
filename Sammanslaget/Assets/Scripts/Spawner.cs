using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject pickUp;
    private float startTime;
    private float height;
    private int randomHeight;

    void Start()
    {
        startTime = Time.time;
        SetHeight();
    }

    void Update()
    {
        if(Time.time > startTime + 1.5f)
        {
            Instantiate(pickUp, new Vector2(10, height), Quaternion.identity);
            startTime = Time.time;
            SetHeight();
        }
    }

    void SetHeight()
    {
        randomHeight = Random.Range(1, 4);

        if (randomHeight == 1)
        {
            height = 1f;
        }
        else if(randomHeight == 2)
        {
            height = -1.5f;
        }
        else if(randomHeight == 3)
        {
            height = -3.5f;
        }
    }
}
