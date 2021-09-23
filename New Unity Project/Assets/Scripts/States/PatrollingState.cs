using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class PatrollingState : FSMState
{

    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float distFromWaypoint;
    [SerializeField] private Transform player;
    [SerializeField] private float seenPlayer;
    [SerializeField] private float lostPlayer;

    private Vector3 _patrolTarget;
    
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
        FindNextWaypoint(waypoints);
    }

    private void Do()
    {
        var distanceToPlayer = Vector3.Distance(player.position, _patrolTarget);
        if (distanceToPlayer <= seenPlayer)
        {
            player.GetComponent<ChasingState>().enabled = true;
        }
        else 
        {
            FindNextWaypoint(waypoints);
        }
    }

    private void Exit()
    {
        
    }

    private void FindNextWaypoint(IReadOnlyList<Transform> wp)
    {
        var randomIndex = Random.Range(0, wp.Count);
        _patrolTarget = wp[randomIndex].position;
    }

    private void MoveToWaypoint(Vector3 position)
    {
        
    }
}