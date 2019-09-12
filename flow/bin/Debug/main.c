#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#include "effectorRespCurv.h"

#pragma comment(lib,"effectorRespCurv.lib")

// Xover Filter Function Type
#define XOVER_BUTTWORTH 		0
#define XOVER_BESSEL			1
#define XOVER_LINKWITZREILY 	2
#define XOVER_BYPASS			3
// Xover Filter Type
#define XOVER_TYPE_LP 	0
#define XOVER_TYPE_HP	1
// Xover Filter Slope
typedef enum _XOVER_SLOPE
{
	XOVER_SLOPE_6 = 0,
	XOVER_SLOPE_12,
	XOVER_SLOPE_18,
	XOVER_SLOPE_24,
	XOVER_SLOPE_30,
	XOVER_SLOPE_36,
	XOVER_SLOPE_48
}eXoverSlope;


typedef enum _Biquad_Filter_Type_
{
	BiquadFilter_AP1 = 0,
	BiquadFilter_LP1,
	BiquadFilter_HP1,
	BiquadFilter_LS1,
	BiquadFilter_HS1,
	BiquadFilter_LP2,
	BiquadFilter_HP2,
	BiquadFilter_LS2,
	BiquadFilter_HS2,
	BiquadFilter_PEAK,
	BiquadFilter_NOTCH,
	BiquadFilter_AP2,
	BiquadFilter_BP2,
	BiquadFilter_BP2_0GAIN
} eBiquadFilterType;

typedef struct
{
	int enable;
	int type;
	float gain;
	float q;
	float freq;
}tbqfParam;


typedef struct
{
	int enable;
	int type;
	int func;
	float fc;
	int slope;
}tXoverParam;

#define EQ_SEGMENT 3


tbqfParam bqftable[EQ_SEGMENT] =
{
	{1, BiquadFilter_PEAK, 3.0, 0.667, 1000},
	{0, BiquadFilter_PEAK, 3.0, 0.667, 1000 },
	{0, BiquadFilter_PEAK, 3.0, 0.667, 3000 }
};

tXoverParam xovertable[] =
{
	{1, XOVER_TYPE_HP, XOVER_BUTTWORTH, 500, XOVER_SLOPE_24 }
};

#define line_len 1500
float curv_axisX[line_len];//每个点的横坐标值
float node_ResponseMagdB[line_len];
float total_ResponseMagdB[line_len];

int main(void)
{
	void*eq1_curv = effectRespCurv_create(4, line_len, 48000, 0);
	int i;
	effectRespCurv_get_axisX(eq1_curv, curv_axisX);
	//添加bqf节点
	for (i = 0; i < EQ_SEGMENT; i++)
	{
		effectRespCurv_add_bqf(eq1_curv, i);
	}
	for (i = 0; i < EQ_SEGMENT; i++)
	{
		effectRespCurv_set_bqf(eq1_curv, i, bqftable[i].enable, bqftable[i].type, bqftable[i].gain, bqftable[i].q, bqftable[i].freq);
	}
	//添加xover节点,如果需要的话
	effectRespCurv_add_xover(eq1_curv, EQ_SEGMENT);
	effectRespCurv_set_xover(eq1_curv, EQ_SEGMENT, xovertable[0].enable, xovertable[0].type,
		xovertable[0].func, xovertable[0].fc, xovertable[0].slope);

	effectRespCurv_get_nodeline(eq1_curv, 0, node_ResponseMagdB);//单独获取第一个bqf的曲线
	effectRespCurv_get_nodeline(eq1_curv, EQ_SEGMENT, node_ResponseMagdB);//单独获取XOVER的曲线
	effectRespCurv_get_line(eq1_curv, total_ResponseMagdB); //获取总体的曲线

	effectRespCurv_destroy(eq1_curv);
	return 0;
}