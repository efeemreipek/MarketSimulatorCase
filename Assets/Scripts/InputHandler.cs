using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private InputValues inputValues;

    private InputAction actionMove;
    private InputAction actionLook;
    private InputAction actionLeftClick;
    private InputAction actionButtonOne;
    private InputAction actionButtonTwo;
    private InputAction actionButtonThree;
    private InputAction actionRightClick;

    private void OnEnable()
    {
        actionMove = InputSystem.actions.FindAction("Move");
        actionLook = InputSystem.actions.FindAction("Look");
        actionLeftClick = InputSystem.actions.FindAction("Left Click");
        actionRightClick = InputSystem.actions.FindAction("Right Click");
        actionButtonOne = InputSystem.actions.FindAction("Button1");
        actionButtonTwo = InputSystem.actions.FindAction("Button2");
        actionButtonThree = InputSystem.actions.FindAction("Button3");

        actionMove.performed += Move_Performed;
        actionMove.canceled += Move_Canceled;

        actionLook.performed += Look_Performed;
        actionLook.canceled += Look_Canceled;

        actionLeftClick.performed += LeftClick_Performed;
        actionLeftClick.canceled += LeftClick_Canceled;

        actionRightClick.performed += RightClick_Performed;
        actionRightClick.canceled += RightClick_Canceled;

        actionButtonOne.performed += ButtonOne_Performed;
        actionButtonTwo.performed += ButtonTwo_Performed;
        actionButtonThree.performed += ButtonThree_Performed;

        InputSystem.actions.Enable();
    }



    private void OnDisable()
    {
        actionMove.performed -= Move_Performed;
        actionMove.canceled -= Move_Canceled;

        actionLook.performed -= Look_Performed;
        actionLook.canceled -= Look_Canceled;

        actionLeftClick.performed -= LeftClick_Performed;
        actionLeftClick.canceled -= LeftClick_Canceled;

        actionRightClick.performed -= RightClick_Performed;
        actionRightClick.canceled -= RightClick_Canceled;

        actionButtonOne.performed -= ButtonOne_Performed;
        actionButtonTwo.performed -= ButtonTwo_Performed;
        actionButtonThree.performed -= ButtonThree_Performed;

        InputSystem.actions.Disable();
    }

    private void Move_Performed(InputAction.CallbackContext obj) => inputValues.Move = obj.ReadValue<Vector2>();
    private void Move_Canceled(InputAction.CallbackContext obj) => inputValues.Move = obj.ReadValue<Vector2>();
    private void Look_Performed(InputAction.CallbackContext obj) => inputValues.Look = obj.ReadValue<Vector2>();
    private void Look_Canceled(InputAction.CallbackContext obj) => inputValues.Look = obj.ReadValue<Vector2>();
    private void LeftClick_Performed(InputAction.CallbackContext obj) => inputValues.LeftClick = obj.ReadValueAsButton();
    private void LeftClick_Canceled(InputAction.CallbackContext obj) => inputValues.LeftClick = obj.ReadValueAsButton();
    private void RightClick_Performed(InputAction.CallbackContext obj) => inputValues.RightClick = obj.ReadValueAsButton();
    private void RightClick_Canceled(InputAction.CallbackContext obj) => inputValues.RightClick = obj.ReadValueAsButton();
    private void ButtonOne_Performed(InputAction.CallbackContext obj) => inputValues.ButtonOne = obj.ReadValueAsButton();
    private void ButtonTwo_Performed(InputAction.CallbackContext obj) => inputValues.ButtonTwo = obj.ReadValueAsButton();
    private void ButtonThree_Performed(InputAction.CallbackContext obj) => inputValues.ButtonThree = obj.ReadValueAsButton();

}
