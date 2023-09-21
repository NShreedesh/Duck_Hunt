using UnityEngine;

namespace Scripts
{
    public class DogConstants : MonoBehaviour
    {
        public const string OneDuckCaught = "dogcaughtoneduck";

        public static int OneDuckCaughtHash { get; }
        static DogConstants()
        {
            OneDuckCaughtHash = Animator.StringToHash(OneDuckCaught);
        }
    }
}
