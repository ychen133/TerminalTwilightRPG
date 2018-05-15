using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAnnoying : Interactable {

	public Sprite MySprite;
	public bool received = false;

    public override void Interact()
    {
        UIManager.Instance.TalkingCharacter.sprite = MySprite;
        UIManager.Instance.DialoguePics.SetActive(true);
        DialogueBuilder D = new DialogueBuilder();
        if(!received) {
            RootNode = new DialogueNode("Hey lady! My name's Anna.");
            D.begin(RootNode);
				D.fork("Do you mind if I ask you a few questions?");
					DialogueNode a = D.branch("Sure!", "Thank you. I'll ask you a series of questions that will test your intelligence. If you pass, I'll give you a special prize!");
					D.branch("Sorry, I'm kinda busy.", "Awww man... That sucks...");
				D.fork();
			
			D.begin(null);
				DialogueNode lose = D.line("Nevermind. I don't want to give you a prize.");
				D.end();

			D.begin(a);
				D.fork("What is 1 + 1?");
					D.branch("3", "ENGH! That's wrong!").Add(lose);
					DialogueNode b2 = D.branch("2", "DING! Correct!");
				D.fork();
			
			D.begin(b2);
				D.fork("What is the color of the sky?");
					DialogueNode c1 = D.branch("Blue", "DING! Correct!");
					DialogueNode c2 = D.branch("Red", "Technically that's correct during dawn and dusk... so DING!");
					D.branch("Green", "ENGH! When have you ever seen a green sky? Ewwww.").Add(lose);
				D.fork();
			
			D.begin(c1);
				D.fork("What is my name?");
					D.branch("Sarah", "ENGH! That's wrong!").Add(lose);
					D.branch("Ella" , "ENGH! That's wrong!").Add(lose);
					DialogueNode d3 = D.branch("Anna", "DING! Correct!");
				DialogueNode c1s = D.fork();
			
			D.begin(c2);
				D.jump(c1s);
			
			
			D.begin(d3);
				D.line("Congrats! You won! Here is your prize. I found it on the ground a few minutes ago.");
				D.item("Bread", 1);
				D.line("Enjoy!");
				D.exec(() => received = true);
				D.end();
        }
        else {
			RootNode = new DialogueNode("Hi again! I don't have any more bread on me, so you'll have to find food elsewhere.");
        }
        RootNode.Run(this);
	}
}
