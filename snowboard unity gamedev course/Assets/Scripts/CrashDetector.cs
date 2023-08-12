using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float delayAmount = 1f;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSFX;
    bool musicPlayed = false;
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Floor")
        {
            FindObjectOfType<PlayerController>().DisableControls();
            crashEffect.Play();
            if(!musicPlayed)
            {
                GetComponent<AudioSource>().PlayOneShot(crashSFX);
                musicPlayed = true; 
            }
            Invoke("ReloadScene", delayAmount);
            
        }    
    }
    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
