using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionConEnemigo : MonoBehaviour {

    // Use this for initialization
    private Animator animate;
    public GameObject mainCamara;
    public static bool marioDañado, destransformandose;
    public float timeTrans = 1.0f;
    private GameObject aux;
    public Texture2D TrajeFuego, TrajeHielo, TrajeNormal, anterior;
    public AudioClip MarioDestransformacion;
    public AudioClip ohhSound;
    void Start () {
        animate = GetComponent<Animator>();
        marioDañado = false;
        destransformandose = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (destransformandose)
        {
            timeTrans -= Time.deltaTime;
            if (timeTrans < 0.0f)
            {
                destransformandose = false;
                animate.enabled = true;
                timeTrans = 1.0f;
                animate.SetBool("Dañado", true);
            }
            else
            {
                if (MarioController.poder == 0)
                {
                    if (timeTrans > 0.6f) transform.localScale = new Vector3(13, 5, 13);
                    else if (timeTrans > 0.4f) transform.localScale = new Vector3(13, 11, 13);
                    else transform.localScale = new Vector3(13, 8, 13);
                }
                else
                {
                    if (timeTrans > 0.6f) GetComponentInChildren<Renderer>().material.mainTexture = TrajeNormal;
                  
                    else if (timeTrans > 0.4f) GetComponentInChildren<Renderer>().material.mainTexture = anterior;
                    else GetComponentInChildren<Renderer>().material.mainTexture = TrajeNormal;

                }
            }
        }

        else if (marioDañado)
        {
            Debug.Log("eeeeeee");
            MarioController.dir = MarioController.anterior;
            BoxCollider bx = aux.GetComponent<BoxCollider>();
            MarioController.dondeMirar = transform.position + bx.center;
            if (MarioController.poder == 0)
            {


            }
            else if (MarioController.poder == 1)
            {
                transform.localScale = new Vector3(13, 8, 13);
                destransformandose = true;
                animate.enabled = false;
                MarioController.poder = 0;
                AudioSource.PlayClipAtPoint(MarioDestransformacion, mainCamara.transform.position);
                AudioSource.PlayClipAtPoint(ohhSound, mainCamara.transform.position);
            }
            else if (MarioController.poder == 2 || MarioController.poder == 3)
            {
                if (MarioController.poder == 2) anterior = TrajeFuego;
                else anterior = TrajeHielo;
                GetComponentInChildren<Renderer>().material.mainTexture = TrajeNormal;
                destransformandose = true;
                animate.enabled = false;
                MarioController.poder = 1;
                AudioSource.PlayClipAtPoint(MarioDestransformacion, transform.position);
                AudioSource.PlayClipAtPoint(ohhSound, transform.position);
            }
            marioDañado = false;
        }
        else animate.SetBool("Dañado", false);
    }

    void OnCollisionEnter(Collision collision)
    {
        //Destroy(collision.gameObject);
       // if (collision.gameObject.transform.parent.transform.parent.tag == "Enemy")
      //  {
            aux = collision.gameObject;
            if (collision.gameObject.tag == "Goomba" && !animate.GetBool("Dañado") && GoombaController.marioDañado)
            {
            Debug.Log("eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee");
            aux = collision.gameObject;
            //Debug.Log("eeeeeee" + collision.contacts[0].point.y);
            marioDañado = true || marioDañado;
            }
            
      //  }
        /*else if (collision.gameObject.tag != "Goomba")
        {
            animate.SetBool("Dañado", false);
        }*/
    }
}
