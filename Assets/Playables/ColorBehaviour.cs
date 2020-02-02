using System;
using UnityEngine;

namespace DefaultNamespace
{
    [Serializable]
    public class ColorBehaviour : LerpToTargetBehaviour
    {
        [SerializeField]
        private Color _initialValue;

        public Color initialValue
        {
            get => _initialValue;
            set => _initialValue = value;
        }
        
        [SerializeField]
        private Color _targetValue;

        public Color targetValue
        {
            get => _targetValue;
            set => _targetValue = value;
        }
    }
}