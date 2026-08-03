using UnityEngine;

public class Singleton : MonoBehaviour
{

    public static Singleton Instance;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DontDestroyOnLoad(Instance);
        if (Instance != this)
        {
            Destroy(this);
        }
        Instance = this;
    }

}
