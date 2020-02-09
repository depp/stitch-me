using DefaultNamespace;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

[RequireComponent(typeof(Collider2D)), RequireComponent(typeof(Rigidbody2D))]
public class Draggable : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public PhysicsSettings physics;
    public GameObject targetGameObject;

    public bool IsInPlay { get; private set; }

    // The drag anchor is the place on the object where the player clicked.
    Vector2 dragAnchor;

    [SerializeField]
    private BoxCollider2D _target;


    public BoxCollider2D target
    {
        get => _target;
        set => _target = value;
    }

    private Vector2 _randomPosition;
    public Vector2 RandomPosition
    {
        get => _randomPosition;
        private set => _randomPosition = value;
    }


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
    
    [FormerlySerializedAs("_simpleSignal")]
    [SerializeField]
    private SimpleSignal _dragSuccessfulCallback;

    public SimpleSignal dragSuccessfulCallback
    {
        get => _dragSuccessfulCallback;
        set => _dragSuccessfulCallback = value;
    }

    [SerializeField]
    private UnityEvent _onEndDragSuccess;

    public UnityEvent onEndDragSuccess
    {
        get => _onEndDragSuccess;
        set => _onEndDragSuccess = value;
    }
    
    private Vector2 _originalPosition;

    public Vector2 originalPosition
    {
        get => _originalPosition;
        set => _originalPosition = value;
    }
    
    private Vector3 _originalRotation;

    public Vector3 originalRotationn
    {
        get => _originalRotation;
        set => _originalRotation = value;
    }

    
    private float _xBounds = 8;

    private float xBounds
    {
        get => _xBounds;
        set => _xBounds = value;
    }

    
    private float _yBounds = 4.3f;

    private float yBounds
    {
        get => _yBounds;
        set => _yBounds = value;
    }

    private void Awake()
    {
        Collider2D collider = GetComponent<Collider2D>();
        collider.isTrigger = true;
        Rigidbody2D body = GetComponent<Rigidbody2D>();
        //IsInPlay = true;
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
        originalRotationn = transform.eulerAngles;
        IsInPlay = true;
        SetRandomPosition();
    }

    private void SetRandomPosition()
    {
        RandomPosition = new Vector2(Random.Range(xBounds * -1f, xBounds), Random.Range(yBounds * -1f, yBounds));
        //transform.localPosition = newPosition;
        
        float currentXMax = RandomPosition.x + collider.bounds.extents.x;
        float currentXMin = RandomPosition.x - collider.bounds.extents.x;
        float currentYMax = RandomPosition.y + collider.bounds.extents.y;
        float currentYMin = RandomPosition.y - collider.bounds.extents.y;

        while (currentXMax > xBounds && currentXMin < xBounds * -1f && currentYMax > yBounds && currentYMin < yBounds * -1f) {
            RandomPosition = new Vector2(Random.Range(xBounds * -1f, xBounds), Random.Range(yBounds * -1f, yBounds));
            currentXMax = RandomPosition.x + collider.bounds.extents.x;
            currentXMin = RandomPosition.x - collider.bounds.extents.x;
            currentYMax = RandomPosition.y + collider.bounds.extents.y;
            currentYMin = RandomPosition.y - collider.bounds.extents.y;
        }
        
        transform.localPosition = RandomPosition;
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

        if (target == null) {
            return;
        }
        
        if (collider.bounds.Intersects(target.bounds)) {
            SnapToPosition();
            IsInPlay = false;
            targetGameObject.SetActive(false);
        }
    }

    private void SnapToPosition()
    {
        //have to zero out any forces because they may cause the bear to move after we set the position
        ResetToOriginalPosition();
        collider.enabled = false;
        onEndDragSuccess.Invoke();
        dragSuccessfulCallback.SignalChange();
    }

    public void ResetToOriginalPosition()
    {
        rigidbody.angularVelocity = 0;
        rigidbody.velocity = Vector2.zero;

        transform.localPosition = originalPosition;
        transform.eulerAngles = originalRotationn;
    }
}
