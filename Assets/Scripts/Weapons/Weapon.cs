using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class Weapon : ScriptableObject {

    public float range;
    public AudioClip primaryFireSound;
    public AudioClip alternativeFireSound;
    public EDamageType damageType = EDamageType.Any;

}
