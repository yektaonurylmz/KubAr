using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AboveTextAndSound : MonoBehaviour
{


    public GameObject textOnGameObject;
    public Boolean TextFollowToCamera = true;
    public Boolean hiddenTextWhenClick = true;
    public Boolean playSoundCheck = true;
    public AudioClip[] audioClips;


    private AudioSource audioSourceforGameObject;

    // Use this for initialization
    void Start()
    {
        audioSourceforGameObject = GameObject.Find("AudioSource").GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {

        followTexttoCamera();


    }

    //Override
    void OnMouseDown()
    {
        showTextAndPlaySound();


    }

   

    void showTextAndPlaySound()
    {
        if (hiddenTextWhenClick)
        {
            if (textOnGameObject.activeSelf == true)
            {
                //Debug.Log("1 left click.");
                //myAudioSource.clip = aClips[0];
                //myAudioSource.Play();
                textOnGameObject.SetActive(false);

            }
            else
            {
                // Debug.Log("2 left click.");
                textOnGameObject.SetActive(true);
                if (playSoundCheck)
                {
                    audioSourceforGameObject.clip = audioClips[0];
                    audioSourceforGameObject.Play();
                }


            }
        }
    }


    void followTexttoCamera()
    {
        if (TextFollowToCamera)
        {
            if (textOnGameObject.activeSelf == true)
            {
                textOnGameObject.transform.LookAt(Camera.main.transform.position);
                //textOnGameObject.transform.Rotate(0, -180, 0);
            }
        }


    }



}
