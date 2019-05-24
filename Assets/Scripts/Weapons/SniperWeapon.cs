using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperWeapon : GunWeapon {

    [SerializeField]
    private Animator gunHolder;

    [SerializeField]
    private GameObject scopeOverlay;

    [SerializeField]
    private float scopeDelay = 0.15f;

    [SerializeField]
    private float minFov = 15.0f;

    [SerializeField]
    private float maxFov = 60.0f;

    private bool isScoped = false;



    protected override void AlternateShoot(bool isAltFire)
    {
        gunSoundSource.PlayOneShot(weaponProperties.alternativeFireSound);
        isScoped = isAltFire;
        PlayScopeAnimation();
    
        if (isScoped) StartCoroutine(OnScoped());
        else StartCoroutine(OnUnscoped());
    }

    private void PlayScopeAnimation()
    {
        gunHolder.SetBool("IsScoped", isScoped);
    }

    IEnumerator OnScoped()
    {
        yield return new WaitForSeconds(scopeDelay);
        scopeOverlay.SetActive(true);
        weaponCamera.SetActive(false);
        mainCamera.fieldOfView = minFov;
    }

    IEnumerator OnUnscoped()
    {
        weaponCamera.SetActive(true);
        scopeOverlay.SetActive(false);
        mainCamera.fieldOfView = maxFov;
        yield return new WaitForSeconds(scopeDelay);
      
    }

    public override void OnWeaponSwitch()
    {
        StartCoroutine(OnUnscoped());
        gunHolder.SetBool("IsScoped", false);
    }
}
