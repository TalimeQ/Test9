using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EDamageType
{
    SniperRifle,
    Pistol,
    Any
}



public class BaseDestructible : MonoBehaviour {

    [SerializeField]
    EDamageType damagableBy;

    public ITargetListener targetListener;

    private void Start()
    {
        targetListener = FindObjectOfType<GameController>();    
    }

    private void Destroy()
    {
        targetListener.OnTargetDestoyed();
        Destroy(this.gameObject);
    }

    public void OnGettingHit(EDamageType damagingType)
    {
        if (damagableBy == EDamageType.Any) Destroy();
        else if (damagableBy == damagingType) Destroy();
    }
}
