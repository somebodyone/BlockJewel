using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLBASE;

namespace DLAM
{
    /// <summary>
    /// 游戏操作区域管理类
    /// </summary>
    public class OperatingMgr : IMgr
    {
        private BlockDrag m_Left;
        private BlockDrag m_Mid;
        private BlockDrag m_Right;
        private List<BlockBg> m_SearchBlockBG;
        private float m_Offset = 3;
        private List<int> m_ClearRowBlockList;
        private List<int> m_ClearColBlockList;
        private bool m_LeftOver;
        private bool m_MidOver;
        private bool m_RightOver;

        public void InitMgr()
        {
            m_Left = GameRoot.Ins.Left.GetComponent<BlockDrag>();
            m_Mid = GameRoot.Ins.Mid.GetComponent<BlockDrag>();
            m_Right = GameRoot.Ins.Right.GetComponent<BlockDrag>();
            m_Left.DragBlock(DragBlockHundler);
            m_Mid.DragBlock(DragBlockHundler);
            m_Right.DragBlock(DragBlockHundler);
            m_Left.DragBlockEnd(DragBlockEndHundler);
            m_Mid.DragBlockEnd(DragBlockEndHundler);
            m_Right.DragBlockEnd(DragBlockEndHundler);
            m_SearchBlockBG = new List<BlockBg>();
            m_ClearRowBlockList = new List<int>();
            m_ClearColBlockList = new List<int>();
        }

        public void StartMgr()
        {
            ReBuildNewBlock();
        }

        private void DragBlockHundler(Transform t, List<Block> blocks)
        {
            m_SearchBlockBG.Clear();
            for (int row = 0; row < BlockMgr.BlockBg.GetLength(0); row++)
            {
                for (int col = 0; col < BlockMgr.BlockBg.GetLength(1); col++)
                {
                    for (int index = 0; index < blocks.Count; index++)
                    {
                        float x = t.position.x + blocks[index].transform.localPosition.x;
                        float y = t.position.y + blocks[index].transform.localPosition.y;
                        float targetx = GameRoot.Ins.BlockParent.transform.position.x + BlockMgr.BlockBg[row, col].transform.localPosition.x;
                        float targety = GameRoot.Ins.BlockParent.transform.position.y + BlockMgr.BlockBg[row, col].transform.localPosition.y;
                        float xdis = Mathf.Abs(x - targetx);
                        float ydis = Mathf.Abs(y - targety);
                        if (xdis <= m_Offset && ydis <= m_Offset)
                        {
                            if (!BlockMgr.BlockBg[row, col].GetFill())
                            {
                                m_SearchBlockBG.Add(BlockMgr.BlockBg[row, col]);
                            }
                            break;
                        }
                        else
                        {
                            BlockMgr.BlockBg[row, col].CloseHightBox();
                        }
                    }
                }
            }
            ShowHightBox(blocks);
        }

        /// <summary>
        /// 显示虚线框
        /// </summary>
        private void ShowHightBox(List<Block> blocks)
        {
            //数量不对，不显示虚线框
            if (blocks.Count != m_SearchBlockBG.Count)
            {
                for (int i = 0; i < m_SearchBlockBG.Count; i++)
                {
                    m_SearchBlockBG[i].CloseHightBox();
                }
                return;
            };
            //显示虚线框
            for (int i = 0; i < m_SearchBlockBG.Count; i++)
            {
                m_SearchBlockBG[i].ShowHightBox();
            }
        }

        private void DragBlockEndHundler(Transform t, List<Block> blocks)
        {
            FillBlock(blocks);
            CloseAllBgHightBox();
        }

