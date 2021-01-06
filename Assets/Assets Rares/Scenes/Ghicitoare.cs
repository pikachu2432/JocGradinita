using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghicitoare : MonoBehaviour
{
    public AudioSource bravo;
    public AudioSource ghicitoare;

    private bool hasPlayed_1;
    private bool hasPlayed_2;
    // Start is called before the first frame update
    void Start()
    {
        bool hasPlayed_1 = false;
        bool hasPlayed_2 = false;
    }

    // Update is called once per frame
    void Update()
    {
        if ( !hasPlayed_1) {
            bravo.Play();
            hasPlayed_1 = true;
        }
        if ( hasPlayed_1 && !hasPlayed_2 && !bravo.isPlaying) {
            ghicitoare.Play();
            hasPlayed_2 = true;
        }

    }
    
}