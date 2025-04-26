using System.Collections;
using UnityEngine;

public class Torch : MonoBehaviour, IInteractable
{
    void Start()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }
    public bool isLit = false;
    public void Interact(Transform interactorTransform)
    {
        LightTorch();
    }

    void LightTorch()
    {
        isLit=true;
        Debug.Log("Torch lit");
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
        StartCoroutine(TorchDecay());
        //add visuals
        //start timer with progress bar
        //snuff out
        //mark !isLit
        //gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }
    IEnumerator TorchDecay()
    {
        yield return new WaitForSeconds(5);
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        Debug.Log("torch went out");
        isLit = false;
    }
}
