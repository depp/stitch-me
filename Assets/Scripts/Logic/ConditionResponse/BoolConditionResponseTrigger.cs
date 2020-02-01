using System;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    [ExecuteInEditMode]
    public class BoolConditionResponseTrigger : ConditionResponseTrigger
    {
        [SerializeField]
        private List<BoolConditionResponse> _boolEvents;

        public List<BoolConditionResponse> boolEvents
        {
            get => _boolEvents;
            set => _boolEvents = value;
        }
        
        protected override void TriggerAllResponses()
        {
            for (int i = 0; i < boolEvents.Count; i++) {
                boolEvents[i].TriggerResponse();
            }
        }

        protected override void TriggerUntilFirstSuccess()
        {
            for (int i = 0; i < boolEvents.Count; i++) {
                if (boolEvents[i].CheckCondition() == true) {
                    boolEvents[i].TriggerResponse();
                    return;
                }
            }
        }

#if UNITY_EDITOR
        private void Update()
        {
            for (int i = 0; i < boolEvents.Count; i++) {
                if (executionType == ExecutionType.ExecuteAll) {
                    boolEvents[i].prefix = "IF";
                    boolEvents[i].SyncConditionHeadings();
                }
                else {
                    boolEvents[i].prefix = GetPrefix(i, boolEvents.Count);
                    boolEvents[i].SyncConditionHeadings();
                }
            }
        }
#endif   
        
    }
    
    public enum ExecutionType { ExecuteAll, CancelAfterFirstSuccess }
}