using System.Collections;
using UnityEngine;

public class ParabolicBullet : Bullet
{
    [SerializeField] private AnimationCurve curve;

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }

    public override void Setup(Vector3 direction, float speed, float range, float damage)
    {
        Rigidbody.isKinematic = false;

        if (TimeCheckerCoroutine != null)
            StopCoroutine(TimeCheckerCoroutine);

        TimeCheckerCoroutine = TimeChecker(TimeLife);
        StartCoroutine(TimeCheckerCoroutine);

        Rigidbody.AddForce(direction * speed, ForceMode.Impulse);
        StartCoroutine(Fall());
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

    public override void Hide()
    {
        if(VFX)
            VFX.GetComponent<ParticleSystem>().Stop();

        Rigidbody.velocity = Vector3.zero;
        Rigidbody.isKinematic = true;
        gameObject.SetActive(false);
    }

    public override void Hit()
    {
        if (!gameObject.activeInHierarchy)
            return;

        if (TimeCheckerCoroutine != null)
            StopCoroutine(TimeCheckerCoroutine);

        TimeCheckerCoroutine = TimeChecker(TimeLife / 10);
        StartCoroutine(TimeCheckerCoroutine);

        StopCoroutine(Fall());
        Rigidbody.isKinematic = true;
    }   

    protected override IEnumerator TimeChecker(float value)
    {
        CurrentTime = value;

        while (CurrentTime > 0)
        {
            CurrentTime -= Time.deltaTime;
            yield return null;
        }

        Hide();
        yield return null;
    }

    private IEnumerator Fall()
    {
        while (true)
        {
            float dropRate = curve.Evaluate(Time.deltaTime);
            Rigidbody.AddForce(Physics.gravity * dropRate, ForceMode.Acceleration);

            yield return null;
        }
    }
}