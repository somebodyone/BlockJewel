using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLBASE
{
    /// <summary>
    /// 系统类型
    /// </summary>
    public enum SysEnum
    {
        /// <summary>
        /// 声音系统
        /// </summary>
        AudioSys,
        /// <summary>
        /// 事件系统
        /// </summary>
        EventSys,
        /// <summary>
        /// UI系统
        /// </summary>
        UISys,
        /// <summary>
        /// 存储系统
        /// </summary>
        GameDataSys,
        /// <summary>
        /// 游戏系统
        /// </summary>
        GameSys,
        /// <summary>
        /// 对象池系统
        /// </summary>
        PoolSys,
        /// <summary>
        /// 配置表Excel系统
        /// </summary>
        ExcelSys
    }

    public static class SysManager
    {
        private static Dictionary<SysEnum, SysBase> Sys = new Dictionary<SysEnum, SysBase>();
        private static GameObject SysGame;
        public static ObjectBase ObjectBase;

        /// <summary>
        /// 初始化系统
        /// </summary>
        public static void InitSys()
        {
            if (SysGame == null)
            {
                Debug.Log("初始化系统！");
                SysGame = new GameObject();
                SysGame.name = "LDFramwork";
                SysGame.AddComponent<ObjectBase>();
                ObjectBase = SysGame.GetComponent<ObjectBase>();
            }
        }

        /// <summary>
        /// 加載系统
        /// </summary>
        public static void LoadSys<T>(SysEnum sysEnum) where T : SysBase, new()
        {
            T t = new T();
            foreach (SysEnum key in Sys.Keys)
            {
                if (key == sysEnum)
                {
                    Debug.Log("已經加載" + sysEnum.ToString() + "系統");
                    return;
                }
            }
            Debug.Log("加載" + sysEnum.ToString() + "系統");
            Sys.Add(sysEnum, t);
        }

        /// <summary>
        /// 获取当前系统
        /// </summary>
        /// <param name="sysEnum"></param>
        public static T GetSys<T>(SysEnum sysEnum) where T : SysBase, new()
        {
            SysBase sys = new T();
            foreach (SysEnum item in Sys.Keys)
            {
                if (item == sysEnum)
                {
                    Sys.TryGetValue(item, out sys);
                    return sys as T;
                }
            }
            return sys as T;
        }       


        public static void OnStart()
        {
            foreach(SysBase item in Sys.Values)
            {
                item.OnStart();
            }
        }

        public static void FixedUpdate()
        {
            foreach (SysBase item in Sys.Values)
            {
                item.FixedUpdate();
            }
        }

        public static void Update()
        {
            foreach (SysBase item in Sys.Values)
            {
                item.Update();
            }
        }

        public static void LateUpdate()
        {
            foreach (SysBase item in Sys.Values)
            {
                item.LateUpdate();
            }
        }

        public static void Destroy()
        {
            foreach (SysBase item in Sys.Values)
            {
                item.Destroy();
            }
        }

        public static void OnApplicationQuit()
        {
            foreach (SysBase item in Sys.Values)
            {
                item.OnApplicationQuit();
            }
        }
    }
}