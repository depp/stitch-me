using System;
using UnityEngine;
using UnityEngine.Events;

namespace DefaultNamespace
{
    [Serializable]
    public abstract class ConditionResponse
    {
        private string _prefix;

        public string prefix
        {
            get => _prefix;
            set => _prefix = value;
        }

        [SerializeField]
        [Multiline]
        private string _description;

        public string description
        {
            get => _description;
            set => _description = value;
        }

        [SerializeField]
        private UnityEvent _action;

        public UnityEvent action
        {
            get => _action;
            set => _action = value;
        }

        public virtual void SyncConditionHeadings()
        {
            description = prefix;
        }

        public abstract bool CheckCondition();

        public void TriggerResponse()
        {
            if (CheckCondition() == true) {
                action.Invoke();
            }
        }

        protected string GetActionDescription()
        {
            string actionDescription = "";
            
            if (action.GetPersistentEventCount() > 0) {
                for (int i = 0; i < action.GetPersistentEventCount(); i++) {
                    actionDescription += "\n    ";
                    actionDescription += $"{action.GetPersistentMethodName(i)}";
                }
            }
            else {
                actionDescription += "\n    ";
                actionDescription += "No actions specified";
            }

            return actionDescription;
        }
    }
}