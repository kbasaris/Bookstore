(function(app){
	'use strict'

	app.directive('mainSideBar', mainSideBar);

	function mainSideBar() {
		return {
		    restrict: 'AEC',
			replace: true,
			templateUrl: '/Scripts/Spa/Layout/mainSideBar.html'
		}
	}

})(angular.module('ui'))