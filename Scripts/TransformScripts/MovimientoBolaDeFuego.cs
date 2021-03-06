﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class MovimientoBolaDeFuego : MonoBehaviour
{
    public float timeToActivatecollider = 0.1f;
    public AudioClip deleteAnEnemy;
    public Vector3 origen;
    // Use this for initialization
    void Start()
    {
    }
    double distance(Vector3 dist1, Vector3 dist2)
    {
        return Math.Sqrt((dist1.x - dist2.x) * (dist1.x - dist2.x) + (dist1.z - dist2.z) * (dist1.z - dist2.z) + (dist1.y - dist2.y) * (dist1.y - dist2.y));
    }
    // Update is called once per frame
    void Update()
    {
        if (timeToActivatecollider > 0) origen = transform.position;
        timeToActivatecollider -= Time.deltaTime;
        if (timeToActivatecollider < 0)
        {
            GetComponent<SphereCollider>().enabled = true;
        }
    }

    private void OnCollisionEnter(Collision enter)
    {
        if (enter.gameObject.transform.parent != null && enter.gameObject.transform.parent.tag == "Tile")
        {
            if (distance(origen, transform.position) < 17)
            {
                GetComponent<Rigidbody>().AddForce(new Vector3(0, 25, 0), ForceMode.Impulse);
            }
            else GetComponent<Rigidbody>().AddForce(new Vector3(0, 10, 0), ForceMode.Impulse);
            GetComponent<Rigidbody>().AddForce(-transform.forward*10, ForceMode.Impulse);
        }
        else if (enter.gameObject.tag == "Goomba" || enter.gameObject.tag == "Koopa")
        {
            DestroyObject(enter.gameObject);
            AudioSource.PlayClipAtPoint(deleteAnEnemy, transform.position);
            DestroyObject(gameObject);
        }
        else
        {
            AudioSource.PlayClipAtPoint(deleteAnEnemy, transform.position);
            DestroyObject(gameObject);
        }
    }
}
