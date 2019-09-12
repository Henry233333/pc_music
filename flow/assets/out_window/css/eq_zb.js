//eq坐标系

$(function () {
    var canvas_zb = document.getElementById("bg_canvas");
    var ctx_zb = canvas_zb.getContext('2d');
    ctx_zb.fillStyle = "white";
    ctx_zb.font = "10px '微软雅黑'";
    ctx_zb.textAlign = "left";
    ctx_zb.fillText("+18",5,15);

    ctx_zb.lineWidth = 0.5;
    ctx_zb.strokeStyle = "white";
    ctx_zb.beginPath();
    ctx_zb.lineTo(0,120);
    ctx_zb.lineTo(canvas_zb.width,120);
    ctx_zb.stroke();
    ctx_zb.closePath();
    ctx_zb.fillText("+9",5,120);


    ctx_zb.beginPath();
    ctx_zb.lineTo(0,240);
    ctx_zb.lineTo(canvas_zb.width,240);
    ctx_zb.stroke();
    ctx_zb.closePath();
    ctx_zb.fillText("0",5,240);

    ctx_zb.beginPath();
    ctx_zb.lineTo(0,360);
    ctx_zb.lineTo(canvas_zb.width,360);
    ctx_zb.stroke();
    ctx_zb.closePath();
    ctx_zb.fillText("-9",5,360);
    ctx_zb.fillText("-18",5,475);


    ctx_zb.beginPath();
    ctx_zb.lineTo(1000/3,0);
    ctx_zb.lineTo(1000/3,480);
    ctx_zb.stroke();
    ctx_zb.closePath();
    ctx_zb.fillText("200",1000/3-10,475);

    ctx_zb.beginPath();
    ctx_zb.lineTo(2000/3,0);
    ctx_zb.lineTo(2000/3,480);
    ctx_zb.stroke();
    ctx_zb.closePath();
    ctx_zb.fillText("2k",2000/3-5,475);

    ctx_zb.fillText("20k",980,475);

    ctx_zb.beginPath();
    ctx_zb.lineTo(1000/3/6,0);
    ctx_zb.lineTo(1000/3/6,480);
    ctx_zb.stroke();
    ctx_zb.closePath();
    ctx_zb.beginPath();
    ctx_zb.lineTo(1000/3/3.4,0);
    ctx_zb.lineTo(1000/3/3.4,480);
    ctx_zb.stroke();
    ctx_zb.closePath();
    ctx_zb.beginPath();
    ctx_zb.lineTo(1000/3/2.5,0);
    ctx_zb.lineTo(1000/3/2.5,480);
    ctx_zb.stroke();
    ctx_zb.closePath();
    ctx_zb.fillText("50",1000/3/2.5-5,475);

    ctx_zb.beginPath();
    ctx_zb.lineTo(1000/3/2,0);
    ctx_zb.lineTo(1000/3/2,480);
    ctx_zb.stroke();
    ctx_zb.closePath();

    ctx_zb.beginPath();
    ctx_zb.lineTo(1000/3/1.7,0);
    ctx_zb.lineTo(1000/3/1.7,480);
    ctx_zb.stroke();
    ctx_zb.closePath();

    ctx_zb.beginPath();
    ctx_zb.lineTo(1000/3/1.55,0);
    ctx_zb.lineTo(1000/3/1.55,480);
    ctx_zb.stroke();
    ctx_zb.closePath();

    ctx_zb.beginPath();
    ctx_zb.lineTo(1000/3/1.44,0);
    ctx_zb.lineTo(1000/3/1.44,480);
    ctx_zb.stroke();
    ctx_zb.closePath();

    ctx_zb.beginPath();
    ctx_zb.lineTo(1000/3/1.36,0);
    ctx_zb.lineTo(1000/3/1.36,480);
    ctx_zb.stroke();
    ctx_zb.closePath();
    ctx_zb.fillText("100",1000/3/1.36-5,475);



    ctx_zb.beginPath();
    ctx_zb.lineTo((1000/3)+1000/3/6,0);
    ctx_zb.lineTo((1000/3)+1000/3/6,480);
    ctx_zb.stroke();
    ctx_zb.closePath();
    ctx_zb.beginPath();
    ctx_zb.lineTo((1000/3)+1000/3/3.4,0);
    ctx_zb.lineTo((1000/3)+1000/3/3.4,480);
    ctx_zb.stroke();
    ctx_zb.closePath();
    ctx_zb.beginPath();
    ctx_zb.lineTo((1000/3)+1000/3/2.5,0);
    ctx_zb.lineTo((1000/3)+1000/3/2.5,480);
    ctx_zb.stroke();
    ctx_zb.closePath();
    ctx_zb.fillText("500",(1000/3)+1000/3/2.5-8,475);

    ctx_zb.beginPath();
    ctx_zb.lineTo((1000/3)+1000/3/2,0);
    ctx_zb.lineTo((1000/3)+1000/3/2,480);
    ctx_zb.stroke();
    ctx_zb.closePath();

    ctx_zb.beginPath();
    ctx_zb.lineTo((1000/3)+1000/3/1.7,0);
    ctx_zb.lineTo((1000/3)+1000/3/1.7,480);
    ctx_zb.stroke();
    ctx_zb.closePath();

    ctx_zb.beginPath();
    ctx_zb.lineTo((1000/3)+1000/3/1.55,0);
    ctx_zb.lineTo((1000/3)+1000/3/1.55,480);
    ctx_zb.stroke();
    ctx_zb.closePath();

    ctx_zb.beginPath();
    ctx_zb.lineTo((1000/3)+1000/3/1.44,0);
    ctx_zb.lineTo((1000/3)+1000/3/1.44,480);
    ctx_zb.stroke();
    ctx_zb.closePath();

    ctx_zb.beginPath();
    ctx_zb.lineTo((1000/3)+1000/3/1.36,0);
    ctx_zb.lineTo((1000/3)+1000/3/1.36,480);
    ctx_zb.stroke();
    ctx_zb.closePath();
    ctx_zb.fillText("1k",(1000/3)+1000/3/1.36-5,475);

    ctx_zb.beginPath();
    ctx_zb.lineTo((2000/3)+1000/3/6,0);
    ctx_zb.lineTo((2000/3)+1000/3/6,480);
    ctx_zb.stroke();
    ctx_zb.closePath();
    ctx_zb.beginPath();
    ctx_zb.lineTo((2000/3)+1000/3/3.4,0);
    ctx_zb.lineTo((2000/3)+1000/3/3.4,480);
    ctx_zb.stroke();
    ctx_zb.closePath();
    ctx_zb.beginPath();
    ctx_zb.lineTo((2000/3)+1000/3/2.5,0);
    ctx_zb.lineTo((2000/3)+1000/3/2.5,480);
    ctx_zb.stroke();
    ctx_zb.closePath();
    ctx_zb.fillText("5k",(2000/3)+1000/3/2.5-5,475);


    ctx_zb.beginPath();
    ctx_zb.lineTo((2000/3)+1000/3/2,0);
    ctx_zb.lineTo((2000/3)+1000/3/2,480);
    ctx_zb.stroke();
    ctx_zb.closePath();

    ctx_zb.beginPath();
    ctx_zb.lineTo((2000/3)+1000/3/1.7,0);
    ctx_zb.lineTo((2000/3)+1000/3/1.7,480);
    ctx_zb.stroke();
    ctx_zb.closePath();

    ctx_zb.beginPath();
    ctx_zb.lineTo((2000/3)+1000/3/1.55,0);
    ctx_zb.lineTo((2000/3)+1000/3/1.55,480);
    ctx_zb.stroke();
    ctx_zb.closePath();

    ctx_zb.beginPath();
    ctx_zb.lineTo((2000/3)+1000/3/1.44,0);
    ctx_zb.lineTo((2000/3)+1000/3/1.44,480);
    ctx_zb.stroke();
    ctx_zb.closePath();

    ctx_zb.beginPath();
    ctx_zb.lineTo((2000/3)+1000/3/1.36,0);
    ctx_zb.lineTo((2000/3)+1000/3/1.36,480);
    ctx_zb.stroke();
    ctx_zb.closePath();
    ctx_zb.fillText("10k",(2000/3)+1000/3/1.36-5,475);




});
