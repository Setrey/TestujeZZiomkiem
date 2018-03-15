using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMotor : MonoBehaviour {

    NavMeshAgent agent;
    Transform target;

    // Use this for initialization
    void Start() {
        agent = GetComponent<NavMeshAgent>();
    }

    public void MoveToPoint(Vector3 point) {
        agent.SetDestination(point);
        agent.stoppingDistance = .8f;
    }

    public void FollowTarget(Interactable newTarget) {
        agent.stoppingDistance = newTarget.sphereCollider.radius * .8f;    //odleglosc od obiektu
        agent.updateRotation = false;
        target = newTarget.interactionTransform;
    }

    public void StopFallowingTarget() {
        target = null;
        agent.updateRotation = true;
    }

    private void Update() {
        if(target != null) {
            agent.SetDestination(target.position);
            FaceTarget();
        }
    }

    void FaceTarget() {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
}
