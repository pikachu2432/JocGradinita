using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource Question;
    public AudioSource Answer;
    public AudioSource Instructions;
    private bool hasPlayed_0;
    private bool hasPlayed_1;
    private bool hasPlayed_2;
    void Start()
    {
        hasPlayed_0 = false;
        hasPlayed_1 = false;
        hasPlayed_2 = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasPlayed_0)
        {
            Question.Play();
            hasPlayed_0 = true;
            
        }
        else if (hasPlayed_0 && !hasPlayed_1 && !Question.isPlaying)
        {
            Answer.Play();
            hasPlayed_1 = true;
            Debug.Log("sunet1");
        }
        else if (hasPlayed_1 && !hasPlayed_2 && !Answer.isPlaying)
        {
            Instructions.Play();
            hasPlayed_2 = true;
        }

    }
}
