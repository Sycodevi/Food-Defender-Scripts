
using UnityEngine;

public class Objective : MonoBehaviour
{
    public UIHandler uiHandler;

    public int currentHealth;
    public int TotalHealth = 100;

    private void Start()
    {
        currentHealth = TotalHealth;
    }
    public void DealDamage(int damage)
    {
        currentHealth -= damage;
        uiHandler.UpdateHealth();
    }
}
