using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GoombaController : MonoBehaviour {

    // Use this for initialization
    public static bool movimiento;
    public int GirarYAvanzar = 0;
    public bool NoHaLlegado = false;
    public Vector3 objetivo;

    double distance(Vector3 dist1, Vector3 dist2)
    {
        return Math.Sqrt((dist1.x - dist2.x) * (dist1.x - dist2.x) + (dist1.z - dist2.z) * (dist1.z - dist2.z));
    }
    void Start () {
        movimiento = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (movimiento)
        {
            movimiento = false;
            NoHaLlegado = true;
            
            if (GirarYAvanzar % 2 == 0) transform.Rotate(0, 90, 0);
            objetivo = transform.forward * 10 + transform.position;
            ++GirarYAvanzar;
        }
        if (NoHaLlegado)
        {
            transform.Translate((objetivo.x-transform.position.x) * Time.deltaTime * 5, 0, (objetivo.z - transform.position.z) * Time.deltaTime * 5, Space.World);
            if (distance(objetivo, transform.position) < 0.01) NoHaLlegado = false;
            Debug.Log("Estoy avanzando " + (objetivo.z - transform.position.z));
            Debug.Log(transform.position.x + " " + transform.position.y + " " + transform.position.z);
            Debug.Log(transform.forward * 10);
        }
	}
}
