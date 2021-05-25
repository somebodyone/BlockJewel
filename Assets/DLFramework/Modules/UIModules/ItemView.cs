using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLBASE
{
    public class ItemView : MonoBehaviour
    {
        public virtual void Init()
        {

        }

        public virtual void RefreshData(IData data)
        {

        }
        public virtual void Show()
        {
            gameObject.SetActive(true);
        }


        public virtual void Close()
        {
            gameObject.SetActive(false);
        }
    }
}

