using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControls : MonoBehaviour
{
    public GameObject player;
    private PlayerMove pm;

    private void Start()
    {
        pm = player.GetComponent<PlayerMove>();
    }

    private void OnMouseDown()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit) && pm.grounded)
        {
            player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 20);
            ServiceLocator.sound.PlayOnce("jump2");
            TextToggle.toggle = true;
        }
    }
}
