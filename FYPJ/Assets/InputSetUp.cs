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
    public PlayerAction Accelerate;
    public PlayerAction SwitchPolarity;
    public PlayerAction SwitchToNormal;
    public PlayerAction Boost;
    public PlayerAction Select;

    public PlayerOneAxisAction Move;

    public MyCharacterActions()
    {
        Left = CreatePlayerAction("Move Left");
        Right = CreatePlayerAction("Move Right");
        Up = CreatePlayerAction("Move Up");
        Down = CreatePlayerAction("Move Down");

        Jump = CreatePlayerAction("Jump");
        Accelerate = CreatePlayerAction("Accelerate");
        SwitchPolarity = CreatePlayerAction("Switch Polarity");
        SwitchToNormal = CreatePlayerAction("Switch To Normal");
        Boost = CreatePlayerAction("Boost");
        Select = CreatePlayerAction("Select");


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
        
        characterActions.Left.AddDefaultBinding(Key.LeftArrow);
        characterActions.Left.AddDefaultBinding(InputControlType.DPadLeft);

        characterActions.Right.AddDefaultBinding(Key.RightArrow);
        characterActions.Right.AddDefaultBinding(InputControlType.DPadRight);

        characterActions.Up.AddDefaultBinding(Key.UpArrow);
        characterActions.Up.AddDefaultBinding(InputControlType.DPadDown);

        characterActions.Down.AddDefaultBinding(Key.DownArrow);
        characterActions.Down.AddDefaultBinding(InputControlType.DPadUp);

        characterActions.Accelerate.AddDefaultBinding(Key.Space);
        characterActions.Accelerate.AddDefaultBinding(InputControlType.DPadUp);

        characterActions.SwitchPolarity.AddDefaultBinding(Key.X);
        characterActions.SwitchPolarity.AddDefaultBinding(InputControlType.Action3);

        characterActions.SwitchToNormal.AddDefaultBinding(Key.C);
        characterActions.SwitchToNormal.AddDefaultBinding(InputControlType.Action2);

        characterActions.Jump.AddDefaultBinding(Key.Z);
        characterActions.Jump.AddDefaultBinding(InputControlType.Action1);

        characterActions.Boost.AddDefaultBinding(Key.V);
        characterActions.Boost.AddDefaultBinding(InputControlType.Action4);

        characterActions.Select.AddDefaultBinding(Key.Z);
        characterActions.Select.AddDefaultBinding(InputControlType.Action4);
        
	}
	
	// Update is called once per frame
	void Update () {
	    /*
        if(characterActions.Jump.IsPressed)
        {
            Debug.Log("Action 1");
        }
         */ 
	}
}
