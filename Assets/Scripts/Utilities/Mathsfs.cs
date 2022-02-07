using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mathsfs
{

    public static float FloatModulus(float a, float m)
    {
        float res = a;

        if (a < 0 || m < 0)
        {
            Debug.LogError("Mathfs.FloatModulus : cannot handle negative values");
            return 0f;
        }

        if (res >= 0)
        {
            while (res >= m)
            {
                res -= m;
            }
        }
        return res;
    }

    public static float Remap(float origFrom, float origTo, float targetFrom, float targetTo, float value)
    {
        float rel = Mathf.InverseLerp(origFrom, origTo, value);
        return Mathf.Lerp(targetFrom, targetTo, rel);
    }


    public class Random
    {
        public static Vector3 InsideUnitCone(Vector3 direction, float maxAngle, float minAngle = 0f)
        {
            Vector3 v = UnityEngine.Random.insideUnitSphere;

            float r = Mathf.Sqrt(v.x * v.x + v.y * v.y + v.z * v.z);
            float theta = Mathf.Acos(v.z / r);
            float phi = (v.x == 0) ? Mathf.PI / 2 : Mathf.Atan(v.y / v.x);
            if (v.x < 0) phi += Mathf.PI;

            theta = Remap(0f, Mathf.PI, Mathf.Deg2Rad * minAngle, Mathf.Deg2Rad * maxAngle, theta);

            Vector3 ret = new Vector3(
                r * Mathf.Cos(phi) * Mathf.Sin(theta),
                r * Mathf.Sin(phi) * Mathf.Sin(theta),
                r * Mathf.Cos(theta));

            return Quaternion.LookRotation(direction) * ret;
        }

        public static Vector2 InsideUnitCone2D(float minAngle, float maxAngle)
        {
            Vector2 v = UnityEngine.Random.insideUnitCircle;

            Vector2 vp = new Vector2(
                                   Mathf.Sqrt(v.x * v.x + v.y * v.y),
                                   Mathf.Atan(v.y / v.x));

            vp.y = Remap(-Mathf.PI / 2f, Mathf.PI / 2f, Mathf.Deg2Rad * minAngle, Mathf.Deg2Rad * maxAngle, vp.y);

            return new Vector2(vp.x * Mathf.Cos(vp.y), vp.x * Mathf.Sin(vp.y));
        }
    }


}
