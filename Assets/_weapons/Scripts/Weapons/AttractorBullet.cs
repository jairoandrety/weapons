using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttractorBullet : Bullet
{
    private Collider[] colliders;
    private List<Orbit> orbiters = new List<Orbit>();
    private IEnumerator attractC;

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }

    public override void Setup(Vector3 direction, float speed, float range, float damage)
    {
        Speed = speed;
        Range = range;
        Damage = damage;

        Rigidbody.isKinematic = false;

        if (TimeCheckerCoroutine != null)
            StopCoroutine(TimeCheckerCoroutine);

        TimeCheckerCoroutine = TimeChecker(TimeLife);
        StartCoroutine(TimeCheckerCoroutine);

        Rigidbody.AddForce(direction * speed, ForceMode.Impulse);
        //StartCoroutine(Move(TimeLife / 2));
    }

    //Vector3 vel = Vector3.zero;
    //private IEnumerator Move(float value)
    //{
    //    float elapsedTime = 0;
    //    CurrentTime = value / 2;
    //    vel = Rigidbody.velocity;

    //    Debug.Log("Setup Orbits");
    //    while (CurrentTime > 0)
    //    {
    //        vel = Vector3.Lerp(Rigidbody.velocity, Vector3.zero, elapsedTime);
    //        CurrentTime -= Time.deltaTime;
    //        elapsedTime += Time.deltaTime;

    //        yield return null;
    //    }

    //    SetupOrbit();
    //    yield return null;
    //}   

    public override void Hit()
    {
        if (!gameObject.activeInHierarchy)
            return;

        if (TimeCheckerCoroutine != null)
            StopCoroutine(TimeCheckerCoroutine);

        TimeCheckerCoroutine = TimeChecker(TimeLife);
        StartCoroutine(TimeCheckerCoroutine);

        Rigidbody.isKinematic = true;
        Rigidbody.velocity = Vector3.zero;

        orbiters.Clear();
        colliders = Physics.OverlapSphere(transform.position, Range);

        foreach (Collider coll in colliders)
        {
            Orbit orbit = coll.GetComponent<Orbit>();
            if (orbit != null)
            {
                //orbit.Setup(this.transform, Speed, Range, Speed);
                orbit.AddForce(transform, Speed);

                orbiters.Add(orbit);
            }
        }

        if (TimeCheckerCoroutine != null)
            StopCoroutine(TimeCheckerCoroutine);

        TimeCheckerCoroutine = TimeChecker(TimeLife);
        StartCoroutine(TimeCheckerCoroutine);

        if (VFX)
        {
            ActiveVFX();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Hit();

        if (VFX)
        {
            ActiveVFX();
        }
    }

    public override void ActiveVFX()
    {
        if (VFX)
            VFX.GetComponent<ParticleSystem>().Play();
    }

    protected override IEnumerator TimeChecker(float value)
    {
        CurrentTime = value;
        orbiters.ForEach(i => i.isMoving = true);

        while (CurrentTime > 0)
        {
            CurrentTime -= Time.deltaTime;
            yield return null;
        }

        Hide();
        yield return null;
    }

    public override void Hide()
    {
        orbiters.ForEach(i => i.EndForce());

        if (VFX)
            VFX.GetComponent<ParticleSystem>().Stop();

        Rigidbody.velocity = Vector3.zero;
        Rigidbody.isKinematic = true;
        gameObject.SetActive(false);
    }
}