using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour {
    public static T Instance;
    public bool DontDestroy;
    protected virtual void Awake() {
        if (Instance == null) {
            Instance = this as T;
            if (DontDestroy)
                DontDestroyOnLoad(gameObject);
        } else if (Instance != this as T) {
            Destroy(gameObject);
        }
    }
}
