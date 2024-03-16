window.triggerResizeEvent = function () {
    var resizeEvent = window.document.createEvent('UIEvents');
    resizeEvent.initUIEvent('resize', true, false, window, 0);
    window.dispatchEvent(resizeEvent);
}

window.scrollToTop = function () {
    window.scrollTo(0, 0);
}