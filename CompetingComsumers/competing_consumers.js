exports.application = function () {
    return app();
}

var queue;

var app = function () {
    this.start = startApplication;
    this.getQueue = getQueue;
    this.submit = submit;
    this.queueSize = queueSize;

    return this;
}
var startApplication = function () {
    if (!queue)
        queue = [];
}
var getQueue = function () {
    return queue;
}
var queueSize = function () {
    return queue ? queue.length : 0;
}

var submit = function (request) {
    if (request) {
        queue.push(request);
    }
}