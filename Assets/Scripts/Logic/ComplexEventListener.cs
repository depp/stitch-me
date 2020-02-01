using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class ComplexEventListener : MonoBehaviour
    {
        [SerializeField]
        private ComplexEvent _complexEvent;

        public ComplexEvent complexEvent
        {
            get => _complexEvent;
            set => _complexEvent = value;
        }

        [SerializeField]
        private ComplexEventResponse _response;

        private ComplexEventResponse response
        {
            get => _response;
            set => _response = value;
        }

        private void OnEnable()
        {
            complexEvent.RegisterListener(this);
        }

        private void OnDisable()
        {
            complexEvent.UnregisterListener(this);
        }

        public void OnEventRaised(ComplexPayload payload)
        {
            response.Invoke(payload);
        }
    }
}