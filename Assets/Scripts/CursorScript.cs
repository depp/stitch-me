using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorScript : MonoBehaviour
{
    public Sprite cursor;
    public Sprite defaultSprite;
    public Camera camera;
    private SpriteRenderer spriteRenderer;
    private Vector3 mousePosition;
    private float initial_Z;

    private void Awake()
    {
        spriteRenderer= GetComponent<SpriteRenderer>();
        cursor = spriteRenderer.sprite;

        //camera = GetComponent<Camera>();

        Cursor.visible = false;
        initial_Z = transform.position.z;
    }

    //private void Start()
    //{
    //    //camera = Camera.allCameras[0];
    //}

    void Update()
    {
        mousePosition = Input.mousePosition;
        transform.position = camera.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, initial_Z ));
    }

    public void Poop()
    {

    }
}
