using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLBASE;

namespace DLAM
{
    /// <summary>
    /// 游戏管理类
    /// </summary>
    public class GameMgr : GameSys, IMgr
    {
        public  GameBoradMgr GameBoradMgr;
        public  OperatingMgr OperatingMgr;
        public  EffectMgr EffectMgr;

        public void InitMgr()
        {
            GameBoradMgr = new GameBoradMgr();
            OperatingMgr = new OperatingMgr();
            EffectMgr = new EffectMgr();
            GameBoradMgr.InitMgr();
            OperatingMgr.InitMgr();
        }

        public void StartMgr()
        {
            GameBoradMgr.StartMgr();
            OperatingMgr.StartMgr();
        }

        public void UpdateMgr()
        {

        }

        public void EndMgr()
        {

        }
    }
}
