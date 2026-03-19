using UnityEngine;

[CreateAssetMenu(menuName = "PowerUp/Speed")]
public class SpeedPowerUp : PowerUpSO
{
    public float multiplier = 1.2f;

    public override void OnUse(GameObject player)
    {
        var controller = player.GetComponent<PlayerController>();
        controller.SetSpeedMultiplier(multiplier);
    }
}
