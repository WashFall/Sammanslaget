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
    private List<GameObject> spawnList = new List<GameObject>();

    void Start()
    {
        startTime = Time.time;
        spawnList.Add(cherry);
        spawnList.Add(bottle);

        SetHeight();
        SetSpawnObject();
    }

    void Update()
    {
        if(Time.time > startTime + 1.5f)
        {
            Instantiate(spawnList[spawnIndex], new Vector2(8.5f, height), Quaternion.identity);
            startTime = Time.time;
            SetHeight();
            SetSpawnObject();
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
}