        /// <summary>
        /// 填充方块
        /// </summary>
        private void FillBlock(List<Block> blocks)
        {
            //判断找到的格子是否和当前选择的数量一样，一样填充，不一样，则不填充
            if (blocks.Count != m_SearchBlockBG.Count) return;
            for (int i = 0; i < m_SearchBlockBG.Count; i++)
            {
                blocks[i].transform.SetParent(GameRoot.Ins.BlockParent);
                blocks[i].transform.position = m_SearchBlockBG[i].transform.position;
                blocks[i].SetArrayPos(m_SearchBlockBG[i].GetArrayPos());
                blocks[i].transform.localScale = new Vector3(GameConfig.BlockScale, GameConfig.BlockScale, GameConfig.BlockScale);
                m_SearchBlockBG[i].SetFill(true);
                int row = (int)m_SearchBlockBG[i].GetArrayPos().x;
                int col = (int)m_SearchBlockBG[i].GetArrayPos().y;
                BlockMgr.Block[row, col] = blocks[i];
            }
            blocks.Clear();
            SearchEliminateBlock();
            SysManager.ObjectBase.StartCortinueGO(EliminateBlock());
            //填充成功，则计数器减
            BlockMgr.BlockIndex--;        
            if (BlockMgr.BlockIndex == 0)
            {
                BlockMgr.BlockIndex = 3;
            }
            ReBuildNewBlock();
            EndAllGames();
        }

        /// <summary>
        /// 找到可消除行和列
        /// </summary>
        private void SearchEliminateBlock()
        {
            m_ClearRowBlockList.Clear();
            m_ClearColBlockList.Clear();
            for (int row = 0; row < BlockMgr.Block.GetLength(0); row++)
            {
                for (int col = 0; col < BlockMgr.Block.GetLength(1); col++)
                {
                    if (BlockMgr.Block[row, col] == null) break;
                    if (col == BlockMgr.Block.GetLength(1) - 1)
                    {
                        m_ClearRowBlockList.Add(row);
                    }
                }
            }
            for (int col = 0; col < BlockMgr.Block.GetLength(1); col++)
            {
                for (int row = 0; row < BlockMgr.Block.GetLength(0); row++)
                {
                    if (BlockMgr.Block[row, col] == null) break;
                    if (row == BlockMgr.Block.GetLength(0) - 1)
                    {
                        m_ClearColBlockList.Add(col);
                    }
                }
            }
        }

        /// <summary>
        /// 直接消除
        /// </summary>
        private IEnumerator EliminateBlock()
        {
            for (int row = 0; row < m_ClearRowBlockList.Count; row++)
            {
                for (int col = 0; col < BlockMgr.Block.GetLength(1); col++)
                {
                    int currentrow = m_ClearRowBlockList[row];
                    GameObject go = BlockMgr.Block[m_ClearRowBlockList[row], col].gameObject;
                    SysManager.ObjectBase.DestoryGO(go);
                    BlockMgr.BlockBg[m_ClearRowBlockList[row], col].SetFill(false);
                    SysManager.GetSys<GameSys>(SysEnum.GameSys).CreatGame<GameMgr>().EffectMgr.ShowBlockEffect();
                    yield return new WaitForSeconds(0.02f);
                }
            }
            for (int row = 0; row < BlockMgr.Block.GetLength(0); row++)
            {
                for (int col = 0; col < m_ClearColBlockList.Count; col++)
                {
                    int currentcol = m_ClearColBlockList[col];
                    if (BlockMgr.Block[row, m_ClearColBlockList[col]] != null)
                    {
                        GameObject go = BlockMgr.Block[row, m_ClearColBlockList[col]].gameObject;
                        SysManager.ObjectBase.DestoryGO(go);
                        BlockMgr.BlockBg[row, m_ClearColBlockList[col]].SetFill(false);
                        SysManager.GetSys<GameSys>(SysEnum.GameSys).CreatGame<GameMgr>().EffectMgr.ShowBlockEffect();
                    }
                    yield return new WaitForSeconds(0.02f);
                }
            }

        }

