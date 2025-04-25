using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class NPCInteractable : MonoBehaviour, IInteractable
{
    public UnityEvent firstTalkEN;
    public UnityEvent giveQuestEN;
    public UnityEvent firstTalkNO;
    public UnityEvent giveQuestNO;

    [SerializeField] public TextBubble textBubble;

    public bool hasSpoken = false;

    private GameSettings gameSettings;
    void Start()
    {
        gameSettings = FindFirstObjectByType<GameSettings>();

        if (gameSettings == null)
        {
            Debug.LogError("GameSettings not found in the scene!");
        }
    }

    public void Interact(Transform interactorTransform)
    {
        if (!hasSpoken&&!textBubble.isTalking)
        {
            if(gameSettings.isEnglish)
            {
                firstTalkEN.Invoke();
            }
            if (gameSettings.isNorwegian)
            {
                firstTalkNO.Invoke();
            }
            
            StartCoroutine(FirstTalk());
        }
        else if(hasSpoken && !textBubble.isTalking)
        {
            if (gameSettings.isEnglish)
            {
                giveQuestEN.Invoke();
            }
            if (gameSettings.isNorwegian)
            {
                giveQuestNO.Invoke();
            }
        }
    }

    IEnumerator FirstTalk()
    {
        while (!textBubble.isTalking)
        {
            yield return null;
        }
        while (textBubble.isTalking)
        {
            yield return null;
        }
        hasSpoken = true;
    }
}
