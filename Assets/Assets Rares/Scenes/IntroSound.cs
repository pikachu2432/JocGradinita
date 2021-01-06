using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroSound : MonoBehaviour
{
    public AudioSource intro;
    public AudioSource instructiuni;
    public AudioSource btnGalben;
    public AudioSource btnAlbastru;
    public AudioSource ghicitoare;

    private bool hasPlayed_1;
    private bool hasPlayed_2;
    private bool hasPlayed_3;
    private bool hasPlayed_4;
    private bool hasPlayed_5;
    // Start is called before the first frame update
    void Start()
    {
        bool hasPlayed_1 = false;
        bool hasPlayed_2 = false;
        bool hasPlayed_3 = false;
        bool hasPlayed_4 = false;
        bool hasPlayed_5 = false;
    }

    // Update is called once per frame
    void Update()
    {
        if ( !hasPlayed_1) {
            intro.Play();
            hasPlayed_1 = true;
        }
        if ( hasPlayed_1 && !hasPlayed_2 && !intro.isPlaying) {
            instructiuni.Play();
            hasPlayed_2 = true;
        }
        if ( hasPlayed_1 && hasPlayed_2 && !hasPlayed_3 && !instructiuni.isPlaying)
        {
            btnGalben.Play();
            hasPlayed_3 = true;
        }
        if ( hasPlayed_1 && hasPlayed_2 && hasPlayed_3 && !hasPlayed_4 && !btnGalben.isPlaying)
        {
            ghicitoare.Play();
            hasPlayed_4 = true;
        }
        if ( hasPlayed_1 && hasPlayed_2 && hasPlayed_3 && hasPlayed_4 && !hasPlayed_5 && !ghicitoare.isPlaying)
        {
            btnAlbastru.Play();
            hasPlayed_5 = true;
        }
      
    }
    
}
