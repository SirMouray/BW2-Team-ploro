using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private Transform startPoint, endPoint;
    [SerializeField] private float speed = 2f;
    private readonly int damage = 999;

    private void Awake()
    {
        if (startPoint == null || endPoint == null)
            Debug.LogWarning($"Punto di inizio o fine non impostato per {gameObject.name}");

        if (startPoint != null)
            transform.position = startPoint.position;
    }

    private void Update()
    {
        LaserMover();
    }

    private void LaserMover()
    {
        if (startPoint == null || endPoint == null)
            return;

        if (transform.position != endPoint.position)
            transform.position = Vector3.MoveTowards(transform.position, endPoint.position, speed * Time.deltaTime);

        Vector3 direction = (endPoint.position - transform.position).normalized;
        if (direction != Vector3.zero)
            transform.rotation = Quaternion.LookRotation(direction);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<HealthSystem>(out var life))
        {
            life.TakeDamage(damage);
        }
    }
}