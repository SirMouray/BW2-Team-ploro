using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ShopItems
{
    public PowerUpSO PowerUp;
    public int price;
}

public class ShopManager : MonoBehaviour
{
    [SerializeField] private List<ShopItems> shopItems;
    [SerializeField] private ShopSlot[] shopSlot;
    [SerializeField] private PlayerInventory inventory;
    [SerializeField] private GameObject player;

    private void Awake()
    {
        if (inventory == null)
            inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>();

        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Start()
    {
        PopulateShop();
    }

    public void TryBuyItem(PowerUpSO item, int price)
    {
        if (SaveManager.Instance == null)
            return;

        if (inventory == null || item == null)
            return;

        if (!item.CanBuy())
            return;

        if (inventory.GetCoin() >= price)
        {
            inventory.SetCoin(price);

            if (player != null)
            {
                item.OnUse(player);
                SaveData(item);
                SaveManager.Instance.SaveFile();
            }

            SaveManager.Instance.data.Coins = inventory.GetCoin();
            SaveManager.Instance.SaveFile();

        }
    }

    private void PopulateShop()
    {
        for (int i = 0; i < shopItems.Count; i++)
        {
            ShopItems item = shopItems[i];
            shopSlot[i].Initialize(item.PowerUp, item.price);
            shopSlot[i].RefreshButton();
        }
    }

    private void SaveData(PowerUpSO item)
    {
        if (SaveManager.Instance == null)
            return;

        if (item is HealthPowerUp)
            SaveManager.Instance.data.HealthUp_count++;

        else if (item is ShieldPowerUp)
            SaveManager.Instance.data.Shield_count++;

        else if (item is SpeedPowerUp)
            SaveManager.Instance.data.SpeedBoost_count++;

        else if (item is DoubleJumpPowerUp)
            SaveManager.Instance.data.EnableDoubleJump_purchased = true;

        else if (item is DoubleCoinPowerUp)
            SaveManager.Instance.data.DoubleCoin_purchased = true;
    }
}