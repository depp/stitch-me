using UnityEditor;
using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(menuName = "StitchMe/BoolVariable")]
    public class BoolVariable : PersistentVariable
    {
        [SerializeField]
        private bool _value;

        [SerializeField]
        private bool _defaultValue;

        public bool defaultValue
        {
            get => _defaultValue;
            set => _defaultValue = value;
        }
        public bool GetValue() => _value;
        
        public void SetValue(bool value)
        {
            _value = value;
            SignalChange();
        }

        public override void SetToDefaultValue()
        {
            SetValue(defaultValue);
            SignalChange();
        }
    }
}