using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverCubo : MonoBehaviour
{

    public Camera mainCamera; // Asigna tu cámara principal desde el editor
    public LayerMask layerMask; // Capa del plano donde el cubo se va a mover
    public float moveSpeed = 5f; // Velocidad del movimiento suave

    private Vector3 targetPosition;
    private bool isMoving = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Detecta si se hace click con el botón izquierdo del mouse
        {
            SetTargetPosition();
        }

        if (isMoving)
        {
            MoveCube();
        }
    }

    void SetTargetPosition()
    {
        // Obtener la posición del mouse en la pantalla
        Vector3 mouseScreenPosition = Input.mousePosition;

        // Crear un rayo desde la cámara hasta la posición del mouse
        Ray ray = mainCamera.ScreenPointToRay(mouseScreenPosition);

        // Variable para almacenar la información de impacto del rayo
        RaycastHit hit;

        // Comprobar si el rayo impacta en el plano
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        {
            // Establecer la posición objetivo del cubo
            targetPosition = hit.point;
            isMoving = true;
        }
    }

    void MoveCube()
    {
        // Mover el cubo hacia la posición objetivo usando Lerp
        transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        // Comprobar si el cubo ha alcanzado la posición objetivo
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            transform.position = targetPosition;
            isMoving = false;
        }
    }
}
