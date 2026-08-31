using UnityEngine;

[RequireComponent(typeof(VoiceLimbInputSource))]
public class ExtraLimbController : MonoBehaviour
{
    private ILimbInputSource inputSource;
    private Quaternion restPose;

    public float flexionRange = -100f;   // curl toward palm
    public float abductionRange = 20f; // sideways swing

    void Start()
    {
        inputSource = GetComponent<ILimbInputSource>();
        restPose = transform.localRotation; // capture your -80/0/-45 pose as rest
    }

    void Update()
    {
        Vector2 v = inputSource.GetValue();

        Quaternion flexion = Quaternion.AngleAxis(v.y * flexionRange, Vector3.right);   // curl axis
        Quaternion abduction = Quaternion.AngleAxis(v.x * abductionRange, Vector3.up);  // swing axis

        transform.localRotation = restPose * abduction * flexion;
    }
}