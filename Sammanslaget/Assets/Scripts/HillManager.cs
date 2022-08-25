using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HillManager : MonoBehaviour
{
    public GameObject[] hills = new GameObject[2];
    private Vector3 hidden = new Vector3(-13, -9.2f, 0);
    private Vector3 startPos;

    private void Start()
    {
        startPos = transform.position;
        for(int i = 0; i < hills.Length; i++)
        {
            hills[i] = transform.GetChild(i).gameObject;
        }

        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-3, 0);
    }

    private void Update()
    {
        if(WorldState.Value <= -3)
        {
            hills[0].transform.localPosition = Vector3.zero;
            hills[1].transform.localPosition = hidden;
        }
        else
        {
            hills[1].transform.localPosition = Vector3.zero;
            hills[0].transform.localPosition = hidden;
        }

        if(transform.position.x < -14)
        {
            transform.position = startPos;
        }
    }
}
