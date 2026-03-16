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
            inventory = GetComponent<PlayerInventory>();
    }

    private void OnEnable()
    {
        if (healthSystem != null)
            healthSystem.ResetHealth();

        GetComponent<Collider>().enabled = true;
    }

    public void HandleDamage()
    {
        //audio
        //animazione
    }

    public void HandleDeath()
    {
        inventory.AddCoin(coinValue);
        //animazione
        GetComponent<Collider>().enabled = false;
        gameObject.SetActive(false);
    }
}
