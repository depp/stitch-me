using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class Clickable : MonoBehaviour, IPointerClickHandler
{
	[SerializeField]
	private UnityEvent _response;

	public void OnPointerClick(PointerEventData PointerEventData) {
		_response.Invoke();
	}

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
