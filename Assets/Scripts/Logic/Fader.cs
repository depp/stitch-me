using System;
using System.Collections;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

namespace Logic
{
    public class Fader : MonoBehaviour
    {
        private Image _image;

        public Image image
        {
            get => _image;
            set => _image = value;
        }

        [SerializeField]
        private float _fadeCounter;

        public float fadeCounter
        {
            get => _fadeCounter;
            set => _fadeCounter = value;
        }

        [SerializeField]
        private float _fadeInterval;

        public float fadeInterval
        {
            get => _fadeInterval;
            set => _fadeInterval = value;
        }

        [SerializeField]
        private SimpleSignal _fadeToBlackCompleted;

        public SimpleSignal fadeToBlackCompleted
        {
            get => _fadeToBlackCompleted;
            set => _fadeToBlackCompleted = value;
        }
        
        [SerializeField]
        private SimpleSignal _fadeInCompleted;

        public SimpleSignal fadeInCompleted
        {
            get => _fadeInCompleted;
            set => _fadeInCompleted = value;
        }
        

        private void OnEnable()
        {
            image = GetComponentInChildren<Image>();
        }

        public void TriggerFadeIn()
        {
            StartCoroutine(FadeIn());
        }

        private IEnumerator FadeIn()
        {
            float i = 1;
            while(i >= 0) {
                image.color=new Color(0,0, 0,i);
                i -= fadeCounter;
                if (i < 0) {
                    image.color=new Color(0,0,0,0);
                    fadeInCompleted.SignalChange();
                }
                yield return new WaitForSeconds(fadeInterval);
            }
        }
        
        public void TriggerFadeToBlack()
        {
            StartCoroutine(FadeToBlack());
        }
        
        private IEnumerator FadeToBlack()
        {
            float i = 0;
            while(i <= 1) {
                image.color=new Color(0,0,0, i);
                i += fadeCounter;
                if (i > 1) {
                    image.color=new Color(0,0,0,1);
                    fadeToBlackCompleted.SignalChange();
                }
                yield return new WaitForSeconds(fadeInterval);
            }
        }

    }
}