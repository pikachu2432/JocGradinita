using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Girl : MonoBehaviour
{
  //  private float speed = 2;
   /* void Update()
    {
        float strafe = Input.GetAxis("Horizontal");
        transform.Translate(new Vector2(strafe, 0) * speed * Time.deltaTime);
    }*/

      private void OnMouseDrag()
      {
          Vector2 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
          transform.position = newPosition;
    }

}
