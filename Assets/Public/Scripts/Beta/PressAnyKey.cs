﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressAnyKey : MonoBehaviour
{
    public GameObject Ukraine;
    public GameObject MainMenu;
    public GameObject Transition;
    public AudioSource Click;
    //public Animation animation;

    void Update()
    {
        if (Input.anyKey)
        {

            //animation.Play();
            Ukraine.SetActive(false);
            MainMenu.SetActive(true);
            Click.Play();
            
            Destroy(this);
        }

    }
}
