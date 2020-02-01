using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    [ExecuteInEditMode]
    public class IntConditionResponseTrigger : ConditionResponseTrigger
    {
        [SerializeField]
        private List<IntConditionResponse> _intEvents;

        public List<IntConditionResponse> intEvents
        {
            get => _intEvents;
            set => _intEvents = value;
        }
        
        protected override void TriggerAllResponses()
        {
            for (int i = 0; i < intEvents.Count; i++) {
                intEvents[i].TriggerResponse();
            }
        }

        protected override void TriggerUntilFirstSuccess()
        {
            for (int i = 0; i < intEvents.Count; i++) {
                if (intEvents[i].CheckCondition() == true) {
                    intEvents[i].TriggerResponse();
                    return;
                }
            }
        }
        
#if UNITY_EDITOR
        private void Update()
        {
            for (int i = 0; i < intEvents.Count; i++) {
                if (executionType == ExecutionType.ExecuteAll) {
                    intEvents[i].prefix = "IF";
                    intEvents[i].SyncConditionHeadings();
                }
                else {
                    intEvents[i].prefix = GetPrefix(i, intEvents.Count);
                    intEvents[i].SyncConditionHeadings();
                }
            }
        }
#endif   
    }
}