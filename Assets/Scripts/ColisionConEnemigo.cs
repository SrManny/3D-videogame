using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionConEnemigo : MonoBehaviour {

    // Use this for initialization
    private Animator animate;
    void Start () {
        animate = GetComponent<Animator>();

    }
	
	// Update is called once per frame
	void LateUpdate () {
		
	}

    void OnCollisionEnter(Collision collision)
    {
        //Destroy(collision.gameObject);
        if (collision.gameObject.tag == "Goomba" && !animate.GetBool("Dañado") && !GoombaController.starts)
        {
            Debug.Log("eeeeeee" + collision.contacts[0].point.y);

            animate.SetBool("Dañado", true);
            MarioController.dir = MarioController.anterior;
            BoxCollider bx = collision.gameObject.GetComponent<BoxCollider>();
            MarioController.dondeMirar = transform.position + bx.center;
        }
        else if (collision.gameObject.tag != "Goomba")
        {
            animate.SetBool("Dañado", false);
        }
    }
}
