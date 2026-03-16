using UnityEngine.UI;
using UnityEngine;

public class PowerUpItems : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private HealthSystem healthSystem;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private PlayerInventory inventory;
    [SerializeField] private ShopManager shopManager;
    [SerializeField] private Button button;

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

        if (!shopManager.CanBuy())
        {
            button.interactable = false;
            return;
        }

        healthSystem.AddMaxHp(hpBoost);
        shopManager.IncreaseCurrentBuy();
    }

    public void Shield()
    {
        if (healthSystem == null || shopManager == null)
            return;

        if (!shopManager.CanBuy())
        {
            button.interactable = false;
            return;
        }

        healthSystem.SetShieldStatus(true);
        shopManager.IncreaseCurrentBuy();
    }

    public void EnableDoubleJump()
    {
        if (playerController == null || shopManager == null)
            return;

        if (!shopManager.CanBuy())
        {
            button.interactable = false;
            return;
        }

        playerController.SetDoubleJump(true);
        shopManager.IncreaseCurrentBuy();
    }

    public void SpeedBoost()
    {
        if (playerController == null || shopManager == null)
            return;

        if (!shopManager.CanBuy())
        {
            button.interactable = false;
            return;
        }

        playerController.SetSpeedMultiplier(SpeedBoostMultiplier);
        shopManager.IncreaseCurrentBuy();
    }

    public void DoubleCoin()
    {
        if (inventory == null || shopManager == null)
            return;

        if (!shopManager.CanBuy())
        {
            button.interactable = false;
            return;
        }

        inventory.SetDoubleCoin(true);
        shopManager.IncreaseCurrentBuy();
    }
}