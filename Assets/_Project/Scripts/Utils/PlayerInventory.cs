using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private int _coins;
    private bool doubleCoin = false;

    public int GetCoin() => _coins;
    public void SetDoubleCoin(bool value) => doubleCoin = value;

    public void AddCoin(int coin)
    {
        if (doubleCoin)
            _coins += coin + coin;
        else
            _coins += coin;
    }
}