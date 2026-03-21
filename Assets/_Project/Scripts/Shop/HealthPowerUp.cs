using UnityEngine;

[CreateAssetMenu(menuName = "PowerUp/Health")]
public class HealthPowerUp : PowerUpSO
{
    public int hpBoost = 10;

    public override void OnUse(GameObject player)
    {
        var health = player.GetComponent<HealthSystem>();
        health.AddMaxHp(hpBoost);
    }
}
