
using UnityEngine;

public class AnimationViewer : MonoBehaviour
{
    public AnimationsSetup animationsSetup;
    [SerializeField] private Animator animator;

    private int selected = 0;

    void Start()
    {
        selected = GameCore.Instance.stats.animationSlected;


    }

    public void ChangeAnimation()
    {
        AnimationSetup animationSelected = animationsSetup.Setups[selected];
        animator.SetTrigger(animationSelected.animationName);
    }
}
