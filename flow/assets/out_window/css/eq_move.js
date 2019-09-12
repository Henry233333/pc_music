function dragFunc(id) {
    var Drag = document.getElementById(id);
    var $box = document.getElementById('bg_canvas');
    Drag.onmousedown = function(event) {
        var ev = event || window.event;
        event.stopPropagation();
        var disX = ev.clientX - Drag.offsetLeft;
        var disY = ev.clientY - Drag.offsetTop;
        document.onmousemove = function(event) {
            var ev = event || window.event;
            var L = event.clientX - disX;
            var T = event.clientY - disY;
            var boxW = $box.offsetWidth;
            var boxH = $box.offsetHeight;
            var divW = Drag.offsetWidth; //div的宽；
            var divH = Drag.offsetHeight;
            //范围限制
            if (L < 15) {
                L = 15;
            }
            if (T < 15) {
                T = 15;
            }
            //if(L > pW - divW){L = pW - divW;}
            //if(T > pH - divH){T = pH - divH;}
            if (L > boxW - divW) {
                L = boxW - divW;
            }
            if (T > boxH - divH) {
                T = boxH - divH;
            }
            Drag.style.left = L + "px";
            Drag.style.top = T + "px";
            Drag.style.cursor = "move";
        };
    };
    Drag.onmouseup = function() {
        document.onmousemove = null;
        this.style.cursor = "default";
    };
};
dragFunc("eq_item_1");