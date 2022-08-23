using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rigid;
    public bool grounded;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigid.velocity = new Vector2(0, 20);
        }
    }
}
