using System;
using System.Security.Cryptography;
using UnityEditor;
//using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using Object = System.Object;
using UnityEngine.Audio;
using System.Collections;
using System.Collections.Generic;
using Random = System.Random;


public class miscareUmbre : MonoBehaviour
{
    private Vector2 mousePosition;
    private float offsetX, offsetY;
    public static bool mouseButtonReleased;

    public static bool playedSound = false;
    
    // public string newScene;
   private void OnMouseDown()
    {
        mouseButtonReleased = false;
        GetComponent<SpriteRenderer>().color = Color.gray;
        offsetX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
        offsetY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;
    }
    private void OnMouseUp()
    {
        mouseButtonReleased = true;
        GetComponent<SpriteRenderer>().color = Color.gray;
        playedSound = false;
        
    }
    private void OnMouseDrag()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(mousePosition.x -offsetX, mousePosition.y - offsetY);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        string thisGameObjectName;
        string collisionGameObjectName;
        thisGameObjectName = gameObject.name.Substring(0);
        collisionGameObjectName = collision.gameObject.name.Substring(0);
        var list =new List<string>{"Bravo","Corect","Foarte_bine"};
        var index = new Random().Next(list.Count);
        var sunetRandom = list[index];
        

        if (mouseButtonReleased && thisGameObjectName == "umbraAvion" && collisionGameObjectName == "avion")
            {
                mouseButtonReleased = false;
                SoundManager.PlaySound(sunetRandom);
                Destroy(gameObject);
            }
            else if (mouseButtonReleased && thisGameObjectName == "umbraAvion" &&
                     (collisionGameObjectName == "elicopter" || collisionGameObjectName == "balon"))
            {
                GetComponent<SpriteRenderer>().color = Color.red;
                if (!playedSound)
                {
                    SoundManager.PlaySound("Stiu_ca_poti");
                    playedSound = true;
                }
            }

            if (mouseButtonReleased && thisGameObjectName == "umbraElicopter" && collisionGameObjectName == "elicopter")
            {
                mouseButtonReleased = false;
                SoundManager.PlaySound(sunetRandom);
                Destroy(gameObject);

            }
            else if (mouseButtonReleased && thisGameObjectName == "umbraElicopter" &&
                     (collisionGameObjectName == "avion" || collisionGameObjectName == "balon"))
            {
                GetComponent<SpriteRenderer>().color = Color.red;
                if (!playedSound)
                {
                    SoundManager.PlaySound("Stiu_ca_poti");
                    playedSound = true;
                }
            }

            if (mouseButtonReleased && thisGameObjectName == "umbraBalon" && collisionGameObjectName == "balon")
            {
                mouseButtonReleased = false;
                SoundManager.PlaySound(sunetRandom);
                Destroy(gameObject);
                

            }
            else if (mouseButtonReleased && thisGameObjectName == "umbraBalon" &&
                     (collisionGameObjectName == "avion" || collisionGameObjectName == "elicopter"))
            {
                GetComponent<SpriteRenderer>().color = Color.red;
                
                if (!playedSound)
                {
                    SoundManager.PlaySound("Stiu_ca_poti");
                    playedSound = true;
                }
            }

            if (GameObject.Find("umbraAvion") == null && GameObject.Find("umbraBalon") == null &&
                GameObject.Find("umbraElicopter") == null)
            {
                if (thisGameObjectName == "avion" && collisionGameObjectName=="portal")
                {
                    PlayerPrefs.SetString("MijlocDeTransport", "avion");
                    SceneManager.LoadScene("JocNumarat");
                }
                if (thisGameObjectName == "elicopter" && collisionGameObjectName=="portal")
                {
                    PlayerPrefs.SetString("MijlocDeTransport", "elicopter");
                    SceneManager.LoadScene("JocNumarat");
                }
                if (thisGameObjectName == "balon" && collisionGameObjectName=="portal")
                {
                    PlayerPrefs.SetString("MijlocDeTransport", "balon");
                    SceneManager.LoadScene("SampleScene");
                }
            }
    }


    public void Update()
    {
       
    }
    
}
