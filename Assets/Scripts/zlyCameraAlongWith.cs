using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zlyCameraAlongWith : MonoBehaviour {

	static Vector3 offset;
	/// <summary>
	/// 摄像机跟随
	/// </summary>
	/// <param name="tf">目标</param>
	/// <param name="speed">每秒移动速度</param>
	/// <param name="XOffset">目标X轴偏移</param>
	/// <param name="YOffset">目标Y轴偏移</param>
	public static void AlongWith(Transform tf, float OriginY = 0f, float speed = 3f, float XOffset = 0f, float YOffset = 0f)
	{
		AlongWith(Camera.main, tf, OriginY, speed, XOffset, YOffset);
	}
	/// <summary>
	/// 摄像机跟随
	/// </summary>
	/// <param name="cam">将要移动的摄像机</param>
	/// <param name="tf">目标</param>
	/// <param name="speed">每秒移动速度</param>
	/// <param name="XOffset">目标X轴偏移</param>
	/// <param name="YOffset">目标Y轴偏移</param>
	public static void AlongWith(Camera cam, Transform tf, float OriginY = 0f, float speed = 3f, float XOffset = 0f, float YOffset = 0f)
	{


		Vector3 v1 = cam.transform.position, v2 = tf.position;
		float size1 = Camera.main.orthographicSize;
		float size2 = 5 + OriginY * 0.1f;
		v2 = new Vector3(v2.x + XOffset, v2.y + YOffset, v2.z);
		float sj = 1f / speed;
		float ms = Time.fixedDeltaTime;
		if (ms >= sj)
			cam.transform.position = new Vector3 (v2.x, v2.y, v1.z);
		else 
			cam.transform.position = new Vector3 (v1.x + (v2.x - v1.x) / sj * ms, v1.y + (v2.y - v1.y) / sj * ms, v1.z);
		
		Camera.main.orthographicSize = size1 + (size2 - size1) / sj * ms;

	}

}
