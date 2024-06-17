using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CubeNavMeshMovement : MonoBehaviour
{
    public Camera mainCamera; // Asigna tu cámara principal desde el editor
    private NavMeshAgent navMeshAgent;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Detecta si se hace click con el botón izquierdo del mouse
        {
            MoveCubeToMousePosition();
        }
    }

    void MoveCubeToMousePosition()
    {
        // Obtener la posición del mouse en la pantalla
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        // Variable para almacenar la información de impacto del rayo
        RaycastHit hit;

        // Comprobar si el rayo impacta en el plano
        if (Physics.Raycast(ray, out hit))
        {
            // Establecer la posición objetivo del cubo en el NavMeshAgent
            navMeshAgent.SetDestination(hit.point);
        }
    }
}