using UnityEngine;

public class AnimationCurveExample : MonoBehaviour
{
   
    [SerializeField] AnimationCurve _curve;

    private void Update()
    {
        transform.Rotate(new Vector3(0,0,_curve.Evaluate(Time.time)));
    }

}
