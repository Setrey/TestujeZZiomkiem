using UnityEngine;

public class Interactable : MonoBehaviour {

    public float radius = 3f;
    public Transform interactionTransform;

    bool isFocus = false;
    Transform player;

    bool hasInteracted = false; //wypisywanie tylko raz interakcji/kolizji

    public virtual void Interact() {
        //This method is meant to be overwrtten
        Debug.Log("Interacting with " + transform.name);
    }

    private void Update() {
        if(isFocus && !hasInteracted) {
            float distance = Vector3.Distance(player.position, interactionTransform.position);  //obliczanie odleglosci gracza od obiektu
            if(distance <= radius)  //jezeli odleglosc jest mniejsza od promienia
            {
                //Debug.Log("INTERACT");
                Interact();
                hasInteracted = true;
                //OnDefocused();
            }
        }
    }

    public void onFocused(Transform playerTransform) {
        isFocus = true;
        player = playerTransform;
        hasInteracted = false;
    }

    public void OnDefocused() {
        isFocus = false;
        player = null;
        hasInteracted = false;
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
