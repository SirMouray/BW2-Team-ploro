using UnityEngine;
using UnityEngine.Events;

public class HealthSystem : MonoBehaviour, IDamageable
{
    [Header("HP Settings")]
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int minHealth = 0;
    [SerializeField] private bool fullHpOnStart = false;
    private int currentHealth;
    private bool isDead = false;
    private bool isShielded = false;

    [Header("Event Settings")]
    [SerializeField] private UnityEvent<int, int> onHpChange;
    [SerializeField] private UnityEvent onDeath;

    private void Awake()
    {
        if (fullHpOnStart)
            SetHp(maxHealth);
    }

    public void SetShieldStatus(bool status) => isShielded = status;

    public int GetMaxHp() => maxHealth;

    public void AddMaxHp(int hp) => maxHealth += hp;

    private void SetHp(int hp)
    {
        currentHealth = Mathf.Clamp(hp, minHealth, maxHealth);
        onHpChange?.Invoke(currentHealth, maxHealth);

        Debug.Log($"{gameObject.name} ha {currentHealth} hp");
    }

    public void TakeDamage(int damage)
    {
        if (isDead)
            return;

        if (isShielded)
        {
            isShielded = false;
            return;
        }

        SetHp(currentHealth - damage);

        if (currentHealth <= minHealth)
        {
            isDead = true;
            onDeath?.Invoke();
            if (this.GetComponent<EnemyController>())
                this.GetComponent<EnemyController>().Deactive();
        }
    }

    public void ResetHealth()
    {
        isDead = false;
        SetHp(maxHealth);
    }
}