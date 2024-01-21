using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;


public class crystalRotate : MonoBehaviour
{
    private float maxRotationSpeed = 200f;
    private float minimumRotationSpeed = 50f;
    private float rotationSpeed;

    
    // Start is called before the first frame update
    void Start()
    {
        rotationSpeed = Random.Range(minimumRotationSpeed, maxRotationSpeed) * (Random.value > 0.5f ? 1 : -1);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.right, rotationSpeed * Time.deltaTime);
    }
}
