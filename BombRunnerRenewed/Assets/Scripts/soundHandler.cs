using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundHandler : MonoBehaviour
{
    // Start is called before the first frame update

    public AudioSource boomSound;
    void start()
    {
        boomSound = GetComponent<AudioSource>();
    }
    
    public void playExp()
    {
        if (!boomSound.isPlaying)
        {
            boomSound.Play();
        }
    }


}
