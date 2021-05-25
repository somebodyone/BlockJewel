using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLAM
{
    public class BlockConfig 
    {
        //单格子方块
        public static int[,] OBlock = new int[1, 1] { { 1 } };
        //两个格子
        public static int[,] OTBlock = new int[2, 1] { { 1 }, { 1 } };

        public static int[,] OCBlock = new int[3, 1] { { 1 }, { 1 }, { 1 } };

        public static int[,] ODBlock = new int[4, 1] { { 1 }, { 1 }, { 1 }, { 1 } };

        public static int[,] OEBlock = new int[5, 1] { { 1 }, { 1 }, { 1 }, { 1 }, { 1 } };

        public static int[,] MTBlock = new int[2, 2] { { 1, 1 }, { 1, 1 } };

        public static int[,] MTTBlock = new int[2, 3] { { 1, 1, 1 }, { 1, 1, 1 } };

        public static int[,] ZLBlock = new int[2, 2] { { 1, 1 }, { 1, 0 } };
        //Z形状
        public static int[,] ZBlock = new int[2, 3] { { 1, 1, 0 }, { 0, 1, 1 } };
        //反Z形状
        public static int[,] RZBlock = new int[2, 3] { { 0, 1, 1 }, { 1, 1, 0 } };
        //T形状
        public static int[,] TBlock = new int[2, 3] { { 0, 1, 0 }, { 1, 1, 1 } };
        //7形状
        public static int[,] LBlock = new int[3, 3] { { 1, 1, 1 }, { 1, 0, 0 }, { 1, 0, 0 } };
        //反7
        public static int[,] RLBlock = new int[3, 3] { { 1, 0, 0 }, { 1, 0, 0 }, { 1, 1, 1 } };

        public static int[,] DLBlock = new int[3, 2] { { 1, 1 }, { 1, 0 }, { 1, 0 } };

        public static int[,] DLRBlock = new int[3, 2] { { 1, 1 }, { 0, 1 }, { 0, 1 } };
        //田字
        public static int[,] MBlock = new int[3, 3] { { 1, 1, 1 }, { 1, 1, 1 }, { 1, 1, 1 } };

        //方块数组聚合
        public static int[][,] Block = new int[16][,] { OBlock, OTBlock, OCBlock, ODBlock, OEBlock, ZLBlock, MTBlock, MTTBlock, ZBlock, RZBlock, TBlock, LBlock, RLBlock, DLBlock, DLRBlock, MBlock };
    }
}
