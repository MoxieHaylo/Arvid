using UnityEngine;

public class Ladder : MonoBehaviour, IInteractable
{
    public bool hasMoved = false;
    public void Interact(Transform interactorTransform)
    {
        PushLadder();
    }

    void PushLadder()
    {
        Debug.Log("pushed ladder");
        hasMoved = true;
    }
}
