using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UpdateText : MonoBehaviour
{
	public Text Msg;

    // Start is called before the first frame update
    void Start()
    {
    	Msg = GetComponent<Text>();
    }

    // Update is called once per frame
    //should be changed to update on game events - pieces clicking together etc
    void Update()
    {
    	Msg.text = "A new message";
    }
}
