using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonajeController : MonoBehaviour
{
    private Vector3 inputPersonaje;
    private CharacterController characterController;
    private float velocidad = 10f;

    private Vector3 movePlayer;

    public Camera mainCamara;
    private Vector3 camForward;
    private Vector3 camRight;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        inputPersonaje = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        inputPersonaje = Vector3.ClampMagnitude(inputPersonaje, 1);

        direccionCamara();

        movePlayer = inputPersonaje.x * camRight + inputPersonaje.z * camForward;
        characterController.transform.LookAt(characterController.transform.position + movePlayer);
        
        characterController.Move(movePlayer * Time.deltaTime * velocidad);
    }



    void direccionCamara()
    {

        camForward = mainCamara.transform.forward;
        camRight = mainCamara.transform.right;

        camForward.y = 0;
        camRight.y = 0;

        camForward = camForward.normalized;
        camRight = camRight.normalized;
    }
}
