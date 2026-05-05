using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Threading.Tasks;

public class AnimationCurveExample : MonoBehaviour
{
   
    [SerializeField] AnimationCurve _curve;

    private void Update()
    {
        transform.Rotate(new Vector3(0,0,_curve.Evaluate(Time.time)));
    }

}
