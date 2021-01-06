using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circleOnClick : MonoBehaviour
{
    // Start is called before the first frame update
    public SpriteRenderer solidcircle;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    private void OnMouseDown()
    {
        solidcircle.color = gameFlow.selectedColor;
    }
}
