using UnityEngine;

namespace Scripts.ConstantVariables
{
    public static class BirdConstants
    {
        public const string FlyStraight = "fly straight";
        public const string FlyUp = "fly up";
        public const string Shot = "shot";
        public const string Dead = "dead";

        public static int ShotHash { get; }
        public static int DeadHash { get; }
        public static int FlyStraightHash { get; }
        public static int FlyUpHash { get; }

        static BirdConstants()
        {
            FlyStraightHash = Animator.StringToHash(FlyStraight);
            FlyUpHash = Animator.StringToHash(FlyUp);
            ShotHash = Animator.StringToHash(Shot);
            DeadHash = Animator.StringToHash(Dead);
        }
    }
}
