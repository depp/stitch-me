using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(menuName = "StitchMe/SimpleSignal")]
    public class SimpleSignal : ScriptableObject
    {
        private List<SimpleSignalListener> _listeners = new List<SimpleSignalListener>();

        private List<SimpleSignalListener> listeners => _listeners;

        public List<SimpleSignalListener> RegisterListener(SimpleSignalListener listener)
        {
            listeners.Add(listener);
            return listeners;
        }

        public List<SimpleSignalListener> UnregisterListener(SimpleSignalListener listener)
        {
            listeners.Remove(listener);
            return listeners;
        }

        public void SignalChange()
        {
            // if () {
            //     Debug.Log(callingObject.name);
            // }
            
            foreach (var listener in listeners) {
                listener.OnEventRaised();
            }
        }

    }
}