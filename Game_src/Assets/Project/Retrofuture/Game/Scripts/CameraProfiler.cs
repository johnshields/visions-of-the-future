using UnityEngine;

namespace Project.Retrofuture.Game.Scripts
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

        private void LateUpdate()
        {
            var desiredPosition = _target.position + _offset;
            transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        }
    }
}