        /// <summary>
        /// 生成方块
        /// </summary>
        /// <param name="id">方块配置id</param>
        /// <param name="state">方块颜色类型</param>
        /// <param name="dir">方块方向</param>
        private void BuildBlock(BlockDrag blockDrag, int id, int state, int dir)
        {
            blockDrag.Blocks.Clear();
            int[,] blockArray = GameUtlis.SetMtrixDir(BlockConfig.Block[id], dir);
            blockDrag.InitBlock(blockArray, id, state, dir);
            for (int row = 0; row < blockArray.GetLength(0); row++)
            {
                for (int col = 0; col < blockArray.GetLength(1); col++)
                {
                    if (blockArray[row, col] == 1)
                    {
                        GameObject go = Object.Instantiate(GameRoot.Ins.Block);
                        go.transform.SetParent(blockDrag.transform, false);
                        float start = -(blockArray.GetLength(0) - 1) * GameConfig.Distance / 2;
                        float end = -(blockArray.GetLength(1) - 1) * GameConfig.Distance / 2;
                        go.transform.localPosition = new Vector3(row * GameConfig.Distance + start, col * GameConfig.Distance + end, 0);
                        go.transform.localScale = new Vector3(GameConfig.BlockScale, GameConfig.BlockScale, GameConfig.BlockScale);
                        Block block = go.GetComponent<Block>();
                        Vector2 pos = new Vector2(col, row);
                        block.InitBlock(id, pos);
                        blockDrag.Blocks.Add(block);
                    }
                }
            }
        }

        /// <summary>
        /// 重新构建新的方块
        /// </summary>
        private void ReBuildNewBlock()
        {
            //当前还未消除完成
            if (BlockMgr.BlockIndex != 3) return;
            int type = Random.Range(0, BlockConfig.Block.Length);
            int state = Random.Range(0, 5);
            int dir = Random.Range(0, 4);
            BuildBlock(m_Left, type, state, dir);
            type = Random.Range(0, BlockConfig.Block.Length);
            state = Random.Range(0, 5);
            dir = Random.Range(0, 4);
            BuildBlock(m_Mid, type, state, dir);
            type = Random.Range(0, BlockConfig.Block.Length);
            state = Random.Range(0, 5);
            dir = Random.Range(0, 4);
            BuildBlock(m_Right, type, state, dir);
        }

        /// <summary>
        /// 关闭所有虚线框
        /// </summary>
        private void CloseAllBgHightBox()
        {
            for (int i = 0; i < BlockMgr.BlockBg.GetLength(0); i++)
            {
                for (int j = 0; j < BlockMgr.BlockBg.GetLength(0); j++)
                {
                    BlockMgr.BlockBg[i, j].CloseHightBox();
                }
            }
        }

        /// <summary>
        /// 所有对象都无法填充判断
        /// </summary>
        private void EndAllGames()
        {
            m_LeftOver = false;
            m_RightOver = false;
            m_MidOver = false;
            m_LeftOver = NoFillBoard(m_Left.Blocks);
            m_MidOver = NoFillBoard(m_Mid.Blocks);
            m_RightOver = NoFillBoard(m_Right.Blocks);
            if (m_LeftOver && m_MidOver && m_RightOver)
            {
                EndGame();
                return;
            }
        }
        /// <summary>
        /// 是否可以填充判断
        /// </summary>
        private bool NoFillBoard(List<Block> blocks)
        {
            if (blocks == null) return false;
            if (blocks.Count == 0) return true;
            for (int row = 0; row < BlockMgr.BlockBg.GetLength(0); row++)
            {
                for (int col = 0; col < BlockMgr.BlockBg.GetLength(1); col++)
                {
                    for (int i = 0; i < blocks.Count; i++)
                    {
                        int blockrow = (int)blocks[i].GetArrayPos().x + row;
                        int blockcol = (int)blocks[i].GetArrayPos().y + col;
                        if (blockrow > BlockMgr.BlockBg.GetLength(0) - 1 || blockcol > BlockMgr.BlockBg.GetLength(1) - 1) break;
                        if (BlockMgr.BlockBg[blockrow, blockcol].GetFill())
                        {
                            break;
                        }
                        if (i == blocks.Count - 1)
                        {
                            //还可以消除
                            return false;
                        }
                    }
                    if (row == BlockMgr.BlockBg.GetLength(0) - 1 && col == BlockMgr.BlockBg.GetLength(1) - 1)
                    {
                        //无法消除
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// 游戏结束
        /// </summary>
        private void EndGame()
        {
            Debug.Log("游戏结束！！！");
        }

        /// <summary>
        /// 重新开始游戏
        /// </summary>
        private void ResetGame()
        {
            
        }


        public void UpdateMgr()
        {

        }

        public void EndMgr()
        {

        }
    }
}
