using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {

    [SerializeField] Vector3 rotationVector;
    [SerializeField] float rotateSpeed = 1f;

    private void Update() {
        transform.Rotate(rotationVector * rotateSpeed * Time.deltaTime);
    }

}
