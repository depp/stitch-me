using Logic;
using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(menuName = "StitchMe/IntVariable")]
    public class IntVariable : PersistentVariable
    {
        [SerializeField]
        private int _value;
        
        [SerializeField]
        private int _defaultValue;

        public int defaultValue
        {
            get => _defaultValue;
            set => _defaultValue = value;
        }
        
        public int GetValue() => _value;

        public void SetValue(int value)
        {
            _value = value;
            SignalChange();
        }
        
        public override void SetToDefaultValue()
        {
            SetValue(defaultValue);
            SignalChange();
        }

        public void ApplyChange(int value)
        {
            this.SetValue(this.GetValue() + value);
            SignalChange();
        }
    }
}