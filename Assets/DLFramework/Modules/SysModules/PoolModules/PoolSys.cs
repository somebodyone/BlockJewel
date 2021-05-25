using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLBASE
{
    public class PoolSys : SysBase
    {
        private Dictionary<string, IPool> dicPool = new Dictionary<string, IPool>();

        /// <summary>
        /// 创建池子
        /// </summary>
        /// <param name="name"></param>
        public T CreatPool<T>(string name) where T : IPool, new ()
        {
            IPool pools = new T();
            foreach (string key in dicPool.Keys)
            {
                if (key == name)
                {
                    //已经注册该事件
                    dicPool.TryGetValue(key, out pools);
                    return (T)pools;
                }
            }
            Debug.Log("创建池子成功,池子名称:  " + name);
            dicPool.Add(name, pools);
            return (T)pools;
        }

        /// <summary>
        /// 获取池子
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        public T GetPool<T>(string name)where T : IPool, new()
        {
            IPool t = new T();
            foreach(string item in dicPool.Keys)
            {
                if (item == name)
                {
                    dicPool.TryGetValue(item, out t);
                    return t as T;
                }
            }
            return t as T;
        }
    }
}

