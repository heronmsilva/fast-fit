using UnityEngine;

public class Controls : MonoBehaviour
{
    private GameManager gm;

    private void Start()
    {
        gm = GetComponent<GameManager>();
    }

    public void FlipPieceUp()
    {
        if (gm.IsGameOver) return;

        gm.Piece.GetComponent<PieceController>().FlipUp();
    }

    public void FlipPieceRight()
    {
        if (gm.IsGameOver) return;

        gm.Piece.GetComponent<PieceController>().FlipRight();
    }

    public void RotatePieceLeft()
    {
        if (gm.IsGameOver) return;

        gm.Piece.GetComponent<PieceController>().RotateLeft();
    }

    public void RotatePieceRight()
    {
        if (gm.IsGameOver) return;

        gm.Piece.GetComponent<PieceController>().RotateRight();
    }
}
