using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Editor properties
    [SerializeField] private GameObject _dynamicContainer = null; 
    [SerializeField] private GameObject _wallPrefab = null;
    [SerializeField] private GameObject _floatingTextPrefab = null;
    [SerializeField] private GameObject _pieceStartPoint = null;
    [SerializeField] private GameObject _uiLevel = null;
    [SerializeField] private GameObject _gameOverOverlay = null;
    [SerializeField] private TouchDetector _touchDetector = null;
    [SerializeField] private ParticleSystem _backgroundParticles = null;
    [SerializeField] private Text _timeText = null;
    [SerializeField] private Text _scoreText = null;
    [SerializeField] private Text _levelText = null;
    [SerializeField] private Image _levelFill = null;
    [SerializeField] private Image _outline = null;
    [SerializeField] private Difficulty _initialDifficulty = Difficulty.Level0; 
    [SerializeField] private float _wallDistance = 30f;
    [SerializeField] private float _startSpeed = 3f;
    [SerializeField] private float _increaseSpeed = .2f;
    [SerializeField] private int _animationChance = 50; 
    [SerializeField] private int _startLives = 1; 
    [SerializeField] private int _maxCrossSequence = 10;
    [SerializeField] private int _speedUpScale = 25;
    [SerializeField] private List<GameObject> _piecePrefabs = new List<GameObject>();
    [SerializeField] private List<Image> _lifeImages = new List<Image>();
    [SerializeField] private List<Material> _cubeMaterials = new List<Material>();
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
    private bool _isRespawning = false;
    #endregion

    #region Public properties
    public static GameManager Instance { get { return _instance; } }
    public Vector2 MinXY { get { return _minXY; } }
    public Vector2 MaxXY { get { return _maxXY; } }
    public bool IsGameOver { get { return _isGameOver; } }
    public float AnimationDelay { get { return _animationDelay; } }
    public float AnimationSpeed { get { return _animationSpeed; } }
    public int AnimationChance { get { return _animationChance; } }
    public int SpeedUpScale { get { return _speedUpScale; } }
    #endregion

    #region Builtin methods
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
                
        SetAnimationDelay();
        SetAnimationSpeed();
        SpawnObjects();
        ApplyDifficulty();
    }

    private void Update()
    {
        if (IsWallCrossed() && ! _isRespawning)
        {
            _isRespawning = true;
            StopFastForward();
            IncreaseSpeed();
            IncreaseCrossSequence();
            if (IsCrossSequenceReachedMax())
            {
                ResetCrossSequence();
                IncreaseDifficulty();
                AnimateUILevel();
                IncreaseLives();
            }
            Score();
            SetAnimationDelay();
            SetAnimationSpeed();
            AnimateOutline();
            StartCoroutine(DelayRespawn());
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
                _gameOverOverlay.SetActive(true);
        }
    }
    #endregion

    #region Game logic
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

    public void LoadMenuScene()
    {
        Debug.Log("Load Menu Scene");
    }

    private void AnimateOutline()
    {
        _outline.GetComponent<Animator>().Play("OutlineFill");
    }

    private void StopFastForward()
    {
        if (_isGameOver) return;
        _touchDetector.StopFastForward();
    }

    // The animations should be delayed by 1/4
    // of the total time that the wall takes to
    // get to the destination
    private void SetAnimationDelay()
    {
        _animationDelay = (_wallDistance / _speed) / 4;
    }

    // The animations should take 1/4
    // of the total time that the wall takes to
    // get to the destination
    private void SetAnimationSpeed()
    {
        _animationSpeed = 1 / ((_wallDistance / _speed) / 4);
    }

    private void IncreaseLives()
    {
        _lives += (_lives < _lifeImages.Count) ? 1 : 0;
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
    
    private void AnimateUILevel()
    {
        _uiLevel.GetComponent<Animator>().Play("LevelSwing");
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
        StopFastForward();
        RespawnObjects();
        ApplyDifficulty();
    }
    
    private bool IsWallCrossed()
    {
        return _wall.transform.position == Vector3.zero;
    }

    private void Score()
    {
        int points = (int) ((Time.time - _startTime) * _speed * ((int) _difficulty + 1));
        ShowFloatingText(points);
        _score += points;
        
    }

    private void ShowFloatingText(int points)
    {
        GameObject floatingText = Instantiate(
            _floatingTextPrefab, 
            _piece.transform.position, 
            Quaternion.identity, 
            _dynamicContainer.transform
        );
        floatingText.GetComponent<TextMesh>().text = points.ToString();
    }
    #endregion

    #region UI actions
    public void FlipPieceUp()
    {
        if (_isGameOver) return;
        _piece.GetComponent<PieceController>().FlipUp();
    }

    public void FlipPieceRight()
    {
        if (_isGameOver) return;
        _piece.GetComponent<PieceController>().FlipRight();
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

    #region UI Update
    private void UpdateUIHeader()
    {
        UpdateUITime();
        UpdateUIScore();
        UpdateUIDifficulty();
        UpdateUILives();
    }

    private void UpdateUITime()
    {
        if (_touchDetector.IsFastForwarding) return;

        int time = (int) (Time.time - _startTime - _touchDetector.TotalFastForward);
        TimeSpan timeSpan = TimeSpan.FromSeconds(time);

        _timeText.text = string.Format("{0:D2}:{1:D2}", timeSpan.Minutes, timeSpan.Seconds);
    }

    private void UpdateUIScore()
    {
        _scoreText.text = _score.ToString();
    }

    private void UpdateUIDifficulty()
    {
        if (_difficulty == Difficulty.Level5)
            _levelText.text = "MAX";
        else
            _levelText.text = "Lv " + ((int) _difficulty).ToString();

        _levelFill.fillAmount = (float) _crossSequence / _maxCrossSequence;
    }

    private void UpdateUILives()
    {
        for (int i = 0; i < _lifeImages.Count; i++)
        {
            if (i < _lives)
                _lifeImages[i].enabled = true;
            else
                _lifeImages[i].enabled = false;
        }
    }
    #endregion

    #region Spawn Objects
    IEnumerator DelayRespawn()
    {
        yield return new WaitForSeconds(.5f);

        RespawnObjects();
        ApplyDifficulty();
        _isRespawning = false;
    }

    private void RespawnObjects()
    {
        Destroy(_wall);
        Destroy(_piece);

        SpawnObjects();
    }

    private void SpawnObjects()
    {
        SpawnWall();
        UpdateCubeMaterial();
        UpdateBackgroundParticles();
        SpawnPiece();
        RandomizePiecePosition();
        RandomizePieceRotation();
        CreateHole();
        SetupInitialTransforms();
    }

    private void UpdateBackgroundParticles()
    {
        ParticleSystem ps = _backgroundParticles.GetComponent<ParticleSystem>();
        
        var main = ps.main;
        main.startColor = _cubeMaterials[(int) _difficulty].color;
        main.startSpeed = 3 * _speed;
        main.startLifetime = 60 / (3 * _speed);
        
        var emission = ps.emission;
        emission.rateOverTime = (int) (3 * _speed * 1.6);
    }

    private void UpdateCubeMaterial()
    {
        foreach (Transform cube in _wall.transform)
        {
            cube.gameObject.GetComponent<Renderer>().material = _cubeMaterials[(int) _difficulty];
        }
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
        int i = UnityEngine.Random.Range(0, _piecePrefabs.Count);
        _piece = Instantiate(_piecePrefabs[i], _dynamicContainer.transform) as GameObject;
    }

    // Randomize a position for the piece 
    // within the wall boundries
    private void RandomizePiecePosition()
    {
        int i = UnityEngine.Random.Range(0, _wall.transform.childCount);
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
        int randMult = UnityEngine.Random.Range(0, 4);

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
