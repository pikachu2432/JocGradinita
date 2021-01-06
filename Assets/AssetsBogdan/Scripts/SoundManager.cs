using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip Bravo, ErrorSound, Corect, Foarte_bine, Stiu_ca_poti, BravoSf, Buton, Tutorial,Alege_mijloc;

    private static AudioSource audiSrc;
    
    // Start is called before the first frame update
    void Start()
    {
        Bravo = Resources.Load<AudioClip>("Bravo");
        Corect = Resources.Load<AudioClip>("Corect");
        ErrorSound = Resources.Load<AudioClip>("ErrorSound");
        Foarte_bine = Resources.Load<AudioClip>("Foarte_bine");
        Stiu_ca_poti = Resources.Load<AudioClip>("Stiu_ca_poti");
        BravoSf = Resources.Load<AudioClip>("BravoSf");
        Buton = Resources.Load<AudioClip>("Buton");
        Tutorial= Resources.Load<AudioClip>("Tutorial");
        Alege_mijloc = Resources.Load<AudioClip>("Alege_mijlocul_de_transport");
        
        audiSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public bool playedTutorial = false;

    public bool playedButon = false;
    public bool playedInc = false;
    public bool playedAlg = false;
    void Update()
    {
        if (!playedTutorial)
        {
            SoundManager.PlaySound("Tutorial");
            playedTutorial = true;
        }
        if (playedTutorial && !playedButon && !audiSrc.isPlaying)
        {
            SoundManager.PlaySound("Buton");
            playedButon = true;
        }
        if (GameObject.Find("umbraAvion") == null && GameObject.Find("umbraBalon") == null &&
            GameObject.Find("umbraElicopter") == null)
        {
            if (!playedInc)
            {
                SoundManager.PlaySound("BravoSf");
                playedInc = true;
            }

            if (playedInc && !playedAlg && !audiSrc.isPlaying)
            {
                SoundManager.PlaySound("Alege_mijlocul_de_transport");
            }

        }
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "Bravo":
                audiSrc.PlayOneShot(Bravo);
                break;
            case "ErrorSound":
                audiSrc.PlayOneShot(ErrorSound);
                break;
            case "Corect":
                audiSrc.PlayOneShot(Corect);
                break;
            case "Foarte_bine":
                audiSrc.PlayOneShot(Foarte_bine);
                break;
            case "Stiu_ca_poti":
                audiSrc.PlayOneShot(Stiu_ca_poti);
                break;
            case "BravoSf":
                audiSrc.PlayOneShot(BravoSf);
                break;
            case "Buton":
                audiSrc.PlayOneShot(Buton);
                break;
            case "Tutorial":
            {
                audiSrc.PlayOneShot(Tutorial);
                break;
            }
            case "Alege_mijlocul_de_transport":
                audiSrc.PlayOneShot(Alege_mijloc);
                break;
        }
    }
    
}
