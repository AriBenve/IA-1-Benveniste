using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Team
{
    Red,
    Blue
}

[System.Serializable]
public class Teams
{
    public Team teamName;
    public Nodos nodoInicio, nodoFin;
    public Nodos nodoRetirada;
}
