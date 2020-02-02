using System;
using System.Collections;
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

        [SerializeField]
        private bool _hasDelay;

        public bool hasDelay
        {
            get => _hasDelay;
            set => _hasDelay = value;
        }

        [SerializeField]
        private float _delayTime;

        public float delayTime
        {
            get => _delayTime;
            set => _delayTime = value;
        }
        
        [SerializeField]
        private bool _triggerOnStart = true;

        public bool triggerOnStart
        {
            get => _triggerOnStart;
            set => _triggerOnStart = value;
        }

        private void Start()
        {
            if (triggerOnStart == true) {
                if (hasDelay == false) {
                    actions.Invoke();
                    
                }
                else {
                    StartCoroutine(CallAction());
                }
            }
        }

        private IEnumerator CallAction()
        {
            yield return new WaitForSeconds(delayTime);
            actions.Invoke();
        }
        
        

        public void ExecuteActions()
        {
            if (hasDelay == false) {
                actions.Invoke();
            }
            else {
                StartCoroutine(CallAction());
            }
        }
    }
}