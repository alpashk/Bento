using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class FoodPiece : BaseDraggable
{
    #region Fields

    [SerializeField] private Shape shape;
    [SerializeField] private Taste taste;

    private Vector3 startPosition;

    private Action<FoodPiece> onDragBegin;
    private Action<FoodPiece> onDragEnd;

    #endregion

    

    #region Properties

    public Shape Shape => shape;

    public Taste Taste => taste;

    #endregion

    
    
    #region Unity lifecycle

    private void Start()
    {
        startPosition = transform.position;
    }

    #endregion


    
    #region Methods

    public void Initialize(Action<FoodPiece> onDragBegin, Action<FoodPiece> onDragEnd)
    {
        this.onDragBegin = onDragBegin;
        this.onDragEnd = onDragEnd;
    }

    public void ResetPosition()
    {
        transform.position = startPosition;
    }
    
    
    public void SetPosition(Vector3 targetPosition)
    {
        transform.position = targetPosition;
    }
    

    public void Enable(bool value)
    {
        gameObject.SetActive(value);
    }

    #endregion


    
    #region IDragHandler

    public override void OnBeginDrag(PointerEventData eventData)
    {
        base.OnBeginDrag(eventData);
        onDragBegin?.Invoke(this);
    }

    public override void OnEndDrag(PointerEventData eventData)
    {
        base.OnEndDrag(eventData);
        onDragEnd?.Invoke(this);
    }

    #endregion
}
