#ifndef _EFFECTORRESPCURV_H
#define _EFFECTORRESPCURV_H

#ifdef __cplusplus
extern "C" {
#endif

#define DLL_API _declspec(dllexport)

#ifndef _P_COMPLEX_DATA_
#define _P_COMPLEX_DATA_
typedef struct {
double Magnitude;
double Phase;
} COMPLEX_DATA;
#endif


/*
linePointNum: view point-num in x-ray
viewmode:
0 - logarithmic-view  (default)
1 - linear-view
line will be re-draw when this called
*/
DLL_API void* effectRespCurv_create(int node_num, int linePointNum, int fs, int viewmode);
//获取横坐标的数值组(频率), 长度为linePointNUM
DLL_API int effectRespCurv_get_axisX(void*ins, float axisX[]);

DLL_API int effectRespCurv_add_bqf(void*ins, int ID);
DLL_API int effectRespCurv_add_xover(void*ins, int ID);
DLL_API int effectRespCurv_set_bqf_enable(void*ins, int ID, int enable);
DLL_API int effectRespCurv_set_xover_enable(void*ins, int ID, int enable);
DLL_API int effectRespCurv_set_bqf(void*ins, int ID, int enable, int type, float gain, float q, float freq);
DLL_API int effectRespCurv_set_xover(void*ins, int ID, int enable, int type, int func, float fc, int slope);
DLL_API int effectRespCurv_get_line(void*ins, float ResponseMagdB[]);
DLL_API	int effectRespCurv_get_nodeline(void*ins, int ID, float ResponseMagdB[]);
DLL_API void effectRespCurv_destroy(void*ins);

/*
viewmode:
0 - logarithmic-view  (create default)
1 - linear-view
line will be re-draw when this called
*/
DLL_API int effectRespCurv_ChangeViewMode(void*ins, int viewmode);  //此接口暂不调用


#ifdef __cplusplus
}
#endif

#endif //DllEffector_GUI_H