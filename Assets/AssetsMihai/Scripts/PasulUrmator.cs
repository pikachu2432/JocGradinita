using System.Collections;
using System.Collections.Generic;
using static DataSaver;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PasulUrmator : MonoBehaviour
{
    private GameObject unu;
    private GameObject doi;
    private GameObject trei;
    private GameObject multime1;
    private GameObject multime2;
    private GameObject multime3;
    private int incercare;
    //Declarare texturi posibile
    public Sprite pasare_1;
    public Sprite pasare_2;
    public Sprite pasare_3;
    public Sprite stea_1;
    public Sprite stea_2;
    public Sprite stea_3;
    public Sprite nor_1;
    public Sprite nor_2;
    public Sprite nor_3;
    //Declarare audiouri posibile
    public AudioSource succes;
    public AudioSource ceSus;
    private bool hasPlayed_0;
    public AudioSource siCe;
    private bool hasPlayed_01;
    public AudioSource instructiuni;
    private bool hasPlayed_1;
    public AudioSource numaram1;
    private bool hasPlayed_2;
    public AudioSource numaram2;
    private bool hasPlayed_3;
    public AudioSource numaram3;
    private bool hasPlayed_4;
    public AudioSource randulTau;
    private bool hasPlayed_5;
    public AudioSource numarulDorit;
    private bool hasPlayed_6;
    public AudioSource butonGalben;
    private bool hasPlayed_7;
    private bool fazaInstructiuni;
    private Vector3 userDirection = Vector3.right;
    private bool move;
    //Declarare grafici mijloc de transport
    public Sprite avion;
    public Sprite elicopter;
    public Sprite balon;

    // Start is called before the first frame update
    private void Start()
    {
        unu = GameObject.Find("unu");
        doi = GameObject.Find("doi");
        trei = GameObject.Find("trei");
        multime1 = GameObject.Find("multime1");
        multime2 = GameObject.Find("multime2");
        multime3 = GameObject.Find("multime3");
        incercare = 0;
        fazaInstructiuni = true;
        hasPlayed_0 = false;
        hasPlayed_01 = false;
        hasPlayed_1 = false;
        hasPlayed_2 = false;
        hasPlayed_3 = false;
        hasPlayed_4 = false;
        hasPlayed_5 = false;
        hasPlayed_6 = false;
        move = false;
        switch (PlayerPrefs.GetString("MijlocDeTransport"))
        {
            case "avion":
                gameObject.GetComponent<SpriteRenderer>().sprite = avion;
                break;
            case "elicopter":
                gameObject.GetComponent<SpriteRenderer>().sprite = elicopter;
                break;
            case "balon":
                gameObject.GetComponent<SpriteRenderer>().sprite = balon;
                break;
        }
    }

    private void reactivareMultimi()
    {
        multime1.SetActive(true);
        multime2.SetActive(true);
        multime3.SetActive(true);
    }

    public void setImaginePasari()
    {
        multime1.GetComponent<SpriteRenderer>().sprite = pasare_1;
        multime2.GetComponent<SpriteRenderer>().sprite = pasare_2;
        multime3.GetComponent<SpriteRenderer>().sprite = pasare_3;
    }

    private void setImagineNori()
    {
        multime1.GetComponent<SpriteRenderer>().sprite = nor_1;
        multime2.GetComponent<SpriteRenderer>().sprite = nor_2;
        multime3.GetComponent<SpriteRenderer>().sprite = nor_3;
    }

    private void setImagineStele()
    {
        multime1.GetComponent<SpriteRenderer>().sprite = stea_1;
        multime2.GetComponent<SpriteRenderer>().sprite = stea_2;
        multime3.GetComponent<SpriteRenderer>().sprite = stea_3;
    }

    private void reactivareNumere()
    {
        unu.SetActive(true);
        doi.SetActive(true);
        trei.SetActive(true);
        if (unu.GetComponent<Number>().getNumber() != 1)
            unu.GetComponent<Number>().setColided(false);
        if (doi.GetComponent<Number>().getNumber() != 2)
            doi.GetComponent<Number>().setColided(false);
        if (trei.GetComponent<Number>().getNumber() != 3)
            trei.GetComponent<Number>().setColided(false);
    }

    // Update is called once per frame
    private void Update()
    {
        if (fazaInstructiuni)
        {
            if (unu.activeSelf == false &&
                doi.activeSelf == false &&
                trei.activeSelf == false)
                move = false;

            if (move) {
                if (unu.activeSelf == true)
                    unu.transform.Translate(userDirection * 5 * Time.deltaTime);
                if (doi.activeSelf == true)
                    doi.transform.Translate(userDirection * 4 * Time.deltaTime);
                if (trei.activeSelf == true)
                    trei.transform.Translate(userDirection * 3 * Time.deltaTime);
            }

            if (!hasPlayed_0)
            {
                ceSus.Play();
                hasPlayed_0 = true;
            }
            else if (hasPlayed_0 && !hasPlayed_01 && !ceSus.isPlaying)
            {
                siCe.Play();
                hasPlayed_01 = true;
            }
            else if (hasPlayed_01 && !hasPlayed_1 && !siCe.isPlaying)
            {
                instructiuni.Play();
                hasPlayed_1 = true;
            }
            else if (hasPlayed_1 && !hasPlayed_2 && !instructiuni.isPlaying)
            {
                move = true;
                numaram1.Play();
                hasPlayed_2 = true;
            }
            else if (hasPlayed_2 && !hasPlayed_3 && !numaram1.isPlaying)
            {
                reactivareNumere();
                reactivareMultimi();
                setImagineNori();
                move = true;
                numaram2.Play();
                hasPlayed_3 = true;
            }
            else if (hasPlayed_3 && !hasPlayed_4 && !numaram2.isPlaying)
            {
                reactivareNumere();
                reactivareMultimi();
                setImagineStele();
                move = true;
                numaram3.Play();
                hasPlayed_4 = true;
            }
            else if (hasPlayed_4 && !hasPlayed_5 && !numaram3.isPlaying)
            {
                randulTau.Play();
                hasPlayed_5 = true;
            }
            else if (hasPlayed_5 && !hasPlayed_6 && !randulTau.isPlaying)
            {
                numarulDorit.Play();
                hasPlayed_6 = true;
            }
            else if (hasPlayed_6 && !hasPlayed_7 && !numarulDorit.isPlaying)
            {
                butonGalben.Play();
                fazaInstructiuni = false;
                hasPlayed_7 = true;
            }
        }
        else if (unu.activeSelf == false &&
                doi.activeSelf == false &&
                trei.activeSelf == false && !fazaInstructiuni)
             {
                    if (incercare > 0)
                        succes.Play();
                    
                    //Reactivarea numerelor
                    reactivareNumere();
            
                    //Reactivarea multimilor
                    reactivareMultimi();
                    if (incercare == 0)
                    {    
                        trei.GetComponent<Number>().setColided(false);
                        setImaginePasari();
                    }
                    else if (incercare == 1)
                        setImagineNori();
                    else if (incercare == 2)
                        setImagineStele();
                    else if (incercare > 2)
                        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                    incercare++;
             }   
    }
}
