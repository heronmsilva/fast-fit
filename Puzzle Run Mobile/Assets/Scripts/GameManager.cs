using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Editor properties
    [SerializeField] private GameObject _dynamicContainer = null; 
    [SerializeField] private GameObject _wallPrefab = null;
    [SerializeField] private GameObject _piecePrefab = null;
    [SerializeField] private GameObject _pieceStartPoint = null;
    [SerializeField] private float _wallDistance = 30f;
    [SerializeField] private float _startSpeed = 3f;
    [SerializeField] private float _increaseSpeed = .2f;
    #endregion

    #region Class properties
    private static GameManager _instance;
    private GameObject _wall, _piece;
    private Vector2 _minXY, _maxXY;
    private float _speed;
    private bool _isGameOver = false;
    #endregion

    #region Public properties
    public static GameManager Instance { get { return _instance; } }
    public Vector2 MinXY { get { return _minXY; } }
    public Vector2 MaxXY { get { return _maxXY; } }
    public bool IsGameOver { get { return _isGameOver; } }
    #endregion

    private void Awake()
    {
        if (_instance != null && _instance != this)
            Destroy(this.gameObject);
        else
            _instance = this;
    }

    private void Start()
    {
        _minXY = _maxXY = Vector2.zero;
        _speed = _startSpeed;
        
        SpawnObjects();
    }

    private void Update()
    {
        if (IsWallCrossed())
        {
            _speed += _increaseSpeed;
            RespawnObjects();
        }
    }

    public void GameOver()
    {
        // Since several collisions might be triggering gameover
        // it has to be checked if it has already been triggered
        if (! _isGameOver)
        {
            _isGameOver = true;
            Time.timeScale = 0;
        }
    }

    #region Piece movement triggers
    public void FlipPiece()
    {
        _piece.GetComponent<PieceController>().Flip();
    }

    public void RotatePieceLeft()
    {
        _piece.GetComponent<PieceController>().RotateLeft();
    }

    public void RotatePieceRight()
    {
        _piece.GetComponent<PieceController>().RotateRight();
    }
    #endregion

    // If the wall reaches the zero destination
    // it has not collided with the piece
    private bool IsWallCrossed()
    {
        return _wall.transform.position == Vector3.zero;
    }

    #region Spawn Objects
    private void RespawnObjects()
    {
        Destroy(_wall);
        Destroy(_piece);

        SpawnObjects();
    }

    private void SpawnObjects()
    {
        SpawnWall();
        SpawnPiece();
        RandomizePiecePosition();
        RandomizePieceRotation();
        CreateHole();
        SetupInitialTransforms();
    }

    private void SpawnWall()
    {
        _wall = Instantiate(_wallPrefab, _dynamicContainer.transform) as GameObject;
        _wall.GetComponent<MoveTo>().speed = _speed;
        _wall.GetComponent<MoveTo>().waypoint = Vector3.zero;

        SetupMinMaxXY();
    }

    // Once the wall is spawned, we need to know what are the min/max XY positions
    // in order to limit piece position and movement within the wall location
    private void SetupMinMaxXY()
    {
        foreach (Transform cube in _wall.transform)
        {
            _minXY.x = (cube.position.x < _minXY.x) ? cube.position.x : _minXY.x;
            _minXY.y = (cube.position.y < _minXY.y) ? cube.position.y : _minXY.y;
            _maxXY.x = (cube.position.x > _maxXY.x) ? cube.position.x : _maxXY.x;
            _maxXY.y = (cube.position.y > _maxXY.y) ? cube.position.y : _maxXY.y;
        }
    }

    private void SpawnPiece()
    {
        _piece = Instantiate(_piecePrefab, _dynamicContainer.transform) as GameObject;
    }

    // Randomize a position for the piece 
    // within the wall boundries
    private void RandomizePiecePosition()
    {
        int i = Random.Range(0, _wall.transform.childCount);
        Vector3 pos = _wall.transform.GetChild(i).position;

        // If the position is exactly at the border
        // we need to shift it one unity accordingly
        if (pos.x == _minXY.x) pos += Vector3.right;
        if (pos.x == _maxXY.x) pos -= Vector3.right;
        if (pos.y == _minXY.y) pos += Vector3.up;
        if (pos.y == _maxXY.y) pos -= Vector3.up;

        _piece.transform.position = pos;
    }

    private void RandomizePieceRotation()
    {
        int randMult = Random.Range(0, 4);

        Vector3 eulerAngles = _piece.transform.eulerAngles;
        eulerAngles = new Vector3(0, 0, 90) * randMult;
        _piece.transform.eulerAngles = eulerAngles;
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

    private void SetupInitialTransforms()
    {
        _wall.transform.position += Vector3.forward * _wallDistance;

        _piece.transform.rotation = Quaternion.identity;
        _piece.transform.position = _pieceStartPoint.transform.position;
    }
    #endregion
}
