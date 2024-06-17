using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverCubo : MonoBehaviour
{

    public Camera mainCamera; // Asigna tu c�mara principal desde el editor
    public LayerMask layerMask; // Capa del plano donde el cubo se va a mover
    public float moveSpeed = 5f; // Velocidad del movimiento suave

    private Vector3 targetPosition;
    private bool isMoving = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Detecta si se hace click con el bot�n izquierdo del mouse
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
        // Obtener la posici�n del mouse en la pantalla
        Vector3 mouseScreenPosition = Input.mousePosition;

        // Crear un rayo desde la c�mara hasta la posici�n del mouse
        Ray ray = mainCamera.ScreenPointToRay(mouseScreenPosition);

        // Variable para almacenar la informaci�n de impacto del rayo
        RaycastHit hit;

        // Comprobar si el rayo impacta en el plano
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        {
            // Establecer la posici�n objetivo del cubo
            targetPosition = hit.point;
            isMoving = true;
        }
    }

    void MoveCube()
    {
        // Mover el cubo hacia la posici�n objetivo usando Lerp
        transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        // Comprobar si el cubo ha alcanzado la posici�n objetivo
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            transform.position = targetPosition;
            isMoving = false;
        }
    }
}
