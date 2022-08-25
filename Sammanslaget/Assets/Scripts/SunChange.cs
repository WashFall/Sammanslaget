using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunChange : MonoBehaviour
{
    public GameObject[] faces = new GameObject[2];

    private void Start()
    {
        for(int i = 0; i < faces.Length; i++)
        {
            faces[i] = transform.GetChild(i).gameObject;
        }
    }
}
