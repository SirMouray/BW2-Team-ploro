using UnityEngine;

[CreateAssetMenu(menuName = "PowerUp/DoubleJump")]
public class DoubleJumpPowerUp : PowerUpSO
{
    public override void OnUse(GameObject player)
    {
        var controller = player.GetComponent<PlayerController>();
        controller.SetDoubleJump(true);
    }
}
