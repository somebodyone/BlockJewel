using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DLBASE
{
    public class GameSys : SysBase
    {
        private GameSys m_SysBase;

        /// <summary>
        /// 创建新游戏
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public T CreatGame<T>()where T: GameSys,new ()
        {
            if (m_SysBase == null)
            {
                m_SysBase = new T();
            }
            return m_SysBase as T;
        }

        /// <summary>
        /// 获取游戏
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetGame<T>()where T : GameSys, new()
        {
            return m_SysBase as T;
        }
    }
}