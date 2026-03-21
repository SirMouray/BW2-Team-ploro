using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private HealthSystem healthSystem;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private PlayerInventory playerInventory;

    private void Awake()
    {
        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player");

        if (healthSystem  == null)
            healthSystem = player.GetComponent<HealthSystem>();

        if (playerController == null)
            playerController = player.GetComponent<PlayerController>();

        if (playerInventory == null)
            playerInventory = player.GetComponent<PlayerInventory>();
    }

    private void Start()
    {
        if (SaveManager.Instance.data == null)
            return;

        for (int i = 0; i < SaveManager.Instance.data.HealthUp_count; i++)
            healthSystem.AddMaxHp(10);

        for (int i = 0; i < SaveManager.Instance.data.SpeedBoost_count; i++)
            playerController.SetSpeedMultiplier(1.2f);

        if (SaveManager.Instance.data.EnableDoubleJump_purchased)
            playerController.SetDoubleJump(true);

        if (SaveManager.Instance.data.DoubleCoin_purchased)
            playerInventory.SetDoubleCoin(true);

        if (SaveManager.Instance.data.Shield_count > 0)
            healthSystem.SetShieldStatus(true);
    }

}