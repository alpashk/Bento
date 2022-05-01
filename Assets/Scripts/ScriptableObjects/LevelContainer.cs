using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelContainer", menuName = "ScriptableObject/LevelContainer")]
public class LevelContainer : ScriptableSingleton<LevelContainer>
{
    [SerializeField] private List<int> levelList;


    public List<int> LevelList => levelList;
}
