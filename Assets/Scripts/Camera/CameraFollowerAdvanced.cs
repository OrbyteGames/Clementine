using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowerAdvanced : MonoBehaviour
{

    [SerializeField]
    Transform _target;


    [Range(0f, 1f), SerializeField]
    float _smoothness = 0.5f;

    [SerializeField]
    bool _isFixed = true;

    Vector3 _positionOffset;
    Quaternion _rotationOffset;


    // Use this for initialization
    void Start()
    {
        if (_target == null)
            _target = GameObject.FindGameObjectWithTag("Player").transform;
        _positionOffset = transform.position-_target.position;
        _rotationOffset = transform.rotation;

    }

    // Update is called once per frame
    void Update()
    {
        if (!_isFixed)
        {
            transform.position = Vector3.Slerp(transform.position, _target.position + _positionOffset, _smoothness);
        }
        else
        {
            Vector3 nextRotation= Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(_target.position - transform.position),_smoothness).eulerAngles;
            nextRotation.x = 0;
            transform.rotation = Quaternion.Euler(nextRotation);


        }


    }
}
