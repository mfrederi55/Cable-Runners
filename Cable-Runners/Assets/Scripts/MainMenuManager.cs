using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public static MainMenuManager _;
    
    [SerializeField] private bool _debugMode;

    public enum MainMenuButtons { play, options, quit };
    public enum OptionsMenuButtons { back };

    [SerializeField] private string _sceneAfterPlayButton;
    [SerializeField] private GameObject _optionsMenuContainer;
    [SerializeField] private GameObject _mainMenuContainer;

    public void Awake()
    {
        if (_ == null) { _ = this; } else { Debug.LogError("There are more than 1 MainMenuManager's in the scene"); }
    }

    public void Start()
    {
        OpenMenu(_mainMenuContainer);
    }
    public void MainMenuButtonClicked(MainMenuButtons buttonClicked)
    {
        DebugMessage("button clicked " + buttonClicked.ToString());
        switch (buttonClicked)
        {
            case MainMenuButtons.play:
                PlayClicked();
                break; 
            case MainMenuButtons.options:
                OpenMenu(_optionsMenuContainer);
                break;
            case MainMenuButtons.quit:
                QuitGame();
                break;
            default:
                Debug.Log("button clicked that was not implemented in MainMenuManager method");
                break;
        }
    }

    private void DebugMessage(string message)
    {
        if (_debugMode) { Debug.Log(message); }
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif
    }

    public void PlayClicked()
    {
        SceneManager.LoadScene(_sceneAfterPlayButton);
    }

    public void OptionsMenuButtonClicked(OptionsMenuButtons buttonClicked)
    {
        DebugMessage("button clicked " + buttonClicked.ToString());
        switch (buttonClicked)
        {
            case OptionsMenuButtons.back:
                OpenMenu(_mainMenuContainer);
                break;
        }
    }


    public void OpenMenu(GameObject menuToOpen)
    {
        _mainMenuContainer.SetActive(menuToOpen == _mainMenuContainer);
        _optionsMenuContainer.SetActive(menuToOpen == _optionsMenuContainer);
    }
}
