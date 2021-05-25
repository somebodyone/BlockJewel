///<summary>
///描述: 
///作者: xxx 
///创建时间: 2020/12/21 10:09 
///__Summary__Processed__ 
///</summary>
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


/// <summary>
/// UGUI事件监听。
/// </summary>

namespace DLBASE
{
 	public class EventTriggerListener : EventTrigger {
	
		public delegate void VoidDelegate (GameObject go, PointerEventData pointerEventData=null);
		public VoidDelegate onClick;
		public VoidDelegate onDown;
	    public VoidDelegate onMove;
	    public VoidDelegate onEnter;
		public VoidDelegate onExit;
		public VoidDelegate onUp;
		public VoidDelegate onSelect;
		public VoidDelegate onUpdateSelect;
		public delegate void DragDelegate (GameObject go,PointerEventData eventData);
		public DragDelegate onBeginDrag;
		public DragDelegate onDrag;
		public DragDelegate onDragEnd;
	
		static public EventTriggerListener Get (GameObject go)
		{
			EventTriggerListener listener = go.GetComponent<EventTriggerListener>();
			if (listener == null) listener = go.AddComponent<EventTriggerListener>();
			return listener;
		}
		
		public override void OnPointerClick(PointerEventData eventData)
		{
	        if (onClick != null)
	        {
	            onClick(gameObject);
	        }
		}
	
	    public override void OnMove(AxisEventData eventData)
	    {
	        if (onClick != null) onMove(gameObject);
	    }
	
	    public override void OnPointerDown (PointerEventData eventData){
			if(onDown != null) onDown(gameObject,eventData);
		}
		public override void OnPointerEnter (PointerEventData eventData){
			if(onEnter != null) onEnter(gameObject);
		}
		public override void OnPointerExit (PointerEventData eventData){
			if(onExit != null) onExit(gameObject);
		}
		public override void OnPointerUp (PointerEventData eventData){
			if(onUp != null) onUp(gameObject, eventData);
		}
		public override void OnSelect (BaseEventData eventData){
			if(onSelect != null) onSelect(gameObject);
		}
		public override void OnUpdateSelected (BaseEventData eventData){
			if(onUpdateSelect != null) onUpdateSelect(gameObject);
		
		}
			
		public override void OnBeginDrag (PointerEventData eventData)
		{
	        if (onBeginDrag != null) onBeginDrag(gameObject,eventData);
		}
	
		public override void OnDrag (PointerEventData eventData)
		{
	 
			if(onDrag != null) onDrag(gameObject,eventData);
		}
	
		public override void OnEndDrag (PointerEventData eventData)
		{
	        if (onDragEnd != null) onDragEnd(gameObject,eventData);
		}
	
	
			
	//
	//	public virtual void OnCancel (BaseEventData eventData);
	//
	//	public virtual void OnDeselect (BaseEventData eventData);
	//
	
	//
	//	public virtual void OnDrop (PointerEventData eventData);
	//
	//	public virtual void OnEndDrag (PointerEventData eventData);
	//
	//	public virtual void OnInitializePotentialDrag (PointerEventData eventData);
	//
	//	public virtual void OnMove (AxisEventData eventData);
	
	//	public virtual void OnScroll (PointerEventData eventData);
	
	//	public virtual void OnSubmit (BaseEventData eventData);
	
	
	}
	
}