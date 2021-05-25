using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLAM
{
    /// <summary>
    /// 游戏区域管理类
    /// </summary>
    public class GameBoradMgr : IMgr
    {
        public void InitMgr()
        {
            BlockMgr.Block = new Block[GameConfig.Row,GameConfig.Col];
            BlockMgr.BlockBg = new BlockBg[GameConfig.Row, GameConfig.Col];
        }
        public void StartMgr()
        {
            for (int row = 0; row < BlockMgr.BlockBg.GetLength(0); row++)
            {
                for (int col = 0; col < BlockMgr.BlockBg.GetLength(1); col++)
                {
                    float start = -(BlockMgr.BlockBg.GetLength(0) - 1) * GameConfig.Distance / 2;
                    float end = -(BlockMgr.BlockBg.GetLength(1) - 1) * GameConfig.Distance / 2;
                    GameObject go = Object.Instantiate(GameRoot.Ins.BlockBG);
                    go.transform.SetParent(GameRoot.Ins.BlockParent, false);
                    go.transform.localPosition = new Vector3(col * GameConfig.Distance + start, row * GameConfig.Distance + end, 0);
                    go.transform.localScale = new Vector3(GameConfig.BGScale, GameConfig.BGScale, GameConfig.BGScale);
                    Vector2 pos = new Vector2(row, col);
                    BlockBg blockBg = go.GetComponent<BlockBg>();
                    blockBg.SetArrayPos(pos);
                    BlockMgr.BlockBg[row, col] = blockBg;
                }
            }
        }
        public void UpdateMgr()
        {

        }
        public void EndMgr()
        {

        }       
    }
}
