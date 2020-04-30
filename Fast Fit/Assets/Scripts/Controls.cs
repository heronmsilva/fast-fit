using UnityEngine;

public class Controls : MonoBehaviour
{
    [SerializeField] private GameObject rookieControls = null;
    [SerializeField] private GameObject proControls = null;

    private GameManager gm;

    private void Start()
    {
        gm = GetComponent<GameManager>();
        SetupControls();
    }

    private void SetupControls()
    {
        int index = PlayerPrefManager.GetControls();
        string control = GameManager.Controls[index];
        switch (control)
        {
            case "ROOKIE":
                SetupRookieControls();
                break;
            case "PRO":
                SetupProControls();
                break;
        }
    }

    private void SetupRookieControls()
    {
        rookieControls.SetActive(true);
        proControls.SetActive(false);
    }

    private void SetupProControls()
    {
        rookieControls.SetActive(false);
        proControls.SetActive(true);
    }

    public void FlipPieceUp()
    {
        if (gm.IsGameOver || gm.IsPaused || gm.IsWallTooClose()) return;

        gm.Piece.GetComponent<PieceController>().FlipUp();
    }

    public void FlipPieceRight()
    {
        if (gm.IsGameOver || gm.IsPaused || gm.IsWallTooClose()) return;

        gm.Piece.GetComponent<PieceController>().FlipRight();
    }

    public void RotatePieceLeft()
    {
        if (gm.IsGameOver || gm.IsPaused || gm.IsWallTooClose()) return;

        gm.Piece.GetComponent<PieceController>().RotateLeft();
    }

    public void RotatePieceRight()
    {
        if (gm.IsGameOver || gm.IsPaused || gm.IsWallTooClose()) return;

        gm.Piece.GetComponent<PieceController>().RotateRight();
    }
}
