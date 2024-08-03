using UnityEngine;

namespace Combat.Attacks
{
    public class Projectile : MonoBehaviour
    {
        public float shootForce = 10f;

        public OnHitEffect OnHit { get; set; }
        public Transform ImpactVFX { get; set; }
        public GameObject Attacker { get; set; }

        public void Shoot(Vector2 direction)
        {
            var rb = GetComponent<Rigidbody2D>();
            rb.AddForce(direction * shootForce, ForceMode2D.Impulse);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Instantiate(ImpactVFX);

            if (collision.transform.tag == "Enemy")
            {
                var hitData = new HitData()
                {
                    Target = collision.gameObject,
                    Attacker = Attacker
                };

                foreach (var hit in OnHit.components)
                {
                    hit.GetBehavior().OnHit(hitData);
                }
            }

            Destroy(gameObject);
        }
    }
}