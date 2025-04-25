using UnityEngine;
using TMPro;
public class GameSettings : MonoBehaviour
{ 
    public static GameSettings Instance { get; private set; }

    [SerializeField] private GameObject enMenu;
    [SerializeField] private GameObject noMenu;

    public bool isEnglish= false;
    public bool isNorwegian= false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Optional
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isEnglish = true;
        enMenu.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetLangENG()
    {
        isEnglish = true;
        isNorwegian = false;
        enMenu.SetActive(true);
        noMenu.SetActive(false);
    }
    public void SetLangNO()
    {
        isEnglish = false;
        isNorwegian = true;
        enMenu.SetActive(false);
        noMenu.SetActive(true);
    }
}
