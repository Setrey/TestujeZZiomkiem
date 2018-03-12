using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//interfejs wszystkich mozliwych stanow jednostek
public interface IEnemyAI {
    void UpdateAction();
    void OnTriggerEnter(Collision enemy);
    void ToPatrolState();
    void ToAttackState();
    void ToAlertState();
    void ToCheaseState();
}
