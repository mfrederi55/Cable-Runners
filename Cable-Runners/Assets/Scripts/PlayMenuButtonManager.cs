using UnityEngine;

public class PlayMenuButtonManager : MonoBehaviour {
    [SerializeField] private MainMenuManager.PlayMenuButtons _ButtonType;
    public void ButtonClicked() {
        MainMenuManager._.PlayMenuButtonClicked(_ButtonType);
    }
}
