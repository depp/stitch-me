using System;
using UnityEngine;

namespace DefaultNamespace
{
    [Serializable]
    public class BoolConditionResponse : ConditionResponse
    {
        [SerializeField]
        private BoolReference _boolReference;

        public BoolReference boolReference
        {
            get => _boolReference;
            set => _boolReference = value;
        }

        [SerializeField]
        private BoolReference _boolCondition;

        public BoolReference boolCondition
        {
            get => _boolCondition;
            set => _boolCondition = value;
        }
        
        public override void SyncConditionHeadings()
        {
            base.SyncConditionHeadings();
            
            if (boolReference.variable == null) {
                description = "Please populate a reference";
            }
            else if (boolCondition.useConstant == false) {
                description = "You must use a constant comparison value";
            }
            else {
                description = prefix + $" {boolReference.variable.name} is equal to {boolCondition.GetValue()}";
            }

            description += GetActionDescription();
        }

        public override bool CheckCondition()
        {
            if (boolReference.GetValue() == boolCondition.GetValue()) {
                return true;
            }

            return false;
        }
    }
}