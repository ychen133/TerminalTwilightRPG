using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueBuilder {

	private DialogueNode current;
	private List<string> answers;
	private List<DialogueNode> branches;

	public DialogueBuilder() {
		current = null;
		answers = new List<string>();
		branches = new List<DialogueNode>();
	}

	/// <summary>
	/// Start defining dialogue nodes after this particular node
	/// </summary>
	/// <param name="n">The particular node</param>
	public void begin(DialogueNode n) {
		current = n;
	}

	/// <summary>
	/// Add a text dialogue node.
	/// </summary>
	/// <param name="text">The text to show.</param>
	public DialogueNode line(string text) {
		DialogueNode d = new DialogueNode(text);
		if(current != null) {
			current.Add(d);
		}
		current = d;
		return current;
	}

	/// <summary>
	/// Add an item-giving node.
	/// </summary>
	/// <param name="item_name">The name of the item.</param>
	/// <param name="quantity">The amount of the item.</param>
	public DialogueNode item(string item_name, int quantity) {
		DialogueNode d = new DialogueNode(item_name, quantity);
		if(current != null) {
			current.Add(d);
		}
		current = d;
		return current;
	}

	/// <summary>
	/// Start defining a fork.
	/// </summary>
	/// <param name="question">The question</param>
	public void fork(string question) {
		answers.Clear();
		answers.Add(question);
	}

	/// <summary>
	/// Finish defining a fork.
	/// </summary>
	public DialogueNode fork() {
		if(answers.Count <= 1) {
			Debug.LogError("The fork must have at least one branch");
			return null;
		}
		DialogueNode d = new DialogueNode(new List<string>(answers));
		d.Add(new List<DialogueNode>(branches));
		answers.Clear();
		branches.Clear();
		if(current != null) {
			current.Add(d);
		}
		current = d;
		return current;
	}


	/// <summary>
	/// Add a branch to the fork.
	/// </summary>
	/// <param name="answer">The text on the answer button.</param>
	/// <param name="text">The dialogue text that follows this branch.</param>
	public DialogueNode branch(string answer, string text) {
		if(answers.Count <= 0) {
			Debug.LogError("You cannot add a branch if you did not start a fork.");
			return null;
		}
		DialogueNode d = new DialogueNode(text);
		answers.Add(answer);
		branches.Add(d);
		return d;
	}

	/// <summary>
	/// Set the next node explicitly
	/// </summary>
	/// <param name="next">The next node</param>
	public DialogueNode jump(DialogueNode next) {
		if(current == null) {
			Debug.LogError("You cannot jump from a null node.");
			return null;
		}
		current.Add(next);
		current = next;
		return current;
	}

	/// <summary>
	/// Mark the end of a conversation
	/// </summary>
	public DialogueNode end() {
		return current;
	}

	/// <summary>
	/// Add extra functionality to the current node when it runs
	/// </summary>
	/// <param name="f"></param>
	public void exec(Action f) {
		if(current == null) {
			Debug.LogError("You cannot add functionality to a null node.");
			return;
		}
		current.AddFunctionality(f);
	}


}
