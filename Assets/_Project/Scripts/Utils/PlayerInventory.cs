using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private int _coins;

    public void AddCoin(int coin)
    {
        _coins += coin;
    }
}
