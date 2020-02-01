using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour
{
    public Sprite cursor;
    private SpriteRenderer spriteRenderer;


    private void Start()
    {
        spriteRenderer= GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if(Input.anyKeyDown)
        {
            cursor = spriteRenderer.sprite;
        }
    }

    public void Poop()
    {

    }
}
