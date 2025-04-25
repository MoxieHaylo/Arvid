using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] public GameObject creditsPanelEN;
    [SerializeField] public GameObject creditsPanelNO;
    [SerializeField] private GameSettings gameSettings;

    private void Awake()
    {
        settingsPanel.SetActive(false);
        creditsPanelEN.SetActive(false);
        creditsPanelNO.SetActive(false);
    }
    public void Play()
    {
        SceneManager.LoadScene("Game");
    }

    public void EndGame()
    {
        Application.Quit();
    }

    public void Settings()
    {
        settingsPanel.SetActive(true);
        creditsPanelEN.SetActive(false);
        creditsPanelNO.SetActive(false);
    }
    public void Credits()
    {
        settingsPanel.SetActive(false);
        if(gameSettings.isEnglish)
        {
            creditsPanelEN.SetActive(true);
            creditsPanelNO.SetActive(false);
        }
        if (gameSettings.isNorwegian)
        {
            creditsPanelNO.SetActive(true);
            creditsPanelEN.SetActive(false);
        }
    }

}
