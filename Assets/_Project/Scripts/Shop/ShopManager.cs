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

    private void Awake()
    {
        if (inventory == null)
            inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>();
    }

    private void Start()
    {
        PopulateShop();
    }

    public void TryBuyItem(PowerUpSO item, int price)
    {
        if (inventory == null && item == null)
            return;

        if (inventory.GetCoin() >= price)
        {
            inventory.SetCoin(price);

            if (SaveManager.Instance != null)
                SaveManager.Instance.data.Coins = inventory.GetCoin();
        }
    }

    private void PopulateShop()
    {
        for (int i = 0; i < shopItems.Count; i++)
        {
            ShopItems item = shopItems[i];
            shopSlot[i].Initialize(item.PowerUp, item.price);
        }
    }
}