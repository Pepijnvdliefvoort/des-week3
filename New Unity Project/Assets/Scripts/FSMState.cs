using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FSMState : MonoBehaviour
{
    private bool _firstRun = true;

    public void Awake()
    {
        
    }

    // Start is called before the first frame update
    public virtual void OnEnable()
    {
        if (!_firstRun)
        {
            OnEnable();
        }

        _firstRun = false;
    }

    public virtual void Update()
    {
    }

    public virtual void OnDisable()
    {
    }
}