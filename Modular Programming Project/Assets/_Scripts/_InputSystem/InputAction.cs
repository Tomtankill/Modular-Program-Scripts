/*
 * JOB:
 * 
 * This Enum's job is to take in every single input that players make.
 * 
 * FUNCTIONALITY:
 * 
 * Every Single action that the player can do NEEDS to be in this script.
 */



public enum InputAction {

    // MOVEMENT // 0 - 6 //
    None = 0,
    MoveHorizontal = 1,
    MoveVertical = 2,
    LookHorizontal = 3,
    LookVertical = 4,
    Run = 5,
    Jump = 6,

    // ABILITIES // 7 - 10 //
    SpellOne = 7,
    SpellTwo = 8,
    SpellThree = 9,
    SpellFour = 10,

    // MISC // 11 - * //
    Pause = 11,

}