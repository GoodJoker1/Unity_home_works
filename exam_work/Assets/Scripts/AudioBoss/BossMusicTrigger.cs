using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMusicTrigger : MonoBehaviour
{
    public AudioSource bossMusic; 
    private bool isMusicPlaying = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isMusicPlaying)  
        {
            bossMusic.Play(); 
            isMusicPlaying = true; 
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && isMusicPlaying) 
        {
            bossMusic.Stop(); 
            isMusicPlaying = false;
        }
    }
}
