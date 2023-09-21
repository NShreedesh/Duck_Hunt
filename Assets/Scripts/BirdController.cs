using Scripts.ConstantVariables;
using Scripts.Interfaces;
using System.Collections;
using UnityEngine;

namespace Scripts
{
    public class BirdController : MonoBehaviour, IShootable
    {
        [Header("Components")]
        [SerializeField]
        private Animator anim;

        [Header("Bird Death Values")]
        private bool isBirdDead;

        public void Shot()
        {
            if (isBirdDead) return;

            isBirdDead = true;
            anim.Play(BirdConstants.ShotHash);
            StartCoroutine(PlayerDeadCoroutine());
        }

        private IEnumerator PlayerDeadCoroutine()
        {
            yield return new WaitForSeconds(0.2f);
            anim.Play(BirdConstants.DeadHash);
        }

        private void OnDisable()
        {
            StopAllCoroutines();
        }
    }
}
