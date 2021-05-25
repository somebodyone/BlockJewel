using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XGY
{
	public static class DOTweenExtrensions
	{
		public static void DOMoveLoop(this Transform transform, Vector3 from, Vector3 to, float duration)
		{
			transform.DOMove(to, duration).OnComplete(() => {
				transform.DOMoveLoop(to, from, duration);
			});
		}

        public static void DOMoveXLoop(this Transform transform, float from, float to, float duration)
        {
            transform.DOMoveX(to, duration).OnComplete(() =>
            {
                transform.DOMoveXLoop(to, from, duration);
            });
        }

        public static void DOLocalMoveLoop(this Transform transform, Vector3 from, Vector3 to, float duration)
		{
            transform.DOLocalMove(to, duration).OnComplete(() =>
            {
                transform.DOLocalMoveLoop(to, from, duration);
            });
        }
	}
	
}