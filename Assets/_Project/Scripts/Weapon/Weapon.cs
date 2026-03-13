using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private WeaponInfo _weaponInfo;
    [SerializeField] private Camera _camera;
    private float _nextTimeToShoot;

    private void Shoot()
    {
        Ray ray = _camera.ViewportPointToRay(new Vector3(0.5f,0.5f,0));
        RaycastHit hit;
        //Debug.DrawLine(ray.origin, ray.direction*_weaponInfo._range,Color.red);
        if(Physics.Raycast(ray, out hit, _weaponInfo._range))
        {
            //Enemy enemy = hit.collider.GetComponent<Enemy>():
            //if (enemy != null)
            //{
            //  funzione di take damage
            //}
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
