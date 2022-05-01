using UnityEngine;

public class BaseUiScreen : MonoBehaviour
{
    #region Methods

    public void Show()
    {
        gameObject.SetActive(true);
    }


    public void Hide()
    {
        gameObject.SetActive(false);
    }

    #endregion
}
