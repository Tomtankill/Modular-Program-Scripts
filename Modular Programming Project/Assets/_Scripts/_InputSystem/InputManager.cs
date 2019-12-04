using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputManager : MonoBehaviour, IInputManager {

    private static InputManager _instance;

    public static IInputManager instance { get { return _instance;  } }

    public static void SetInstance(InputManager instance) {
        if (InputManager._instance == instance) return; // If instance is already set, don't set it again.
        if (InputManager._instance != null) { // If instance is already set, disable me.
            InputManager._instance.enabled = false;
        }
        InputManager._instance = instance; // Set my instance if the other things don't get done.

    }

    private bool _dontDestryOnLoad = true; // Do I kill myself when the scene changes?

    protected virtual void Awake() {
        if (_dontDestryOnLoad) DontDestroyOnLoad(this.transform.root.gameObject); // Don't kill me when the scene changes.
    }

    public bool isEnabled {
        get {
            return this.isActiveAndEnabled;
        }

        set {
            this.enabled = value;
        }
    }

    public abstract bool GetButton(int playerId, InputAction Action);

    public abstract bool GetButtonDown(int playerId, InputAction Action);

    public abstract bool GetButtonUp(int playerId, InputAction Action);

    public abstract float GetAxis(int playerId, InputAction Action);

}
