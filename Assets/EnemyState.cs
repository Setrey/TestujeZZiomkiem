using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//Opisuje przejscia pomiedzy poszczegolnymi stanami
public class EnemyState : MonoBehaviour {

    
    public Transform waypoints;

    [HideInInspector] public PatrolState paterolState;
    IEnemyAI currentState;
    [HideInInspector] public NavMeshAgent navMeshAgent;

    void Awake() {
        paterolState = new PatrolState(this);
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Use this for initialization
    void Start() {
        currentState = paterolState;
    }

    // Update is called once per frame
    void Update() {
        paterolState.UpdateAction();
    }

    //void OnTriggerEnter(Collision other) {
    //    currentState.OnTriggerEnter(other);
    //}
}
