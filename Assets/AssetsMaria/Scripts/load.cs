using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class load : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject fullStar;
    private GameObject fullCircle;
    private GameObject fullRomb;
    private GameObject fullRectangle;
    private GameObject fullHexagon;
    private bool go1;
    private bool go2;
    private bool go3;
    private bool go4;
    private bool go5;
    public AudioSource Bravo;
    public AudioSource Instructions;
    public AudioSource CeFrumos;

    private bool hasPlayed_0;
    private bool hasPlayed_1;

    void Start()
    {
        fullStar = GameObject.Find("fullStar");
        fullCircle = GameObject.Find("fullCircle");
        fullRomb = GameObject.Find("fullRomb");
        fullRectangle = GameObject.Find("fullRectangle");
        fullHexagon = GameObject.Find("fullHexagon");
        fullHexagon.GetComponent<SpriteRenderer>().color = Color.white;
        fullStar.GetComponent<SpriteRenderer>().color = Color.white;
        fullRectangle.GetComponent<SpriteRenderer>().color = Color.white;
        fullCircle.GetComponent<SpriteRenderer>().color = Color.white;
        fullRomb.GetComponent<SpriteRenderer>().color = Color.white;
        go1 = true;
        go2 = true;
        go3 = true;
        go4 = true;
        go5 = true;
        hasPlayed_0 = false;
        hasPlayed_1 = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (!hasPlayed_0)
        {
            Instructions.Play();
            hasPlayed_0 = true;
        }
        // Debug.Log(fullStar.GetComponent<SpriteRenderer>().color);
        Debug.Log(go1);
        if (fullStar.GetComponent<SpriteRenderer>().color != Color.white)
        {
            Debug.Log("intra in if");
            go1 = false;
        }
        if (fullCircle.GetComponent<SpriteRenderer>().color != Color.white)
        {
            Debug.Log("intra in if2");
            go2 = false;
        }
        if (fullRomb.GetComponent<SpriteRenderer>().color != Color.white)
        {
            go3 = false;
        }
        if (fullRectangle.GetComponent<SpriteRenderer>().color != Color.white)
        {
           
            go4 = false;

        }
        if (fullHexagon.GetComponent<SpriteRenderer>().color != Color.white)
        {
            go5 = false;

        }
       if (go1 == false && go2 == false && go3 == false && go4 == false && go5 == false)
        {
           
            if (hasPlayed_1 == false)
            {
                Debug.Log("penultimul if");
                hasPlayed_1 = true;
                CeFrumos.Play();
            }
        }
      
        if(!CeFrumos.isPlaying && hasPlayed_1 == true)
        {
            Debug.Log("Intra in if final");
            SceneManager.LoadScene("JocNumarat");
        }
    }
}
