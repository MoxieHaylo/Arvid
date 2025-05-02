using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public Torch[] torches;
    public Chicken[] chickens;

    public bool torchComplete = false;
    public bool tutorialComplete = false;
    public bool fetchComplete = false;

    private Ladder ladder;
    private Chicken chicken;

    [Header("★ Validation ★")]
    public int maxValidation;
    public int currentValidation;
    public ValidationBar validationBar;

    private void Start()
    {
        ladder = FindFirstObjectByType<Ladder>();
        if (ladder == null)
        {
            Debug.LogError("Ladder not found in the scene!");
        }
        chicken = FindFirstObjectByType<Chicken>();
        if (chicken == null)
        {
            Debug.LogError("Chicken not found in scene");
        }
        validationBar = FindFirstObjectByType<ValidationBar>();
    }

    void Update()
    {
        // Always check torches every frame
        torchComplete = AllTorchesLit();
        fetchComplete = AllChickensCaught();

        if (torchComplete)
        {
            Debug.Log("All torches are lit!");
        }
        if (fetchComplete)
        {
            foreach (Chicken chicken in chickens)
            {
                if (!chicken.hasEscaped)
                {
                    chicken.StartCoroutine(chicken.PlotEscape());
                    chicken.hasEscaped = true;
                }
            }
            StartCoroutine(chicken.PlotEscape());
        }

        if (ladder != null && ladder.hasMoved)
        {
            tutorialComplete = true;
        }
        validationBar.UpdateValidationBar((float)currentValidation/(float)maxValidation);
        
        
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

    bool AllChickensCaught()
    {
        foreach (Chicken chicken in chickens)
        {
            if (!chicken.inPen)
            {
                return false;
            }
        }
        return true;
    }
}
