using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLBASE
{
    public class IPool
    {
        /// <summary>
        /// 池子
        /// </summary>
        public List<GameObject> m_Pools = new List<GameObject>();

        /// <summary>
        /// 从对象池中取出对象
        /// </summary>
        public GameObject GetObj(string name)
        {
            GameObject result = null;
            //当对象池里面有对象得时候
            if (m_Pools.Count > 0)
            {
                result = m_Pools[0];
                result.SetActive(true);
                m_Pools.RemoveAt(0);
                return result;
            }
            //当对象池里面没有对象得时候
            GameObject prefab = null;
            prefab = Resources.Load<GameObject>("Effect/Perfabs/" + name);
            //生成
            result =Object.Instantiate(prefab);
            result.name = name;
            //返回
            return result;
        }

        /// <summary>
        /// 回收对象
        /// </summary>
        /// <param name="obj"></param>
        public void RecycleObj(GameObject obj)
        {
            obj.SetActive(false);
            m_Pools.Add(obj);
        }
    }
}
