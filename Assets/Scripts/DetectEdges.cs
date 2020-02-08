using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class DetectEdges : MonoBehaviour
    {
        [SerializeField]
        private SimpleSignal _bordersHit;

        public SimpleSignal bordersHit
        {
            get => _bordersHit;
            set => _bordersHit = value;
        }

    public float Max_x;
    public float Min_x;

    public float Max_y;
    public float Min_y;
    private string gameObjectName;
        private Rigidbody2D rigidbody;
         
    void Awake()
    {
      gameObjectName = gameObject.name;
      rigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
      if(Input.GetMouseButton(0) == false) 
      {
      
        if(transform.localPosition.y >= Max_y ||
          transform.localPosition.y <= Min_y ||
          transform.localPosition.x >= Max_x ||
          transform.localPosition.x <= Min_x )
        {   
            bordersHit.SignalChange();
            Debug.Log($"Edge Detected on {gameObjectName}. Resetting it to its starting position!");

            rigidbody.angularVelocity = 0;
            rigidbody.velocity = Vector2.zero;

            var position = gameObject.GetComponent<Draggable>().RandomPosition;
            transform.localPosition = position;
        }
      }
      // out of bounds head: x 5.50, -6.25 : y -10.40, 1.40

    }
  }
}


