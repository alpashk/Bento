using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelContainer", menuName = "ScriptableObject/LevelContainer")]
public class LevelContainer : ScriptableSingleton<LevelContainer>
{
    #region Fileds

    [SerializeField] private List<LevelData> levelList;

    #endregion
    
    
    
    #region Properties

    public int LevelCount => levelList.Count;

    #endregion

    
    
    #region Methods

    public LevelData GetElementAt(int number)
    {
        if (LevelCount < number)
        {
            Debug.LogError("There is no such level");
            return null;
        }
        else
        {
            return levelList[number];
        }
    }

    #endregion
}
