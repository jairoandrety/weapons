using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AnimationSetup
{
    public string animationName = string.Empty;
}

[CreateAssetMenu(fileName = "AnimationsSetup", menuName = "ScriptableObjects/AnimationsSetup")]
public class AnimationsSetup : ScriptableObject
{
    [SerializeField] private List<AnimationSetup> setups = new List<AnimationSetup>();

    public List<AnimationSetup> Setups { get => setups; }
}
