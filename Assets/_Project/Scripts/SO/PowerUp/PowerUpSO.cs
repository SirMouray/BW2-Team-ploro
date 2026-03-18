using UnityEngine;

[CreateAssetMenu(fileName = "NewPowerUp")]
public class PowerUpSO : ScriptableObject
{
    [Header("Infos")]
    [SerializeField] public Sprite icon;
    [SerializeField] public string itemName = "HealthUp";
    [SerializeField] public int maxStack = 3;

    [Header("Boosts")]
    [SerializeField] public int maxHealth;
    [SerializeField] public float speedMultiplier;
    [SerializeField] public bool canDoubleJump;
    [SerializeField] public bool canDoubleCoins;
    [SerializeField] public int shieldPoints;
}
