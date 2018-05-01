using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeIslandSign : Interactable
{
    public override void Interact()
    {

        if (!GetReceived(this)) // if the item from this sign has never been recieved before...
        {
            // CONSTRUCT NODES

            // RootNode IS INHERITED AND MUST BE SET AS THE ROOT NODE AND THEN CALL Run() AT THE END
            RootNode = new DialogueNode("BEWARE: Monster territory ahead.");

            List<string> proceed_questions = new List<string>();
            DialogueNode proceed_node = new DialogueNode(proceed_questions);
            proceed_questions.Add("Will you proceed anyway?");
            proceed_questions.Add("Yes");
            proceed_questions.Add("No");
            proceed_questions.Add("HELL NAW!");

            DialogueNode yes_node = new DialogueNode("Very well then. This may help.");

            DialogueNode yes_item = new DialogueNode("Dauthodagr", 2);

            DialogueNode no_node = new DialogueNode("Good choice.");

            DialogueNode hell_naw_node = new DialogueNode("HEY! Watch your language little lady.");

            DialogueNode give_sword = new DialogueNode("Dauthodagr", 2);

            // ASSEMBLE DIALOGUE TREE

            RootNode.Add(proceed_node);

            List<DialogueNode> proceed_child_nodes = new List<DialogueNode>();
            proceed_node.Add(proceed_child_nodes);

            proceed_child_nodes.Add(yes_node);
            proceed_child_nodes.Add(no_node);
            proceed_child_nodes.Add(hell_naw_node);

            yes_node.Add(give_sword);            
        }
        else 
        {
            RootNode = new DialogueNode("BEWARE: Monster territory ahead.");

            DialogueNode next_message = new DialogueNode("You already got an item from me. Good luck.");

            RootNode.Add(next_message);
        }

        RootNode.Run(this);
    }
}
