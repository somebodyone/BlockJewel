using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLBASE
{
    public class GameBase : MonoBehaviour
    {
        public virtual void _Init() { }
        public virtual void _OnStart() { }
        public virtual void _FixedUpdate() { }
        public virtual void _Update() { }
        public virtual void _LateUpdate() { }
        public virtual void _Destroy() { }
        public virtual void _OnApplicationQuit() { }
        public virtual void _OnApplicationPause() { }
        public virtual void _OnMouseDown() { }
        public virtual void _OnMouseDrag() { }
        public virtual void _OnMouseUp() { }

        public void OnApplicationPause(bool pause)
        {
            _OnApplicationPause();
        }

        public void OnMouseDown()
        {
            _OnMouseDown();
        }

        public void OnMouseDrag()
        {
            _OnMouseDrag();
        }

        public void OnMouseUp()
        {
            _OnMouseUp();
        }

        public void Awake()
        {
            _Init();
        }
        public void Start()
        {
            _OnStart();
            SysManager.OnStart();
        }
        public void FixedUpdate()
        {
            _FixedUpdate();
            SysManager.FixedUpdate();
        }
        public void Update()
        {
            _Update();
            SysManager.Update();
        }
        public void LateUpdate()
        {
            _LateUpdate();
            SysManager.LateUpdate();
        }
        public void OnDestroy()
        {
            _Destroy();
            SysManager.Destroy();
        }

        public void OnApplicationQuit()
        {
            _OnApplicationQuit();
            SysManager.OnApplicationQuit();
        }
    }
}