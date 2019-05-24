using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GunWeapon : MonoBehaviour {

    [SerializeField]
    protected Weapon weaponProperties;

    [SerializeField]
    protected GameObject weaponCamera;

    [SerializeField]
    protected Camera mainCamera;

    [SerializeField]
    protected ParticleSystem muzzleFlash;



    protected int layerMask = 1;

    protected AudioSource gunSoundSource;

    protected virtual void Shoot()
    {
        PlayGunshotMedia();
        RaycastHit hitInfo;
        if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hitInfo, weaponProperties.range, layerMask))
        {
            HitTarget(hitInfo);
        }
    }

    protected abstract void AlternateShoot(bool isAltFire);
    public abstract void OnWeaponSwitch();

    private void Start()
    {
        gunSoundSource = GetComponent<AudioSource>();
        int layerMask = 1 << 8;
        layerMask = ~layerMask;
    }

    private void PlayGunshotMedia()
    {
        muzzleFlash.Play();
        gunSoundSource.PlayOneShot(weaponProperties.primaryFireSound);
    }


    private void HitTarget(RaycastHit hitInfo)
    {
        BaseDestructible target = hitInfo.transform.GetComponent<BaseDestructible>();
        if (target)
        {
            target.OnGettingHit(weaponProperties.damageType);
        }
    }

    public void RequestShoot()
    {
        Shoot();
    }

    public void RequestAlternateShoot(bool isAltFire)
    {
        AlternateShoot(isAltFire);
    }

        
}
