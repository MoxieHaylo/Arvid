using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Torch : MonoBehaviour, IInteractable
{
    public bool isLit = false;

    public Canvas torchCanvas;
    public Image staminaBar; // ← assign in Inspector!

    private void Start()
    {
        torchCanvas.gameObject.SetActive(false);
    }

    public void Interact(Transform interactorTransform)
    {
        if (!isLit)
        {
            LightTorch();
        }
    }

    void LightTorch()
    {
        isLit = true;
        Debug.Log("Torch lit");

        if (torchCanvas != null && staminaBar != null)
        {
            torchCanvas.gameObject.SetActive(true);
            staminaBar.fillAmount = 1f; // Full at start
        }

        StartCoroutine(SmoothTorchDecay());
    }

    IEnumerator SmoothTorchDecay()
    {
        float totalTime = 5f;
        float elapsedTime = 0f;

        while (elapsedTime < totalTime)
        {
            elapsedTime += Time.deltaTime;
            if (staminaBar != null)
            {
                staminaBar.fillAmount = Mathf.Lerp(1f, 0f, elapsedTime / totalTime);
            }
            yield return null;
        }

        if (torchCanvas != null)
        {
            torchCanvas.gameObject.SetActive(false);
        }
        Debug.Log("Torch went out");
        isLit = false;
    }
}
