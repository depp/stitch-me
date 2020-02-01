using System;
using UnityEngine;
using UnityEngine.Events;

namespace DefaultNamespace
{
    public class PrepareScene : MonoBehaviour
    {
        [SerializeField]
        private UnityEvent _prepareSceneEvents;

        public UnityEvent prepareSceneEvents
        {
            get => _prepareSceneEvents;
            set => _prepareSceneEvents = value;
        }

        private void Start()
        {
            prepareSceneEvents.Invoke();
        }
    }
}