using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lider : MonoBehaviour
{
    public Nodos StartingNode;
    public Team team;
    protected virtual void Start()
    {
        GameManager.instance.leaderPathfinding += SetStartNode;
    }

    void SetStartNode(Team nombreEquipo)
    {

        if (team != nombreEquipo)
            return;

        Debug.Log("Llamando a esta funcion");
        StartingNode = GameManager.instance.SetStart(transform.position, nombreEquipo);
    }
}
