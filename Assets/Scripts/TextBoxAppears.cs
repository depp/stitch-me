using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextBoxAppears : MonoBehaviour
{

	public Canvas ChatCanvas;
    // Start is called before the first frame update
    void Start()
    {
    	//ChatCanvas = GetComponent<Canvas>();
    	ChatCanvas.GetComponent<Canvas> ().planeDistance = 0;
    }

    void Update() {
        if (Input.GetMouseButton(0))
        {
            ChatCanvas.GetComponent<Canvas> ().planeDistance = 100;
        }
    }
}
