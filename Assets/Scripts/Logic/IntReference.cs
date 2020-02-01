using System;
using UnityEngine;

namespace DefaultNamespace
{
    [Serializable]
    public class IntReference : ReferenceBase
    {
        [SerializeField]
        private IntVariable _variable;

        public IntVariable variable
        {
            get => _variable;
            set => _variable = value;
        }

        [SerializeField]
        private int _constantValue;

        public int constantValue
        {
            get => _constantValue;
            set => _constantValue = value;
        }

        public int GetValue()
        {
            if (useConstant == true) {
                return constantValue;
            }

            return _variable.GetValue();
        }

        public void SetValue(int value)
        {
            _variable.SetValue(value);
        }

        public void ApplyChange(int value)
        {
            _variable.ApplyChange(value);
        }
    }
}