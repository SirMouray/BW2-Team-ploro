using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopSlot : MonoBehaviour
{
    [SerializeField] private PowerUpSO powerUp;
    [SerializeField] private Image itemImage;
    [SerializeField] private TextMeshPro nameText;
    [SerializeField] private TextMeshPro priceText;
    [SerializeField] private ShopManager shopManager;
    [SerializeField] private Button button;
    private int price;

    private void Awake()
    {
        if (shopManager == null)
            shopManager = FindAnyObjectByType<ShopManager>();
    }

    public void Initialize(PowerUpSO item, int price)
    {
        powerUp = item;
        itemImage.sprite = item.icon;
        nameText.SetText(item.name);
        this.price = price;
        priceText.SetText(price.ToString());

        RefreshButton();
    }

    public void OnButtonClick()
    {
        if (shopManager != null)
        {
            shopManager.TryBuyItem(powerUp, price);
            RefreshButton();
        }
    }

    public void RefreshButton()
    {
        if (button != null && !powerUp.CanBuy())
        {
            button.interactable = false;
        }
    }
}
