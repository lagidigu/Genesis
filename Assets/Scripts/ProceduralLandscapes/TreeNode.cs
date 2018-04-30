using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeNode 
{
	public Vector3 position;
	public TreeNode predecessor;
	public List<TreeNode> successors;
	public int branchFactor;


	public TreeNode(Vector3 position, int branchFactor) //Call this when it is a root node
	{
		this.position = position;
		this.branchFactor = branchFactor;
	}

	public TreeNode(Vector3 position, TreeNode predecessor, int branchFactor)
	{
		this.position = position;
		this.predecessor = predecessor;
		this.branchFactor = branchFactor;
	}
}
