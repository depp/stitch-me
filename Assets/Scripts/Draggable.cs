using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Collider2D))]
public class Draggable : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public PhysicsSettings physics;

    // The drag anchor is the place on the object where the player clicked.
    Vector2 dragAnchor;

    [SerializeField]
    private BoxCollider2D _target;
    
    public BoxCollider2D target
    {
        get => _target;
        set => _target = value;
    }

    [SerializeField]
    private Collider2D _collider;

    public Collider2D collider
    {
        get => _collider;
        set => _collider = value;
    }
    
    private Rigidbody2D _rigidbody;

    public Rigidbody2D rigidbody
    {
        get => _rigidbody;
        set => _rigidbody = value;
    }

    [SerializeField]
    private UnityEvent _onEndDragSuccess;

    public UnityEvent onEndDragSuccess
    {
        get => _onEndDragSuccess;
        set => _onEndDragSuccess = value;
    }
    
    private Vector3 _originalPosition;

    public Vector3 originalPosition
    {
        get => _originalPosition;
        set => _originalPosition = value;
    }
    
    private void Awake()
    {
        Rigidbody2D body = GetComponent<Rigidbody2D>();
        if (body == null)
        {
            body = gameObject.AddComponent<Rigidbody2D>();
        }
        if (physics == null)
        {
            Debug.LogWarningFormat("No physics settings on {0}", gameObject.name);
        }
        else
        {
            body.drag = physics.linearDrag;
            body.angularDrag = physics.angularDrag;
        }
    }

    private void OnEnable()
    {
        collider = GetComponent<Collider2D>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        originalPosition = transform.localPosition;
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
        
        if (collider.bounds.Intersects(target.bounds)) {
            // var joint = target.GetComponent<SpringJoint2D>();
            // joint.connectedBody = rigidbody;
            collider.enabled = false;
            onEndDragSuccess.Invoke();
        }
    }
}
