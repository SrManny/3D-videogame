using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class NewBehaviourScript : MonoBehaviour {

    public float speed = 5.0f;
    public string state = "idle";
    public static Vector3 dir;
    public GameObject plataforma1;
    public static bool ocupat = false;
    // Use this for initialization
    double distance(Vector3 dist1, Vector3 dist2)
    {
        return Math.Sqrt((dist1.x-dist2.x)*(dist1.x - dist2.x) + (dist1.z- dist2.z)* (dist1.z - dist2.z));
    }

    void Start () {
        BoxCollider bx = plataforma1.GetComponent<BoxCollider>();
        dir = bx.center + plataforma1.transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        //if ((dir.x != transform.position.x) || (dir.z != transform.position.z)) ;
        /*if (0 == distance(dir, transform.position))
        GetComponent<Rigidbody>().
           GetComponent<Rigidbody>().isKinematic = false;*/

        double aux = distance(dir, transform.position);
        double jump = dir.y - transform.position.y;
        if (aux < 0.1 && Math.Abs(jump) <= 0.5 && ocupat) ocupat = false;
        if (Math.Abs(jump) > 15 || aux > 12)
        {
            ocupat = false;
            state = "idle";
            Debug.Log("Estoy idle");
        }
        else if ((state == "Walking" || state == "idle") && Math.Abs(jump) < 1 && aux < 12)
        {
            state = "Walking";
            transform.Translate((dir.x - transform.position.x) * Time.deltaTime * speed, 0, (dir.z - transform.position.z) * Time.deltaTime * speed);
            Debug.Log("Estoy walking" + jump);
        }

        else if (state == "Walking" && aux < 12 && jump > 8 && jump < 12)
        {
            state = "Jumping";
            GetComponent<Rigidbody>().AddForce(new Vector3((dir.x - transform.position.x) * 2, 84, (dir.z - transform.position.z) * 2), ForceMode.Impulse);
            Debug.Log("Estoy quiero saltar con una fuerza vertical de " + (dir.y - transform.position.y) * 10);
        }
        else if (state == "Walking" && aux < 12 && jump < -8 && jump > -12)
        {
            state = "Jumping";
            GetComponent<Rigidbody>().AddForce(new Vector3((dir.x - transform.position.x) * 2, Math.Abs(dir.y - transform.position.y) * 5, (dir.z - transform.position.z) * 2), ForceMode.Impulse);
            Debug.Log("Estoy quiero saltar");
        }
        else if (state == "Jumping" && jump < -4)
        {
            state = "idle";
        }
        Debug.Log("La altura es " + jump +" y la distancia es " + aux + "estoy en el estado " + state + "estoy ocupado" + ocupat);
        /*if ((state == "Walking" || state == "idle") && aux < 0.3 || aux > 12)
        {
            state = "idle";
            Debug.Log("Estoy idle");
        }
        else if (state == "Jumping" && jump < -5)
        {
            state = "Walking";
            Debug.Log("Estoy Walking despues de saltar");
        }
        else if (aux < 12 && state != "Jumping")
        {
            state = "Walking";
        }
        if (state == "Walking" && (jump > 8 && jump < 12) || (jump < -8 && jump > -12))
        {
            state = "Jumping";
            GetComponent<Rigidbody>().AddForce(new Vector3((dir.x - transform.position.x)*2, Math.Abs(dir.y - transform.position.y)*10, (dir.z - transform.position.z)*2), ForceMode.Impulse);
        }
        else if (state == "Walking")
        {
            transform.Translate((dir.x - transform.position.x) * Time.deltaTime * speed, 0, (dir.z - transform.position.z) * Time.deltaTime * speed);
            Debug.Log("OLA");
        }*/
    }
}
