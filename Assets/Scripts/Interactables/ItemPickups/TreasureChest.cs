using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureChest : Interactable
{
	private bool received;
	private Animator animator;
	public ItemBase item;
	public int amount;

	private void Start() {
		animator = GetComponent<Animator>();
		if(animator == null){ Debug.LogError("Could not get animator!");}
		if(amount < 0){ Debug.LogError("Item amount cannot be negative!");}
	}

    public override void Interact()
    {
		if (GameManager.Instance.IsState(GameStates.IdleState)) {
                GameManager.Instance.SetState(GameStates.DialogueState);
		}
		//If this treasure chest was never opened before...
        if(!received) {
			StartCoroutine(OpenChest());
		}
		//If this treasure chest was opened already...
		else {
			AlreadyOpened();
		}
    }

	private IEnumerator OpenChest() {
		animator.SetTrigger("Open");
		yield return new WaitForSeconds(0.7f);
		if(item == null) {
			RootNode = new DialogueNode("The chest was empty...");
		}
		else {
			RootNode = new DialogueNode(item.name, amount);
		}
		received = true;
		RootNode.Run(this);
	}

	private void AlreadyOpened() {
		RootNode = new DialogueNode("You already opened this chest.");
		RootNode.Run(this);
	}
}
