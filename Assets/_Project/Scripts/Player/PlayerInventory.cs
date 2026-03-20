using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private int _coins;
    [SerializeField] private UnityEvent<int> coinUpdate;
    private bool doubleCoin = false;

    public int GetCoin() => _coins;
    public void SetCoin(int price)
    {
        _coins -= price;

        if (_coins < 0)
            _coins = Mathf.Max(_coins, 0);

        coinUpdate.Invoke(_coins);
    }
    public void SetDoubleCoin(bool value) => doubleCoin = value;

    public void AddCoin(int coin)
    {
        if (doubleCoin)
            _coins += coin + coin;
        else
            _coins += coin;

        if (SaveManager.Instance != null)
            SaveManager.Instance.data.Coins = _coins;

        coinUpdate.Invoke(_coins);
    }
}