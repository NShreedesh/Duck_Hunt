using UnityEngine;

namespace Scripts
{
    public class CameraController : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField]
        private InputController inputController;
        private Camera _cam;

        private void Awake()
        {
            _cam = GetComponent<Camera>();
        }

        public Vector3 GetWorldMousePosition()
        {
            Vector3 cursorPosition = _cam.ScreenToWorldPoint(inputController.CursorPosition);
            cursorPosition.z = 0;
            return cursorPosition;
        }
    }
}
