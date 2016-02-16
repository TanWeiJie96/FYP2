using UnityEngine;
using System.Collections;
using InControl;

public class MyCharacterActions : PlayerActionSet
{
    public PlayerAction Left;
    public PlayerAction Right;
    public PlayerAction Up;
    public PlayerAction Down;

    public PlayerAction Jump;
    public PlayerOneAxisAction Move;

    public MyCharacterActions()
    {
        Left = CreatePlayerAction("Move Left");
        Right = CreatePlayerAction("Move Right");
        Up = CreatePlayerAction("Move Up");
        Down = CreatePlayerAction("Move Down");

        Jump = CreatePlayerAction("Jump");

        Move = CreateOneAxisPlayerAction(Left, Right);


    }
}

public class InputSetUp : MonoBehaviour
{
    public MyCharacterActions characterActions;
    public static InputSetUp instance;

    void Awake()
    {
        if (instance == null)
            //if not, set it to this.
            instance = this;
        //If instance already exists:
        else if (instance != this)
            //Destroy this, this enforces our singleton pattern so there can only be one instance of SoundManager.
            Destroy(gameObject);
    }


	// Use this for initialization
	void Start () {
        characterActions = new MyCharacterActions();

        characterActions.Left.AddDefaultBinding(Key.A);
        characterActions.Left.AddDefaultBinding(InputControlType.DPadLeft);

        characterActions.Right.AddDefaultBinding(Key.D);
        characterActions.Right.AddDefaultBinding(InputControlType.DPadRight);

        characterActions.Up.AddDefaultBinding(Key.W);
        characterActions.Up.AddDefaultBinding(InputControlType.DPadDown);

        characterActions.Down.AddDefaultBinding(Key.S);
        characterActions.Down.AddDefaultBinding(InputControlType.DPadUp);

        characterActions.Jump.AddDefaultBinding(Key.Space);
        characterActions.Jump.AddDefaultBinding(InputControlType.Action1);
	}
	
	// Update is called once per frame
	void Update () {
	    
        if(characterActions.Jump.IsPressed)
        {
            Debug.Log("Action 1");
        }
	}
}
