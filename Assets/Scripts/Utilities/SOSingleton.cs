using UnityEngine;

public class SOSingleton<T> : ScriptableObject where T : ScriptableObject
{
    private static T _instance;

    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = Resources.Load(typeof(T).ToString()) as T;
                if (_instance == null) Debug.Log("Create the " + typeof(T).ToString() + "!");
            }
            return _instance;
        }
    }
}