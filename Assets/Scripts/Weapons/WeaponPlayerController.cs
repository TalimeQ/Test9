using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPlayerController : MonoBehaviour
{
    [SerializeField]
    private WeaponController weaponController;

    private void Update()
    {
        CheckForFireInput();
        CheckForAlternateFireInput();
        CheckForWeaponSwapInput();
        if (Input.GetKeyDown(KeyCode.Escape)) Application.Quit();
    }

    private void CheckForFireInput()
    {
        if (Input.GetButtonDown("Fire1")) weaponController.RequestShoot();
    }

    private void CheckForAlternateFireInput()
    {
        if (Input.GetButtonDown("AltFire")) weaponController.RequestAltShoot(true);
        
        if (Input.GetButtonUp("AltFire")) weaponController.RequestAltShoot(false);
    }

    private void CheckForWeaponSwapInput()
    {
        if (Input.GetButtonDown("SwapWeapon"))
        {
            weaponController.RequestWeaponSwap();
        }
    }
}
