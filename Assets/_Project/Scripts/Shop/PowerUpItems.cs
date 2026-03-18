using UnityEngine.UI;
using UnityEngine;

public class PowerUpItems : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private HealthSystem healthSystem;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private PlayerInventory inventory;
    [SerializeField] private ShopManager shopManager;


    [Header("HealthSystem")]
    [SerializeField] private int hpBoost = 10;

    [Header("SpeedBoost")]
    [SerializeField] private float SpeedBoostMultiplier = 1.2f;

    private void Awake()
    {
        if (healthSystem == null)
            healthSystem = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthSystem>();

        if (playerController == null)
            playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        if (inventory == null)
            inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>();

        if (shopManager == null)
            shopManager = GetComponent<ShopManager>();
    }

    public void HealthUp()
    {
        if (healthSystem == null || shopManager == null)
            return;

        healthSystem.AddMaxHp(hpBoost);

        if (SaveManager.Instance != null)
            SaveManager.Instance.data.HealthUp_count++;
    }

    public void Shield()
    {
        if (healthSystem == null || shopManager == null)
            return;

        healthSystem.SetShieldStatus(true);

        if (SaveManager.Instance != null)
            SaveManager.Instance.data.Shield_count++;
    }

    public void EnableDoubleJump()
    {
        if (playerController == null || shopManager == null)
            return;

        playerController.SetDoubleJump(true);

        if (SaveManager.Instance != null)
            SaveManager.Instance.data.EnableDoubleJump_purchased = true;
    }

    public void SpeedBoost()
    {
        if (playerController == null || shopManager == null)
            return;

        playerController.SetSpeedMultiplier(SpeedBoostMultiplier);

        if (SaveManager.Instance != null)
            SaveManager.Instance.data.SpeedBoost_count++;
    }

    public void DoubleCoin()
    {
        if (inventory == null || shopManager == null)
            return;

        inventory.SetDoubleCoin(true);

        if (SaveManager.Instance != null)
            SaveManager.Instance.data.DoubleCoin_purchased = true;
    }
}