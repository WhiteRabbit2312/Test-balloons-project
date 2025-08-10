using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestProject
{
    public class ObstacleInputHandler : MonoBehaviour
    {
        [Header("Swipe Settings")]
        [SerializeField] private float _minSwipeDistance = 50f;
        [SerializeField] private float _maxSwipeTime = 1f;
        
        [Header("Physics")]
        [SerializeField] private float _swipeForceScale = 0.05f;
        [SerializeField] private float _maxForce = 30f;
        [SerializeField] private LayerMask _interactableLayers;
        
        private Camera _mainCamera;
        private Vector2 _swipeStartPosition;
        private float _swipeStartTime;
        
        private void Awake()
        {
            _mainCamera = Camera.main;
        }
        
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _swipeStartTime = Time.time;
                _swipeStartPosition = Input.mousePosition;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                float swipeTime = Time.time - _swipeStartTime;
                Vector2 swipeEndPosition = Input.mousePosition;
                float swipeDistance = Vector2.Distance(_swipeStartPosition, swipeEndPosition);

                if (swipeTime > 0.02f && swipeTime < _maxSwipeTime && swipeDistance > _minSwipeDistance)
                {
                    ProcessSwipe(_swipeStartPosition, swipeEndPosition, swipeTime);
                }
                else
                {
                    ProcessTap(_swipeStartPosition);
                }
            }
        }
        
        private void ProcessTap(Vector2 screenPosition)
        {
            Ray ray = _mainCamera.ScreenPointToRay(screenPosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity, _interactableLayers);

            if (hit.collider == null) return;

            ICollectable collectable = hit.collider.GetComponent<ICollectable>();
            if (collectable != null)
            {
                collectable.OnCollect();
                return;
            }

            IInteractiveObject interactive = hit.collider.GetComponent<IInteractiveObject>();
            if (interactive != null)
            {
                interactive.OnTap();
            }
        }
        
        private void ProcessSwipe(Vector2 startPos, Vector2 endPos, float swipeTime)
        {
            Ray ray = _mainCamera.ScreenPointToRay(startPos);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity, _interactableLayers);

            if (hit.collider != null)
            {
                IInteractiveObject interactive = hit.collider.GetComponent<IInteractiveObject>();
                if (interactive != null)
                {
                    Vector2 swipeVelocity = (endPos - startPos) / swipeTime;
                    Vector2 forceToApply = swipeVelocity * _swipeForceScale;
                    forceToApply = Vector2.ClampMagnitude(forceToApply, _maxForce);
                    interactive.OnSwipe(forceToApply);
                }
            }
        }
    }
}