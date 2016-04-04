﻿export class SideBarDirective implements ng.IDirective {
	'use strict';

	static create() {
		return {
			replace: true,
			restrict: "A",
			templateUrl: (iElement, iAttrs) => {
				if (!iAttrs.appSidebar) {
					throw new Error("app-sidebar: template url must be provided");
				}

				return iAttrs.appSidebar;

			}

		};

		//////$('.navbar-toggle').click(function () {
		//////	$('.navbar-nav').toggleClass('slide-in');
		//////	$('.side-body').toggleClass('body-slide-in');
		//////	$('#search').removeClass('in').addClass('collapse').slideUp(200);

		//////	/// uncomment code for absolute positioning tweek see top comment in css
		//////	//$('.absolute-wrapper').toggleClass('slide-in');

		//////});

		//////// Remove menu for searching
		//////$('#search-trigger').click(function () {
		//////	$('.navbar-nav').removeClass('slide-in');
		//////	$('.side-body').removeClass('body-slide-in');

		//////	/// uncomment code for absolute positioning tweek see top comment in css
		//////	//$('.absolute-wrapper').removeClass('slide-in');

		//////});

	}

}