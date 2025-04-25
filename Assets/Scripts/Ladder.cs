using UnityEngine;

public class Ladder : MonoBehaviour, IInteractable
{
    public void Interact(Transform interactorTransform)
    {
        PushLadder();
    }

    void PushLadder()
    {
        Debug.Log("pushed ladder");
    }
}
