using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeClass : MonoBehaviour 
{
	//TODO: Split the up into different parts as soon as a structure is established. 
	[SerializeField] public float energy; 
	float energyThreshold; //The maximal amount that a the energy can be surpassed 

	List<TreeNode> nodes;
	List<List<TreeNode>> layeredNodes;

	int currentGenerationLayer;

	[SerializeField] Vector2 lengthInterval = new Vector2(.1f, 5f);
	[SerializeField] Vector2 xRotationInterval;
	[SerializeField] Vector2 yRotationInterval;
	[SerializeField] Vector2 branchFactorInterval;
	[SerializeField] Vector2 polarityInterval = new Vector2(5, 50f); //TODO: Fine-tune

	[SerializeField] float lengthEnergyFactor;
	[SerializeField] float rotationEnergyFactor;
	[SerializeField] float branchEnergyFactor;

	void Start()
	{
		InitVars ();
		GenerateBaseLayer ();
		GetComponent<TreeDisplay> ().DisplayTree (layeredNodes);
	}

	void InitVars()
	{
		energyThreshold = energy * 0.05f; 
		nodes = new List<TreeNode> ();
		layeredNodes = new List<List<TreeNode>> ();
	}

	void GenerateBaseLayer()
	{
		TreeNode root = GenerateRootNode (transform.position, GenerateBranchFactor (), GeneratePolarity());
		List<TreeNode> layer = new List<TreeNode> ();
		layer.Add (root);
		GenerateLayer (layer);

		currentGenerationLayer++;
	}
	void GenerateLayer(List<TreeNode> predecessors)
	{
		List<TreeNode> layer = new List<TreeNode> ();
		for (int i = 0; i < predecessors.Count; i++) 
		{
			for (int j = 0; j < predecessors[i].branchFactor; j++)
			{
				TreeNode node = GenerateTreeNode (predecessors[i], GenerateLength(), GenerateXRotation(), GenerateYRotation(), GenerateBranchFactor(), GeneratePolarity());
				if (node != null) 
				{
					layer.Add (node);
				}
			}
		}
		currentGenerationLayer++;
		if (energy > 0)
		{
			GenerateLayer (layer);
		}
	}

	TreeNode GenerateRootNode(Vector3 position, int branchFactor, float polarity)
	{
		float energySubstraction = GetBranchConstant(branchFactor);
		if (energy - energySubstraction > - energyThreshold)
		{
			TreeNode node = new TreeNode (position, branchFactor);
			AddToTree (node);
			SubtractEnergy(energySubstraction);
			return node;
		}
		return null;
	}
	TreeNode GenerateTreeNode(TreeNode predecessor, float length, float xRotation, float yRotation, int branchFactor, float polarity)
	{
		float energySubstraction = GetEnergyExpenditure(length, xRotation, yRotation, branchFactor);
		if (energy - energySubstraction > - energyThreshold) 
		{
			Vector3 newPos = RotatePointAroundPivot (predecessor.position, predecessor.position + new Vector3(0, length, 0), new Vector3(xRotation, yRotation, 0));
			TreeNode node = new TreeNode (newPos, predecessor, branchFactor);
			AddToTree (node);
			SubtractEnergy(energySubstraction);
			return node;
		}
		return null;
	}

	private void AddToTree(TreeNode node)
	{
		nodes.Add (node);
		if (layeredNodes.Count < currentGenerationLayer + 1)
		{
			layeredNodes.Add (new List<TreeNode>());
		}
		layeredNodes [currentGenerationLayer].Add (node);
	}

	private void SubtractEnergy(float value)
	{
		if (energy - value < 0) 
		{
			energy = - Mathf.Infinity;
		}
		else 
		{
			energy -= value;
		}
	}

	private float GetEnergyExpenditure(float length, float xRotation, float yRotation, float branchFactor)
	{
		return length * lengthEnergyFactor + GetRotationEnergyExpenditure(xRotation, yRotation) + GetBranchConstant(branchFactor);
	}

	private float GetRotationEnergyExpenditure(float xRotation, float yRotation)
	{
		return (Mathf.Abs (xRotation) *  + Mathf.Abs (yRotation)) * rotationEnergyFactor;
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

	private Vector3 RotatePointAroundPivot(Vector3 pivot, Vector3 point, Vector3 angles)
	{
		Vector3 dir = point - pivot;
		dir = Quaternion.Euler (angles) * dir;
		return (dir + pivot);
	}

	float GenerateLength()
	{
		return Random.Range (lengthInterval.x, lengthInterval.y);
	}

	float GenerateXRotation()
	{
		return Random.Range (xRotationInterval.x, xRotationInterval.y);
	}

	float GenerateYRotation()
	{
		return Random.Range (yRotationInterval.x, yRotationInterval.y);
	}

	int GenerateBranchFactor()
	{
		return (int) Random.Range (branchFactorInterval.x, branchFactorInterval.y);
	}

	int GeneratePolarity()
	{
		return (int) Random.Range (polarityInterval.x, polarityInterval.y);
	}
	float GetFalloffDistribution(float startIntensity) //Values need to be between 0 and 1
	{//Start Intensity will determine what chance there is to get the lowest value, and will go down linearly to 0
		float x = Random.Range(0, 1);
		return (1 - x) / startIntensity; 
	}
}
