using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public Torch[] torches;

    void Update()
    {
        if (AllTorchesLit())
        {
            Debug.Log("All torches are lit!");
            // Do your quest step / open door / etc
        }
    }

    bool AllTorchesLit()
    {
        foreach (Torch torch in torches)
        {
            if (!torch.isLit)
            {
                return false;
            }
        }
        return true;
    }
}
