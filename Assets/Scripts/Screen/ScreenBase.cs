using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using DG.Tweening;

namespace Screens 
{ 
  public enum ScreenType
  {
     Panel,
     Info_Panel,
     Shop
  }


  public class ScreenBase : MonoBehaviour
  {
      public ScreenType screenType;

        public List<Transform> listofobjects;
        public List<Typper> listofPhrases;


        public bool startHided = false;

        [Header("Animation")]
        public float delayBetweenObjects = .05f;
        public float animationDuration = .3f;


        private void Start()
        {
            if (startHided)
            {
                HideObjects();
            }
        }


        [Button]
        protected virtual void Show()
        {
            ShowObjects();
            Debug.Log("Show");
        }
        
        [Button]
        protected virtual void Hide()
        {
            HideObjects();
            Debug.Log("Hide");

        }

        private void HideObjects()
        {
            listofobjects.ForEach(i => i.gameObject.SetActive(false));
        }

        private void ShowObjects()
        {
            for (int i = 0; i < listofobjects.Count; i++)
            {
                var obj = listofobjects[i];

                obj.gameObject.SetActive(true);
                obj.DOScale(0, animationDuration).From().SetDelay(i * delayBetweenObjects);
            }

            Invoke(nameof(StartType), delayBetweenObjects * listofobjects.Count);
        }

        private void StartType()
        {
            for (int i = 0; i < listofPhrases.Count; i++)
            {
                listofPhrases[i].StartType();

            }
        }


        private void ForceShowObjects()
        {
            listofobjects.ForEach(i => i.gameObject.SetActive(true));

        }
    }

}