using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItem : MonoBehaviour
{
    public List<GameObject> items;
	// Use this for initialization
	void Start ()
    {
		items.ForEach(x => Instantiate(x));
    }
}
