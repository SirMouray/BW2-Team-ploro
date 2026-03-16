using UnityEngine;

public class EnemyDamageHandler : MonoBehaviour
{
    [SerializeField] private HealthSystem healthSystem;

    private void Awake()
    {
        if (healthSystem == null)
            healthSystem = GetComponent<HealthSystem>();
    }

    private void OnEnable()
    {
        if (healthSystem != null)
            healthSystem.ResetHealth();

        GetComponent<Collider>().enabled = true;
    }

    public void HandleDamage()
    {
        //audio
        //animazione
    }

    public void HandleDeath()
    {
        //drop coin
        //animazione
        GetComponent<Collider>().enabled = false;
        gameObject.SetActive(false);
    }
}
