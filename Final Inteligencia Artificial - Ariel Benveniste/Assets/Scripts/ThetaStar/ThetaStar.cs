using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThetaStar : MonoBehaviour
{
    private LayerMask _wallMask;

    public List<Vector3> AStar(Nodos start, Nodos goal)
    {
        List<Vector3> path = new List<Vector3>();
        if (start == null || goal == null) return path;

        PriorityQueue<Nodos> frontier = new PriorityQueue<Nodos>();
        frontier.Enqueue(start, 0);
        Dictionary<Nodos, Nodos> cameFrom = new Dictionary<Nodos, Nodos>();
        cameFrom.Add(start, null);
        Dictionary<Nodos, int> costSoFar = new Dictionary<Nodos, int>();
        costSoFar.Add(start, 0);

        Nodos current = default;
        while (frontier.Count != 0)
        {
            current = frontier.Dequeue();

            if (current == goal) break;

            foreach (var next in current.GetNeighbors())
            {
                if (next.isBlocked) continue;
                int newCost = costSoFar[current] + next.cost;
                if (!costSoFar.ContainsKey(next))
                {
                    frontier.Enqueue(next, newCost + Heuristic(next.transform.position, goal.transform.position));
                    cameFrom.Add(next, current);
                    costSoFar.Add(next, newCost);
                }
                else if (newCost < costSoFar[next])
                {
                    frontier.Enqueue(next, newCost + Heuristic(next.transform.position, goal.transform.position));
                    cameFrom[next] = current;
                    costSoFar[next] = newCost;
                }
            }
        }

        if (current != goal) return path;

        //Armamos el camino
        while (current != start) //Si queremos el start pondriamos != null
        {
            path.Add(current.transform.position);
            current = cameFrom[current];
        }

        return path;
    }

    float Heuristic(Vector3 a, Vector3 b)
    {
        //return Vector3.Distance(a, b); //mas costosa pero mas precisa (puede entrar en conflicto con los pasos) 
        //return (b - a).sqrMagnitude; //menos costosa con el valor elevado al cuadrado
        return Mathf.Abs(b.x - a.x) + Mathf.Abs(b.y - a.y); // Manhattan: usar para grillas
    }

    readonly List<Vector3> EMPTY = new List<Vector3>();

    public List<Vector3> Theta_Star(Nodos start, Nodos goal)
    {
        if (start == null || goal == null) return EMPTY;

        var path = AStar(start, goal);

        path.Add(start.transform.position); //Si el a* no devuelve el incial lo podemos agregar
        // path.Reverse(); //Si queremos podemos calcular el camino desde el principio al final (si A* lo da vuelta esto no se hace/se hace antes)

        int current = 0;
        while (current + 2 < path.Count)
        {
            if (path[current].InLineOfSight(path[current + 2], _wallMask))
                path.RemoveAt(current + 1);
            else
                current++;
        }

        return path;
    }
}
