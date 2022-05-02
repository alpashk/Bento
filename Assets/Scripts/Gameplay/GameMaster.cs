using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    #region Fields

    [SerializeField] private List<FoodPiece> foodPieces;

    [SerializeField] private List<DragTarget> dragTargets;

    [SerializeField] private GameplayUi gameplayUi;
    [SerializeField] private WinScreenUi winUi;

    [SerializeField] private float snapRange;

    private GameData gameData;
    private float snapRangeSqr;

    #endregion


    
    #region Unity lifecycle

    private void Awake()
    {
        gameData = GameData.Instance;
        int currentLevel = gameData.CurrentLevel;

        snapRangeSqr = snapRange * snapRange;
        
        LevelContainer levelContainer = LevelContainer.instance;
        LevelData level = levelContainer.GetElementAt(currentLevel);

        bool isNextLevelAvailable = levelContainer.LevelCount > currentLevel + 1;
        
        winUi.Initialize(isNextLevelAvailable);
        
        gameplayUi.Initialize(GameplayUi_OnHintClick);

        Shape shapeToExclude = level.ShapeToExclude;
        
        DisableShapes(shapeToExclude);
        
        CreateLevel(level.TargetData);
    }

    #endregion



    #region Methods

    private void DisableShapes(Shape shapeToDisable)
    {
        foreach (FoodPiece foodPiece in foodPieces)
        {
            foodPiece.Initialize(FoodPiece_OnBeginDrag, FoodPiece_OnEndDrag);
            if (foodPiece.Shape == shapeToDisable)
            {
                foodPiece.Enable(false);
            }
        }
    }

    private void CreateLevel(List<DragTargetData> dataList)
    {
        for (int i = 0; i < dragTargets.Count; i++)
        {
            dragTargets[i].Initialize(dataList[i]);
        }
    }


    private void CheckValidity()
    {
        bool isValid = true;
        foreach (DragTarget dragTarget in dragTargets)
        {
            if (!dragTarget.CheckValidity())
            {
                isValid = false;
                break;
            }
        }

        if (!isValid)
        {
            return;
        }
        
        gameData.LevelCompleted();
        winUi.Enable(true);
    }
    

    #endregion


    #region Event handlers

    private void FoodPiece_OnBeginDrag(FoodPiece piece)
    {
        foreach (DragTarget dragTarget in dragTargets)
        {
            if (dragTarget.ReceivedPiece == piece)
            {
                dragTarget.ReceivedPiece = null;
                return;
            }
        }
    }


    private void FoodPiece_OnEndDrag(FoodPiece piece)
    {
        float closestDistanceSqr = float.MaxValue;
        DragTarget closestTarget = null;
        foreach (var dragTarget in dragTargets)
        {
            Vector3 distanceVector = dragTarget.transform.position - piece.transform.position;
            float sqrMagnitude = distanceVector.sqrMagnitude;

            if (sqrMagnitude < closestDistanceSqr && sqrMagnitude <= snapRangeSqr)
            {
                closestDistanceSqr = sqrMagnitude;
                closestTarget = dragTarget;
            }
        }

        if (closestTarget != null && closestTarget.ReceivedPiece == null)
        {
            closestTarget.ReceivedPiece = piece;
            piece.transform.position = closestTarget.transform.position;
            CheckValidity();
        }
        else
        {
            piece.ResetPosition();
        }
    }

    #endregion

    

    #region Event handlers

    //TODO refactor all, move target to piece
    private void GameplayUi_OnHintClick()
    {
        if (gameData.HintAmount <= 0)
        {
            return;
        }
        
        gameData.HintAmount--;

        foreach (DragTarget dragTarget in dragTargets)
        {
            if (dragTarget.ReceivedPiece == null)
            {
                FoodPiece foodPiece = foodPieces.Find(x =>
                    x.Shape == dragTarget.TargetShape && x.Taste == dragTarget.TargetTaste);
                dragTarget.ReceivedPiece = foodPiece;
                foodPiece.transform.position = dragTarget.transform.position;
                CheckValidity();
                return;
            }
        }

        foreach (DragTarget dragTarget in dragTargets)
        {
            if (!dragTarget.CheckValidity())
            {
                dragTarget.ReceivedPiece.ResetPosition();
                
                FoodPiece foodPiece = foodPieces.Find(piece =>
                    piece.Shape == dragTarget.TargetShape && piece.Taste == dragTarget.TargetTaste);
                DragTarget previousPosition = dragTargets.Find(target => target.ReceivedPiece == foodPiece);
                if (previousPosition != null)
                {
                    previousPosition.ReceivedPiece = null;
                }
                dragTarget.ReceivedPiece = foodPiece;
                foodPiece.transform.position = dragTarget.transform.position;
                CheckValidity();
                return;
            }
        }
        
    }
    
    #endregion
}
