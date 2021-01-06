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


public class intro : MonoBehaviour
{
	public string scena;
	public int secunde;
	IEnumerator SceneLoadWithDelay(string sceneName, int numSeconds)
	{
		yield return new WaitForSeconds(numSeconds);

		SceneManager.LoadScene(sceneName);
	}

	void Start()
    {
		StartCoroutine(SceneLoadWithDelay(scena, secunde));
	}
}
