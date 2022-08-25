using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class BirdMove : MonoBehaviour
{
    private Vector3 startPos;
    private Animator birdAnim;

    void Start()
    {
        birdAnim = GetComponentInChildren<Animator>();
        startPos = transform.position;
        GetComponent<Rigidbody2D>().velocity = new Vector2(3, 0);
    }

    void Update()
    {
        if(transform.position.x > 25)
        {
            transform.position = startPos;
        }

        if(WorldState.Value <= -3)
        {
            birdAnim.SetBool("ToggleBirdAnim", true);
        }
        else
        {
            birdAnim.SetBool("ToggleBirdAnim", false);
        }
    }
}
