using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlyerCube : MonoBehaviour
{
    public float _playerSpeed, playerRotationAngle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float _verticalMovement, _horizontalMovement;
        _verticalMovement = Input.GetAxis("Vertical");
        _horizontalMovement = Input.GetAxis("Horizontal");
        transform.Translate(_horizontalMovement * _playerSpeed * Time.deltaTime, 0, _verticalMovement * _playerSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(transform.up, playerRotationAngle*Time.deltaTime* _playerSpeed);
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(transform.up, -playerRotationAngle*Time.deltaTime*_playerSpeed);
        }
    }
}
