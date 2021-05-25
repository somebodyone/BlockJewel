using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLBASE;

namespace DLAM
{
    public class Block : GameBase
    {
        public SpriteRenderer m_Sprite;
        public int m_type;
        private Vector2 m_Pos;

        public void InitBlock(int type,Vector2 pos)
        {
            m_Pos = pos;
            m_type = type;
        }

        public void SetArrayPos(Vector2 pos)
        {
            m_Pos = pos;
        }

        public Vector2 GetArrayPos()
        {
            return m_Pos;
        }

        public void UpLayer()
        {
            m_Sprite.sortingOrder = 100;
        }

        public void DownLayer()
        {
            m_Sprite.sortingOrder = 10;
        }
    }
}

