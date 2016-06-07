exports.application = function () {
    return app();
}

var queue;
var processedRequests = [];

var app = function () {
    this.start = startApplication;
    this.getQueue = getQueue;
    this.submit = submit;
    this.queueSize = queueSize;
    this.processedRequests = getProcessedRequests;

    return this;
}
var startApplication = function () {
    if (!queue)
        queue = [];
    setInterval(consumer, 100);
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

var getProcessedRequests = function() {
    return processedRequests;
}

var consumer = function() {
    while (queue.length > 0) {
        var request = queue.shift();
        request.execute();

        processedRequests.push(request);
    }
}