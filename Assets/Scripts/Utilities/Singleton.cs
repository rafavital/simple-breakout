using UnityEngine;

namespace BRK.Utilities
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T m_instance;

        public static T Instance
        {
            get
            {
                if (m_instance == null)
                {
                    m_instance = FindObjectOfType<T>();

                    if (m_instance == null)
                    {
                        GameObject singletonObject = new GameObject($"{typeof(T).Name} Instance");
                        m_instance = singletonObject.AddComponent<T>();
                    }
                }
                return m_instance;
            }
        }

        private void OnApplicationQuit()
        {
            m_instance = null;
        }
    }
}