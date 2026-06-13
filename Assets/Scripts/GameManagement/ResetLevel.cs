using System;
using UnityEngine;

public class ResetLevel : MonoBehaviour
{
    public static ResetLevel Instance;


    public event Action OnPlayerRespawn;


    public void OnRespawn()
    {
        OnPlayerRespawn?.Invoke();


    }
}
