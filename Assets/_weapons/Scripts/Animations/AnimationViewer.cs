using UnityEngine;

public class AnimationViewer : MonoBehaviour
{
    public AnimationsSetup animationsSetup;
    AnimationSetup animationSelected = new AnimationSetup();
    [SerializeField] private Animator animator;

    private int selected = 0;

    void Start()
    {
        selected = GameCore.Instance.stats.animationSlected;
        ChangeAnimation();
    }

    public void ChangeAnimation()
    {
        animationSelected = animationsSetup.Setups[selected];
        Debug.Log(animationSelected.animationName);
        animator.SetTrigger(animationSelected.animationName);
    }
}
