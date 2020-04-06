using UnityEngine;

public class CubeCollider : MonoBehaviour
{
    private void OnCollisionEnter(Collision col)
    {
        GameManager.Instance.GameOver();
    }
}
