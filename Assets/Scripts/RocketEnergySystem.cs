using UnityEngine;
using UnityEngine.UI;

public class RocketEnergySystem : MonoBehaviour
{
    [SerializeField] private Image fuelbar;
    Rocket rocket;

    private float maxFuel;

    private void Awake()
    {
        rocket = GetComponent<Rocket>();
        maxFuel = rocket.Fuel;
    }

    private void Update()
    {
        if (rocket.Fuel < maxFuel)
        {
            rocket.Fuel += 0.1f;
        }
        float amount = rocket.Fuel / maxFuel;
        FuelBarAmount(amount);
    }

    private void FuelBarAmount(float amount)
    {
        fuelbar.fillAmount = amount;
    }
}