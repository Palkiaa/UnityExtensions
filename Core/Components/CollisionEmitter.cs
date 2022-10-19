using System;

using UnityEngine;

namespace UnityExtensions
{
    public class CollisionEmitter : MonoBehaviour
    {
        public Collider[] Colliders => GetComponents<Collider>();

        public event EventHandler<Collision> OnEnter;

        public event EventHandler<Collision> OnStay;

        public event EventHandler<Collision> OnExit;

        public event EventHandler<Collider> OnTrigEnter;

        public event EventHandler<Collider> OnTrigStay;

        public event EventHandler<Collider> OnTrigExit;

        private void OnCollisionEnter(Collision collision)
        {
            OnEnter?.Invoke(this, collision);
        }

        private void OnCollisionStay(Collision collision)
        {
            OnStay?.Invoke(this, collision);
        }

        private void OnCollisionExit(Collision collision)
        {
            OnExit?.Invoke(this, collision);
        }

        private void OnTriggerEnter(Collider other)
        {
            OnTrigEnter?.Invoke(this, other);
        }

        private void OnTriggerStay(Collider other)
        {
            OnTrigStay?.Invoke(this, other);
        }

        private void OnTriggerExit(Collider other)
        {
            OnTrigExit?.Invoke(this, other);
        }
    }
}