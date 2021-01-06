using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using Object = System.Object;
using UnityEngine.Audio;
using System.Collections;
using System.Collections.Generic;
using Random = System.Random;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Balon : MonoBehaviour
{
	private GameObject balon = null;
	private GameObject balonfaracos = null;
	private GameObject butonelice = null;
	private GameObject butoncos = null;

	IEnumerator SceneLoadWithDelay(string sceneName, int numSeconds)
	{
		yield return new WaitForSeconds(numSeconds);

		SceneManager.LoadScene(sceneName);
	}


	public void onPressButtonCorrect()
	{
		var list = new List<string> { "Bravo", "Corect", "Foarte_bine" };
		var index = new Random().Next(list.Count);
		var sunetRandom = list[index];

		balonfaracos = GameObject.Find("balonfaracos");
		balonfaracos.SetActive(false);
		balon.SetActive(true);
		SoundManager.PlaySound(sunetRandom);
		Destroy(butoncos);
		StartCoroutine(SceneLoadWithDelay("scenaSfarsit", 3));
	}

	public void onPressButtonWrong()
    {
		butonelice.GetComponent<Image>().color = Color.red;
		SoundManager.PlaySound("Stiu_ca_poti");
	}

	void Start()
    {
		balon = GameObject.Find("balon");
		butonelice = GameObject.Find("butonelice");
		butoncos = GameObject.Find("butoncos");
		balon.SetActive(false);
	}
}
