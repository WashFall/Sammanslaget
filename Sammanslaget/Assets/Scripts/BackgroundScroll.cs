using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    public float speed;
    Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        float coord = Mathf.Repeat(Time.time * speed, 1);
        Vector2 offset = new Vector2(coord, 0);
        rend.sharedMaterial.SetTextureOffset("_MainTex", offset);
    }
}
