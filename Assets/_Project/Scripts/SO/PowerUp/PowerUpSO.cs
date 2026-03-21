using UnityEngine;

[CreateAssetMenu(fileName = "NewPowerUp")]
public class PowerUpSO : ScriptableObject
{
    [Header("Infos")]
    [SerializeField] public Sprite icon;
    [SerializeField] public int maxPurchases = 3;

    public virtual void OnUse(GameObject player)
    {

    }

    public bool CanBuy()
    {
        if (SaveManager.Instance.data == null)
            return false;

        if (this is HealthPowerUp)
            return SaveManager.Instance.data.HealthUp_count < maxPurchases;

        if (this is ShieldPowerUp)
            return SaveManager.Instance.data.Shield_count < maxPurchases;

        if (this is SpeedPowerUp)
            return SaveManager.Instance.data.SpeedBoost_count < maxPurchases;

        if (this is DoubleJumpPowerUp)
            return !SaveManager.Instance.data.EnableDoubleJump_purchased;

        if (this is DoubleCoinPowerUp)
            return !SaveManager.Instance.data.DoubleCoin_purchased;

        return true;
    }
}
