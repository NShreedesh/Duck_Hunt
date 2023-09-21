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

        [Header("Bird Movement")]
        [SerializeField]
        private float speed = 1;
        [SerializeField]
        private float fallSpeed = 1;
        private Vector2 _targetValue;

        [Header("Bird Death Values")]
        [SerializeField]
        private float _deadBirdFallTarget;
        [SerializeField]
        private float waitForDeathFallingTime = 0.2f;
        private bool _isDead;
        private bool _shouldDeadfall;
        private WaitForSeconds _waitForDeathFalling;

        private void Awake()
        {
            _waitForDeathFalling = new WaitForSeconds(waitForDeathFallingTime);
        }

        private void Update()
        {
            if (_isDead)
            {
                if(_shouldDeadfall) DeadFall();
                return;
            }

            Move();
            Turn();
        }

        private void Move()
        {
            if (_targetValue == (Vector2)transform.position)
            {
                _targetValue = new Vector2(Random.Range(-1.25f, 1.25f), Random.Range(0, 0.6f));

                if (_targetValue.y > transform.position.y + 0.3f)
                {
                    anim.Play(BirdConstants.FlyUp);
                }
                else
                {
                    anim.Play(BirdConstants.FlyStraight);
                }
            }

            transform.position = Vector2.MoveTowards(transform.position, _targetValue, Time.deltaTime * speed);
        }

        private void Turn()
        {
            if (_targetValue.x < transform.position.x)
            {
                transform.rotation = Quaternion.Euler(transform.position.x, 180, transform.position.z);
            }
            else if (_targetValue.x > transform.position.x)
            {
                transform.rotation = Quaternion.Euler(transform.position.x, 0, transform.position.z);
            }
        }

        private void DeadFall()
        {
            if (_deadBirdFallTarget == transform.position.y) return;
            
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, _deadBirdFallTarget), Time.deltaTime * fallSpeed);
        }

        public void Shot()
        {
            if (_isDead) return;

            _isDead = true;
            anim.Play(BirdConstants.ShotHash);
            StartCoroutine(PlayerDeadCoroutine());
        }

        private IEnumerator PlayerDeadCoroutine()
        {
            yield return _waitForDeathFalling;
            anim.Play(BirdConstants.DeadHash);
            _shouldDeadfall = true;
        }

        private void OnDisable()
        {
            StopAllCoroutines();
        }
    }
}
