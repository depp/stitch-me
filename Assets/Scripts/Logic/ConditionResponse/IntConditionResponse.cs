using System;
using UnityEngine;

namespace DefaultNamespace
{
    [Serializable]
    public class IntConditionResponse : ConditionResponse
    {
        [SerializeField]
        private IntComparisonOperation _intComparisonOperation;

        public IntComparisonOperation intComparisonOperation
        {
            get => _intComparisonOperation;
            set => _intComparisonOperation = value;
        }

        [SerializeField]
        private IntReference _intReference;

        public IntReference intReference
        {
            get => _intReference;
            set => _intReference = value;
        }

        [SerializeField]
        private IntReference _intCondition;

        public IntReference intCondition
        {
            get => _intCondition;
            set => _intCondition = value;
        }

        public override void SyncConditionHeadings()
        {
            base.SyncConditionHeadings();

            if (intReference.variable == null) {
                description = "Please populate a reference";
            }

            else if (intCondition.useConstant == false) {
                description = "You must use a constant comparison value";
            }
            
            else  {
                description = prefix + $" {intReference.variable.name} is {intComparisonOperation} {intCondition.GetValue()}";
            }

            description += GetActionDescription();
        }

        public override bool CheckCondition()
        {
            switch (intComparisonOperation) {
                
                case IntComparisonOperation.EqualTo:
                    if (intReference.GetValue() == intCondition.GetValue()) {
                        return true;
                    }
                    break;
                
                case IntComparisonOperation.GreaterThan:
                    if (intReference.GetValue() > intCondition.GetValue()) {
                        return true;
                    }
                    break;
                
                case IntComparisonOperation.LessThan:
                    if (intReference.GetValue() < intCondition.GetValue()) {
                        return true;
                    }
                    break;
            }

            return false;
        }

    }
}