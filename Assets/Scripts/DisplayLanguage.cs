using UnityEngine;
using TMPro;

public class DisplayLanguage : MonoBehaviour
{
    public TextMeshProUGUI language;
    public GameSettings gameSettings;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (language !=null)
        {
            language.text = " ";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(gameSettings.isEnglish)
        {
            language.text = "Hello!";
        }
        if (gameSettings.isNorwegian)
        {
            language.text = "Hej!";
        }
    }
}
