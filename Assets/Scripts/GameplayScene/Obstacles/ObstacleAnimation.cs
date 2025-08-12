using UnityEngine;

namespace TestProject
{
    [RequireComponent(typeof(Animator))]
    public class ObstacleAnimation : MonoBehaviour
    {
        private readonly int _disappearHash = Animator.StringToHash("Disappear");
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void Disappear()
        {
            _animator.Play(_disappearHash);
        }
    }
}