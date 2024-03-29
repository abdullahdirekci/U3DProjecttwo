﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using U3Dprojecttwo.Controllers;
namespace U3Dprojecttwo.Movements
{

    public class HorizontalMover
    {
        PlayerController _playerController;
        float _moveSpeed;
        float _moveBoundary;
        public HorizontalMover(PlayerController playerController)
        {
            _playerController = playerController;
            _moveSpeed = _playerController.MoveSpeed;
            _moveBoundary = _playerController.MoveBoundary;
        }
        public void TickFixed(float horizontal)
        {
            if (horizontal == 0f) return;

            _playerController.transform.Translate(Vector3.right * horizontal * Time.deltaTime * _moveSpeed);
            float boundary = Mathf.Clamp(_playerController.transform.position.x, -_moveBoundary, _moveBoundary);
            _playerController.transform.position = new Vector3(boundary, _playerController.transform.position.y, 0f);
        }
    }

}