using UnityEngine;

namespace Prototype._1950s.Game.Scripts.Player
{
    public class CameraController : MonoBehaviour
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