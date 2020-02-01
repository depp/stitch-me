using System;
using UnityEngine;

namespace DefaultNamespace
{
    [Serializable]
    public class BoolReference
    {
        [SerializeField]
        private BoolVariable _boolVariable;

        public BoolVariable boolVariable
        {
            get => _boolVariable;
            set => _boolVariable = value;
        }

        public bool GetValue()
        {
            return _boolVariable.GetValue();
        }

        public void SetValue(bool value)
        {
            _boolVariable.SetValue(value);
        }
    }
}