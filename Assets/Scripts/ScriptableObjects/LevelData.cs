using System;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "LevelData", menuName = "ScriptableObject/LevelData")]
public class LevelData : ScriptableObject
{
    [SerializeField] private Shape shapeToExclude;
    [SerializeField] private List<DragTargetData> targetData;
    
    
    public List<DragTargetData> TargetData => targetData;

    public Shape ShapeToExclude => shapeToExclude;
}


[Serializable]
public class DragTargetData
{
    [SerializeField] private Shape targetShape;
    [SerializeField] private Taste targetTaste;
    
    public Shape TargetShape => targetShape;

    public Taste TargetTaste => targetTaste;
}
