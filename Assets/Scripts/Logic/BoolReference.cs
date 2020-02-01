using System;
using UnityEngine;

namespace DefaultNamespace
{
    [Serializable]
    public class BoolReference : ReferenceBase
    {
        [SerializeField]
        private BoolVariable _variable;

        public BoolVariable variable
        {
            get => _variable;
            set => _variable = value;
        }
        
        [SerializeField]
        private bool _constantValue;

        public bool constantValue
        {
            get => _constantValue;
            set => _constantValue = value;
        }
        
        public bool GetValue()
        {
            if (useConstant == true) {
                return constantValue;
            }
            
            return _variable.GetValue();
        }

        public void SetValue(bool value)
        {
            _variable.SetValue(value);
        }
    }
}