using UnityEditor;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public Gun gun;
    public MountPoint[] mountPoints;
    public Transform target;
    public int range;

    void OnDrawGizmos()
    {
#if UNITY_EDITOR
        // Draw wire sphere representing the range
        Handles.color = Color.yellow;
        Handles.DrawWireDisc(transform.position, Vector3.up, range);

        if (!target) return;

        var dashLineSize = 2f;

        foreach (var mountPoint in mountPoints)
        {
            var hardpoint = mountPoint.transform;
            var from = Quaternion.AngleAxis(-mountPoint.angleLimit / 2, hardpoint.up) * hardpoint.forward;
            var projection = Vector3.ProjectOnPlane(target.position - hardpoint.position, hardpoint.up);

            // Projection line
            Handles.color = Color.white;
            Handles.DrawDottedLine(target.position, hardpoint.position + projection, dashLineSize);

            // Do not draw target indicator when out of angle
            if (Vector3.Angle(hardpoint.forward, projection) > mountPoint.angleLimit / 2)
                return;

            // Target line
            Handles.color = Color.red;
            Handles.DrawLine(hardpoint.position, hardpoint.position + projection);

            // Range line
            Handles.color = Color.green;
            Handles.DrawWireArc(hardpoint.position, hardpoint.up, from, mountPoint.angleLimit, projection.magnitude);
            Handles.DrawSolidDisc(hardpoint.position + projection, hardpoint.up, 0.5f);
#endif
        }
    }

    void Update()
    {
        // Do nothing when no target
        if (!target)
            return;

        // Check if target is within range
        float distanceToTarget = Vector3.Distance(transform.position, target.position);
        if (distanceToTarget > range)
        {
            // Target is outside of range, do not shoot
            return;
        }

        // Aim target
        bool allAimed = true;
        foreach (var mountPoint in mountPoints)
        {
            bool reachAngleLimit;
            bool aimed = mountPoint.Aim(target.position, out reachAngleLimit);

            if (!aimed)
            {
                allAimed = false;
                break; // Exit early if any mount point is not aimed
            }
        }

        // Shoot only when all mount points are aimed and target is within range
        if (allAimed)
        {
            gun.Fire();
        }
    }
}
