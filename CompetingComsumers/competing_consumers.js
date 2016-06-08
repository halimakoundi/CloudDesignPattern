
var QueueModule = require("./queue.js");

exports.application = function () {
    return app();
}
var queue = new QueueModule.Queue();
var processedRequests = [];

var app = function () {
    this.start = startApplication;
    this.getQueue = getQueue;
    this.submit = submit;
    this.processedRequests = getProcessedRequests;
    this.enqueue = function () { console.log("called in app"); }

    return this;
}
var startApplication = function () {
    //if (!queue)
    //    queue = [];
    
    setInterval(consumer, 100);
}

var getQueue = function () {
    return queue;
}

var submit = function (request) {
    queue.enqueue(request);
}

var getProcessedRequests = function() {
    return processedRequests;
}

var consumer = function() {
    while (queue.hasNext()) {
        var request = queue.peek();
        request.execute();

        processedRequests.push(request);
    }
}
