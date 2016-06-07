//create queue if not exist
// add messages to the queue
// messages in the queue gets processed

var competingComsumers = require("../competing_consumers.js");

describe("Messages are added to the queue when new request is sent", function () {

    beforeEach(function () {
        jasmine.Clock.useMock();
    });

    it("Should create queue when queue does not exist",
        function () {
            var application = competingComsumers.application();

            application.start();
            var queue = application.getQueue();

            expect(queue).toBeDefined();
        });

    it("should add messages to the queue when request is received",
        function () {
            var application = competingComsumers.application();
            application.start();
            var request = function () { console.log("Request execution"); };

            application.submit(request);
            var queueSize = application.queueSize();

            expect(queueSize).toBe(1);
        });

    it("should process messages from the queue as they get added",
    function () {

        var application = competingComsumers.application();
        application.start();
        var request = {
            'execute': function () {
                if (this.state != "done") {
                    console.log("Request execution");
                    this.state = "done";
                }
            },
            'state': "pending"
        };

        application.submit(request);

        jasmine.Clock.tick(101);

        var processedRequests = application.processedRequests();

        expect(processedRequests.length).toBe(1);
        var requestState = processedRequests.shift().state;
        expect(requestState).toBe("done");
    });

});