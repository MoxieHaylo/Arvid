using UnityEngine;
using System.Collections;
using TMPro;

public class TextBubble : MonoBehaviour
{
    private SpriteRenderer backgroundSpriteRenderer;
    private TextMeshPro textMeshPro;
    public string[] lines;
    public float textSpeed;

    private int index;

    public bool isTalking= true;

    private void Awake()
    {
        backgroundSpriteRenderer = transform.Find("Background").GetComponent<SpriteRenderer>();
        textMeshPro = transform.Find("Text").GetComponent<TextMeshPro>();
    }

    private void Start()
    {
        textMeshPro.text = string.Empty;
        StartDialogue();
        isTalking = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (textMeshPro.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textMeshPro.text = lines[index];
                UpdateBackgroundSize();
            }
        }   
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        textMeshPro.text = string.Empty;

        foreach (char c in lines[index].ToCharArray())
        {
            textMeshPro.text += c;
            UpdateBackgroundSize();
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
            isTalking = false;
        }
    }

    void UpdateBackgroundSize()
    {
        textMeshPro.ForceMeshUpdate();
        Vector2 textSize = textMeshPro.GetRenderedValues(false);
        Vector2 padding = new Vector2(0.5f, 0.5f);
        backgroundSpriteRenderer.size = textSize + padding;
    }
}
