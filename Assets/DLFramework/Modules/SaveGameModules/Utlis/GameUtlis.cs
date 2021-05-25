using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLBASE
{

    public class GameUtlis : MonoBehaviour
    {
        public enum WaitType
        {
            Once,
            Reseapt
        }

        public static int RandomAmount(int endAmount)
        {
            int next = UnityEngine.Random.Range(0, endAmount);
            return next;
        }

        public static float RandomAmount(float endAmount)
        {
            float next = UnityEngine.Random.Range(0, endAmount);
            return next;
        }

        public static IEnumerator Wait(float time, Action callback)
        {
            yield return new WaitForSeconds(time);
            callback?.Invoke();
        }

        public static IEnumerator WebImage(string url,Action<Sprite> action)
        {
            WWW www = new WWW(url);
            yield return www;
            if (www.error == null)
            {
                print("---load Succeed---");
                Texture2D t = www.texture;
                Sprite csprite = Sprite.Create(t, new Rect(0, 0, t.width, t.height), new Vector2(0, 0));
                action.Invoke(csprite);
            }
        }
    }

}