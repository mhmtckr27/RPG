using UnityEngine;

namespace RPG
{
    public class ThirdPersonMovement : MonoBehaviour
    {
        [SerializeField] private float _rotateSpeed = 1000f;
        [SerializeField] private float _moveSpeed = 5f;
    
        private Rigidbody _rigidbody;
        private Transform _transform;
        private Animator _animator;
    
        private static readonly int Horizontal = Animator.StringToHash("Horizontal");
        private static readonly int Vertical = Animator.StringToHash("Vertical");
        private float _lookInput;

        [SerializeField] public bool isInputDisabled;

        private void Awake()
        { 
            _rigidbody = GetComponent<Rigidbody>();
            _transform = GetComponent<Transform>();
            _animator = GetComponent<Animator>();
        }

        public void DisableInput()
        {
            isInputDisabled = true;
        }

        private void Update()
        {
            if (isInputDisabled)
                return;
            
            //we add instead of direct set because we may miss some fixedupdates when FPS changes so we don't want to lose any rotation data.
            _lookInput += Input.GetAxis("Mouse X");
        }

        private void FixedUpdate()
        {
            if(isInputDisabled)
                return;
            
            _transform.Rotate(0, _lookInput * _rotateSpeed * Time.deltaTime, 0);
            _lookInput = 0;
            
            float verticalMoveInput = Input.GetAxis("Vertical");
            float horizontalMoveInput = Input.GetAxis("Horizontal");

            if (Input.GetKey(KeyCode.LeftShift))
                verticalMoveInput *= 2;

            Vector3 velocity = new Vector3(horizontalMoveInput, 0, verticalMoveInput);
            velocity.Normalize();
            velocity *= _moveSpeed * Time.fixedDeltaTime;

            Vector3 moveOffset = _transform.rotation * velocity;
            Vector3 newPosition = _transform.position + moveOffset;
        
            _rigidbody.MovePosition(newPosition);
            _animator.SetFloat(Vertical, verticalMoveInput, 0.1f, Time.deltaTime);
            _animator.SetFloat(Horizontal, horizontalMoveInput, 0.1f, Time.deltaTime);
        }
    }
}
