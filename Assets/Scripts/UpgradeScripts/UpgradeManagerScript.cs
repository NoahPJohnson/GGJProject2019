using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManagerScript : MonoBehaviour
{
    int weaponInterfaceCount = 10;
    WeaponInterface[] UpgradeWeaponArray = new WeaponInterface[10];

    // Use this for initialization
    void Start ()
    {
        UpgradeWeaponArray[0] = new WeaponType1(); //Normal Weapon Lv 1
        UpgradeWeaponArray[1] = new WeaponType2(); //Spread Weapon Lv 1
        UpgradeWeaponArray[2] = new WeaponType3(); //Bounce Weapon Lv 1
        UpgradeWeaponArray[3] = new WeaponType4(); //Normal Weapon Lv 2
        UpgradeWeaponArray[4] = new WeaponType5(); //Spread Weapon Lv 2
        UpgradeWeaponArray[5] = new WeaponType6(); //Bounce Weapon Lv 2
        UpgradeWeaponArray[6] = new WeaponType7(); //Normal + Spread Weapon
        UpgradeWeaponArray[7] = new WeaponType8(); //Spread + Bounce Weapon
        UpgradeWeaponArray[8] = new WeaponType9(); //Bounce + Normal Weapon
        UpgradeWeaponArray[9] = new WeaponType10(); //Normal + Spread + Bounce Weapon
    }

    public WeaponInterface GetUpgradeAt(int receivedIndex)
    {
        return UpgradeWeaponArray[receivedIndex];
    }

    public WeaponInterface CalculateUpgrade(WeaponInterface playerTempWeaponInterface, int upgradeWeaponIndex)
    {
        bool playerHasUpgrade = false;
        WeaponInterface upgradeToReturn = UpgradeWeaponArray[0];
        for (int i  = 0; i < weaponInterfaceCount; i++)
        {
            if (playerTempWeaponInterface == UpgradeWeaponArray[i])
            {
                playerHasUpgrade = true;
                if (playerTempWeaponInterface == UpgradeWeaponArray[upgradeWeaponIndex])
                {
                    Debug.Log("Matching upgrades. Result is Weapon type: " + (i + 4));
                    upgradeToReturn = UpgradeWeaponArray[i + 3];
                }
                else if ((i == 0 && upgradeWeaponIndex == 1) || (i == 1 && upgradeWeaponIndex == 0))
                {
                    Debug.Log("Normal and Spread. Result is Weapon type: 7");
                    upgradeToReturn = UpgradeWeaponArray[6];
                }
                else if ((i == 0 && upgradeWeaponIndex == 2) || (i == 2 && upgradeWeaponIndex == 0))
                {
                    Debug.Log("Normal and Bounce. Result is Weapon type: 9");
                    upgradeToReturn = UpgradeWeaponArray[8];
                }
                else if ((i == 1 && upgradeWeaponIndex == 2) || (i == 2 && upgradeWeaponIndex == 1))
                {
                    Debug.Log("Spread and Bounce. Result is Weapon type: 8");
                    upgradeToReturn = UpgradeWeaponArray[7];
                }
                else if (i > 5 && i < 9)
                {
                    Debug.Log("Normal and Spread and Bounce. Result is Weapon type 10");
                    upgradeToReturn = UpgradeWeaponArray[9];
                }
            }
        }
        if (playerHasUpgrade == false)
        {
            Debug.Log("Player's FIRST Upgrade");
            upgradeToReturn = UpgradeWeaponArray[upgradeWeaponIndex];
        }
        return upgradeToReturn;
    }
}
