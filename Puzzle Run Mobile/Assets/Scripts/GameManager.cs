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
        CreateHole();
    }

    private void SpawnWall()
    {
        _wall = Instantiate(_wallPrefab, _dynamicContainer.transform) as GameObject;
    }

    private void SpawnPiece()
    {
        _piece = Instantiate(_piecePrefab, _dynamicContainer.transform) as GameObject;
    }

    private void CreateHole()
    {
        List<Transform> cubes = GetPieceCubes();

        // Check if number of cubes are equal to
        // the number of containers
        if (cubes.Count != _piece.transform.childCount)
        {
            Debug.LogWarning("Found " + cubes.Count + " cubes for " + _piece.transform.childCount + " containers");
            return;
        }

        for (int i = 0; i < cubes.Count; i++)
        {
            cubes[i].position = _piece.transform.GetChild(i).position;
            cubes[i].parent = _piece.transform.GetChild(i);
        }
    }

    // Return a list of wall cubes which are 
    // in the same place as the piece's containers
    private List<Transform> GetPieceCubes()
    {
        List<Transform> cubes = new List<Transform>();
        foreach (Transform cube in _wall.transform)
        {
            foreach (Transform container in _piece.transform)
            {
                if (cube.position == container.position)
                    cubes.Add(cube);
            }
        }
        return cubes;
    }
}
