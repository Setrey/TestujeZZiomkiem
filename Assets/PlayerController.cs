﻿using UnityEngine.EventSystems;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {

    public Transform player;

    public LayerMask movementMask;
    Camera cam;
    PlayerMotor motor;
    Interactable focus;

    // Use this for initialization
    void Start() {
        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();
    }

    // Update is called once per frame
    void Update() {
        //if(EventSystem.current.IsPointerOverGameObject())   //jezeli nie klikna na plansze
        //    return;

        if(Input.GetMouseButtonDown(0)) {
            //promien
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            //Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);
            RaycastHit hit;
            RemoveFocus();

            if(Physics.Raycast(ray, out hit, 100, movementMask)) {
                // Debug.Log("We hit " + hit.collider.name + " " + hit.point);
                //move our player to what we hit, kazemy jednostce isc tam gdzie wcisnelismy

                motor.MoveToPoint(hit.point);
            }
        }

        if(Input.GetMouseButtonDown(1)) //prawy przycisk myszy, interakcja z obiektem
        {
            //promien
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, 100)) {
                // Debug.Log("We hit " + hit.collider.name + " " + hit.point);

                //if we hit an interactable (pobieramy interacctable obiekt na ktorym kliknelismy myszka)
                Interactable interactable = hit.collider.GetComponent<Interactable>();

                //if we did set it as our focus
                if(interactable != null) {
                    SetFocus(interactable);
                }
            }
        }

        if(Input.GetKey("LeftAlt")) {

        }
    }

    void SetFocus(Interactable newFocus) {

        if(focus != newFocus) {
            if(focus != null)
                focus.OnDefocused();
            focus = newFocus;
        }
        newFocus.onFocused(transform);
        motor.FollowTarget(newFocus);
    }

    void RemoveFocus() {
        if(focus != null)
            focus.OnDefocused();
        focus = null;
        motor.StopFallowingTarget();
    }
}
