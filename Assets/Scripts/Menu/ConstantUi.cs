using TMPro;
using UnityEngine;

public class ConstantUi : MonoBehaviour
{
    [SerializeField] private TMP_Text hintText;

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }

    private void GameData_OnHintCountChanged(int amount)
    {
        hintText.text = amount.ToString();
    }
}
