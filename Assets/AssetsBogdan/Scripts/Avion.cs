using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Avion : MonoBehaviour
{
 private void OnMouseDown()
 {
  GetComponent<SpriteRenderer>().color=Color.gray;
 }
 private void OnMouseUp()
 {
  GetComponent<SpriteRenderer>().color=Color.white;
 }
 private void OnMouseDrag()
 {
  Vector2 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
  transform.position = newPosition;
 }

 private void OnTriggerEnter2D(Collider2D collision)
 {
  SceneManager.LoadScene("JocNumarat");
  
 }
}
