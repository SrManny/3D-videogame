using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Desplazar : MonoBehaviour {

    // Use this for initialization
    public bool click = false;

    double distance(Vector3 dist1, Vector3 dist2)
    {
        return Math.Sqrt((dist1.x - dist2.x) * (dist1.x - dist2.x) + (dist1.z - dist2.z) * (dist1.z - dist2.z));
    }
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
            MarioController.dondeMirar = MarioController.dir;
            MarioController.ocupat = true;
            float jump = MarioController.dir.y - MarioController.posMario.y;
            double aux = distance(MarioController.dir, MarioController.posMario);
            if (Math.Abs(jump) <= 17 && aux <= 12) GoombaController.movimiento = true;
        }
    }
}
