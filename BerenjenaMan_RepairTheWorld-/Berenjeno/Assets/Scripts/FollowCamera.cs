using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform objetivo;
    public float suavizado = 5f;
    Vector3 desfase;

    // Start is called before the first frame update
    void Start()
    {
        desfase = transform.position - objetivo.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 posicionObjetivo = objetivo.position + desfase;
        transform.position = Vector3.Lerp (transform.position,posicionObjetivo,suavizado * Time.deltaTime);
    }
}
