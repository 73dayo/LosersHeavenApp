using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class PointManager : MonoBehaviour
{
    public static PointManager instance;

    public int hoge;

    private void Awake()
    {
        if (instance == null)
        {

            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {

            Destroy(gameObject);
        }
    }

    public void Hoge()
    {
        Debug.Log("Hoge!");
    }
}
