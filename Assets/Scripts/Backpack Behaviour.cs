﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackpackBehaviour : MonoBehaviour
{

    List<Item> items = new List<Item>();
    BackpackConfig backpackconfig;

	// Use this for initialization
	void Start ()
    {
	}
	
	// Update is called once per frame
	void Update ()
    {
        OnTriggerEnter(Collider other)
        {

        }
    }


}