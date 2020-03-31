using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region Editor properties
    [SerializeField] private GameObject _dynamicContainer = null; 
    [SerializeField] private GameObject _wallPrefab = null;
    [SerializeField] private GameObject _piecePrefab = null;
    [SerializeField] private GameObject _pieceStartPoint = null;
    [SerializeField] private Text timeText = null;
    [SerializeField] private Text scoreText = null;
    [SerializeField] private Text livesText = null;
    [SerializeField] private Text levelText = null;
    [SerializeField] private Image levelFill = null;
    [SerializeField] private Difficulty _initialDifficulty = Difficulty.Level0; 
    [SerializeField] private float _wallDistance = 30f;
    [SerializeField] private float _startSpeed = 3f;
    [SerializeField] private float _increaseSpeed = .2f;
    [SerializeField] private int _animationChance = 50; 
    [SerializeField] private int _startLives = 3; 
    [SerializeField] private int _maxCrossSequence = 10;
    [SerializeField] private int _maxLives = 5; 
    #endregion

    #region Class properties
    private static GameManager _instance;
    private GameObject _wall, _piece;
    private Vector2 _minXY, _maxXY;
    private float _speed, _startTime;
    private int _lives;
    private enum Difficulty 
    {
        Level0,
        Level1,
        Level2,
        Level3,
        Level4,
        Level5
    }
    private Difficulty _difficulty;
    private float _animationDelay = 1f;
    private float _animationSpeed = 1f;
    private int _score = 0;
    private int _crossSequence = 0;
    private bool _isGameOver = false;
    #endregion

    #region Public properties
    public static GameManager Instance { get { return _instance; } }
    public Vector2 MinXY { get { return _minXY; } }
    public Vector2 MaxXY { get { return _maxXY; } }
    public bool IsGameOver { get { return _isGameOver; } }
    public float AnimationDelay { get { return _animationDelay; } }
    public float AnimationSpeed { get { return _animationSpeed; } }
    public int AnimationChance { get { return _animationChance; } }
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
        _startTime = Time.time;
        _lives = _startLives;
        _difficulty = _initialDifficulty;
        
        SpawnObjects();
        ApplyDifficulty();
    }

    private void Update()
    {
        if (IsWallCrossed())
        {
            IncreaseSpeed();
            IncreaseCrossSequence();
            if (IsCrossSequenceReachedMax())
            {
                ResetCrossSequence();
                IncreaseDifficulty();
                IncreaseLives();
            }
            Score();
            RespawnObjects();
            ApplyDifficulty();
        }

        UpdateUIHeader();
    }

    private void LateUpdate()
    {
        if (_isGameOver)
        {
            if (_lives > 0)
                UseLifeToRestartGame();
            else 
                Debug.Log("Game over");
        }
    }

    private void IncreaseLives()
    {
        _lives += (_lives < _maxLives) ? 1 : 0;
    }

    private void DecreaseLives()
    {
        _lives -= 1;
    }

    private void IncreaseDifficulty()
    {
        int curDifficulty = (int) _difficulty;
        _difficulty = (Difficulty) (curDifficulty + 1);
    }

    private void ResetCrossSequence()
    {
        _crossSequence = 0;
    }

    private bool IsCrossSequenceReachedMax()
    {
        return _crossSequence == _maxCrossSequence;
    }

    private void IncreaseCrossSequence()
    {
        _crossSequence += 1;
    }

    private void IncreaseSpeed()
    {
        _speed += _increaseSpeed;
    }

    private void UseLifeToRestartGame()
    {
        DecreaseLives();
        ResetCrossSequence();
        Time.timeScale = 1;
        _isGameOver = false;
        RespawnObjects();
        ApplyDifficulty();
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

    public void FastForward()
    {
        _wall.GetComponent<MoveTo>().speed = 50f;
    }

    #region Piece movement triggers
    public void FlipPiece()
    {
        if (_isGameOver) return;
        _piece.GetComponent<PieceController>().Flip();
    }

    public void RotatePieceLeft()
    {
        if (_isGameOver) return;
        _piece.GetComponent<PieceController>().RotateLeft();
    }

    public void RotatePieceRight()
    {
        if (_isGameOver) return;
        _piece.GetComponent<PieceController>().RotateRight();
    }
    #endregion

    // If the wall reaches the zero destination
    // it has not collided with the piece
    private bool IsWallCrossed()
    {
        return _wall.transform.position == Vector3.zero;
    }

    private void Score()
    {
        _score += (int) ((Time.time - _startTime) * _speed);
    }

    private void UpdateUIHeader()
    {
        timeText.text = ((int) (Time.time - _startTime)).ToString();
        scoreText.text = _score.ToString();
        livesText.text = _lives.ToString();
        
        if (_difficulty == Difficulty.Level5)
            levelText.text = "MAX";
        else
            levelText.text = ((int) _difficulty).ToString();

        levelFill.fillAmount = (float) _crossSequence / _maxCrossSequence;
    }

    #region Difficulty
    private void SetupDifficulty()
    {
        SetDifficulty();
        ApplyDifficulty();
    }

    private void ApplyDifficulty()
    {
        switch (_difficulty)
        {
            case Difficulty.Level0:
                break;
            case Difficulty.Level1:
                _wall.GetComponent<WallAnimations>().Fade();
                break;
            case Difficulty.Level2:
                _wall.GetComponent<WallAnimations>().RotateX();
                break;
            case Difficulty.Level3:
                _wall.GetComponent<WallAnimations>().RotateY();
                break;
            case Difficulty.Level4:
                _wall.GetComponent<WallAnimations>().RotateXY();
                break;
            case Difficulty.Level5:
                _wall.GetComponent<WallAnimations>().RandomAnims();
                break;
        }
    }

    private void SetDifficulty()
    {
        int level = (int) (_speed - _startSpeed) / 2;
        if (level <= System.Enum.GetValues(typeof(Difficulty)).Length)
            _difficulty = (Difficulty)level;
    }
    #endregion

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
