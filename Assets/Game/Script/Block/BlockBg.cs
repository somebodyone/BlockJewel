using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLBASE;

namespace DLAM
{
    public class BlockBg : GameBase
    {
        public GameObject m_Bg;
        public GameObject m_White;
        private Vector2 m_Pos;
        private bool m_Isfill;

        public void SetArrayPos(Vector2 pos)
        {
            m_Pos = pos;
        }

        public Vector2 GetArrayPos()
        {
            return m_Pos;
        }

        public void ShowHightBox()
        {
            m_White.SetActive(true);
        }

        public void CloseHightBox()
        {
            m_White.SetActive(false);
        }

        public bool GetFill()
        {
            return m_Isfill;
        }

        public void SetFill(bool isfill)
        {
            m_Isfill = isfill;
        }
    }
}
