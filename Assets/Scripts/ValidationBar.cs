using UnityEngine;
using UnityEngine.UI;

public class ValidationBar : MonoBehaviour
{
    public Image validationBar;
    public RectTransform uiElementBorder;
    public RectTransform uiElementBackground;
    public RectTransform uiElementFill;

    void Start()
    {
        UpdateValidationBar(0);
    }

    public void UpdateValidationBar(float fraction)
    {
        validationBar.fillAmount = fraction;
    }

    public void GrowBy10Percent()
    {
        if (uiElementBorder == null) return;
        if (uiElementBackground == null) return;
        if (uiElementFill == null) return;
        // Get the current width
        float currentWidthBorder = uiElementBorder.sizeDelta.x;
        float currentWidthBG = uiElementBackground.sizeDelta.x;
        float currentWidthFill = uiElementFill.sizeDelta.x; 
        // Grow width by 10%
        float newWidthBorder = currentWidthBorder * 1.1f;
        float newWidthBG = currentWidthBG * 1.1f;
        float newWidthFill = currentWidthFill * 1.1f;
        // Apply the new width
        uiElementBorder.sizeDelta = new Vector2(newWidthBorder, uiElementBackground.sizeDelta.y);
        uiElementBackground.sizeDelta = new Vector2(newWidthBG, uiElementBackground.sizeDelta.y);
        uiElementFill.sizeDelta = new Vector2(newWidthFill, uiElementBackground.sizeDelta.y);

    }
}
