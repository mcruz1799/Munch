﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{

    public int HealthEffect{get {return healthEffect;}}
    [SerializeField] private int healthEffect;
    public int ScoreEffect{get {return scoreEffect;}}
    [SerializeField] private int scoreEffect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
