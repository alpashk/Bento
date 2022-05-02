using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragTarget : MonoBehaviour
{
    #region Fields

    [SerializeField] private Shape targetShape;
    [SerializeField] private Taste targetTaste;

    [SerializeField] private FoodPiece receivedPiece = null;

    #endregion


    
    #region Properties

    public FoodPiece ReceivedPiece
    {
        get => receivedPiece;
        set => receivedPiece = value;
    }

    public Shape TargetShape => targetShape;

    public Taste TargetTaste => targetTaste;

    #endregion

    
    
    #region Methods
    
    public void Initialize(DragTargetData dragTargetData)
    {
        this.targetShape = dragTargetData.TargetShape;
        this.targetTaste = dragTargetData.TargetTaste;
    }

    
    public bool CheckValidity()
    {
        if (receivedPiece == null)
        {
            return false;
        }

        if (targetShape == receivedPiece.Shape && targetTaste == receivedPiece.Taste)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    #endregion
}
