function dragFunc(id) {
    var Drag = document.getElementById(id);
    var $box = document.getElementById('move_canvas');
    var name = $("#" + id).attr("name");
    Drag.onmousedown = function (event) {
        var ev = event || window.event;
        event.stopPropagation();
        var disX = ev.clientX - Drag.offsetLeft;
        var disY = ev.clientY - Drag.offsetTop;
        change_item_status(name);

        var ev = event || window.event;
        var L = event.clientX - disX;
        var T = event.clientY - disY;

        Drag.style.left = L + "px";
        Drag.style.top = T + "px";
        Drag.style.cursor = "move";
        var itemX = L * 2;
        var itemY = -(T - 240) / 13;
        if (itemX < 0) {
            itemX = 0;
        }
        if (itemX > 2000) {
            itemX = 2000
        }
        if (itemY > 18) {
            itemY = 18;
        }
        if (itemY < -18) {
            itemY = -18;
        }
        change_item_xy(name, itemX, itemY);

        document.onmousemove = function (event) {
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
            if (L > boxW - 3) {
                L = boxW - 3;
            }
            if (T > boxH) {
                T = boxH;
            }
            Drag.style.left = L + "px";
            Drag.style.top = T + "px";
            Drag.style.cursor = "move";
            var itemX = L * 2;
            var itemY = -(T - 240) / 13;
            if (itemX < 0) {
                itemX = 0;
            }
            if (itemX > 2000) {
                itemX = 2000
            }
            if (itemY > 18) {
                itemY = 18;
            }
            if (itemY < -18) {
                itemY = -18;
            }
            change_item_xy(name, itemX, itemY);

        };
    };
    Drag.onmouseup = function () {
        document.onmousemove = null;
        this.style.cursor = "default";
    };

};
dragFunc("eq_item_1");
dragFunc("eq_item_2");
dragFunc("eq_item_3");
dragFunc("eq_item_4");
dragFunc("eq_item_5");
dragFunc("eq_item_6");
dragFunc("eq_item_7");
dragFunc("eq_item_8");
var now_eq_item_id = 0;




function change_item_xy(item_id, itemX, itemY) {
    now_eq_item_id = item_id;
    $("#eq_title").text('EQ_'+(parseInt(item_id)+1));
    var list = window.external.get_dataX();
    var listx = eval("(" + list + ")");
    $("#eq_gain_slider_num").val(Math.floor(itemY));
    $("#eq_freq_slider_num").val(Math.floor(listx[itemX]));
    var q = $("#eq_q_slider_num").val();
    var x = canvas.width;
    var y = canvas.height;
    context.clearRect(0, -y, x, 2 * y);
    slider.setValue(itemY);
    slider1.setValue(listx[itemX]);
    set_node_data(item_id, itemY, q, listx[itemX]);
    get_form_eq_data(context);
    get_node_line(item_id, context);

}

function change_item_status(id) {
    if (id == 0) {
        if (item_status_1.enable == 0) {
            $("#EQ_enable").attr("checked", false);
        }
        else {
            $("#EQ_enable").attr("checked", true);
        }
        var values = item_status_1.filter_type;
        change_item_filter_text(values);
    }
    ;
    if (id == 1) {
        if (item_status_2.enable == 0) {
            $("#EQ_enable").attr("checked", false);
        }
        else {
            $("#EQ_enable").attr("checked", true);
        }
        var values = item_status_2.filter_type;
        change_item_filter_text(values);
    }
    ;
    if (id == 2) {
        if (item_status_3.enable == 0) {
            $("#EQ_enable").attr("checked", false);
        }
        else {
            $("#EQ_enable").attr("checked", true);
        }
        var values = item_status_3.filter_type;
        change_item_filter_text(values);
    }
    ;
    if (id == 3) {
        if (item_status_4.enable == 0) {
            $("#EQ_enable").attr("checked", false);
        }
        else {
            $("#EQ_enable").attr("checked", true);
        }
        var values = item_status_4.filter_type;
        change_item_filter_text(values);
    }
    ;
    if (id == 4) {
        if (item_status_5.enable == 0) {
            $("#EQ_enable").attr("checked", false);
        }
        else {
            $("#EQ_enable").attr("checked", true);
        }
        var values = item_status_5.filter_type;
        change_item_filter_text(values);
    }
    ;
    if (id == 5) {
        if (item_status_6.enable == 0) {
            $("#EQ_enable").attr("checked", false);
        }
        else {
            $("#EQ_enable").attr("checked", true);
        }
        var values = item_status_6.filter_type;
        change_item_filter_text(values);
    }
    ;
    if (id == 6) {
        if (item_status_7.enable == 0) {
            $("#EQ_enable").attr("checked", false);
        }
        else {
            $("#EQ_enable").attr("checked", true);
        }
        var values = item_status_7.filter_type;
        change_item_filter_text(values);
    }
    ;
    if (id == 7) {
        if (item_status_8.enable == 0) {
            $("#EQ_enable").attr("checked", false);
        }
        else {
            $("#EQ_enable").attr("checked", true);
        }
        var values = item_status_8.filter_type;
        change_item_filter_text(values);
    }
    ;
}

function change_item_filter_text(value) {
    if(value==0){$("#filter_type").val("0")}
    else if(value==1){$("#filter_type").val("1")}
    else if(value==2){$("#filter_type").val("2")}
    else if(value==3){$("#filter_type").val("3")}
    else if(value==4){$("#filter_type").val("4")}
    else if(value==5){$("#filter_type").val("5")}
    else if(value==6){$("#filter_type").val("6")}
    else if(value==7){$("#filter_type").val("7")}
    else if(value==8){$("#filter_type").val("8")}
    else if(value==9){$("#filter_type").val("9")}
    else if(value==10){$("#filter_type").val("10")}
    else if(value==11){$("#filter_type").val("11")}
    else if(value==12){$("#filter_type").val("12")}
    else if(value==13){$("#filter_type").val("13")}
}