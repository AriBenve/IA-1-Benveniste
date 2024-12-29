using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public List<Nodos> nodos = new List<Nodos>();
    public Teams[] team;

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

    public void SetGoal(Team name, Nodos nodo)
    {
        equipos[name].nodoFin = nodo;
    }
}
