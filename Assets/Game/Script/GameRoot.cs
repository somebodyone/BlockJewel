using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLBASE;

namespace DLAM
{
    public class GameRoot : GameBase
    {
        public static GameRoot Ins;

        public GameObject BlockBG;
        public GameObject Block;
        public Transform BlockParent;
        public Transform Left;
        public Transform Mid;
        public Transform Right;

        public override void _Init()
        {
            Ins = this;
        }
    }
}
