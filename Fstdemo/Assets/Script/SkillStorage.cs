﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillStorage : MonoBehaviour
{
    private GameManager GameManager;
    // Start is called before the first frame update
    void Start()
    {
       GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
