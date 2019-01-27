using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeScript : MonoBehaviour
{
    
    
    [SerializeField] int index;

	// Use this for initialization
	void Start ()
    {
       
	}
	
    public WeaponInterface GetUpgradeWeapon(WeaponInterface playerTWInterface)
    {
        //return transform.parent.GetComponent<UpgradeManagerScript>().GetUpgradeAt(index);
        return transform.parent.GetComponent<UpgradeManagerScript>().CalculateUpgrade(playerTWInterface, index);
    }
}
