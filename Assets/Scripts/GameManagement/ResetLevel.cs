using System;
using UnityEngine;

public class ResetLevel : MonoBehaviour
{
    public static ResetLevel Instance;


    public event Action OnPlayerRespawn;

    private void Awake()
    {
        Instance = this;
    }

    public void OnRespawn()
    {
        OnPlayerRespawn?.Invoke();
    }
}
