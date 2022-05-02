using UnityEngine;

/*
 * CameraProfiler
 * Script for getting Camera to follow the player.
 */
namespace Player
{
    public class CameraProfiler : MonoBehaviour
    {
        private Transform _target;
        private Vector3 _offset;
        public float smoothSpeed = 0.15f;

        private void Start()
        {
            _target = GameObject.FindGameObjectWithTag("Player").transform;
            _offset = transform.position - _target.position;
        }

        // Update camera's desiredPosition of the target.
        private void LateUpdate()
        {
            var desiredPosition = _target.position + _offset;
            transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        }
    }
}