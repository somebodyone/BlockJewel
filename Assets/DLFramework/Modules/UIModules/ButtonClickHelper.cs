///<summary>
///描述: 
///作者: xxx 
///创建时间: 2020/12/21 10:09 
///__Summary__Processed__ 
///</summary>
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DLBASE
{
 	public class ButtonClickHelper  {
	
		public static void AddClickEvent(GameObject go,EventTriggerListener.VoidDelegate callBack)
		{
			EventTriggerListener.Get (go).onClick += callBack;
		}

	
	    public static void AddPointEnter(GameObject go, EventTriggerListener.VoidDelegate callBack)
	    {
	        EventTriggerListener.Get(go).onEnter += callBack;
	    }

        public static void AddPointDown(GameObject go, EventTriggerListener.VoidDelegate callBack)
        {
            EventTriggerListener.Get(go).onDown += callBack;
        }

        public static void AddPointUp(GameObject go, EventTriggerListener.VoidDelegate callBack)
        {
            EventTriggerListener.Get(go).onUp += callBack;
        }

        public static void RemoveClickEvent(GameObject go, EventTriggerListener.VoidDelegate callBack)
        {
            EventTriggerListener.Get(go).onClick -= callBack;
        }

    }
	
}