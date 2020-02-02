using System;
using UnityEngine;

namespace DefaultNamespace
{
    [RequireComponent(typeof(BoxCollider))]
    public class DetectEdges : MonoBehaviour
    {
        private Collider2D _collider2D;

        public Collider2D collider2D1
        {
            get => _collider2D;
            set => _collider2D = value;
        }

        [SerializeField]
        private SimpleSignal _bordersHit;

        public SimpleSignal bordersHit
        {
            get => _bordersHit;
            set => _bordersHit = value;
        }

        private void OnCollisionEnter(Collision other)
        {
            bordersHit.SignalChange();
        }
    }
}