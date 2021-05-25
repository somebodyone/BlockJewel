using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace DLBASE
{
    /// <summary>
    /// 屏幕适配工具
    /// </summary>
    public class ScreenAdaptationTools : MonoBehaviour
    {
        public void Awake()
        {
            Adapatation();
        }

        public void Adapatation()
        {
            ScreenOrientation designAutoRotation = Screen.orientation;
            Camera _camera = this.gameObject.GetComponent<Camera>();
            float aspect = _camera.aspect;
            float designOrthographicSize = 60;
            float designHeight = 1334;
            float designWidth = 750;
            float designAspect = designWidth / designHeight;
            float widthOrthographicSize = designOrthographicSize * designAspect;
            switch (designAutoRotation)
            {
                case ScreenOrientation.Portrait:
                    if (aspect < designAspect)
                    {
                        _camera.orthographicSize = widthOrthographicSize / aspect;
                    }
                    if (aspect > designAspect)
                    {
                        _camera.orthographicSize = designOrthographicSize;
                        //_camera.orthographicSize = designOrthographicSize * (aspect / designAspect);
                    }
                    break;
                case ScreenOrientation.AutoRotation:
                    break;
                case ScreenOrientation.LandscapeLeft:
                    break;
                case ScreenOrientation.LandscapeRight:
                    break;
                case ScreenOrientation.PortraitUpsideDown:
                    break;
                default:
                    break;

            }

        }
    }
}
