using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    // The drag anchor is the place on the object where the player clicked.
    Vector2 dragAnchor;

    [SerializeField]
    private BoxCollider2D _target;
    
    public BoxCollider2D target
    {
        get => _target;
        set => _target = value;
    }

    private BoxCollider2D _boxCollider;

    public BoxCollider2D boxCollider
    {
        get => _boxCollider;
        set => _boxCollider = value;
    }

    [SerializeField]
    private UnityEvent _onEndDragSuccess;

    public UnityEvent onEndDragSuccess
    {
        get => _onEndDragSuccess;
        set => _onEndDragSuccess = value;
    }

    private void OnEnable()
    {
        boxCollider = GetComponent<BoxCollider2D>(); 
    }

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

        if (boxCollider.bounds.Intersects(target.bounds)) {
            boxCollider.enabled = false;
            onEndDragSuccess.Invoke();
        }
    }
    // if(topHeaderBoxCollider.bounds.Intersects(currentHeader.boxCollider.bounds))

    void UpdateDrag(PointerEventData eventData)
    {
        RaycastResult raycast = eventData.pointerCurrentRaycast;
        if (!raycast.isValid)
            return;
        Vector2 currentAnchor = transform.TransformPoint(dragAnchor);
        Vector2 targetAnchor = raycast.worldPosition;
        Vector2 delta = targetAnchor - currentAnchor;
        transform.position += (Vector3)delta;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        DragAnchor.instance.StartDrag(gameObject, eventData.pointerPressRaycast.worldPosition);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        DragAnchor.instance.EndDrag(gameObject);
    }
}
