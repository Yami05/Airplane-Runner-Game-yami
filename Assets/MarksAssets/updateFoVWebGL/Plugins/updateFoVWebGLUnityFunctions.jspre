Module['updateFoVWebGL'] = Module['updateFoVWebGL'] || {};

Module['updateFoVWebGL'].updateFOV = function(orientation, width, height) {
	this.updateFOVInternal = this.updateFOVInternal || Module.cwrap("updateFoVWebGL_updateFOV", null, ["string", "number", "number"]);
	this.updateFOVInternal(orientation, width, height);
};