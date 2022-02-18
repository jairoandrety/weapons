using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region SupportClasses
[System.Serializable]
public class WeaponStatsModel
{
    //[Header("Weapon Stats")]
    //[SerializeField] private float shootRate = 0;
    //[SerializeField] private float shootTime = 0;

    [Header("Bullet Stats")]
    [SerializeField] private float speed = 0;
    [SerializeField] private float range = 0;
    [SerializeField] private float damage = 0;

    public float Speed { get => speed; }
    public float Range { get => range; }
    public float Damage { get => damage; }
}

#endregion

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private GameObject vfx;

    [SerializeField] private WeaponStatsSetup setup;
    [SerializeField] private WeaponStatsModel stats = new WeaponStatsModel();

    [SerializeField] private GameObject shootPoint;
    [SerializeField] private GameObject startPoint;

    [SerializeField] private Vector3 initPos;

    public GameObject Vfx { get => vfx; }
    public WeaponStatsSetup Setup { get => setup; }
    public WeaponStatsModel Stats { get => stats; set => stats = value; }

    public GameObject ShootPoint { get => shootPoint; set => shootPoint = value; }
    public GameObject StartPoint { get => startPoint; set => startPoint = value; }
    public Vector3 InitPos { get => initPos; set => initPos = value; }

    public abstract void SetupWeapon(WeaponStatsModel statsModel);
    public abstract void Shoot();
    public abstract void Drop();
}
