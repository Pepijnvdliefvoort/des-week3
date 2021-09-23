using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChasingState : FSMState
{
    public override void OnEnable()
    {
        Entry();
    }

    public override void Update()
    {
        Do();
    }

    public override void OnDisable()
    {
        Exit();
    }
    

    private void Entry()
    {
        
    }

    private void Do()
    {
        
    }

    private void Exit()
    {
        
    }
}