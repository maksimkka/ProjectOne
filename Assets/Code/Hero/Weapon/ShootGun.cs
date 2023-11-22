using Code.Animations;
using Code.Logger;
using UnityEngine;
using UnityEngine.InputSystem;

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

		private Controls controls;

		private void Awake()
		{
			controls = new Controls();
			controls.Fire.Enable();
		}

		private void OnEnable()
		{
			controls.Fire.Shoot.performed += Shoot;

		}

		private void OnDisable()
		{
			controls.Fire.Disable();

		}

		private void Shoot(InputAction.CallbackContext context)
		{
			if (Time.timeScale == 0) return;
			if (groundChecker.IsHeroBase) return;

			var bullet = Instantiate(BulletPrefab, transform.position, Quaternion.identity);

			var bulletRigidBody = bullet.GetComponent<Rigidbody>();
			bulletRigidBody.AddForce(transform.forward * ShootForce, ForceMode.Impulse);

		}
	}
}