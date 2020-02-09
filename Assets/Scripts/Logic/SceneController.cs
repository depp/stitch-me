using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class SceneController : MonoBehaviour
    {
        [SerializeField]
        private SimpleSignal _triggerFadeToBlack;

        public SimpleSignal triggerFadeToBlack
        {
            get => _triggerFadeToBlack;
            set => _triggerFadeToBlack = value;
        }

        [SerializeField]
        private SimpleSignal _singleSceneLoadCompleted;

        public SimpleSignal singleSceneLoadCompleted
        {
            get => _singleSceneLoadCompleted;
            set => _singleSceneLoadCompleted = value;
        }
        
        [SerializeField]
        private SimpleSignal _additiveSceneLoadCompleted;
        
        public SimpleSignal additiveSceneLoadCompleted
        {
            get => _additiveSceneLoadCompleted;
            set => _additiveSceneLoadCompleted = value;
        }

        private string _targetSceneToLoad;

        public string targetSceneToLoad
        {
            get => _targetSceneToLoad;
            set => _targetSceneToLoad = value;
        }

        private bool _fadeTransitionActive;

        private bool fadeTransitionActive
        {
            get => _fadeTransitionActive;
            set => _fadeTransitionActive = value;
        }
        
        public void TriggerLoadScene(ComplexPayload payload)
        {
            var targetScene = payload.stringPayload;
            var loadSceneAdditive = payload.boolPayload;

            if (loadSceneAdditive) {
                StartCoroutine(LoadScene(targetScene, LoadSceneMode.Additive, (AsyncOperation asyncOperation) =>
                {
                    additiveSceneLoadCompleted.SignalChange();
                }));
            }
            else {
                if (fadeTransitionActive == false) {
                    fadeTransitionActive = true;
                    targetSceneToLoad = targetScene;
                    triggerFadeToBlack.SignalChange();
                }
            }
        }

        public void FadeToBlackCompletedCallback()
        {
            StartCoroutine(LoadScene(targetSceneToLoad, LoadSceneMode.Single, (AsyncOperation asyncOperation) =>
            {
                fadeTransitionActive = false;
                singleSceneLoadCompleted.SignalChange();
            }));
        }

        private IEnumerator LoadScene(string targetScene, LoadSceneMode loadSceneMode, Action<AsyncOperation> callback)
        {
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(targetScene, loadSceneMode);
            asyncLoad.completed += callback;
            Debug.Log(asyncLoad);

            while (!asyncLoad.isDone) {
                yield return null;
            }
        }

        public void TriggerUnLoadScene(ComplexPayload payload)
        {
            var targetScene = payload.stringPayload;
            StartCoroutine(StandardAsyncSceneUnload(targetScene));
        }
        
                
        private IEnumerator StandardAsyncSceneUnload(string xSceneName)
        {
            AsyncOperation asyncLoad = SceneManager.UnloadSceneAsync(xSceneName);
            while (!asyncLoad.isDone) {
                yield return null;
            }
        }
        
        public void QuitApplication()
        {
            Application.Quit();
        }
    }
}