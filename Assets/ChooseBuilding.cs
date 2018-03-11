using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseBuilding : MonoBehaviour {

    public Vector3 offset;
    public GameObject[] prefabs;
    Transform objPos;

    // Use this for initialization
    void Start() {
        int len = prefabs.Length;
        GameObject obj = Instantiate(prefabs[Random.Range(0, len)]);
        objPos = obj.GetComponent<Transform>();
        objPos.position = transform.position + offset;
    }

    private void Update() {
        objPos.position = transform.position + offset;
        //NavMeshSurface
    }
}
