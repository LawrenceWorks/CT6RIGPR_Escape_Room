﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class Keypad : MonoBehaviour
{
    public GameObject Enable;
    public GameObject Door1;

    public AudioSource Click;

    public string CorrectPassword = "123";
    public string input;
    public TMP_Text DisplayText;
    public AudioSource CorrectSound;
    public AudioSource WrongSound;
    public AudioMixerGroup mixerGroup;

    private bool KeypadScreen;
    private float btnClicked = 0;
    private float NumOfGuesses;

    void Start()
    {
        btnClicked = 0;
        NumOfGuesses = CorrectPassword.Length;
        CorrectSound.outputAudioMixerGroup = mixerGroup;
        WrongSound.outputAudioMixerGroup = mixerGroup;
    }

    void Update()
    {
        
            if (btnClicked == NumOfGuesses)
            {
                if (input == CorrectPassword)
                {
                    Door1.GetComponent<scr_DoorManager>().CodeInput = true;
                    CorrectSound.Play();
                    Debug.Log("Correct");
                    input = "";
                    btnClicked = 0;

                enabled = false;
                }
                else
                {
                    WrongSound.Play();
                    input = "";
                    DisplayText.text = input.ToString();
                    btnClicked = 0;
                }
            }
        
    }
    void OnGUI()
    {
        
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit, 1.0f))
                {
                    var selction = hit.transform;

                    if (selction.CompareTag("Keypad"))
                    {
                        KeypadScreen = true;

                        var selectionRender = selction.GetComponent<Renderer>();
                        if (selectionRender != null)
                        {
                            KeypadScreen = true;
                        }
                    }
                }
            }

            if (KeypadScreen)
            {
                Enable.SetActive(true);
                Time.timeScale = 0.0f;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        
    }

    public void ValueEntered(string valueEntered) 
    {
        switch (valueEntered) 
        {
            case "Q":
                Enable.SetActive(false);
                btnClicked = 0;
                input = "";
                KeypadScreen = false;
                DisplayText.text = input.ToString();
                Time.timeScale = 1.0f;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                break;

            case "C":
                btnClicked = 0;
                input = "";
                DisplayText.text = input.ToString();
                break;

            default:
                btnClicked++;
                Debug.Log("Value Entered");
                input += valueEntered;
                DisplayText.text = input.ToString();
                break;
        }
    }
    public void Playsound()
    {
        Click.Play();
    }
}
