using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Number : MonoBehaviour
{
    private Vector3 _initialPosition;
    private AudioSource _fail;
    private bool colided;
    private static int number;

    private void Start()
    {
        _initialPosition = gameObject.transform.position;
        _fail = gameObject.GetComponent<AudioSource>();
        colided = false;
    }

    private void Update()
    {
       
    }

    private void OnMouseDown() 
    {
        //GetComponent<SpriteRenderer>().color = Color.blue;
    }

    private void OnMouseUp()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
        colided = false;
    }


    private void OnMouseDrag()
    {
        if (colided == false)
        {
            Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(newPosition.x, newPosition.y, -1);
        }
    }

    public void setColided(bool tf)
    {
        colided = tf;
    }

    public bool getColided()
    {
        return colided;
    }

    public int getNumber()
    {
        return number;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if ((gameObject.name == "unu" && other.gameObject.name == "multime1") ||
            (gameObject.name == "doi" && other.gameObject.name == "multime2") ||
            (gameObject.name == "trei" && other.gameObject.name == "multime3"))
        { 
            switch (gameObject.name)
            {
                case "unu":
                    number = 1;
                    break;
                case "doi":
                    number = 2;
                    break;
                case "trei":
                    number = 3;
                    break;
            }
            other.gameObject.SetActive(false);
            gameObject.transform.position = _initialPosition;
            colided = true;
            gameObject.SetActive(false);
        }
        else
        {
            colided = true;
            _fail.Play();
            gameObject.transform.position = _initialPosition;
        }
    }
}
