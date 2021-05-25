using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLBASE
{
    public class ObjectBase : GameBase
    {
        public void DestoryGO(GameObject go)
        {
            Destroy(go);
        }

        public GameObject InstantiateGO(GameObject go)
        {
            GameObject gameObject = Instantiate(go);
            return gameObject;
        }

        public void StartCortinueGO(IEnumerator enumerator)
        {
            StartCoroutine(enumerator);
        }
    }
}
