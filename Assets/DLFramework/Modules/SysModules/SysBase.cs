using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLBASE
{
    public class SysBase : ISys
    {
        public SysBase()
        {
            InitSys();
        }

        protected virtual void InitSys() { }
        public virtual void OnStart() { }
        public virtual void Destroy() { }
        public virtual void FixedUpdate() { }
        public virtual void LateUpdate() { }
        public virtual void Update() { }
        public virtual void OnApplicationQuit() { }
    }
}

