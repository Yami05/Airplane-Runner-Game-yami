using AOT;
using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace MarksAssets.updateFoVWebGL {
	public class updateFoVWebGL : MonoBehaviour {
		[DllImport("__Internal", EntryPoint="updateFoVWebGL_play")]
		public static extern void Play();//starts adjusting field of view.
		
		[DllImport("__Internal", EntryPoint="updateFoVWebGL_stop")]
		public static extern void Stop();//stops adjusting field of view. Don't see a use case for this, but the option is here.
		
		[DllImport("__Internal", EntryPoint="updateFoVWebGL_setUnityFunction")]
		private static extern void setUnityFunction(Action<string, int, int> _updateFOV);
		
		public bool autostart = true;//default is true to begin adjusting the field of view since the app starts
		private static float initialFOV;//initial field of view.
		private static Camera cam;//the camera this script is attached to.
		
		void Awake() {
			cam = this.GetComponent<Camera>();
			initialFOV = cam.fieldOfView;
			#if UNITY_WEBGL && !UNITY_EDITOR
			/**
				reference method updateFOV so it can be called from javascript later. 
				This is more efficient and generic, avoiding the need to use a hardcoded name with unityInstance.sendMessage
			**/
			setUnityFunction(updateFOV);
			#endif
		}

		void Start() {
			#if UNITY_WEBGL && !UNITY_EDITOR
			if (autostart)
				Play();//updates field of view from the start
			#endif
		}

		/**
			updates the field of view. Called from javascript. This is to avoid the zoom out when you switch from portrait to landscape.
		**/
		[MonoPInvokeCallback(typeof(Action<string, int, int>))]
		private static void updateFOV(string orientation, int width, int height) {
			cam.fieldOfView = orientation == "portrait" ? initialFOV : Camera.HorizontalToVerticalFieldOfView(initialFOV, (float)height/(float)width);
		}
	}
}
