using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    // The drag anchor is the place on the object where the player clicked.
    Vector2 dragAnchor;

    public void OnBeginDrag(PointerEventData eventData)
    {
        dragAnchor = transform.InverseTransformPoint(eventData.pointerPressRaycast.worldPosition);
        UpdateDrag(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        UpdateDrag(eventData);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        UpdateDrag(eventData);
    }

    void UpdateDrag(PointerEventData eventData)
    {
        Vector2 currentAnchor = transform.TransformPoint(dragAnchor);
        Vector2 targetAnchor = eventData.pointerCurrentRaycast.worldPosition;
        Vector2 delta = targetAnchor - currentAnchor;
        transform.position += (Vector3)delta;
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
