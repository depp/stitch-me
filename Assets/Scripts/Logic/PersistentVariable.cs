
using System;
using Logic;
using UnityEngine;

namespace DefaultNamespace
{
    public abstract class PersistentVariable : SimpleSignal
    {
        [SerializeField]
        private ToggleEnum _setDefaultOnEnable = ToggleEnum.YES;

        private ToggleEnum setDefaultOnEnable
        {
            get => _setDefaultOnEnable;
            set => _setDefaultOnEnable = value;
        }

        private void OnEnable()
        {
            if (setDefaultOnEnable == ToggleEnum.YES) {
               SetToDefaultValue(); 
            }
        }

        public abstract void SetToDefaultValue();
    }
}