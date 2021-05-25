using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 事件管理类
/// </summary>
namespace DLBASE
{
    public class EventSys : SysBase
    {
        public delegate void EventDelget(IData data);
        public Dictionary<string, List<EventDelget>> m_Dictionary = new Dictionary<string, List<EventDelget>>();

        /// <summary>
        /// 派发事件
        /// </summary>
        /// <param name="name"></param>
        /// <param name="data"></param>
        public void TriggerEvent(string name, IData data = null)
        {
            List<EventDelget> eventDelget;
            foreach (string key in m_Dictionary.Keys)
            {
                if (key == name)
                {
                    //已经注册该事件
                    m_Dictionary.TryGetValue(key, out eventDelget);
                    for (int i = 0; i < eventDelget.Count; i++)
                    {
                        eventDelget[i]?.Invoke(data);
                    }
                    return;
                }
            }
        }

        /// <summary>
        /// 监听事件
        /// </summary>
        /// <param name="name"></param>
        /// <param name="eventDelget"></param>
        public void AddListionter(string name, EventDelget callback)
        {
            List<EventDelget> eventDelget;
            foreach (string key in m_Dictionary.Keys)
            {
                if (key == name)
                {
                    m_Dictionary.TryGetValue(key, out eventDelget);
                    eventDelget.Add(callback);
                    return;
                }
            }
            eventDelget = new List<EventDelget>();
            eventDelget.Add(callback);
            m_Dictionary.Add(name, eventDelget);
        }

        /// <summary>
        /// 移除监听
        /// </summary>
        /// <param name="name"></param>
        public void RemoveListionter(string name)
        {
            foreach (string key in m_Dictionary.Keys)
            {
                if (key == name)
                {
                    //已经注册该事件
                    m_Dictionary.Remove(key);
                    return;
                }
            }
        }
    }
}