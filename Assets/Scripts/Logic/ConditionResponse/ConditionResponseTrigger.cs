using UnityEngine;

namespace DefaultNamespace
{
    
    public abstract class ConditionResponseTrigger : MonoBehaviour
    {
        [SerializeField]
        private ExecutionType _executionType;

        public ExecutionType executionType
        {
            get => _executionType;
            set => _executionType = value;
        }
        
        public void CallTriggerResponses()
        {
            if (executionType == ExecutionType.ExecuteAll) {
                TriggerAllResponses();
            }
            else {
                TriggerUntilFirstSuccess();
            }
        }

        protected abstract void TriggerAllResponses();
        
        protected abstract void TriggerUntilFirstSuccess();

        
#if UNITY_EDITOR
        protected string GetPrefix(int index, int length)
        {
            if (index == 0) {
                return "IF";
            }

            return "ELSE IF";
        }
#endif      
    }
}