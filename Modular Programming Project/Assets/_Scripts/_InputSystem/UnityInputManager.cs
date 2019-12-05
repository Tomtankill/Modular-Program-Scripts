using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityInputManager : InputManager {

    [SerializeField] private string _playerAxisPrefix = "";

    [SerializeField] private int _maxNumberOfPlayers = 1;


    [Header("Unity Axis Mappings")] // One String for every action defined in InputAction.
    [SerializeField] private string _moveHorizontalAxis = "Horizontal";
    [SerializeField] private string _moveVerticalAxis = "Vertical";
    [SerializeField] private string _runAxis = "Fire3";
    [SerializeField] private string _jumpAxis = "Jump";
    [SerializeField] private string _spellOneAxis = "Fire1";
    [SerializeField] private string _spellTwoAxis = "Fire2";
    [SerializeField] private string _spellThreeAxis = "";
    [SerializeField] private string _spellFourAxis = "";
    [SerializeField] private string _pauseAxis = "Cancel";

    private Dictionary<int, string>[] _actions;

    protected override void Awake() {
        base.Awake();

        if(InputManager.instance != null) {
            isEnabled = false;
            return;
        }

        SetInstance(this);

        _actions = new Dictionary<int, string>[_maxNumberOfPlayers];

        for(int i = 0; i < _maxNumberOfPlayers; i++) {
            Dictionary<int, string> playerActions = new Dictionary<int, string>();
            _actions[i] = playerActions;
            string prefix = !string.IsNullOrEmpty(_playerAxisPrefix) ? _playerAxisPrefix + i : string.Empty;
            AddAction(InputAction.MoveHorizontal, prefix + _moveHorizontalAxis, playerActions);
            AddAction(InputAction.MoveVertical, prefix + _moveVerticalAxis, playerActions);
            AddAction(InputAction.Run, prefix + _runAxis, playerActions);
            AddAction(InputAction.Jump, prefix + _jumpAxis, playerActions);
            AddAction(InputAction.SpellOne, prefix + _spellOneAxis, playerActions);
            AddAction(InputAction.SpellTwo, prefix + _spellTwoAxis, playerActions);
            AddAction(InputAction.SpellThree, prefix + _spellThreeAxis, playerActions);
            AddAction(InputAction.SpellFour, prefix + _spellFourAxis, playerActions);
            AddAction(InputAction.Pause, prefix + _pauseAxis, playerActions);
        }
    }

    private static void AddAction(InputAction action, string actionName, Dictionary<int, string> actions) {
        if (string.IsNullOrEmpty(actionName)) {
            return;
        }
        actions.Add((int)action, actionName);
    }

    /* The Dictionary
     *             __________________
     *             |[The Dictionary]|
     *             |                |
     * Requires A: |  Key, Value    |
     * Type Value: |  int, string   |
     * An Example: |  2, Fire1;     |
     *             ------------------
     * 
     * The Int will be the Player's Number.
     * The String will be the Action associated to the number in InputAction.
     * 
     */


    public override bool GetButton(int playerId, InputAction action) {
        bool value = Input.GetButton(_actions[playerId][(int) action]);
        return value;
    }

    public override bool GetButtonDown(int playerId, InputAction action) {
        bool value = Input.GetButtonDown(_actions[playerId][(int) action]);
        return value;
    }

    public override bool GetButtonUp(int playerId, InputAction action) {
        bool value = Input.GetButtonUp(_actions[playerId][(int) action]);
        return value;
    }

    public override float GetAxis(int playerId, InputAction action) {
        float value = Input.GetAxis(_actions[playerId][(int) action]);
        return value;
    }
}
