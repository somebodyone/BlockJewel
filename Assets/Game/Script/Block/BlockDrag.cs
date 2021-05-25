using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLBASE;
using System;

namespace DLAM
{
    public class BlockDrag : GameBase
    {
        public List<Block> Blocks;
        private int[,] m_Block;
        private int m_Id;
        private int m_State;
        private int m_Dir;
        private Vector3 m_OldPos;
        private Action<Transform, List<Block>> m_DragBlock;
        private Action<Transform, List<Block>> m_DragBlockEnd;

        public override void _Init()
        {
            m_OldPos = transform.localPosition;
        }

        public void InitBlock(int[,] blockconfig,int id,int state,int dir)
        {
            m_Block = blockconfig;
            m_Id = id;
            m_State = state;
            m_Dir = dir;
        }

        public override void _OnMouseDown()
        {

        }

        public void UpLayer()
        {
            for (int i = 0; i < Blocks.Count; i++)
            {
                Blocks[i].UpLayer();
            }
        }

        public void DownLayer()
        {
            for (int i = 0; i < Blocks.Count; i++)
            {
                Blocks[i].DownLayer();
            }
        }

        public override void _OnMouseDrag()
        {
            UpLayer();
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos = new Vector3(pos.x, pos.y, transform.position.z);
            transform.localPosition = pos;
            transform.localScale = Vector3.one;
            m_DragBlock?.Invoke(transform, Blocks);
        }
        public override void _OnMouseUp()
        {
            DownLayer();
            ResetBlock();
            m_DragBlockEnd?.Invoke(transform, Blocks);
        }

        public void ResetBlock()
        {
            transform.localPosition = m_OldPos;
            transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
        }

        public void DragBlock(Action<Transform, List<Block>> drag)
        {
            m_DragBlock += drag;
        }

        public void DragBlockEnd(Action<Transform, List<Block>> dragend)
        {
            m_DragBlockEnd += dragend;
        }
    }
}
