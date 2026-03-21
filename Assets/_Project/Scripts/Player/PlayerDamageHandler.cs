using System.Collections;
using UnityEngine;

public class PlayerDamageHandler : MonoBehaviour
{
    [SerializeField] private GameObject gameoverUI;
    [SerializeField] private HealthSystem healthSystem;

    private void Awake()
    {
        if (healthSystem == null)
            healthSystem = GetComponent<HealthSystem>();
    }

    public void HandleDamage()
    {
        if (AudioManager.Instance != null)
            AudioManager.Instance.PlaySFXSound("PlayerDamaged");
    }

    public void HandleDeath()
    {
        if (AudioManager.Instance != null)
            AudioManager.Instance.PlaySFXSound("PlayerDeath");
        DisablePlayer();

        if (SaveManager.Instance != null)
            SaveManager.Instance.SaveFile();

        StartCoroutine(DeathSequence());
    }

    public void OnRespawnButton()
    {
        if (gameoverUI != null)
            gameoverUI.SetActive(false);

        Time.timeScale = 1.0f;

        if (healthSystem != null)
            healthSystem.ResetHealth();

        EnablePlayer();
    }

    public void OnExitButton()
    {
        //return al main
    }

    private IEnumerator DeathSequence()
    {
        yield return new WaitForSeconds(5f);
        ShowGameoverUI();
    }

    private void ShowGameoverUI()
    {
        if (gameoverUI != null)
            gameoverUI.SetActive(true);

        Time.timeScale = 0f;
    }

    private void DisablePlayer()
    {
        GetComponent<PlayerController>().enabled = false;
        GetComponent<Collider>().enabled = false;
    }

    private void EnablePlayer()
    {
        GetComponent<PlayerController>().enabled = true;
        GetComponent<Collider>().enabled = true;
    }
}