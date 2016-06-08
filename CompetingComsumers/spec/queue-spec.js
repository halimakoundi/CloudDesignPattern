var queueModule = require("../queue.js");

describe("Queue Should ", function () {

    it("Be queal to other queue given zero elements ", function () {
        var emptyQueue = new queueModule.Queue();
        var otherEmptyQueue = new queueModule.Queue();

        var areEqual = emptyQueue.equals(otherEmptyQueue);

        expect(areEqual).toBe(true);
    });

    it("Not be equal to other queue with different number of elements ", function () {
        var nonEmptyQueue = new queueModule.Queue();
        var emptyQueue = new queueModule.Queue();
        var request = 1;
        nonEmptyQueue.enqueue(request);

        var areEqual = nonEmptyQueue.equals(emptyQueue);

        expect(areEqual).toBe(false);
    });

    it("Not Enqueue invalid requests as they are submitted",
       function () {
           var queue = new queueModule.Queue();
           var invalidRequest = null;
           queue.enqueue(invalidRequest);

           var hasNext = queue.hasNext();

           expect(hasNext).toBe(false);
       });

    it("Enqueue requests as they are submitted",
        function () {
            var queue = new queueModule.Queue();
            var request = 1;
            queue.enqueue(request);

            var peekedRequest = queue.peek();

            expect(peekedRequest).toBe(request);
        });

    it("Return false when asked hasNext and is empty ",
    function () {
        var emptyQueue = new queueModule.Queue();

        var hasNext = emptyQueue.hasNext();

        expect(hasNext).toBe(false);
    });

    it("Return true when asked hasNext and is not empty ",
    function () {
        var queue = new queueModule.Queue();
        var request = 1;
        queue.enqueue(request);

        var hasNext = queue.hasNext();

        expect(hasNext).toBe(true);
    });

});