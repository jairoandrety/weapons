using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleWeapon : Weapon
{
    private GameObject bullet;

    private void Start()
    {
        InitPos = transform.position;
        SetupWeapon(Setup.Stats);
    }

    #region Abstract
    public override void SetupWeapon(WeaponStatsModel statsModel)
    {
        this.Stats = statsModel;
        SetupPooler();
    }

    public override void Shoot()
    {
        bullet = ObjectPooler.SharedInstance.GetPooledObject(Setup.BulletPrefab.name);
        bullet.gameObject.SetActive(true);
        bullet.transform.position = ShootPoint.transform.position;
        Vector3 direction = ShootPoint.transform.position - StartPoint.transform.position;

        if(bullet != null)
        {
            bullet.GetComponent<Bullet>().Setup(direction, Stats.Speed, Stats.Range, Stats.Damage);
        }
    }
    #endregion

    private void SetupPooler()
    {
        PoolItem poolItem = new PoolItem(Setup.BulletPrefab.name, 10, Setup.BulletPrefab, true);
        if(ObjectPooler.SharedInstance)
            ObjectPooler.SharedInstance.SetPooler(poolItem);
    }

    public override void Drop()
    {
        transform.SetParent(null);
        transform.position = InitPos;
        transform.rotation = Quaternion.Euler(0, 60, 0);
        transform.GetComponent<Collider>().enabled = true;

    }
}
