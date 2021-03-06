using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;

using UnityEngine.UI;

public class AnimationSelector : MonoBehaviour
{
    public AnimationsSetup animationsSetup;

    [SerializeField] private Animator animator;
    [SerializeField] private AnimationSelectorView view;

    private int selected = 0;
    private AnimationSetup animationSelected = new AnimationSetup();

    #region UnityBehaviour
    void Start()
    {
        for (int i = 0; i < view.tooglesAnimations.Count; i++)
        {
            int id = i;
            view.tooglesAnimations[i].onValueChanged.AddListener(value =>
            {
                if (value)
                    selected = id;

                ChangeAnimation();
            });
        }

        view.buttonSelectAnimation.onClick.AddListener(SelectAnimation);
    }
    #endregion

    public void ChangeAnimation()
    {
        animationSelected = animationsSetup.Setups[selected];
        animator.SetTrigger(animationSelected.animationName);
    }

    public void SelectAnimation()
    {
        GameCore.Instance.SelectAnimation(selected);
    }
}