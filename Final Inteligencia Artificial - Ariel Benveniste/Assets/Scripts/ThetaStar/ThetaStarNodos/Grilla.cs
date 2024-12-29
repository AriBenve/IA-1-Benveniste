using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grilla : MonoBehaviour
{
    Nodos[,] MatrizDeNodos;
    public int largo;
    public int alto;
    public GameObject prefab;
    public float offset;

    private void Start()
    {
        InicializarNodos();
    }
    

    void InicializarNodos()
    {
        MatrizDeNodos = new Nodos[largo, alto];
        for (int i = 0; i < largo; i++)
        {
            for(int j = 0; j < alto; j++)
            {
                GameObject aux = Instantiate(prefab);
                aux.transform.position = new Vector3(i * offset, 0, j * offset);
                Nodos nodo = aux.GetComponent<Nodos>();
                nodo.Inicializar(this, new Vector2Int(i ,j));
                MatrizDeNodos[i, j] = nodo;
            }
        }
    }

    public List<Nodos> GetNeighborsBasedOnPosition(int x, int y)
    {
        List<Nodos> neighbors = new List<Nodos>();

        for (int i = -1; i < 2; i += 2)
        {
            if ((y + i) >= 0 && (y + i) < alto)
                neighbors.Add(MatrizDeNodos[x, y + i]);
            if ((x + i) >= 0 && (x + i) < largo)
                neighbors.Add(MatrizDeNodos[x + i, y]);
        }

        return neighbors;
    }
}
