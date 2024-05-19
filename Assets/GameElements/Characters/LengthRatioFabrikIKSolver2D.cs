using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Profiling;
using UnityEngine.U2D.IK;

/// <summary>
/// Component responsible for 2D Forward And Backward Reaching Inverse Kinematics (LengthRatioFabrik) IK.
/// </summary>
[Solver2DMenu("Chain (LengthRatioFabrik)")]
public class LengthRatioFabrikIKSolver2D : Solver2D
{
    const float k_MinTolerance = 0.001f;
    const int k_MinIterations = 1;

    [SerializeField]
    IKChain2D m_Chain = new IKChain2D();

    [SerializeField]
    [Range(k_MinIterations, 50)]
    int m_Iterations = 10;

    [SerializeField]
    [Range(k_MinTolerance, 0.1f)]
    float m_Tolerance = 0.01f;

    private float m_TotalLength = 0.01f;

    float[] m_LengthRatios;
    float[] m_Lengths;
    Vector2[] m_Positions;
    Vector3[] m_WorldPositions;

    /// <summary>
    /// Get and set the solver's integration count.
    /// </summary>
    public int iterations
    {
        get => m_Iterations;
        set => m_Iterations = Mathf.Max(value, k_MinIterations);
    }

    /// <summary>
    /// Get and set target distance tolerance.
    /// </summary>
    public float tolerance
    {
        get => m_Tolerance;
        set => m_Tolerance = Mathf.Max(value, k_MinTolerance);
    }

    /// <summary>
    /// Returns the number of chains in the solver.
    /// </summary>
    /// <returns>Returns 1, because FABRIK Solver has only one chain.</returns>
    protected override int GetChainCount() => 1;

    /// <summary>
    /// Gets the chain in the solver at index.
    /// </summary>
    /// <param name="index">Index to query. Not used in this override.</param>
    /// <returns>Returns IKChain2D for the Solver.</returns>
    public override IKChain2D GetChain(int index) => m_Chain;

    /// <summary>
    /// Prepares the data required for updating the solver.
    /// </summary>
    protected override void DoPrepare()
    {
        if (m_Positions == null || m_Positions.Length != m_Chain.transformCount)
        {
            m_Positions = new Vector2[m_Chain.transformCount];
            m_Lengths = new float[m_Chain.transformCount - 1];
            m_LengthRatios = new float[m_Chain.transformCount - 1];
            m_WorldPositions = new Vector3[m_Chain.transformCount];
        }

        for (var i = 0; i < m_Chain.transformCount; ++i)
        {
            m_Positions[i] = GetPointOnSolverPlane(m_Chain.transforms[i].position);
        }


        for (var i = 0; i < m_Chain.transformCount - 1; ++i)
        {
            m_Lengths[i] = (m_Positions[i + 1] - m_Positions[i]).magnitude;
        }
        // Debug.Log($"Lengths: {string.Join(',',m_Lengths)}");
        m_TotalLength = m_Lengths.Sum();
        for (var i = 0; i < m_Chain.transformCount - 1; ++i)
        {
            m_LengthRatios[i] = m_TotalLength / m_Lengths[i];
        }
        // Debug.Log($"TotalLength:{m_TotalLength} LengthRatios: {string.Join(',',m_LengthRatios)}");
    }

    /// <summary>
    /// Updates the IK and sets the chain's transform positions.
    /// </summary>
    /// <param name="targetPositions">Target position for the chain.</param>
    protected override void DoUpdateIK(List<Vector3> targetPositions)
    {
        Profiler.BeginSample(nameof(LengthRatioFabrikIKSolver2D.DoUpdateIK));
        Vector3 originalPostion = GetPointOnSolverPlane(m_Chain.effector.transform.position);
        var targetPosition = targetPositions[0];
        // Debug.Log($"TargetPos {targetPosition} on SolverPlane {GetPointOnSolverPlane(targetPosition)}");
        targetPosition = GetPointOnSolverPlane(targetPosition);
        bool result = LENGTH_RATIO_FABRIK_2D.Solve(m_TotalLength, targetPosition, iterations, tolerance, m_Lengths, m_LengthRatios, ref m_Positions);

        // Debug.Log($"NewPositions:[{string.Join(", ", m_Positions)}]");
        if (result)
        {
            // Convert all plane positions to world positions
            for (var i = 0; i < m_Positions.Length; ++i)
            {
                m_WorldPositions[i] = GetWorldPositionFromSolverPlanePoint(m_Positions[i]);
            }

            for (var i = 0; i < m_Chain.transformCount - 1; ++i)
            {
                var startLocalPosition = (Vector2)m_Chain.transforms[i + 1].localPosition;
                var endLocalPosition = (Vector2)m_Chain.transforms[i].InverseTransformPoint(m_WorldPositions[i + 1]);
                // Debug.Log((startLocalPosition,endLocalPosition));
                m_Chain.transforms[i].localRotation *= Quaternion.FromToRotation(startLocalPosition, endLocalPosition);
            }
        }

        Profiler.EndSample();
    }
}



