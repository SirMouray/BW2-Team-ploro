using UnityEngine;

public class EnemyDamageHandler : MonoBehaviour
{
    [SerializeField] private HealthSystem healthSystem;
    [SerializeField] private PlayerInventory inventory;
    [SerializeField] private int coinValue;

    private void Awake()
    {
        if (healthSystem == null)
            healthSystem = GetComponent<HealthSystem>();

        if (inventory == null)
            inventory = GameObject.FindWithTag("Player").GetComponent<PlayerInventory>();
    }

    private void OnEnable()
    {
        if (healthSystem != null)
            healthSystem.ResetHealth();

        GetComponent<Collider>().enabled = true;
    }

    public void HandleDamage()
    {
        if (AudioManager.Instance != null)
            AudioManager.Instance.PlaySFXSound("BulletImpact");
    }

    public void HandleDeath()
    {
        inventory.AddCoin(coinValue);

        if (AudioManager.Instance != null)
            AudioManager.Instance.PlaySFXSound("EnemyDeath");
    }
}