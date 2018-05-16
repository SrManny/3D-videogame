using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class MarioController : MonoBehaviour {

    public float speed = 5.0f;
    public string state = "falling";
    public static int poder = 1;
    public static Vector3 dir, anterior, dondeMirar, posMario;
    public GameObject plataforma1;
    public static bool ocupat = false;
    private Animator animate;
    public AudioClip jumpSound;
    private AudioSource source;
    // Use this for initialization

    double distance(Vector3 dist1, Vector3 dist2)
    {
        return Math.Sqrt((dist1.x-dist2.x)*(dist1.x - dist2.x) + (dist1.z- dist2.z)* (dist1.z - dist2.z));
    }

    void Start () {
        BoxCollider bx = plataforma1.GetComponent<BoxCollider>();
        dir = bx.center + plataforma1.transform.position;
        state = "falling";
        animate = GetComponent<Animator>();
        posMario = transform.position;


    }


    // Update is called once per frame
    void Update () {
        //if ((dir.x != transform.position.x) || (dir.z != transform.position.z)) ;
        /*if (0 == distance(dir, transform.position))
        GetComponent<Rigidbody>().
           GetComponent<Rigidbody>().isKinematic = false;*/
        // Quaternion cameraRelativeRotation = Quaternion.FromToRotation(transform.forward, dir);
        posMario = transform.position;
        double aux = distance(dir, transform.position);
        double jump = dir.y - transform.position.y;
        // Ray lookRay = new Ray(transform.position, lookToward);
        // transform.LookAt(lookRay.GetPoint(1));
        transform.LookAt(new Vector3(dondeMirar.x, transform.position.y, dondeMirar.z));
        //dir = Quaternion.cameraRelativeRotation * dir;
        //transform.rotation = Quaternion.LookRotation(new Vector3(dir.x, transform.position.y, dir.z));
        if (aux < 0.1 && Math.Abs(jump) <= 1 && ocupat)
        {
            ocupat = false;
        }
        if (Math.Abs(jump) < 1.1 && aux < 0.01)
        {
            animate.SetInteger("State", 0);
            state = "idle";
            anterior = transform.position;
        }
        
        else if (Math.Abs(jump) > 17 || aux > 12)
        {
            ocupat = false;
            state = "idle";
            animate.SetInteger("State", 0);
            //Debug.Log("Estoy idle");
        }
        else if ((state == "Walking" || state == "falling" || state == "idle") && Math.Abs(jump) < 1.1 && aux < 12)
        {
            state = "Walking";
            if (aux > 0.5) animate.SetInteger("State", 1);
            else animate.SetInteger("State", 0);
            //transform.Translate((dir.x - transform.position.x) * Time.deltaTime * speed, 0, (dir.z - transform.position.z) * Time.deltaTime * speed, Space.World);
            transform.Translate((dir.x - transform.position.x) * Time.deltaTime * speed, 0, (dir.z - transform.position.z) * Time.deltaTime * speed, Space.World);
            if (aux < 0.3) transform.position = new Vector3(dir.x, transform.position.y, dir.z);
           // Debug.Log("Estoy walking" + jump);
        }

        else if ((state == "idle" || state == "Walking") && aux < 12 && jump > 8 && jump < 12)
        {
            state = "Jumping";
            animate.SetInteger("State", 2);
            GetComponent<Rigidbody>().AddForce(new Vector3((dir.x - transform.position.x) * 1, 41, (dir.z - transform.position.z) * 1), ForceMode.Impulse);
            //GetComponent<Rigidbody>().AddForce(new Vector3(3, 60, 3), ForceMode.Impulse);
           // Debug.Log("Estoy quiero saltar con una fuerza vertical de " + (dir.y - transform.position.y) * 10);
            AudioSource.PlayClipAtPoint(jumpSound, transform.position);
        }
        else if ((state == "idle" || state == "Walking") && aux < 12 && jump < -8 && jump > -12)
        {
            state = "Jumping";
            animate.SetInteger("State", 2);
            GetComponent<Rigidbody>().AddForce(new Vector3((dir.x - transform.position.x) * 1, 21, (dir.z - transform.position.z) * 1), ForceMode.Impulse);
            AudioSource.PlayClipAtPoint(jumpSound, transform.position);
           // Debug.Log("Estoy quiero saltar");
        }
        else if (state == "Jumping" && jump < -3.4)
        {
            state = "falling";
        }

        
       // Debug.Log("La altura es " + jump +" y la distancia es " + aux + "estoy en el estado " + state + "estoy ocupado" + ocupat);
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
