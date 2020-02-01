using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(menuName = "StitchMe/ComplexPayload")]
    public class ComplexPayload : ScriptableObject
    {
        [SerializeField]
        private string _stringPayload;

        public string stringPayload
        {
            get => _stringPayload;
            set => _stringPayload = value;
        }

        [SerializeField]
        private bool _boolPayload;

        public bool boolPayload
        {
            get => _boolPayload;
            set => _boolPayload = value;
        }
    }
}