using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtons : MonoBehaviour
{
    [SerializeField] [CanBeNull] private string sceneToGo;
    [SerializeField] private GameObject[] panels; // 0 = StartScreen, 1 = SettingsPanel, 2 = CreditsPanel
    [SerializeField] private GameObject[] buttonsGroups; // 0 = StartScreenButtons
    
    public void NewGameButton()
    {
        if (sceneToGo != null) SceneManager.LoadScene(sceneToGo);
    }

    public void ContinueButton()
    {
        // To be added
    }

    public void SettingsButton()
    {
        buttonsGroups[0].SetActive(false);
        panels[1].SetActive(true);
    }
    
    public void CreditsButton()
    {
        buttonsGroups[0].SetActive(false);
        panels[2].SetActive(true);
    }

    public void QuitButton()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

    public void BackButton()
    {
        for (var i = 1; i < panels.Length; i++)
        {
            if (panels[i].activeSelf)
            {
                panels[i].SetActive(false);
                buttonsGroups[0].SetActive(true);
            }
        }
    }
}
