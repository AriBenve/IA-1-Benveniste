using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public List<Nodos> nodos = new List<Nodos>();
    public Teams[] team;

    public delegate void LeaderPathfinding(Team team);

    public LeaderPathfinding leaderPathfinding;
    //public LeaderPathfinding leaderPathfindingAzul;
    //public LeaderPathfinding leaderPathfindingRojo;

    private Dictionary<Team, Teams> equipos = new Dictionary<Team, Teams>();

    private void Awake()
    {
        instance = this;
        foreach(var item in team)
        {
            if(!equipos.ContainsKey(item.teamName))
            {
                equipos.Add(item.teamName, item);
            }
        }
    }

    public Nodos SetStart(Vector3 initialposition, Team nombreEquipo)
    {
        Nodos nodoMasCercano = null;
        float distanciaMinima = 10000;
        float distanciaActual;

        foreach(var item in nodos)
        {
            distanciaActual = Vector3.Distance(initialposition, item.transform.position);
            if (distanciaActual < distanciaMinima)
            {
                distanciaMinima = distanciaActual;
                equipos[nombreEquipo].nodoInicio = item;
            }
            //Debug.Log("el nodo más cercano es " + nodoMasCercano.name);
        }
        
        return equipos[nombreEquipo].nodoInicio;
    }

    public void SetGoal(Team name, Nodos nodo)
    {
        equipos[name].nodoFin = nodo;
        GameManager.instance.leaderPathfinding?.Invoke(name);
    }
}
