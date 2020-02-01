using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// An anchor for where we are dragging a part to. The object will follow the
/// mouse cursor, but only be active while a part is being dragged.
/// </summary>
public class DragAnchor : MonoBehaviour
{
    public PhysicsSettings physics;

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
    TargetJoint2D joint;

    public void StartDrag(GameObject draggable, Vector2 dragPos)
    {
        if (draggable == null)
            throw new System.ArgumentNullException(nameof(draggable));
        if (currentDraggable != null)
        {
            Debug.LogError("Tried to drag multiple objects");
            EndDrag();
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
        joint = draggable.GetComponent<TargetJoint2D>();
        if (joint == null)
        {
            joint = draggable.AddComponent<TargetJoint2D>();
        }
        // Note: Set anchor before target, or you will get glitches.
        joint.anchor = draggable.transform.InverseTransformPoint(dragPos);
        joint.target = dragPos;
        if (physics == null)
        {
            Debug.LogWarning("Missing physics settings");
        }
        else
        {
            joint.frequency = physics.springFrequency;
            joint.dampingRatio = physics.springDamping;
        }
    }

    /// <summary>
    /// End a dragging action.
    /// </summary>
    /// <param name="draggable">The object currently being dragged.</param>
    public void EndDrag(GameObject draggable)
    {
        if (currentDraggable == draggable)
            EndDrag();
    }

    /// <summary>
    /// End the current dragging action.
    /// </summary>
    private void EndDrag()
    {
        gameObject.SetActive(false);
        currentDraggable = null;
        if (joint != null)
        {
            Destroy(joint);
            joint = null;
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
        transform.position = mousePosWorld;
        if (joint != null)
        {
            joint.target = mousePosWorld;
        }
    }
}
