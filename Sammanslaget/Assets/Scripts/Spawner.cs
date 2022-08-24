using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject cherry, bottle;
    private float startTime;
    private float height;
    private int randomHeight;
    private int spawnIndex;
    private float spawnRate;
    private List<GameObject> spawnList = new List<GameObject>();

    void Start()
    {
        startTime = Time.time;
        spawnList.Add(cherry);
        spawnList.Add(bottle);

        SetHeight();
        SetSpawnObject();
        SetSpawnRate();
    }

    void Update()
    {
        if(Time.time > startTime + spawnRate)
        {
            Instantiate(spawnList[spawnIndex], new Vector2(8.5f, height), Quaternion.identity);
            startTime = Time.time;
            SetHeight();
            SetSpawnObject();
            SetSpawnRate();
        }
    }

    private void SetSpawnObject()
    {
        spawnIndex = Random.Range(0, spawnList.Count);
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

    void SetSpawnRate()
    {
        int spawnRateSelect = Random.Range(1, 5);

        if (spawnRateSelect == 1)
            spawnRate = 0.75f;
        else if (spawnRateSelect == 2)
            spawnRate = 1f;
        else if (spawnRateSelect == 3)
            spawnRate = 1.25f;
        else if (spawnRateSelect == 4)
            spawnRate = 1.5f;
    }
}
