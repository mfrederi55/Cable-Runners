using UnityEngine;

public class OptionsMenuButtonManager : MonoBehaviour
{
    [SerializeField] private MainMenuManager.OptionsMenuButtons _ButtonType;
    public void ButtonClicked()
    {
        MainMenuManager._.OptionsMenuButtonClicked(_ButtonType);
    }
}
