using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using U3Dprojecttwo.Movements;
using U3Dprojecttwo.Abstracts.Inputs;
using U3Dprojecttwo.Inputs;
using UnityEngine.InputSystem;

using S = UnityEngine.SerializeField;
using D = UnityEngine.Debug;


namespace U3Dprojecttwo.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        [S] float moveSpeed = 10f;
        [S] float jumpForce = 300f;
        [S] float moveBoundary = 4.5f;


        HorizontalMover _horizontalMover;
        JumpWithRigidbody _jump;
        IInputReader _input;
        float horizontal;
        bool _isJump;

        public float MoveSpeed => moveSpeed;
        public float MoveBoundary => moveBoundary;
        private void Awake()
        {
            _horizontalMover = new HorizontalMover(this);
            _jump = new JumpWithRigidbody(this);
            _input = new InputReader(GetComponent<PlayerInput>());
        }
        private void Update()
        {
            horizontal = _input.Horizontal;
            if (_input.isJump)
            {
                _isJump = true;
            }
        }
        private void FixedUpdate()
        {
            _horizontalMover.TickFixed(horizontal);
            if (_isJump)
            {
                _jump.TickFixed(jumpForce);
            }
            _isJump = false;
        }
    }

}