using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace DLBASE
{
    /// <summary>
    /// 游戏数据存取类
    /// </summary>
    public class GameDataSys : SysBase
    {
#if UNITY_EDITOR
        public static string m_Path = Application.dataPath + "/StreamingAssets" + "/JsonTest.json";
#elif UNITY_IPHONE
        public static  string m_Path = Application.persistentDataPath + "/JsonTest.json";
#elif UNITY_ANDROID
       public static  string m_Path = Application.persistentDataPath +"/JsonTest.json";
#endif

        private string debgt;
        public string m_Debug
        {
            get
            {
                return debgt;
            }
            set
            {
                debgt = value;
            }
        }
      

        /// <summary>
        /// 存储数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        public void SaveGameData<T>(T data) where T : IData
        {
            //如果本地没有对应的json 文件，重新创建
            if (!File.Exists(m_Path))
            {
                m_Debug = "创建文件成功" ;
                File.Create(m_Path);
            }

            string json = JsonConvert.SerializeObject(data);
            Debug.Log(json);
            File.WriteAllText(m_Path, json);
            m_Debug = "保存成功" + json;
        }

        /// <summary>
        /// 读取数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T ReadGameData<T>() where T : IData, new()
        {
            if (!File.Exists(m_Path))
            {
                File.Create(m_Path);
                Debug.LogError("读取的文件不存在！");
                return default(T);
            }
            
            string json = File.ReadAllText(m_Path);
            Debug.Log(json);
            T data = JsonConvert.DeserializeObject<T>(json);
            if (data == null)
            {
                data = new T();
            }
            m_Debug = "读取成功" + json;
            return data;
        }

        /// <summary>
        /// 首次打开游戏的时候 需要先创建一个文件
        /// </summary>
        public  void CreatFile()
        {
            //创建json文件
            if (!File.Exists(m_Path))
            {
                //File.Create(m_Path).Close();
                //File.Create(m_Path);
            }
        }
    }
}
