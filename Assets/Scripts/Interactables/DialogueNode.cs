/* NAME:            Interactable.cs
 * AUTHOR:          Shinlynn Kuo, Yu-Che Cheng (Jeffrey), Hamza Awad, Emmilio Segovia
 * DESCRIPTION:     The node to construct a dialogue tree in an interactable class.
 * REQUIREMENTS:    None
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueNode : MonoBehaviour
{
        private enum TypeOfNode { QandA, SingleMessage, ItemGiving };
        //if not QandA (single message, or item)
        public string message = "no message";
        public DialogueNode NextNode;
        //if QandA
        public List<string> QandA; //[0] is Question, the rest are Answers
        public List<DialogueNode> children; //next child determined by QandA answer
        private string ItemName;
        private int ItemQuantity = 0; //default: flag that there is no item
        private TypeOfNode MyType;

        /// <summary>
        /// This constructs a single message Node.
        /// next_node is optional, its default is "null" meaning there are noot anymore
        /// Nodes. You may send null for readability if so desired.
        /// </summary>
        public DialogueNode(string new_message)
        {
            message = new_message;
            MyType = TypeOfNode.SingleMessage;
        }

        /// <summary>
        /// This constructs QandA nodes which take in a List<string>.
        /// Index [0] is the question and the rest are answers for the player to choose.
        /// Do not make these null otherwise dialogue will try to send a single message
        /// that does not exist. The lists' nullity are flags for the type of Node it is.
        /// </summary>
        public DialogueNode(List<string> q_and_a)
        {
            QandA = q_and_a;
            MyType = TypeOfNode.QandA;
        }
        
        /// <summary>
        /// This constructs item-giving nodes.
        /// The item will be added to the Inventory when this dialogue's Next() is called.
        /// next_node is optional and defaults to null if the conversation ends here.
        /// These nodes do not send messages since adding an item to inventory automatically
        /// invokes a message to the player of what item(s) is/are obtained.
        /// </summary>
        public DialogueNode(string item_name, int item_quantity)
        {
            ItemName = item_name;
            ItemQuantity = item_quantity;
            MyType = TypeOfNode.ItemGiving;
        }

        /// <summary>
        /// Adds the next Node to be called after the current node
        /// </summary>
        public void Add(DialogueNode next_node)
        {
            if (MyType == TypeOfNode.SingleMessage || MyType == TypeOfNode.ItemGiving)
            {
                NextNode = next_node;
            }
            else
            {
                Debug.LogError("You tried to add a single next node to a QandA node but it should have a List<DialogueNodes> added.");
            }
        }

        /// <summary>
        /// Adds the list of potential next nodes based on the user's response to the dialogue question.
        /// </summary>
        public void Add(List<DialogueNode> children)
        {
            if (MyType == TypeOfNode.QandA)
            {
                this.children = children;
            }
            else
            {
                Debug.LogError("You tried to add a list of children nodes to a dialogue node that is not QandA. Please add a single DialogueNode.");
            }
        }

        /// <summary>
        /// This is invokes the DialogueNode to perform its action.
        /// It decides whether to print a single message, give an item to
        /// inventory, or display a QandA message based on variables set by the constructor.
        /// </summary>
    public void Run(Interactable caller)
        {
        if (ItemQuantity == 0 && QandA == null) {
            UIManager.Instance.RunDialogue(caller, message);
        }
        else if (ItemQuantity > 0) {
            Interactable.AddItem(caller, ItemName, ItemQuantity);
            GameManager.Instance.SetReceived(caller.GetType().ToString());
        }
        else {
            UIManager.Instance.RunDialogue(caller, QandA);
        }
        }

        /// <summary>
        /// Return the single child of this Node (default).
        /// </summary>
        public DialogueNode GetNext()
        {
            return NextNode;
        }

        /// <summary>
        /// Overrides the default Next() function for when a particular
        /// child needs to be called based on the player's answer to a QandA.
        /// </summary>
        public DialogueNode GetNext(int child_answer)
        {
            if (child_answer >= 0 && child_answer <= children.Count) {
                return children[child_answer];
            }
            //else
            Debug.LogError("Out of range response to QandA.");
            return null;
        }

        public bool HasNext()
        {
            if (!ReferenceEquals(NextNode, null) || (!ReferenceEquals(children, null) && children.Count > 0))
                return true;
            //else
            return false;
        }
}
