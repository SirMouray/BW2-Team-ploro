using UnityEngine;

[CreateAssetMenu(menuName = "PowerUp/DoubleCoin")]
public class DoubleCoinPowerUp : PowerUpSO
{
    public override void OnUse(GameObject player)
    {
        var inventory = player.GetComponent<PlayerInventory>();
        inventory.SetDoubleCoin(true);
    }
}