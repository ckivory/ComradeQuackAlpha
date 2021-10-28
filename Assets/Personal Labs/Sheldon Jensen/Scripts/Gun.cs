using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    // ***CONTROLS*** //
    //-------------------
    // right-click: aim
    // right-click + left-click: shoot
    // left-shift: switch weapon


    // Reference: https://youtu.be/THnivyG0Mvo

    public float damage = 10;
    public float range = 100;

    public GameObject gun;
    public GameObject impactEffect;
    public Vector3 gunRotation;
    public LayerMask PlayerLayerMask;
    public ParticleSystem muzzleFlash;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // check for shooting input
        if (Input.GetButtonDown("Fire1") && Input.GetButton("Fire2"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // play flash animation
        muzzleFlash.Play();

        // get raycast from mouse position
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast(ray, out hit, range, ~PlayerLayerMask))
        {
            //Transform objectHit = hit.transform;
            Debug.Log(hit.transform.name);
            

            // find what we hit and apply damage
            Target t = hit.transform.GetComponent<Target>();
            if (t != null)
            {
                Debug.Log(t.name + " was hit!");
                t.TakeDamage(damage);
                Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            }
        }
    }
}
