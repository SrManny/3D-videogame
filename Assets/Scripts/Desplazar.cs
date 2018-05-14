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
        if (!MarioController.ocupat)
        {
            MarioController.dir = transform.position + bx.center;
            MarioController.ocupat = true;
        }
    }
}
