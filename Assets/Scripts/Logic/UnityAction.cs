using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace DefaultNamespace
{
    public class UnityAction : MonoBehaviour
    {
        [FormerlySerializedAs("_prepareSceneEvents"),SerializeField]
        private UnityEvent _actions;

        public UnityEvent actions
        {
            get => _actions;
            set => _actions = value;
        }

        private void Start()
        {
            actions.Invoke();
        }

        public void ExecuteActions()
        {
            actions.Invoke();
        }
    }
}