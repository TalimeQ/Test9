using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SmallWeapon : GunWeapon {

    protected override void AlternateShoot(bool isAltFire)
    {
        // Pistol does not zoom, in this assigment :)
    }

    public override void OnWeaponSwitch()
    {
        // Peestol does not need the weapon switch info at the moment :)
    }

}
