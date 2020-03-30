using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _dynamicContainer, _wallPrefab, _piecePrefab;

    private GameObject _wall;
    private GameObject _piece;

    private void Start()
    {
        SpawnWall();
        SpawnPiece();
    }

    private void SpawnWall()
    {
        _wall = Instantiate(_wallPrefab, _dynamicContainer.transform) as GameObject;
    }

    private void SpawnPiece()
    {
        _piece = Instantiate(_piecePrefab, _dynamicContainer.transform) as GameObject;
    }
}
