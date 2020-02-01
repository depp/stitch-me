using System;
using UnityEngine;

namespace DefaultNamespace
{
    [Serializable]
    public class IntReference
    {
        [SerializeField]
        private IntVariable _intVariable;

        public IntVariable intVariable
        {
            get => _intVariable;
            set => _intVariable = value;
        }

        public int GetValue()
        {
            return _intVariable.GetValue();
        }

        public void SetValue(int value)
        {
            _intVariable.SetValue(value);
        }

        public void ApplyChange(int value)
        {
            _intVariable.ApplyChange(value);
        }
    }
}