using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonTest1 : MonoBehaviour
{
    static SingletonTest1 _inst = null;

    public static SingletonTest1 Inst
    {
        get
        {
            if(_inst == null)
            {
                GameObject go = new GameObject("Singleton GameMgr");
                _inst = go.AddComponent<SingletonTest1>();
                DontDestroyOnLoad(go);
            }
            return _inst;
        }
    }
}
