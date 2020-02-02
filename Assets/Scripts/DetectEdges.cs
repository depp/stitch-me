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
    void Awake()
    {
      gameObjectName = gameObject.name;
    }

    void Update()
    {
      if(Input.GetMouseButton(0) == false) 
      {
      
        if(transform.position.y >= Max_y ||
          transform.position.y <= Min_y ||
          transform.position.x >= Max_x ||
          transform.position.x <= Min_x )
        {
          bordersHit.SignalChange();
          Debug.Log("Edge Detected on " + gameObjectName);
        }
      }
      // out of bounds head: x 5.50, -6.25 : y -10.40, 1.40

    }
  }
}


