﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_DoorManager : MonoBehaviour
{
    // Start is called before the first frame update

    public bool CodeInput;
    public bool KeyInput;
    bool DoorHasOpened;

    public AudioSource opensound;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (CodeInput & KeyInput & !DoorHasOpened)
        {
            DoorHasOpened = true;
            DoorOpen();
        }
    }

    void DoorOpen()
    {
        GetComponent<Animator>().Play("Open Door1");
        opensound.Play();
    }
}
