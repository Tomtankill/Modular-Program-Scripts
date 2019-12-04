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

    // MOVEMENT // 0 - 4 //
    None = 0,
    MoveHorizontal = 1,
    MoveVertical = 2,
    Run = 3,
    Jump = 4,

    // ABILITIES // 5 - 8 //
    SpellOne = 5,
    SpellTwo = 6,
    SpellThree = 7,
    SpellFour = 8,

    // MISC // 9 - * //
    Pause = 9,

}