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
#if UNITY_EDITOR
            HandleMouseInput();
#else
            HandleTouchInput();
#endif
        }
        
        private void HandleMouseInput()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _swipeStartTime = Time.time;
                _swipeStartPosition = Input.mousePosition;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                ProcessEndEvent(Input.mousePosition);
            }
        }
        
        private void HandleTouchInput()
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        _swipeStartTime = Time.time;
                        _swipeStartPosition = touch.position;
                        break;

                    case TouchPhase.Ended:
                        ProcessEndEvent(touch.position);
                        break;
                }
            }
        }
        
        private void ProcessEndEvent(Vector2 endPosition)
        {
            float swipeTime = Time.time - _swipeStartTime;
            float swipeDistance = Vector2.Distance(_swipeStartPosition, endPosition);

            if (swipeTime < _maxSwipeTime && swipeDistance > _minSwipeDistance)
            {
                ProcessSwipe(_swipeStartPosition, endPosition, swipeTime);
            }
            else
            {
                ProcessTap(_swipeStartPosition);
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
            if (swipeTime <= 0) return;

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