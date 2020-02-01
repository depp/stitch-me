using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A 
/// </summary>
[RequireComponent(typeof(SpringJoint2D))]
public class DragAnchor : MonoBehaviour
{
    static DragAnchor _instance;

    /// <summary>
    /// Gets the global instance of the drag anchor.
    /// </summary>
    public static DragAnchor instance
    {
        get
        {
            if (_instance == null)
            {
                throw new System.InvalidOperationException("No DragAnchor in this scene");
            }
            return _instance;
        }
    }

    GameObject currentDraggable;
    SpringJoint2D joint;

    public void StartDrag(GameObject draggable, Vector2 dragPos)
    {
        if (currentDraggable != null)
        {
            Debug.LogError("Tried to drag multiple objects");
            EndDrag(currentDraggable);
        }
        Rigidbody2D otherBody = draggable.GetComponent<Rigidbody2D>();
        if (otherBody == null)
        {
            Debug.LogError("Cannot drag an object which is not a RigidBody2D");
            return;
        }
        transform.position = dragPos;
        gameObject.SetActive(true);
        currentDraggable = draggable;
        joint.connectedBody = otherBody;
        joint.connectedAnchor = draggable.transform.InverseTransformPoint(dragPos);
    }

    public void EndDrag(GameObject draggable)
    {
        if (currentDraggable == draggable)
        {
            gameObject.SetActive(false);
            currentDraggable = null;
            joint.connectedBody = null;
        }
    }

    private void Awake()
    {
        if (_instance != null)
        {
            Debug.LogError("Multiple DragAnchor instances");
            Destroy(gameObject);
            return;
        }
        _instance = this;
        gameObject.SetActive(false);
        joint = GetComponent<SpringJoint2D>();
    }

    private void OnDestroy()
    {
        if (this == _instance)
        {
            _instance = null;
        }
    }

    void Update()
    {
        Vector2 mousePosScreen = Input.mousePosition;
        Vector2 mousePosWorld = Camera.main.ScreenToWorldPoint(mousePosScreen);
        transform.position = new Vector3(mousePosWorld.x, mousePosWorld.y, transform.position.z);
    }
}
