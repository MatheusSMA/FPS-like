using UnityEngine;

public class Pistol : GunBase
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletSpeed;

    protected override void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.transform.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(firePoint.forward * bulletSpeed, ForceMode.Impulse);
    }


}