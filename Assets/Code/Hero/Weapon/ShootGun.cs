using Code.Animations;
using UnityEngine;

namespace Code.Weapon
{
    public class ShootGun : MonoBehaviour
    {
        [SerializeField]
        private GameObject BulletPrefab;
        [SerializeField]
        private GroundChecker groundChecker;
        [SerializeField]
        private float ShootForce;

        void Update()
        {
            if(Time.timeScale == 0) return;
            if(groundChecker.IsHeroBase) return;
            if (Input.GetMouseButtonDown(0))
            {
                var bullet = Instantiate(BulletPrefab, transform.position, Quaternion.identity);
                
                var bulletRigidBody = bullet.GetComponent<Rigidbody>();
                bulletRigidBody.AddForce(transform.forward * ShootForce, ForceMode.Impulse);
            }
        }
    }
}