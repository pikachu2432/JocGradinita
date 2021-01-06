using System;
using System.Security.Cryptography;
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

public class RepAvion : MonoBehaviour
{
	private GameObject avion = null;
	private GameObject avionfaraaripa = null;
	private GameObject butoncos = null;
	private GameObject butonaripa = null;

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

		avionfaraaripa = GameObject.Find("avionfaraaripa");
		avionfaraaripa.SetActive(false);
		avion.SetActive(true);
		SoundManager.PlaySound(sunetRandom);
		Destroy(butonaripa);
		StartCoroutine(SceneLoadWithDelay("reparareBalon", 3));

	}

	public void onPressButtonWrong()
	{
		butoncos.GetComponent<Image>().color = Color.red;
		SoundManager.PlaySound("Stiu_ca_poti");
	}

	void Start()
	{
		avion = GameObject.Find("avion");
		butoncos = GameObject.Find("butoncos");
		butonaripa = GameObject.Find("butonaripa");
		avion.SetActive(false);
	}
}
