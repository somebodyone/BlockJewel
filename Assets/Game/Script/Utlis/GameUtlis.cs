using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLAM
{
    public static class GameUtlis 
    {
        /// <summary>
        /// 转置矩阵
        /// </summary>
        /// <returns></returns>
        public static int[,] TransposeMtrix(int[,] matrix)
        {
            int[,] array = new int[matrix.GetLength(1), matrix.GetLength(0)];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    array[matrix.GetLength(1) - 1 - j,i] = matrix[i, j];
                }
            }
            return array;
        }

        public static int[,] TurnMtrix(int[,] matrix)
        {
            int[,] array = new int[matrix.GetLength(0), matrix.GetLength(1)];
            if(matrix.GetLength(0)==1|| matrix.GetLength(1) == 1)
            {
                return matrix;
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    array[i, j] = matrix[matrix.GetLength(0) - 1 - i, matrix.GetLength(1) - 1 - j];
                }
            }
            return array;
        }

        public static int[,] ChangeMtrixDir(int[,] matrix, int dir)
        {
            int[,] blocks = new int[0, 0];
            switch (dir)
            {
                case 0:
                    blocks = GameUtlis.TransposeMtrix(matrix);
                    blocks = TurnMtrix(blocks);
                    break;
                case 1:
                    blocks = GameUtlis.TransposeMtrix(matrix);
                    blocks = TurnMtrix(blocks);
                    break;
                case 2:
                    blocks = GameUtlis.TransposeMtrix(matrix);
                    blocks = TurnMtrix(blocks);
                    break;
                case 3:
                    blocks = GameUtlis.TransposeMtrix(matrix);
                    blocks = TurnMtrix(blocks);
                    break;
            }
            return blocks;
        }
        public static int[,] SetMtrixDir(int[,] matrix, int dir)
        {
            int[,] blocks = new int[0, 0];
            switch (dir)
            {
                case 0:
                    blocks = matrix;
                    break;
                case 1:
                    blocks = GameUtlis.TransposeMtrix(matrix);
                    blocks = TurnMtrix(blocks);
                    break;
                case 2:
                    blocks = GameUtlis.TransposeMtrix(matrix);
                    blocks = TurnMtrix(blocks);
                    blocks = GameUtlis.TransposeMtrix(blocks);
                    blocks = TurnMtrix(blocks);
                    break;
                case 3:
                    blocks = GameUtlis.TransposeMtrix(matrix);
                    blocks = TurnMtrix(blocks);
                    blocks = GameUtlis.TransposeMtrix(blocks);
                    blocks = TurnMtrix(blocks);
                    blocks = GameUtlis.TransposeMtrix(blocks);
                    blocks = TurnMtrix(blocks);
                    break;
                case 4:
                    blocks = matrix;
                    break;
            }
            return blocks;
        }

        public static IEnumerator Wait(float time,Action callback)
        {
            yield return new WaitForSeconds(time);
            callback?.Invoke();
        }

        public static void RandomNumber(float prcent,Action sucess,Action fail)
        {
            float num = UnityEngine.Random.Range(0, 100);
            if (num > prcent)
            {
                fail?.Invoke();
            }
            else
            {
                sucess?.Invoke();
            }
        }

    }
}

