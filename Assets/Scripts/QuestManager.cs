using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public Torch[] torches;

    public bool torchComplete = false;
    public bool tutorialComplete = false;

    private Ladder ladder;

    private void Start()
    {
        ladder = FindFirstObjectByType<Ladder>();

        if (ladder == null)
        {
            Debug.LogError("Ladder not found in the scene!");
        }
    }

    void Update()
    {
        // Always check torches every frame
        torchComplete = AllTorchesLit();

        if (torchComplete)
        {
            Debug.Log("All torches are lit!");
        }

        if (ladder != null && ladder.hasMoved)
        {
            tutorialComplete = true;
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
