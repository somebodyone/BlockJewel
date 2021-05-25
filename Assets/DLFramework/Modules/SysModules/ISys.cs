using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DLBASE
{
 	public interface ISys
	{
        void OnStart();
        void Update();
        void FixedUpdate();
        void LateUpdate();
        void Destroy();
    }	
}