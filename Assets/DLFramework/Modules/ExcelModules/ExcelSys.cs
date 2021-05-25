using Excel;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using UnityEngine;

namespace DLBASE
{
    public static class  ExcelSys 
    {
        private static readonly string filePath = Application.dataPath + "/BlockJewel/Excel/" + "Block.xlsx";
        ///// <summary>
        ///// 读取游戏难度数据
        ///// </summary>
        //public static DiffData[] ReadExecelDiff()
        //{
        //    //这里的用List存储 可避免一些空行的保存
        //    List<DiffData> list = new List<DiffData>();
        //    int columnNum = 0, rowNum = 0;//excel 行数 列数
        //    DataRowCollection collect = ReadExcel(filePath, ref columnNum, ref rowNum);
        //    if (collect == null)
        //    {
        //        Debug.Log("没有读取到数据！！！" + filePath);
        //    }
        //    //这里i从1开始遍历， 因为第一行是标签名
        //    for (int i = 2; i < rowNum; i++)
        //    {
        //        //如果改行是空行 不保存
        //        if (IsEmptyRow(collect[i], columnNum)) continue;

        //        DiffData t = new DiffData();
        //        int.TryParse(collect[i][0].ToString(), out t.difficulty);
        //        string[] str = collect[i][1].ToString().Split(',');
        //        t.blocks = str;
        //        list.Add(t);
        //    }
        //    return list.ToArray();
        //}

        public static DLConfigDatas ReadConfigData()
        {
            string path = "ExcelConfig";
            DLConfigDatas data = Resources.Load<DLConfigDatas>(path);
            return data;
        }

        //判断是否是空行
        static bool IsEmptyRow(DataRow collect, int columnNum)
        {
            for (int i = 0; i < columnNum; i++)
            {
                if (!collect.IsNull(i)) return false;
            }
            return true;
        }

        /// <summary>
        /// 读取excel文件内容获取行数 列数 方便保存
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <param name="columnNum">行数</param>
        /// <param name="rowNum">列数</param>
        /// <returns></returns>
        static DataRowCollection ReadExcel(string filePath, ref int columnNum, ref int rowNum)
        {
            FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);

            DataSet result = excelReader.AsDataSet();
            //Tables[0] 下标0表示excel文件中第一张表的数据
            columnNum = result.Tables[0].Columns.Count;
            rowNum = result.Tables[0].Rows.Count;
            return result.Tables[0].Rows;
        }

    }
}
