using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeClassCentered : MonoBehaviour
{
    /*
    //TODO: Split the up into different parts as soon as a structure is established. 
    [SerializeField] public float energy;
    float energyThreshold; //The minimal amount that the energy can be surpassed 

    List<TreeNode> nodes;
    List<List<TreeNode>> layeredNodes;

    int currentGenerationLayer;

    [SerializeField] Vector2 lengthInterval = new Vector2(.1f, 5f);
    [SerializeField] Vector2 xRotationInterval;
    [SerializeField] Vector2 yRotationInterval;
    [SerializeField] Vector2 branchFactorInterval;
    [SerializeField] Vector2 polarityInterval = new Vector2(5, 50f); //TODO: Fine-tune

    [SerializeField] Vector2 trunkLengthInterval = new Vector2(5, 25f); //TODO: Fine-tune

    [SerializeField] float lengthEnergyFactor;
    [SerializeField] float rotationEnergyFactor;
    [SerializeField] float branchEnergyFactor;

    [SerializeField] float maxIterations;

    private int trunkLength;

    void Start()
    {
        InitVars();
        GenerateBaseLayer();
        GetComponent<TreeDisplay>().DisplayTree(layeredNodes);
    }

    void InitVars()
    {
        energyThreshold = energy * 0.05f;
        nodes = new List<TreeNode>();
        layeredNodes = new List<List<TreeNode>>();

        trunkLength = (int) Random.Range(trunkLengthInterval.x, trunkLengthInterval.y);
    }

    void GenerateBaseLayer()
    {

    }

    void GenerateTrunk()
    {
        TreeNode node = new TreeNode(position, branchFactor);
        for (int i = 0; i < trunkLength; i++)
        {
            node = new TreeNode(position, node, branchFactor);

        }
    }

    private float GetBranchConstant(float branchFactor)
    {
        if (branchFactor > 0)
        {
            return branchEnergyFactor;
        }
        else
        {
            return 0;
        }
    }

    private void AddToTree(TreeNode node)
    {
        nodes.Add(node);
        if (layeredNodes.Count < currentGenerationLayer + 1)
        {
            layeredNodes.Add(new List<TreeNode>());
        }
        layeredNodes[currentGenerationLayer].Add(node);
    }

    private void SubtractEnergy(float value)
    {
        if (energy - value < 0)
        {
            energy = -Mathf.Infinity;
        }
        else
        {
            energy -= value;
        }
    }
    */
}
