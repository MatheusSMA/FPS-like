using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBase : MonoBehaviour
{
    protected Animator gunAnimator;
    [SerializeField] protected Transform firePoint;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    private void Awake()
    {
        gunAnimator = GetComponentInChildren<Animator>();
    }

    protected virtual void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            gunAnimator.SetTrigger("Firing");
            Shoot();
        }
    }

    protected virtual void Shoot()
    {

    }


}
