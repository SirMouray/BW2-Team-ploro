using UnityEngine;

[CreateAssetMenu(menuName = "PowerUp/Shield")]
public class ShieldPowerUp : PowerUpSO
{
    public override void OnUse(GameObject player)
    {
        var health = player.GetComponent<HealthSystem>();
        health.SetShieldStatus(true);
    }
}
