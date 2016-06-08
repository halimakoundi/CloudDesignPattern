exports.Queue = function () {
    this._queue = [];
    this.enqueue = function (request) {
        if (request) {
            this._queue.push(request);
        }
    }
    this.equals = function (other) {
        return JSON.stringify(this._queue) == JSON.stringify(other._queue);
    }

    this.peek = function () {
        return this._queue.shift();
    }

    this.hasNext = function () {
        return this._queue.length > 0;
    }
}