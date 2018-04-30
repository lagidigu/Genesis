using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeDisplay : MonoBehaviour 
{
	[SerializeField] GameObject Node;
	[SerializeField] GameObject Branch;
	[SerializeField] GameObject Empty;

	public void DisplayTree(List<List<TreeNode>> layeredNodes)
	{
		Transform currentParent = CreateParent ("Tree", layeredNodes[0][0].position, null).transform;

		for (int i = 0; i < layeredNodes.Count; i++)
		{
			currentParent = CreateParent (i.ToString(), layeredNodes[0][0].position, currentParent).transform;
			for (int j = 0; j < layeredNodes[i].Count; j++)
			{
				SpawnNodeWithBranch (layeredNodes[i][j], currentParent);			
			}
		}
	}

	GameObject CreateParent(string name, Vector3 pos, Transform parent)
	{
		GameObject g;
		if (parent != null) 
		{
			g = GameObject.Instantiate (Empty, pos, Quaternion.identity, parent) as GameObject;
		}
		else
		{
			g = GameObject.Instantiate (Empty, pos, Quaternion.identity) as GameObject;
		}
		g.name = name;
		return g;
	}
		
	void SpawnNodeWithBranch(TreeNode node, Transform parent)
	{
		GameObject.Instantiate (Node, node.position, Quaternion.identity, parent);
		if (node.predecessor != null)
		{
			GameObject branch = GameObject.Instantiate (Branch, node.position, Quaternion.identity, parent) as GameObject;
			LineRenderer lr = branch.GetComponent<LineRenderer> ();
			lr.SetPosition (0, node.position);
			lr.SetPosition (1, node.predecessor.position);
		}
	}
}
