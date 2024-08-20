using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TreeNode
{
    public int value;
    public TreeNode leftChild;
    public TreeNode rightChild;

    public TreeNode(int v)
    {
        value = v;
    }
}

public class BinaryTree : MonoBehaviour
{
    private TreeNode startNode;
    private string NodeValueStr = "";

    private void Start()
    {
        AddTree();

        //LevelOrder(startNode);

        NodeValueStr = "";
        PreOrder(startNode);
        Debug.Log("前序：" + NodeValueStr);

        NodeValueStr = "";
        PreOrderLoop(startNode);
        Debug.Log("前序：" + NodeValueStr);

        NodeValueStr = "";
        InOrder(startNode);
        Debug.Log("中序：" + NodeValueStr);

        NodeValueStr = "";
        InOrderLoop(startNode);
        Debug.Log("中序：" + NodeValueStr);

        NodeValueStr = "";
        PostOrder(startNode);
        Debug.Log("后序：" + NodeValueStr);

        NodeValueStr = "";
        PostOrderLoopPreNode(startNode);
        Debug.Log("后序：" + NodeValueStr);

        NodeValueStr = "";
        PostOrderLoopHashSet(startNode);
        Debug.Log("后序：" + NodeValueStr);
    }

    public void AddTree()
    {
        TreeNode node = new TreeNode(1);
        startNode = node;
        node.leftChild = new TreeNode(2);
        node.leftChild.leftChild = new TreeNode(3);
        node.leftChild.leftChild.leftChild = new TreeNode(4);
        node.leftChild.leftChild.rightChild = new TreeNode(5);
        node.leftChild.rightChild = new TreeNode(6);
        node.leftChild.rightChild.leftChild = new TreeNode(7);
        node.rightChild = new TreeNode(8);
        node.rightChild.leftChild = new TreeNode(9);
        node.rightChild.rightChild = new TreeNode(10);
    }

    //前序遍历 中左右  递归
    public void PreOrder(TreeNode node)
    {
        if (node != null)
        {
            NodeValueStr += node.value.ToString() + "、";

            PreOrder(node.leftChild);
            PreOrder(node.rightChild);
        }
    }

    //前序遍历 中左右  非递归
    public void PreOrderLoop(TreeNode _node)
    {
        Stack<TreeNode> stack = new Stack<TreeNode>();
        TreeNode node = _node;
        while (node != null || stack.Any()) //确定序列是否包含任何元素
        {
            if (node != null)
            {
                stack.Push(node);
                NodeValueStr += node.value.ToString() + "、";
                node = node.leftChild;
            }
            else
            {
                var temNode = stack.Pop();
                node = temNode.rightChild;
            }
        }
    }

    //中序遍历 左中右  递归
    public void InOrder(TreeNode node)
    {
        if (node != null)
        {
            InOrder(node.leftChild);
            NodeValueStr += node.value.ToString() + "、";
            InOrder(node.rightChild);
        }
    }

    //中序遍历 左中右  非递归
    public void InOrderLoop(TreeNode _node)
    {
        Stack<TreeNode> stack = new Stack<TreeNode>();
        TreeNode node = _node;
        while (node != null || stack.Any())
        {
            if (node != null)
            {
                stack.Push(node);
                node = node.leftChild;
            }
            else
            {
                var temNode = stack.Pop();
                NodeValueStr += temNode.value.ToString() + "、";
                node = temNode.rightChild;
            }
        }
    }

    //中序遍历 左右中  递归
    public void PostOrder(TreeNode node)
    {
        if (node != null)
        {
            PostOrder(node.leftChild);

            PostOrder(node.rightChild);
            NodeValueStr += node.value.ToString() + "、";
        }
    }

    //中序遍历 左右中  非递归 存储上一个变量
    public void PostOrderLoopPreNode(TreeNode _node)
    {
        Stack<TreeNode> stack = new Stack<TreeNode>();
        TreeNode node = _node;
        TreeNode pre = null;
        stack.Push(node);
        while (stack.Any())
        {
            node = stack.Peek();
            if ((node.leftChild == null && node.rightChild == null) ||
                (pre != null && (pre == node.leftChild || pre == node.rightChild)))
            {
                NodeValueStr += node.value.ToString() + "、";
                pre = node;
                stack.Pop();
            }
            else
            {
                if (node.rightChild != null)
                {
                    stack.Push(node.rightChild);
                }
                if (node.leftChild != null)
                {
                    stack.Push(node.leftChild);
                }
            }
        }
    }

    //后序遍历 左右中  非递归 把检测过的节点放入哈希表
    public void PostOrderLoopHashSet(TreeNode _node)
    {
        Stack<TreeNode> stack = new Stack<TreeNode>();
        HashSet<TreeNode> hash = new HashSet<TreeNode>();
        TreeNode node = _node;
        while (node != null || stack.Any())
        {
            if (node != null)
            {
                stack.Push(node);
                node = node.leftChild;
            }
            else
            {
                var temNode = stack.Peek();
                if (temNode.rightChild != null && !hash.Contains(temNode.rightChild))
                {
                    node = temNode.rightChild;
                    hash.Add(node);
                }
                else
                {
                    NodeValueStr += temNode.value.ToString() + "、";
                    hash.Add(node);
                    stack.Pop();
                }
            }
        }
    }

    public void LevelOrder(TreeNode _node)
    {
        Queue<TreeNode> queue = new Queue<TreeNode>();
        TreeNode node = _node;
        queue.Enqueue(node);
        while (queue.Any())
        {
            var temNode = queue.Dequeue();
            NodeValueStr += node.value.ToString() + "、";
            if (temNode.leftChild != null)
            {
                queue.Enqueue(temNode.leftChild);
            }
            if (temNode.rightChild != null)
            {
                queue.Enqueue(temNode.rightChild);
            }
        }
    }
}