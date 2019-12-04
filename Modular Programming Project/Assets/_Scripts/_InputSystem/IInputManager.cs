﻿public interface IInputManager {
    bool isEnabled { get; set; }
    bool GetButton (int playerId, InputAction Action);
    bool GetButtonDown (int playerId, InputAction Action);
    bool GetButtonUp (int playerId, InputAction Action);
    float GetAxis (int playerId, InputAction Action);

}