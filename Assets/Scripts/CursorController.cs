using UnityEngine;
using UnityEngine.InputSystem;

namespace Scripts
{
    public class CursorController : MonoBehaviour
    {
        [Header("Scripts")]
        [SerializeField]
        private InputController inputController;

        [Header("Components")]
        [SerializeField]
        private Camera cam;

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = false;
        }

        private void Update()
        {
            Vector3 cursorPosition = cam.ScreenToWorldPoint(inputController.CursorPosition);
            cursorPosition.z = 0;
            transform.position = cursorPosition;
        }
    }
}
