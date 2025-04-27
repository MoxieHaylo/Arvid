using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class NPCInteractable : MonoBehaviour, IInteractable
{
    public UnityEvent firstTalkEN;
    public UnityEvent giveQuestEN;
    public UnityEvent firstTalkNO;
    public UnityEvent giveQuestNO;
    public UnityEvent thanksEN;

    [SerializeField] public TextBubble textBubble;


    public bool hasSpoken = false;
    public bool hasQuests = false;

    private GameSettings gameSettings;
    private QuestManager questManager;
    private PlayerController playerController;

    void Start()
    {
        gameSettings = FindFirstObjectByType<GameSettings>();
        if (gameSettings == null)
        {
            Debug.LogError("GameSettings not found in the scene!");
        }
        questManager = FindFirstObjectByType<QuestManager>();
        if (gameSettings == null)
        {
            Debug.LogError("Quest manager not found in the scene!");
        }
        playerController = FindFirstObjectByType<PlayerController>();
        if (playerController == null)
        {
            Debug.LogError("Pop in a player dummy!");
        }

    }

    public void Interact(Transform interactorTransform)
    {
        if (hasSpoken && !textBubble.isTalking && (CompareTag("Torch NPC")) && questManager.torchComplete)//super specific
        {
            //hasQuests = false;
            Debug.Log("Torches done...for now");
            //thanksEN.Invoke();
            StartCoroutine(ThankPlayer());

        }
        if (hasSpoken && !textBubble.isTalking && (CompareTag("Tutorial NPC")) && questManager.tutorialComplete)//super specific
        {
            //hasQuests = false;
            Debug.Log("Tutorial doneski");
            StartCoroutine(ThankPlayer());
        }

        if (!hasSpoken && !textBubble.isTalking)
        {
            if (gameSettings.isEnglish)
            {
                firstTalkEN.Invoke();
            }
            if (gameSettings.isNorwegian)
            {
                firstTalkNO.Invoke();
            }

            StartCoroutine(FirstTalk());
        }
        if (hasSpoken && !textBubble.isTalking && !hasQuests)
        {
            //Debug.Log("gibbin ze questos");
            //hasQuests = true;
            //if (gameSettings.isEnglish)
            //{
            //    giveQuestEN.Invoke();

            //}
            //if (gameSettings.isNorwegian)
            //{
            //    giveQuestNO.Invoke();
            //}
            StartCoroutine(QuestTalk());
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

    IEnumerator QuestTalk()
    {
        Debug.Log("gibbin ze questos");

        if (gameSettings.isEnglish)
        {
            giveQuestEN.Invoke();

        }
        if (gameSettings.isNorwegian)
        {
            giveQuestNO.Invoke();
        }
        hasQuests = true;
        yield break;
    }
    IEnumerator ThankPlayer()
    {
        thanksEN.Invoke();
        playerController.currentFlightStamina=playerController.maxFlightStamina;
        yield return new WaitForSeconds(5);//cooldown so we don't end up in a quest loop
        hasQuests = false;
        yield break;
    }
}
