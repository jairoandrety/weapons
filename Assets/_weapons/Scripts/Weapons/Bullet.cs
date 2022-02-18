using System.Collections;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    [Header("Bullet Stats")]
    [SerializeField] private float speed = 0;
    [SerializeField] private float range = 0;
    [SerializeField] private float damage = 0;


    [SerializeField] private float timeLife = 0;
    [SerializeField] private GameObject vfx;

    private Rigidbody rigidbody;
    private IEnumerator timeCheckerCoroutine;
    private float currentTime = 0;

    public float Speed { get => speed; set => speed = value; }
    public float Range { get => range; set => range = value; }
    public float Damage { get => damage; set => damage = value; }

    public float TimeLife { get => timeLife; set => timeLife = value; }
    public GameObject VFX { get => vfx; set => vfx = value; }
    public IEnumerator TimeCheckerCoroutine { get => timeCheckerCoroutine; set => timeCheckerCoroutine = value; }
    public float CurrentTime { get => currentTime; set => currentTime = value; }
    public Rigidbody Rigidbody { get => rigidbody; set => rigidbody = value; }

    public abstract void Setup(Vector3 direction, float speed, float range, float damage);
    public abstract void Hit();
    public abstract void ActiveVFX();
    protected abstract IEnumerator TimeChecker(float value);    
    public abstract void Hide();
}