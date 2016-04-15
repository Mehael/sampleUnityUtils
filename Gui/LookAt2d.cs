using UnityEngine;
using System.Collections;

namespace ExtensionMethods
{
    public static class Extensions
    {
        public static void LookAt2d(this Transform source, Transform target)
        {
            source.LookAt2d(target.position);
        }

        public static void LookAt2d(this Transform source, Vector3 target, float deviation = 0)
        {
            var difference = new Vector2(target.x - source.position.x,
                target.y - source.position.y);

            var angle = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            source.rotation = Quaternion.Euler(new Vector3(0, 0, angle + deviation));
        }
    }
}