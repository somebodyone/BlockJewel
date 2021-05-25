///<summary>
///描述: 
///作者: xxx 
///创建时间: 2020/08/21 16:50 
///__Summary__Processed__ 
///</summary>
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;

namespace DLBASE
{
    public class ButtonScale : GameBase
    {
        public Vector3 pressScale = new Vector3(0.8f, 0.8f, 0.8f);

        private Vector3 normalScale = new Vector3(1, 1, 1);
        private float duration = 0.2f;

        public override void _Init()
        {
            EventTriggerListener.Get(gameObject).onDown += OnDown;
            EventTriggerListener.Get(gameObject).onUp += OnUp;
        }

        private void OnDown(GameObject go, PointerEventData pointerEventData)
        {
            transform.DOScale(pressScale, duration);
        }

        private void OnUp(GameObject go, PointerEventData pointerEventData)
        {
            transform.DOScale(normalScale, duration);
        }
    }
}
