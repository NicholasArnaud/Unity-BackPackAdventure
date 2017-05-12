using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnPyshicsTrigger : MonoBehaviour {

    class OnTriggerEnter : UnityEvent
    { }

    class OnTriggerExit : UnityEvent
    { }

    public OnTriggerEnter onTriggerEnter;

    public OnTriggerExit onTriggerExit;




    void Awake()
    {
        
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
