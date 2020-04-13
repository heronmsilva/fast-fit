using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject wallPrefab = null;
    [SerializeField] private GameObject floatingTextPrefab = null;
    [SerializeField] private GameObject dynamicContainer = null;
    [SerializeField] private GameObject pieceStartPoint = null;
    [SerializeField] private ParticleSystem backgroundRays = null;
    [SerializeField] private ParticleSystem backgroundDust = null;
    [SerializeField] private List<GameObject> piecesPrefabs = new List<GameObject>();
    [SerializeField] private List<Material> cubeMaterials = new List<Material>();

    private GameManager gm;
    private AnimationBuffer animBuffer;
    private GameObject wall, piece;
    private Vector2 minXY, maxXY;
    private bool respawning = false;

    public GameObject Wall { get { return wall; } }
    public GameObject Piece { get { return piece; } }
    public Vector2 MinXY { get { return minXY; } }
    public Vector2 MaxXY { get { return maxXY; } }
    public bool IsRespawning { get { return respawning; } }

    private void Awake()
    {
        gm = GetComponent<GameManager>();
        backgroundRays = backgroundRays.GetComponent<ParticleSystem>();
        animBuffer = GetComponent<AnimationBuffer>();
    }

    private void Start()
    {
        minXY = maxXY = Vector2.zero;
    }

    private Material GetMaterial()
    {
        string animation = animBuffer.Peek();
        Material material = null;
        switch (animation)
        {
            case "None":
                material = cubeMaterials[0];
                break;
            case "Fade":
                material = cubeMaterials[1];
                break;
            case "RotateY":
            case "DelayedFadeRotateY":
                material = cubeMaterials[2];
                break;
            case "RotateX":
            case "DelayedFadeRotateX":
                material = cubeMaterials[3];
                break;
            case "RotateXY":
            case "DelayedRotateXY":
                material = cubeMaterials[4];
                break;
        }
        return material;
    }

    public void ShowScoredPoints(int points)
    {
        GameObject floatingText = Instantiate(
            floatingTextPrefab, 
            piece.transform.position, 
            Quaternion.identity, 
            dynamicContainer.transform
        );
        floatingText.GetComponent<TextMesh>().text = points.ToString();
    }

    public IEnumerator DelayedRespawn(float delay)
    {
        respawning = true;

        yield return new WaitForSeconds(delay);

        RespawnObjects();
        respawning = false;
    }

    public void RespawnObjects()
    {
        Destroy(wall);
        Destroy(piece);

        SpawnObjects();
    }

    public void SpawnObjects()
    {
        SpawnWall();
        UpdateCubeMaterial();
        UpdateBackgroundRays();
        UpdateBackgroundDust();
        SetupMinMaxXY();
        SpawnPiece();
        RandomizePiecePosition();
        RandomizePieceRotation();
        CreateHole();
        SetupInitialTransforms();
        SetupWallMovement();
        PlayNextAnimation();
    }

    private void PlayNextAnimation()
    {
        wall.GetComponent<WallAnimations>().Invoke(animBuffer.Next(), 0f);
    }

    private void SpawnWall()
    {
        wall = Instantiate(wallPrefab, dynamicContainer.transform) as GameObject;
    }

    private void UpdateCubeMaterial()
    {
        foreach (Transform cube in wall.transform)
        {
            cube.gameObject.GetComponent<Renderer>().material = GetMaterial();
        }
    }

    private void UpdateBackgroundRays()
    {
        var main = backgroundRays.main;
        main.startColor = GetMaterial().color;
        main.startSpeed = 2.4f * gm.Speed;
        main.startLifetime = 60 / (2.4f * gm.Speed);
        
        var emission = backgroundRays.emission;
        emission.rateOverTime = (int) (2.4f * gm.Speed * 1.6f);
    }

    private void UpdateBackgroundDust()
    {
        var main = backgroundDust.main;
        main.startSpeed = 2f * gm.Speed;
        main.startLifetime = 60 / (2f * gm.Speed);
        
        var emission = backgroundDust.emission;
        emission.rateOverTime = (int) (2f * gm.Speed * 1.6f);
    }

    // Sets up boundries for movement
    // and piece position randomization
    private void SetupMinMaxXY()
    {
        foreach (Transform cube in wall.transform)
        {
            minXY.x = (cube.position.x < minXY.x) ? cube.position.x : minXY.x;
            minXY.y = (cube.position.y < minXY.y) ? cube.position.y : minXY.y;
            maxXY.x = (cube.position.x > maxXY.x) ? cube.position.x : maxXY.x;
            maxXY.y = (cube.position.y > maxXY.y) ? cube.position.y : maxXY.y;
        }
    }

    private void SpawnPiece()
    {
        int rand = Random.Range(0, piecesPrefabs.Count);
        piece = Instantiate(piecesPrefabs[rand], dynamicContainer.transform) as GameObject;
    }

    private void RandomizePiecePosition()
    {
        int i = UnityEngine.Random.Range(0, wall.transform.childCount);
        Vector3 pos = wall.transform.GetChild(i).position;

        // If the position is exactly at the border
        // we need to shift it one unity accordingly
        if (pos.x == minXY.x) pos += Vector3.right;
        if (pos.x == maxXY.x) pos -= Vector3.right;
        if (pos.y == minXY.y) pos += Vector3.up;
        if (pos.y == maxXY.y) pos -= Vector3.up;

        piece.transform.position = pos;
    }

    private void RandomizePieceRotation()
    {
        int randMult = UnityEngine.Random.Range(0, 4);

        Vector3 eulerAngles = piece.transform.eulerAngles;
        eulerAngles = new Vector3(0, 0, 90) * randMult;
        piece.transform.eulerAngles = eulerAngles;
    }

    private void CreateHole()
    {
        List<Transform> cubes = GetPieceCubes();

        // Check if number of cubes are equal to
        // the number of containers
        if (cubes.Count != piece.transform.childCount)
        {
            Debug.LogWarning("Found " + cubes.Count + " cubes for " + piece.transform.childCount + " containers");
            return;
        }

        for (int i = 0; i < cubes.Count; i++)
        {
            cubes[i].position = piece.transform.GetChild(i).position;
            cubes[i].parent = piece.transform.GetChild(i);
        }
    }

    // Return a list of wall cubes which are 
    // in the same place as the piece's containers
    private List<Transform> GetPieceCubes()
    {
        List<Transform> cubes = new List<Transform>();
        foreach (Transform cube in wall.transform)
        {
            foreach (Transform container in piece.transform)
            {
                if (cube.position == container.position)
                    cubes.Add(cube);
            }
        }
        return cubes;
    }

    private void SetupInitialTransforms()
    {
        wall.transform.position += Vector3.forward * gm.WallDistance;

        piece.transform.rotation = Quaternion.identity;
        piece.transform.position = pieceStartPoint.transform.position;
    }

    private void SetupWallMovement()
    {
        wall.GetComponent<MoveTo>().SetSpeed(gm.Speed);
        wall.GetComponent<MoveTo>().SetWaypoint(Vector3.zero);
    }
}
