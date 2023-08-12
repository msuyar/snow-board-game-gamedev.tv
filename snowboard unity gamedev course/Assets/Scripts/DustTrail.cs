using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustTrail : MonoBehaviour
{
    // Start is called before the first frame update
[SerializeField] ParticleSystem dustEffect;
    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "Floor")
        {
            dustEffect.Play();
        }
    } 
    private void OnCollisionExit2D(Collision2D other) 
    {
        dustEffect.Stop();    
    }
    
        
    
}
