using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBackPackLoader : MonoBehaviour
{

    public Backpack backpack = null;
	// Use this for initialization
	void Start ()
    {
		UnityEngine.Assertions.Assert.IsNull(backpack);
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
