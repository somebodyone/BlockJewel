
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// UI界面管理类
/// </summary>
namespace DLBASE
{
    public class UISys : SysBase
    {
        private  Dictionary<string, IView> m_IViews = new Dictionary<string, IView>();        

        /// <summary>
        /// 父物体
        /// </summary>
        public  GameObject UIRoot
        {
            get
            {
                return GameObject.Find("UIRoot");
            }
        }

        /// <summary>
        /// 分发事件
        /// </summary>
        public  void OpenView<T>(string name, IData data = null) where T : IView
        {
            IView view;
            foreach (string item in m_IViews.Keys)
            {
                if (item == name)
                {
                    m_IViews.TryGetValue(item, out view);
                    view.Show();
                    view.RefreshData(data);
                    return;
                }
            }
            GameObject go =  Object.Instantiate(Resources.Load("UI/" + name) as GameObject);
            go.transform.SetParent(UIRoot.transform, false);
            view = go.GetComponent<IView>();
            view.Init();
            view.Show();
            view.name = name;
            m_IViews.Add(name, view);
            view.RefreshData(data);
        }

        /// <summary>
        /// 关闭界面
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        public  void CloseView<T>(string name) where T : IView
        {
            IView view;
            foreach (string item in m_IViews.Keys)
            {
                if (item == name)
                {
                    m_IViews.TryGetValue(item, out view);
                    view.Close();
                    return;
                }
            }
        }

        /// <summary>
        /// 获取指定界面
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <returns></returns>
        public  T GetView<T>(string name) where T : IView
        {
            IView view = null;
            foreach (string item in m_IViews.Keys)
            {
                if (item == name)
                {
                    m_IViews.TryGetValue(item, out view);
                    return (T)view;
                }
            }
            return null;
        }

        /// <summary>
        /// 添加点击事件
        /// </summary>
        /// <param name="go"></param>
        /// <param name="callBack"></param>
        public  void ButtonClick(GameObject go, EventTriggerListener.VoidDelegate callBack)
        {
            ButtonClickHelper.AddClickEvent(go, callBack);
        }
    }
}