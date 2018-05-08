using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desplazar : MonoBehaviour {

    // Use this for initialization
    public bool click;
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
    }

    private void OnMouseDown()
    {
        BoxCollider bx = GetComponent<BoxCollider>();
        if (!NewBehaviourScript.ocupat)
        {
            NewBehaviourScript.dir = transform.position + bx.center;
            NewBehaviourScript.ocupat = true;
        }
    }
}
