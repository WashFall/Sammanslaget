using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager INSTANCE { get { return _instance; } }

    public List<AddScore> AddScoreList = new List<AddScore>();

    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void OnPickUp(GameObject pickUp)
    {
        foreach(AddScore score in AddScoreList)
        {
            score.ScoreUp(pickUp.GetComponent<PickUp>().objectType);
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
