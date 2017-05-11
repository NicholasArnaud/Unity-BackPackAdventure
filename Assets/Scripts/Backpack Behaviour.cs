using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackpackBehaviour : MonoBehaviour
{
    public Backpack backpackconfig;
    Backpack current;

	// Use this for initialization
	void Start ()
    {
        current = backpackconfig;
	}
	
	// Update is called once per frame
	void Update ()
    {
        
    }

    OnTriggerEnter(Collider other)
    {
    }

}
