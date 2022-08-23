using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGrounded : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerMove>().grounded = true;
            Debug.Log("Grounded");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerMove>().grounded = false;
            Debug.Log("Jumping");
        }
    }
}
