using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtons : MonoBehaviour
{
    [SerializeField] [CanBeNull] private string sceneToGo;
    
    public void NewGameButton()
    {
        if (sceneToGo != null) SceneManager.LoadScene(sceneToGo);
    }

    public void ContinueButton()
    {
        // To be added
    }

    public void OpenAndClosePanel(GameObject targetPanel)
    {
        targetPanel.SetActive(!targetPanel);
    }

    public void QuitButton()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
