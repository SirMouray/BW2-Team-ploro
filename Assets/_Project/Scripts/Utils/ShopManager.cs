using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private PlayerInventory playerCoin;
    [SerializeField] private int price = 5;
    [SerializeField] private int maxBuy = 3;
    private int currentBuy = 0;

    private void Awake()
    {
        if (playerCoin == null)
            playerCoin = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>();
    }

    public void IncreaseCurrentBuy() => currentBuy++;

    public bool CanBuy()
    {
        if (playerCoin == null)
            return false;

        if (currentBuy >= maxBuy)
            return false;

        return playerCoin.GetCoin() > price;
    }
}