using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nodos : MonoBehaviour
{
    private List<Nodos> _neighbors = new List<Nodos>();

    private Grilla _grid;
    private Vector2Int _myPosInGrid;

    public bool isBlocked = false;

    public int cost = 1;

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
            GameManager.instance.SetGoal(Team.Red, this);
        if (Input.GetMouseButtonDown(1))
            GameManager.instance.SetGoal(Team.Blue, this);
    }

    public void Inicializar(Grilla grid, Vector2Int myPosInGrid)
    {
        _grid = grid;
        _myPosInGrid = myPosInGrid;
        SetCost(cost);

        if (!GameManager.instance.nodos.Contains(this))
            GameManager.instance.nodos.Add(this);
    }

    public List<Nodos> GetNeighbors()
    {
        if(_neighbors.Count <= 0)
        {
            _neighbors = _grid.GetNeighborsBasedOnPosition(_myPosInGrid.x, _myPosInGrid.y);
        }

        return _neighbors;
    }

    void SetBlocked(bool block)
    {
        isBlocked = block;
        Color color = block ? Color.black : Color.white;
        //GameManager.instance.ChangeObjectColor(gameObject, color);
        gameObject.layer = block ? 6 : 0;
    }

    void SetCost(int c)
    {
        cost = Mathf.Clamp(c, 1, 99);
    }
}
