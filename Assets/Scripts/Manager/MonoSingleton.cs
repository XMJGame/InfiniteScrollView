using UnityEngine;

public class MonoSingleton <T> : MonoBehaviour where T:MonoSingleton<T>
{
    private static T m_Instance;
    public static T Instance
    {
        get
        {
            if (m_Instance == null)
            {
                m_Instance = GameObject.FindObjectOfType(typeof(T)) as T;
                if (m_Instance == null)
                {
                    m_Instance = new GameObject(typeof(T).ToString(), typeof(T)).GetComponent<T>();
                }
                DontDestroyOnLoad(m_Instance.gameObject);
            }
            return m_Instance;
        }
    }
}
