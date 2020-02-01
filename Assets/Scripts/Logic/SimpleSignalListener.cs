using System;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class SimpleSignalListener : MonoBehaviour
    {
        [SerializeField]
        private List<SimpleSignal> _simpleSignals = new List<SimpleSignal>();

        public List<SimpleSignal> simpleSignals
        {
            get => _simpleSignals;
            set => _simpleSignals = value;
        }

        [SerializeField]
        private GameObjectGenericAction _response;

        private GameObjectGenericAction response
        {
            get => _response;
            set => _response = value;
        }

        private void OnEnable()
        {
            foreach (var simpleSignal in simpleSignals) {
                simpleSignal.RegisterListener(this);
            }
        }

        private void OnDisable()
        {
            foreach (var simpleSignal in simpleSignals) {
                simpleSignal.UnregisterListener(this);
            }
        }
        
        public void OnEventRaised() {
            response.Invoke(this.gameObject);
        }
    }
}