using System;
using UnityEngine;

namespace DefaultNamespace
{
    [Serializable]
    public abstract class ReferenceBase
    {
        [SerializeField]
        private bool _useConstant;

        public bool useConstant
        {
            get => _useConstant;
            set => _useConstant = value;
        }
    }
}