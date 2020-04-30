using System.Collections.Generic;
using UnityEngine;

public class AnimationBuffer : MonoBehaviour
{
    [SerializeField] private int queueSize = 1;

    private Queue<string> animationQueue = new Queue<string>();
    
    private List<string> animsByDifficulty = new List<string>() 
    { 
        "None", 
        "Fade", 
        "RotateY", 
        "RotateX", 
        "RotateXY"
    };
    
    private List<string> allAnims = new List<string>()
    {
        "None",
        "Fade",
        "RotateY", 
        "RotateX", 
        "RotateXY",
        "DelayedFadeRotateY",
        "DelayedFadeRotateX",
        "DelayedFadeRotateXY"
    };

    private GameManager gm;

    private void Start()
    {
        gm = GetComponent<GameManager>();
    }

    public string Peek()
    {
        return animationQueue.Peek();
    }

    public string Next()
    {
        AddAnimation();

        return animationQueue.Dequeue().ToString();
    }

    public void ResetQueue()
    {
        animationQueue.Clear();
        switch (gm.CurrDifficulty)
        {
            case GameManager.Difficulty.Level0:
                animationQueue.Enqueue(animsByDifficulty[0]);
                break;
            case GameManager.Difficulty.Level1:
                animationQueue.Enqueue(animsByDifficulty[1]);
                break;
            case GameManager.Difficulty.Level2:
                animationQueue.Enqueue(animsByDifficulty[2]);
                break;
            case GameManager.Difficulty.Level3:
                animationQueue.Enqueue(animsByDifficulty[3]);
                break;
            case GameManager.Difficulty.Level4:
                animationQueue.Enqueue(animsByDifficulty[4]);
                break;
            case GameManager.Difficulty.Level5:
                animationQueue.Enqueue(RandomAnim());
                break;
        }
    }

    private void AddAnimation()
    {
        int difficulty = (int) gm.CurrDifficulty;
        
        if (gm.CurrDifficulty == GameManager.Difficulty.Level5 || gm.MaxFitSequence - gm.FitSequence <= queueSize && gm.CurrDifficulty == GameManager.Difficulty.Level4)
        {
            animationQueue.Enqueue(RandomAnim());
            return;
        }
        
        if (gm.MaxFitSequence - gm.FitSequence <= queueSize)
        {
            animationQueue.Enqueue(animsByDifficulty[difficulty + 1]);
            return;
        }

        animationQueue.Enqueue(animsByDifficulty[difficulty]);
    }

    private string RandomAnim()
    {
        int rand = Random.Range(0, allAnims.Count);
        return allAnims[rand];
    }
}
