using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private WeaponInfo _weaponInfo;
    [SerializeField] private Camera _camera;
    [SerializeField] private ParticleSystem[] _impactParticleSystem;
    private float _nextTimeToShoot;

    private void Shoot()
    {
        if (AudioManager.Instance != null)
            AudioManager.Instance.PlaySFXSound("Shoot");

        Ray ray = _camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        Debug.DrawLine(ray.origin, ray.direction * _weaponInfo._range, Color.red);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, _weaponInfo._range))
        {
            Instantiate(_impactParticleSystem[0], hit.point, Quaternion.LookRotation(hit.normal));

            if(hit.collider.TryGetComponent<IDamageable>(out var life))
            {
                life.TakeDamage(_weaponInfo._damage);
                Instantiate(_impactParticleSystem[1], hit.point, Quaternion.LookRotation(hit.normal));
            }
        }
    }

    private bool CanShoot()
    {
        return Time.time > _nextTimeToShoot;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && CanShoot())
        {
            Shoot();
            _nextTimeToShoot = Time.time + _weaponInfo._rateOfFire;
        }
    }
}