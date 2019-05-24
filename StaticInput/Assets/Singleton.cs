﻿using UnityEngine;
/// <summary>
/// Adapted from: https://wiki.unity3d.com/index.php/Singleton
/// Inherit from this base class to create a singleton.
/// e.g. public class MyClassName : Singleton<MyClassName> {}
/// </summary>
public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T m_Instance;

    /// <summary>
    /// Access singleton instance through this propriety.
    /// </summary>
    public static T Instance
    {
        get
        {
            if (m_Instance == null)
            {
                // Search for existing instance.
                m_Instance = (T)FindObjectOfType(typeof(T));
                // Create new instance if one doesn't already exist.
                if (m_Instance == null)
                {
                    // Need to create a new GameObject to attach the singleton to.
                    GameObject singletonObject = new GameObject();
                    m_Instance = singletonObject.AddComponent<T>();
                    singletonObject.name = typeof(T).ToString() + " (Singleton)";
                }
            }
            return m_Instance;
        }
    }
}