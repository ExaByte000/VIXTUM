using System;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class GamePause : MonoBehaviour
{
    public static GamePause Instance;

    public bool IsPaused {  get; private set; }

    public static event Action<bool> OnPauseChanged;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        DontDestroyOnLoad(this);
    }

    private void OnDestroy()
    {
        if(Instance == this)
        {
            Instance = null;
            OnPauseChanged = null;
        }
    }

    public void SetPause(bool isEnable)
    {
        IsPaused = isEnable;

        OnPauseChanged?.Invoke(isEnable);
    }
}