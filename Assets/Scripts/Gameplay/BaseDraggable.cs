using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BaseDraggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    #region Methods

    private void SetDraggedPosition(PointerEventData data)
    {
        transform.position = data.position;
    }

    #endregion
    
    #region IDragHandlers

    public virtual void OnBeginDrag(PointerEventData eventData)
    {
        transform.SetAsLastSibling();
    }

    public virtual void OnDrag(PointerEventData eventData)
    {
        SetDraggedPosition(eventData);
    }

    public virtual void OnEndDrag(PointerEventData eventData)
    {
    }

    #endregion
}
