using UnityEngine;
using UnityEngine.UI;

public class FlightStaminaBar : MonoBehaviour
{
    public Image flightStamina;

    private void Start()
    {
        UpdateFlightStamina(1f);
    }

    public void UpdateFlightStamina(float fraction)
    {
        flightStamina.fillAmount = fraction;
    }
}
