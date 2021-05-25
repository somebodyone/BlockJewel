using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace DLBASE
{
    public class IView : MonoBehaviour
    {
        ItemView itemView;
        public virtual void Init()
        {

        }

        public virtual void ShowItemView<T>(T t,IData data) where T : ItemView
        {
            if (itemView != null)
            {
                itemView.Show();
                itemView.RefreshData(data);
                return;
            }
            itemView = (ItemView)t;
            itemView.Init();
            itemView.Show();
            itemView.RefreshData(data);
        }

        public virtual void CloseItemView<T>()where T : ItemView
        {
            if (itemView != null)
            {
                itemView.Close();
                return;
            }
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