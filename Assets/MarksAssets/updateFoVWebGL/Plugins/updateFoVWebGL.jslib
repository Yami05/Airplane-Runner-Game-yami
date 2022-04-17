mergeInto(LibraryManager.library, {
	updateFoVWebGL_play: function() {
		if (Module.asmLibraryArg._updateFoVWebGL_play.callUpdateFOV !== undefined) return;
		Module.asmLibraryArg._updateFoVWebGL_play.callUpdateFOV = function callUpdateFOV() {
			const orient = (function() {
				var orientation = (screen.orientation || {}).type || screen.mozOrientation || screen.msOrientation;
				if (!orientation)//safari
					orientation = window.orientation === 0 || window.orientation === 180 ? "portrait-primary" : "landscape";
				return orientation === "portrait-secondary" || orientation === "portrait-primary" ? "portrait" : "landscape";
			})();
            const width = orient === "landscape" && screen.width > screen.height ? screen.height : window.innerWidth;//screen.height for chrome, window.innerWidth for safari
			/*
				Below I attempt to remedy a Safari bug/behavior: when you start on landscape, the innerHeight is smaller than the screen height.
				But after you switch to portrait and back to landscape again, the innerHeight gets the correct value, which is more or less 2 times bigger than screen.height.
				Unfortunately this is not a timing issue. Even after waiting a few seconds, if you start the experience on landscape, the innerHeight does not change until you switch
				orientation modes. Try it out on safari: start the experience on landscape, then switch to portrait, then to landscape again.
				There should be no difference, or a very subtle difference, between the view when you start on landscape, and the landscape view after you switched from portrait.
				If you notice a huge difference, please report to me. I only have one iPhone to debug, I can only hope the behavior is consistent across devices.
			*/
			const height= width  === screen.height ? screen.width : (window.innerHeight < screen.height ? screen.height * 2 : window.innerHeight);
            Module["updateFoVWebGL"].updateFOV(orient, width, height);
            
        };
        Module.asmLibraryArg._updateFoVWebGL_play.callUpdateFOV();
        window.addEventListener("orientationchange", Module.asmLibraryArg._updateFoVWebGL_play.callUpdateFOV);
	},
	updateFoVWebGL_stop: function() {
		if (Module.asmLibraryArg._updateFoVWebGL_play.callUpdateFOV !== undefined) {
			window.removeEventListener("orientationchange", Module.asmLibraryArg._updateFoVWebGL_play.callUpdateFOV);
			Module.asmLibraryArg._updateFoVWebGL_play.callUpdateFOV = undefined;
		}
	}
		
});