using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Helpers
{
    //private static PointerEventData _eventSataCurrentPosition;
    //private static List<RaycastResult> _resultList;

    public static bool IsOverUI() {
        //_eventSataCurrentPosition = new PointerEventData(EventSystem.current) { position = Input.mousePosition };
        //_resultList = new List<RaycastResult>();
        //EventSystem.current.RaycastAll(_eventSataCurrentPosition, _resultList);
        //return _resultList.Count > 0;
       return EventSystem.current.IsPointerOverGameObject();
    }


    
}
