using System;
using UnityEngine;

namespace DefaultNamespace
{
    [Serializable]
    public class Vector3Behaviour : LerpToTargetBehaviour
    {
        [SerializeField]
        private Vector3 _initialValue;

        public Vector3 initialValue
        {
            get => _initialValue;
            set => _initialValue = value;
        }
        
        [SerializeField]
        private Vector3 _targetValue;

        public Vector3 targetValue
        {
            get => _targetValue;
            set => _targetValue = value;
        }
    }
}