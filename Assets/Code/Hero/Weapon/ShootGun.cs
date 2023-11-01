using UnityEngine;

namespace Code.Weapon
{
    public class ShootGun : MonoBehaviour
    {
        [SerializeField]
        private GameObject BulletPrefab;
        [SerializeField]
        private float ShootForce;

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var bullet = Instantiate(BulletPrefab, transform.position, Quaternion.identity);
                
                var bulletRigidBody = bullet.GetComponent<Rigidbody>();
                bulletRigidBody.AddForce(transform.forward * ShootForce, ForceMode.Impulse);
            }
        }
    }
}