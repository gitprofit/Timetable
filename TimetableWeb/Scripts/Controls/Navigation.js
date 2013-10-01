
var Controls = Controls || {};

Controls.Navigation = function () {

	this._nav = null;
	this._listLevel1 = null;
	this._listLevel2 = null;
	this._currLevel2 = null;
	this._anchLevel1 = null;
	this._repository = null;
}

Controls.Navigation.prototype.bindHtml = function (navHtmlElement) {

	this._nav = $(navHtmlElement);
	this._listLevel1 = this._nav.children().first();
	this._listLevel2 = this._listLevel1.children().children('ul');
	this._anchLevel1 = this._listLevel1.children().children('a');

	this._listLevel2.hide();

	this._anchLevel1.click($.proxy(this._select, this));
	this._anchLevel1.first().click();
}

Controls.Navigation.prototype.bindData = function (repository) {
	
	this._repository = repository;
	this._load('schedule', 'menuSchedule');
	this._load('course', 'menuCourse');
	this._load('instructor', 'menuInstructor');
}

Controls.Navigation.prototype._load = function (controllerName, targetHtmlList) {
	//
}

Controls.Navigation.prototype._select = function (event) {

	this._listLevel2.hide();
	this._currLevel2 = $(event.target).parent().children('ul').show();

	this._nav.width(this._listLevel1.outerWidth(true) + this._currLevel2.outerWidth(true));

	this._nav.height(Math.max(
		this._listLevel1.outerHeight(true),
		this._currLevel2.outerHeight(true)
	));
}