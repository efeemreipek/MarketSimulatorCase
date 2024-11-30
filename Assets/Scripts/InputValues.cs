using UnityEngine;

[CreateAssetMenu(fileName = "InputValues", menuName = "Scriptable Objects/InputValues")]
public class InputValues : ScriptableObject
{
    public Vector2 Move;
    public Vector2 Look;
    public bool LeftClick;
    public bool RightClick;
    public bool ButtonOne;
    public bool ButtonTwo;
    public bool ButtonThree;
}
