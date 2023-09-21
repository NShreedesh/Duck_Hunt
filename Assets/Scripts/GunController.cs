using Scripts.Interfaces;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Scripts
{
    public class GunController : MonoBehaviour
    {
        [Header("Scripts")]
        [SerializeField]
        private InputController inputController;
        [SerializeField]
        private CameraController cameraController;

        [Header("Shoot Values")]
        [SerializeField]
        private LayerMask shootHitLayerMask;
        [SerializeField]
        private float reloadTime = 0.3f;
        private bool _canShoot = true;
        private WaitForSeconds _waitForReloadTime;

        [Header("Audio")]
        [SerializeField]
        private AudioClip shootAudioClip;

        private void Awake()
        {
            _waitForReloadTime = new WaitForSeconds(reloadTime);
        }

        private void OnEnable()
        {
            inputController.ShootInputAction.performed += OnShoot;
        }

        private void OnShoot(InputAction.CallbackContext ctx)
        {
            if (!_canShoot) return;

            _canShoot = false;
            StartCoroutine(ResetShoot());

            RaycastHit2D hit = Physics2D.Raycast(cameraController.GetWorldMousePosition(), Vector3.zero, 100, shootHitLayerMask);
            SoundManager.Instance.PlaySFX(shootAudioClip);

            if (hit.transform == null) return;
            if (!hit.transform.TryGetComponent(out IShootable shootable)) return;

            shootable.Shot();
        }

        private IEnumerator ResetShoot()
        {
            yield return _waitForReloadTime;
            _canShoot = true;
        }

        private void OnDisable()
        {
            inputController.ShootInputAction.performed -= OnShoot;

            StopAllCoroutines();
        }
    }

}