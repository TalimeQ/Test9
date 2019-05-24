using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {
 
    List<GunWeapon> playerWeapons = new List<GunWeapon>();

    GunWeapon activeWeapon;

    int currentWeaponIndex;
  
    private void Start()
    {
        FillWeaponList();
        SetStartingWeapon();
    }

    private void SetStartingWeapon()
    {
        currentWeaponIndex = 0;
        activeWeapon = playerWeapons[currentWeaponIndex];
    }

    private void FillWeaponList()
    {
        foreach (Transform weapon in this.gameObject.transform)
        {
            GunWeapon addedWeapon = weapon.GetComponent<GunWeapon>();
            if (addedWeapon) playerWeapons.Add(addedWeapon);
        }
    }

    private void SwapWeapon()
    {
        DeactivateOldWeapon();
        MoveToNextIndex();
        ActivateNewWeapon();
    }

    private void ActivateNewWeapon()
    {
        playerWeapons[currentWeaponIndex].gameObject.SetActive(true);
        activeWeapon = playerWeapons[currentWeaponIndex];
    }

    private void MoveToNextIndex()
    {
        if (currentWeaponIndex < playerWeapons.Count - 1) currentWeaponIndex++;
        else currentWeaponIndex = 0;
    }

    private void DeactivateOldWeapon()
    {
        activeWeapon.OnWeaponSwitch();
        activeWeapon.gameObject.SetActive(false);
    }

    public void RequestAltShoot(bool isAltFire)
    {
        activeWeapon.RequestAlternateShoot(isAltFire);
    }

    public void RequestShoot()
    {
        activeWeapon.RequestShoot();
    }

    public void RequestWeaponSwap()
    {
        SwapWeapon();
    }
}
