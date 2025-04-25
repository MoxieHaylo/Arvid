using UnityEngine;
using UnityEngine.UI;

public class FlightStaminaBar : MonoBehaviour
{
    public Image flightStamina;

    public void UpdateFlightStamina(float fraction)
    {
        flightStamina.fillAmount = fraction;
    }
}
