using Scripts.Enums;
using Scripts.Interfaces;
using System.Collections;
using System.Linq;
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
            SoundManager.Instance.PlaySFX(shootAudioClip);
            StartCoroutine(ResetShoot());

            RaycastHit2D[] hits = Physics2D.RaycastAll(cameraController.GetWorldMousePosition(), Vector3.zero, 100, shootHitLayerMask);
            if (hits.Length == 0) return;
            foreach(RaycastHit2D hit in hits)
            {
                if (!hit.collider.TryGetComponent(out IShootable shootable)) return;
                shootable.Shot();
            }
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