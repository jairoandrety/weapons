using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private GameObject pointWeapon;
    [SerializeField] private Weapon weaponSelected;

    public void ChangeWeapon(Weapon weapon)
    {
        if(weaponSelected!= null)
        weaponSelected.Drop();

        weaponSelected = weapon;
        weaponSelected.transform.SetParent(pointWeapon.transform);

        weaponSelected.transform.localPosition = Vector3.zero;
        weaponSelected.transform.localRotation = Quaternion.Euler(Vector3.zero);

        weaponSelected.GetComponent<Collider>().enabled = false;
    }

    public void Shoot()
    {
        if (weaponSelected == null)
            return;

        weaponSelected.Shoot();
    }
}