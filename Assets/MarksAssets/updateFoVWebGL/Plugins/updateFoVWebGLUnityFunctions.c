#include <stdint.h>
#include "emscripten.h"

void (*updateFoVWebGL_updateFOV_ref)();

/**
	store reference to C# method on Scripts/updateFoVWebGL.cs
**/
void updateFoVWebGL_setUnityFunction(void (*_upFOV)()) {
  updateFoVWebGL_updateFOV_ref = _upFOV;
}

/**
	the function below is the function that is actually called
	by javascript. It runs the referenced function from C# set by GyroCamWebGL_setUnityFunction
	Its reference is stored in Plugins/UnityFunctions.jspre using
	cwrap: https://emscripten.org/docs/porting/connecting_cpp_and_javascript/Interacting-with-code.html
	EMSCRIPTEN_KEEPALIVE: https://emscripten.org/docs/api_reference/emscripten.h.html#c.EMSCRIPTEN_KEEPALIVE
**/

void EMSCRIPTEN_KEEPALIVE updateFoVWebGL_updateFOV(const char *orientation, int width, int height) {
  updateFoVWebGL_updateFOV_ref(orientation, width, height);
}