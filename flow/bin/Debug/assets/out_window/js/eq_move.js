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
            if (L < 0) {
                L = 0;
            }
            if (T < 0) {
                T = 0;
            }
            if (L > boxW-3) {
                L = boxW-3;
            }
            if (T > boxH) {
                T = boxH;
            }
            Drag.style.left = L + "px";
            Drag.style.top = T + "px";
            Drag.style.cursor = "move";
            var itemX =L*2;
            var itemY = -(T-240)/13;
            if(itemX<0){
                itemX=0;
            }
            if(itemX>2000){
                itemX=2000
            }
            if(itemY>18){
                itemY=18;
            }
            if(itemY<-18){
                itemY=-18;
            }
            change_item_xy(itemX,itemY);
        };
    };
    Drag.onmouseup = function() {
        document.onmousemove = null;
        this.style.cursor = "default";
    };

};
dragFunc("eq_item_1");
function change_item_xy(itemX,itemY) {
    var list = window.external.get_dataX();
    var listx = eval("("+list+")");
    $("#eq_gain_slider_num").val(Math.floor(itemY));
    $("#eq_freq_slider_num").val(Math.floor(listx[itemX]));
    var q = $("#eq_q_slider_num").val();
    var x = canvas.width;
    var y = canvas.height;
    context.clearRect(0, -y, x, 2*y);
    slider.setValue(itemY);
    slider1.setValue(listx[itemX]);
    get_form_eq_data(context, itemY, q, listx[itemX]);
}