using UnityEngine;
using UnityEngine.UI;
public class ValidationBar : MonoBehaviour
{
    public Image validationBar;

    void Start()
    {
        UpdateValidationBar(0);
    }
    public void UpdateValidationBar(float fraction)
    {
        validationBar.fillAmount = fraction;
    }
}
