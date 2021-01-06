using System;
using System.Security.Cryptography;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
//using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using Object = System.Object;
using UnityEngine.Audio;
using System.Collections;
using System.Collections.Generic;
using Random = System.Random;
using UnityEngine.UI;

public class Elicopter : MonoBehaviour
{

		private GameObject elicopter = null;
		private GameObject elicopterfaraelice = null;
		private GameObject butonaripa = null;
	    private GameObject butonelice = null;

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

		elicopterfaraelice = GameObject.Find("elicopterfaraelice");
		elicopterfaraelice.SetActive(false);
		elicopter.SetActive(true);
		SoundManager.PlaySound(sunetRandom);
		Destroy(butonelice);
		StartCoroutine(SceneLoadWithDelay("reparareAvion", 3));

	}

	public void onPressButtonWrong()
	{
		butonaripa.GetComponent<Image>().color = Color.red;
		SoundManager.PlaySound("Stiu_ca_poti");
	}

	void Start()
	{
		//SoundManager.PlaySound("Intrebare_elicopter");
		elicopter = GameObject.Find("elicopter");
		elicopter.SetActive(false);
		butonaripa = GameObject.Find("butonaripa");
		butonelice = GameObject.Find("butonelice");
		

	}

}
