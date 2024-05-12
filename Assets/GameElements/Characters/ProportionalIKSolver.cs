using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.IK;

public class ProportionalIKSolver : Solver2D
{
    private List<ProportionalIKChain> chains = new List<ProportionalIKChain>();

    protected override int GetChainCount()
    {
        return chains.Count;
    }

    public override IKChain2D GetChain(int index)
    {
        return chains[index];
    }

    protected override bool DoValidate()
    {
        // Perform validation checks if needed
        return true; // For simplicity, always return true here
    }

    protected override void DoInitialize()
    {
        // Initialize the solver and create IK chains
        chains.Clear(); // Clear existing chains
        // Add your IK chains here, for example:
        // Define bone transforms and lengths
        Transform[] bones = new Transform[3]; // Example: Assuming 3 bones in the chain
        float[] lengths = new float[2]; // Example: Assuming 2 bone lengths
        // Assign your bone transforms and lengths appropriately
        // Example assignment:
        // bones[0] = transform.Find("Bone0");
        // bones[1] = transform.Find("Bone1");
        // bones[2] = transform.Find("Bone2");
        // lengths[0] = 1.0f;
        // lengths[1] = 1.0f;
        AddChain(bones, lengths); // Add the chain
    }

    protected override void DoPrepare()
    {
        // Prepare data for IK calculations
        // For example, update bone positions, lengths, etc.
    }

    protected override void DoUpdateIK(List<Vector3> effectorPositions)
    {
        // Calculate IK positions and adjust bone lengths proportionally
        if (effectorPositions.Count != chains.Count)
        {
            Debug.LogError("Number of effector positions does not match the number of chains.");
            return;
        }

        for (int i = 0; i < chains.Count; i++)
        {
            ProportionalIKChain chain = chains[i];
            chain.UpdateIK(effectorPositions[i]);
        }
    }

    // Method to add a new chain
    public void AddChain(Transform[] bones, float[] lengths)
    {
        chains.Add(new ProportionalIKChain(bones, lengths));
    }
}

public class ProportionalIKChain : IKChain2D
{
    private Transform[] bones; // Array of bone transforms
    private float[] lengths; // Array of bone lengths

    public ProportionalIKChain(Transform[] _bones, float[] _lengths)
    {
        bones = _bones;
        lengths = _lengths;
    }

    public void UpdateIK(Vector3 effectorPosition)
    {
        // Ensure bones and lengths are properly initialized
        if (bones == null || lengths == null || bones.Length != lengths.Length + 1)
        {
            Debug.LogError("Bones or lengths are not properly initialized.");
            return;
        }

        // Calculate the total length of the chain
        float totalLength = 0f;
        for (int i = 0; i < lengths.Length; i++)
        {
            totalLength += lengths[i];
        }

        // Calculate the direction from the root to the effector
        Vector3 rootToEffector = effectorPosition - bones[0].position;

        // Calculate the new bone positions
        for (int i = 0; i < bones.Length - 1; i++)
        {
            // Calculate the desired bone length
            float desiredLength = lengths[i] + (Vector3.Dot(rootToEffector, bones[i + 1].position - bones[i].position) / totalLength);

            // Adjust the bone position proportionally
            Vector3 direction = (bones[i + 1].position - bones[i].position).normalized;
            bones[i + 1].position = bones[i].position + direction * desiredLength;
        }
    }
}
