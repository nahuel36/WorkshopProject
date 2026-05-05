using UnityEngine;

public class EjemploLerp : MonoBehaviour
{
    [SerializeField] float _lerpSpeed = 1.0f;
    [SerializeField] float _startPos = 1.0f;
    [SerializeField] float _endPos = 1.0f;
    [SerializeField,ReadOnlyInInspector]private float _targetPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _targetPos = _endPos;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(
            Mathf.Lerp(transform.position.x, _targetPos, Time.deltaTime * _lerpSpeed),
            transform.position.y,
            transform.position.z
        );

        if (_endPos - transform.position.x < 0.5f)
        {
            _targetPos = _startPos;
        }

        if (transform.position.x - _startPos < 0.5f)
        { 
            _targetPos = _endPos;
        }
    }
}
