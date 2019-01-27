using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeScript : MonoBehaviour
{
    WeaponInterface[] UpgradeWeaponArray = new WeaponInterface[1];
    
    [SerializeField] int index;

	// Use this for initialization
	void Start ()
    {
        UpgradeWeaponArray[0] = new WeaponType1();
	}
	
    public WeaponInterface GetUpgradeWeapon()
    {
        return UpgradeWeaponArray[index];
    }
}
