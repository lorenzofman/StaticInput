﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Benchmarker : MonoBehaviour
{
    int greatNumber = 10000;
    public GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i< greatNumber; i++)
        {
            Instantiate(prefab);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
