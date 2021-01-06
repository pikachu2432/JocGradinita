using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Explicatii : MonoBehaviour
{
    //Obiectele ce vor aparea pe parcurs
    private GameObject avion;
    private GameObject elicopter;
    private GameObject balon;

    //Declarare audiouri posibile
    private bool hasPlayed_0;
    public AudioSource introducere;
    private bool hasPlayed_1;
    public AudioSource avion_explicatii;
    private bool hasPlayed_2;
    public AudioSource elicopter_explicatii;
    private bool hasPlayed_3;
    public AudioSource balon_explicatii;
    

    // Start is called before the first frame update
    void Start()
    {
        avion = GameObject.Find("avion");
        elicopter = GameObject.Find("elicopter");
        balon = GameObject.Find("balon");
        avion.SetActive(false);
        elicopter.SetActive(false);
        balon.SetActive(false);
        hasPlayed_0 = false;
        hasPlayed_1 = false;
        hasPlayed_2 = false;
        hasPlayed_3 = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasPlayed_0)
        {
            introducere.Play();
            hasPlayed_0 = true;
        }
        else if (hasPlayed_0 && !hasPlayed_1 && !introducere.isPlaying)
        {
            avion_explicatii.Play();
            hasPlayed_1 = true;
            avion.SetActive(true);
        }
        else if (hasPlayed_1 && !hasPlayed_2 && !avion_explicatii.isPlaying)
        {
            elicopter_explicatii.Play();
            hasPlayed_2 = true;
            elicopter.SetActive(true);
        }
        else if (hasPlayed_2 && !hasPlayed_3 && !elicopter_explicatii.isPlaying)
        {
            balon_explicatii.Play();
            hasPlayed_3 = true;
            balon.SetActive(true);
        }
        else if (hasPlayed_3 && !balon_explicatii.isPlaying)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
