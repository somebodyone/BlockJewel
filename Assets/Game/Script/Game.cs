using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLBASE;

namespace DLAM
{
    public class Game : GameBase
    {
        public override void _Init()
        {
            SysManager.InitSys();
            SysManager.LoadSys<GameSys>(SysEnum.GameSys);
            SysManager.LoadSys<UISys>(SysEnum.GameSys);
            SysManager.LoadSys<AudioSys>(SysEnum.GameSys);
            SysManager.LoadSys<PoolSys>(SysEnum.GameSys);
            SysManager.LoadSys<GameDataSys>(SysEnum.GameSys);
        }

        public override void _OnStart()
        {
            GameMgr gameMgr = SysManager.GetSys<GameSys>(SysEnum.GameSys).CreatGame<GameMgr>();
            gameMgr.InitMgr();
            gameMgr.StartMgr();
        }
    }
}

