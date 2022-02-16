using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    [SerializeField]
    private bool dontDestroyOnLoad;
    [SerializeField, Tooltip("Destroy Instance Component or whole GameObject")]
    private bool destroyInstanceOnly;

    /// <summary>
    /// Get singleton instance.
    /// </summary>
    public static T Instance
    {
        get; private set;
    }

    // Definition
    protected virtual void Awake()
    {
        if (Instance == null)
        {
            Instance = this as T;
            if (dontDestroyOnLoad)
            {
                DontDestroyOnLoad(gameObject);
            }
        }
        else
        {
            if (destroyInstanceOnly)
            {
                Destroy(this as T);
            }
            else
            {
                Destroy(gameObject);
            }         
        }
    }
}