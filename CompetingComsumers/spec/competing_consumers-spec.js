//create queue if not exist
// add messages to the queue
// messages in the queue gets processed

var competingComsumers = require("../competing_consumers.js");

describe("Messages are added to the queue when new request is sent", function() {

    it("Should create queue when queue does not exist",
        function() {
            var application = competingComsumers.application();

            application.start();
            var queue = application.getQueue();

            expect(queue).toBeDefined();
        });

    it("should add messages to the queue when request is received",
        function() {
            var application = competingComsumers.application();
            application.start();
            var request = function () { console.log("Request execution"); };

            application.submit(request);

            var queueSize = application.queueSize();
            expect(queueSize).toBe(1);
        });

});