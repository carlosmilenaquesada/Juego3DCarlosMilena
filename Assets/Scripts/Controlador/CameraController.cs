using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 offset = new Vector3(0, 2, -8);
    public Transform jugador;
    private float lerpValue = 0.1f;
    private float sensibilidada = 0.6f;

    private void Start()
    {
        
    }

    void LateUpdate()
    {
        offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * sensibilidada, Vector3.up) * offset;
        offset = Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * sensibilidada * (-1), Vector3.right) * offset;
        transform.position = Vector3.Lerp(transform.position, jugador.position + offset, lerpValue);
        
        transform.LookAt(jugador);
    }
}
