using UnityEngine;
using System.Collections;

public class PhysicsUtility : MonoBehaviour
{
    public float bounceThreshold = 3;
    public float sleepThreshold = 0.005f;
    public int solverInterationCount = 6;

    void Awake()
    {
        Physics.bounceThreshold = bounceThreshold;
        Physics.sleepThreshold = sleepThreshold;
        Physics.defaultSolverIterations = solverInterationCount;
    }
}
