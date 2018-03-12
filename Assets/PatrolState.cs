using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : IEnemyAI {

    EnemyState enemy;
    Transform[] waypoints;
    int nextWayPoint = 0;

    public PatrolState(EnemyState en) {
        enemy = en;
        waypoints = enemy.waypoints.GetComponentsInChildren<Transform>();
    }

    public void UpdateAction() { Patrol(); }
    public void OnTriggerEnter(Collision enemy) { }
    public void ToPatrolState() { }
    public void ToAttackState() { }
    public void ToAlertState() { }
    public void ToCheaseState() { }

    void Patrol() {
        enemy.navMeshAgent.destination = waypoints[nextWayPoint].position;
        enemy.navMeshAgent.Resume();
        if(enemy.navMeshAgent.remainingDistance <= enemy.navMeshAgent.stoppingDistance && !enemy.navMeshAgent.pathPending) {
            nextWayPoint = (nextWayPoint + 1) % waypoints.Length;
        }
    }
}
