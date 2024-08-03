using UnityEngine;

namespace Combat
{
    public class HitData
    {
        public GameObject Attacker { get; set; }
        public GameObject Target { get; set; }
        public Vector3 HitPoint { get; set; }
        public Vector3 HitDirection { get; set; }
        public float HitStrength { get; set; } //Can be used for Charged attacks. 0 for instantly released, 1 for fully charged
        public float ChargeTime { get; set; }
        public float HitTime { get; set; }
    }
}
