using UnityEngine;
using UnityEngine.InputSystem;

namespace Scripts
{
    public class InputController : MonoBehaviour
    {
        private Input _input;

        [field: Header("Input Values")]
        public Vector2 CursorPosition { get; private set; }

        private void Awake()
        {
            _input = new Input();   
        }

        private void OnEnable()
        {
            _input.Player.CursorPosition.performed += OnCursorMoved;

            _input.Player.Enable();
        }

        private void OnCursorMoved(InputAction.CallbackContext ctx)
        {
            CursorPosition = ctx.ReadValue<Vector2>();
        }

        private void OnDisable()
        {
            _input.Player.Disable();
        }
    }
}
