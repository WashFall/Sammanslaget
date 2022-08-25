using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    Rigidbody2D rb;
    public string objectType;
    public int worldStateValue;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        int veloSpeed = Random.Range(-8, -15);
        rb.velocity = new Vector2(veloSpeed, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GameManager.INSTANCE.OnPickUp(gameObject);
            GameManager.INSTANCE.SkyColorChange();
            ServiceLocator.sound.PlayOnce("plopp2");
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if(transform.position.x < -10)
        {
            GameManager.INSTANCE.OnMissedPickUp(worldStateValue);
            GameManager.INSTANCE.SkyColorChange();
            Destroy(gameObject);
        }
    }
}
