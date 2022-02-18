using UnityEngine;

[CreateAssetMenu(fileName = "NewWeaponStats", menuName = "ScriptableObjects/Weapons/WeaponStats")]
public class WeaponStatsSetup : ScriptableObject
{
    [SerializeField] private string weaponName;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private WeaponStatsModel stats;

    public string ProfileName { get => weaponName; }
    public GameObject BulletPrefab { get => bulletPrefab; }
    public WeaponStatsModel Stats { get => stats; }
}
