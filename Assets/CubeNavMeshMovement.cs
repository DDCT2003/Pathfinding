using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CubeNavMeshMovement : MonoBehaviour
{
    public Camera mainCamera; // Asigna tu c�mara principal desde el editor
    private NavMeshAgent navMeshAgent;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Detecta si se hace click con el bot�n izquierdo del mouse
        {
            MoveCubeToMousePosition();
        }
    }

    void MoveCubeToMousePosition()
    {
        // Obtener la posici�n del mouse en la pantalla
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        // Variable para almacenar la informaci�n de impacto del rayo
        RaycastHit hit;

        // Comprobar si el rayo impacta en el plano
        if (Physics.Raycast(ray, out hit))
        {
            // Establecer la posici�n objetivo del cubo en el NavMeshAgent
            navMeshAgent.SetDestination(hit.point);
        }
    }
}