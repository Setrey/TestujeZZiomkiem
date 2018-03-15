using UnityEngine;

public class Interactable : MonoBehaviour {

    public Transform interactionTransform;
    public SphereCollider sphereCollider;

    bool isFocus = false;
    Transform player;

    bool hasInteracted = false; //wypisywanie tylko raz interakcji/kolizji

    public Material normalColor;
    public Material selectedColor;

    public virtual void Interact() {
        //This method is meant to be overwrtten
        Debug.Log("Interacting with " + transform.name);
    }

    private void Update() {
        if(isFocus && !hasInteracted) {
            float distance = Vector3.Distance(player.position, interactionTransform.position);  //obliczanie odleglosci gracza od obiektu
            if(distance <= sphereCollider.radius)  //jezeli odleglosc jest mniejsza od promienia
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

    //private void OnDrawGizmosSelected() {
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawWireSphere(transform.position, 2);
    //}

    void OnTriggerEnter(Collider other) {
        if(other.name == "Player") {
            Debug.Log("Trigger enter");
            PlayerController controller = other.GetComponent<PlayerController>();
            controller.AddToInteractabeList(gameObject);
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.name == "Player") {
            Debug.Log("Trigger exit");
            PlayerController controller = other.GetComponent<PlayerController>();
            controller.RemoveFromInteractabeList(gameObject);
            GetComponent<Renderer>().material = normalColor;
        }
    }

    private void OnCollisionEnter(Collision collision) {
        Debug.Log("Collision ");
    }

}
