using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(menuName = "StitchMe/ComplexEvent")]
    public class ComplexEvent : ScriptableObject
    {
        private List<ComplexEventListener> _listeners = new List<ComplexEventListener>();

        public List<ComplexEventListener> listeners
        {
            get => _listeners;
            set => _listeners = value;
        }

        public List<ComplexEventListener> RegisterListener(ComplexEventListener listener)
        {
            listeners.Add(listener);
            return listeners;
        }

        public List<ComplexEventListener> UnregisterListener(ComplexEventListener listener)
        {
            listeners.Remove(listener);
            return listeners;
        }
        
        public void SignalChange(ComplexPayload payload)
        {
            // if () {
            //     Debug.Log(callingObject.name);
            // }
            
            foreach (var listener in listeners) {
                listener.OnEventRaised(payload);
            }
        }
    }
}