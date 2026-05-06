using UnityEngine;

public class EjemploLerp : MonoBehaviour
{
    [SerializeField] float _lerpSpeed = 1.0f;
    [SerializeField] float _leftPos = 1.0f;
    [SerializeField] float _rightPos = 1.0f;
    [SerializeField,ReadOnlyInInspector] private float _endPos;
    [SerializeField, ReadOnlyInInspector] private float _startPos;
    [SerializeField, ReadOnlyInInspector] private float _lerpValue;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _startPos = _leftPos;
        _endPos = _rightPos;
        _lerpValue = 0;
        transform.position = new Vector3(
            _startPos,
    transform.position.y,
    transform.position.z
);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(
            Mathf.Lerp(_startPos, _endPos, _lerpValue),
            transform.position.y,
            transform.position.z
        );

        _lerpValue += Time.deltaTime * _lerpSpeed;

        if (_lerpValue > 1)
        {
            _lerpValue = 0;
            if (_endPos == _leftPos)
            {
                _endPos = _rightPos;
                _startPos = _leftPos;
            }
            else
            { 
                _endPos = _leftPos;
                _startPos = _rightPos;
            }
        }

    }
}
