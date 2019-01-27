using System.Collections;
using UnityEngine;

public class UpgradeType1 : UpgradeInterface
{

	public UpgradeType1()
    {
        this.upgradeWeaponInterface = new WeaponType1();
    }
}
