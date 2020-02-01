using UnityEngine;

namespace AltSalt.Maestro.Logic {
    
    public class PersistObject : MonoBehaviour {

        [SerializeField]
        private bool _persist;

        public bool persist
        {
            get => _persist;
            set => _persist = value;
        }

        void Awake() {
            if(persist) {
                DontDestroyOnLoad(this.gameObject);
            }
        }
    }

}