public static class LENGTH_RATIO_FABRIK_2D
{
    public static bool Solve(float strechThreshold, Vector2 targetPosition, int solverLimit, float tolerance, float[] lengths, float[] length_ratios, ref Vector2[] positions)
    {
        int length = positions.Length - 1;
        int iteration = 0;
        float sqrTolerance = tolerance * tolerance;
        float sqrCurrentToleranceMagnitude = (targetPosition - positions[length]).sqrMagnitude;
        Vector2 originPosition = positions[0];
        Vector2 strechDiff = Vector2.zero;


        if (strechDiff.magnitude < strechThreshold)
        {
            strechDiff = Vector2.zero;
        }

        // Debug.Log($"Original: {originalTargetPosition} moved to {targetPosition}");
        while (sqrCurrentToleranceMagnitude > sqrTolerance)
        {
            Forward(targetPosition, strechDiff, lengths, length_ratios, ref positions);
            Backward(originPosition, strechDiff, lengths, length_ratios, ref positions);
            sqrCurrentToleranceMagnitude = (targetPosition - positions[length]).sqrMagnitude;
            if (++iteration >= solverLimit)
            {
                break;
            }
        }

        return iteration != 0;
    }

    private static bool ValidateChain(LengthRatioFabrikChain2D[] chains)
    {
        for (int i = 0; i < chains.Length; i++)
        {
            LengthRatioFabrikChain2D chain2D = chains[i];
            if (chain2D.subChainIndices.Length == 0 && (chain2D.target - chain2D.last).sqrMagnitude > chain2D.sqrTolerance)
            {
                return false;
            }
        }

        return true;
    }
    private static void Forward(Vector2 targetPosition, Vector2 strechDiff, IList<float> lengths, float[] lengthRatios, ref Vector2[] positions)
    {
        int positionsLastIndex = positions.Length - 1;
        positions[positionsLastIndex] = targetPosition;
        for (int index = positionsLastIndex - 1; index >= 0; index--)
        {
            float difference = (positions[index + 1] - positions[index]).magnitude;
            float ratio = lengths[index] / difference;
            Vector2 stretch = strechDiff * lengthRatios[index];
            // Debug.Log($"Strech {index}: {stretch}");
            // These calculates how the movement of the forward position affects the position of the
            // current based on the difference ratio ocurred when the forward position was moved.
            positions[index] = (1f - ratio) * positions[index + 1] + ratio * positions[index] + stretch;
        }
    }

    private static void Backward(Vector2 originPosition, Vector2 strechDiff, IList<float> lengths, float[] lengthRatios, ref Vector2[] positions)
    {
        int positionsLastIndex = positions.Length - 1;
        positions[0] = originPosition;
        for (int index = 0; index < positionsLastIndex; index++)
        {
            float difference = (positions[index + 1] - positions[index]).magnitude;
            float ratio = lengths[index] / difference;
            Vector2 stretch = strechDiff * lengthRatios[index];
            // Debug.Log($"stretch {index}: {stretch}");
            // These calculates how the movement of the forward position affects the position of the
            // current based on the difference ratio ocurred when the forward position was moved.
            positions[index + 1] = (1f - ratio) * positions[index] + ratio * positions[index + 1] + stretch;
        }
    }

    private static Vector2 ValidateJoint(Vector2 endPosition, Vector2 startPosition, Vector2 right, float min, float max)
    {
        Vector2 to = endPosition - startPosition;
        float num = Vector2.SignedAngle(right, to);
        Vector2 result = endPosition;
        if (num < min)
        {
            Quaternion quaternion = Quaternion.Euler(0f, 0f, min);
            result = startPosition + (Vector2)(quaternion * right * to.magnitude);
        }
        else if (num > max)
        {
            Quaternion quaternion2 = Quaternion.Euler(0f, 0f, max);
            result = startPosition + (Vector2)(quaternion2 * right * to.magnitude);
        }

        return result;
    }
}
