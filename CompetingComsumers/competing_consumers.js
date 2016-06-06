exports.application = function(){
	return app();
}

var queue ;

var app = function(){
	this.start = startApplication;
	this.getQueue = getQueue;	
	
	return this;
}
var startApplication = function(){
	if(!queue)
		queue = [];
}
var getQueue = function(){
	return queue;
}
