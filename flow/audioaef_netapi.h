#ifndef _AUDIOAEF_H
#define _AUDIOAEF_H

#ifdef WIN32
#define DLL_API _declspec(dllexport)
#else
#define DLL_API  	
#endif

#ifdef __cplusplus
extern "C" {
#endif

typedef void (*sddp_req_cb)(char*resp, char*payload, int hostip, int port);


/*********************************************
 	simple device discovery protocol
***********************************************/

/*
//resp, should be "AEFSRV/1.0 SDP-RESP"
//payload, is vendor name, like "alibaba tianmao"

void sddp_req_callback_demo(char*resp, char*payload, int hostip, int port)
{
	printf("find device from [%x:%d] with resp:[%s] and payload:[%s]",hostip,port, resp, payload);
}
*/
DLL_API int net_sddp_client_open(int local_port,sddp_req_cb cb);
DLL_API int net_sddp_client_send_req(void);
DLL_API void net_sddp_client_close(void);

/*********************************************
	audio effect api through net
***********************************************/

/*
char* uri:  "tpc://xxx.xxx.xxx.xxx:10842"
local_port: local tcp port, can be 0 (system assign)
*/
DLL_API void* net_audioaef_create(char*uri, int local_port);

/*return number of server-end instance, <0:failed
	name is store in nameList[], separated by '&'
*/
DLL_API int net_audioaef_get_callInsNameList(void*ins, char*nameList[]);
DLL_API int net_audioaef_set_callInsName(void*ins, char* callInsName);


//关闭音效处理并且释放资源
DLL_API int net_audioaef_destroy(void*ins);
DLL_API int net_audioaef_save_config(void*ins, char*file);

DLL_API int net_audioaef_set_collection_enable(void*ins, char*name, int enable);
DLL_API int net_audioaef_get_collection_enable(void*ins, char*name, int *enable);

//获取level分贝值
DLL_API int net_audioaef_get_level(void*ins, char*name, float*leveldB);
// 设置 level enable
DLL_API int net_audioaef_set_level_enable(void*ins,char*name, int enable);

//设置level attack time
DLL_API int net_audioaef_set_level_att(void*ins, char*name, float second);

//设置level release time
DLL_API int net_audioaef_set_level_rea(void*ins, char*name, float second);

//level模块整体参数配置
DLL_API int net_audioaef_set_level(void*ins, char*name, int enable, float att_time, float rea_time);

//level模块整体参数读取
DLL_API int net_audioaef_get_levelConfig(void*ins, char*name, int *enable, float *att_time, float *rea_time);
	
// compressor参数设置
DLL_API int net_audioaef_set_compressor_enable(void*ins,char*name, int enable);

DLL_API int net_audioaef_set_compressor_att(void*ins,char*name, float second);

DLL_API int net_audioaef_set_compressor_rea(void*ins, char*name, float second);

DLL_API int net_audioaef_set_compressor_threshold(void*ins, char*name, float dB);
DLL_API int net_audioaef_set_compressor_ratio(void*ins,char*name, float ratio);

//整体参数配置
DLL_API int net_audioaef_set_compressor(void*ins,char*name,int enable, float att_time, float rea_time, float threshold, float ratio);
//整体参数读取
DLL_API int net_audioaef_get_compressor(void*ins,char*name,int *enable, float *att_time, float *rea_time, float *threashold, float *ratio);
DLL_API float net_audioaef_get_compressor_level(void*ins, char*name);

// 设置 limiter enable
DLL_API int net_audioaef_set_limiter_enable(void*ins,char*name, int enable);
//设置门限值
DLL_API int net_audioaef_set_limiter_threshold(void*ins,char*name, float threshold);
//设置limiter attack time
DLL_API int net_audioaef_set_limiter_att(void*ins,char*name, float second);
//设置limiter release time
DLL_API int net_audioaef_set_limiter_rea(void*ins,char*name, float second);
//整体参数配置
DLL_API int net_audioaef_set_limiter(void*ins,char*name, int enable, float att_time, float rea_time, float threshold);
//整体参数读取
DLL_API int net_audioaef_get_limiter(void*ins,char*name, int *enable, float *att_time, float *rea_time, float *threshold);

//设置输入增益
DLL_API int net_audioaef_set_gain_enable(void*ins,char*name, int enable);

DLL_API int net_audioaef_set_gain_gain(void*ins,char*name, float dB);

DLL_API int net_audioaef_set_gain_mute(void*ins,char*name, int mute);

////整体参数配置
DLL_API int net_audioaef_set_gain(void*ins, char*name, int enable, float gaindB, int mute);
//整体参数读取
DLL_API int net_audioaef_get_gain(void*ins, char*name, int *enable, float *gaindB, int *mute);
//设置xover 
DLL_API int net_audioaef_set_xover_enable(void*ins,char*name, int enable);

DLL_API int net_audioaef_set_xover_type(void*ins,char*name, int type); //0-LP, 1-HP

DLL_API int net_audioaef_set_xover_freq(void*ins,char*name, float fc);
//设置滤波器类型 0 -butterwoth,1 - bessel ；2- Linkwitz-Reily
DLL_API int net_audioaef_set_xover_func(void*ins,char*name, int func);
//设置滤波器斜率，取值如下
//slope 定义参考定义-2
DLL_API int net_audioaef_set_xover_slope(void*ins,char*name, int slope);

//整体参数配置
DLL_API int net_audioaef_set_xover(void*ins,char*name, int enable, int type, int func, float fc, int slope);
//整体参数读取
DLL_API int net_audioaef_get_xover(void*ins,char*name, int*enable, int *type, int *func, float *fc, int *slope);

/*PEQ 滤波器组设置*/
DLL_API int net_audioaef_set_peq_enable(void*ins,char*name, int enable);

/*PEQ 滤波器组设置*/
DLL_API int net_audioaef_get_peq_enable(void*ins,char*name, int*enable);


//滤波器BQF使能 bqf-N段BQF序号： 0-5
DLL_API int net_audioaef_set_peq_bqf_enable(void*ins,char*name, int bqfID, int enable);
//设置滤波器BQF类型，定义如前面注释中的“定义-1”
DLL_API int net_audioaef_set_peq_bqf_type(void*ins,char*name, int bqfID, int type);

DLL_API int net_audioaef_set_peq_bqf_gain(void*ins,char*name, int bqfID, float gain);
DLL_API int net_audioaef_set_peq_bqf_q(void*ins,char*name, int bqfID, float q);

DLL_API int net_audioaef_set_peq_bqf_freq(void*ins,char*name, int bqfID, float freq);
//某一段BQF整体参数配置
DLL_API int net_audioaef_set_peq_bqf(void*ins,char*name, int bqfID, int enable,  int type, float gain, float q, float freq);
//某一段BQF整体参数读取
DLL_API int net_audioaef_get_peq_bqf(void*ins,char*name, int bqfID, int* enable, int *type, float *gain, float *q, float *freq);


/*GEQ 滤波器组设置*/
DLL_API int net_audioaef_set_geq_enable(void*ins,char*name, int enable);
DLL_API int net_audioaef_get_geq_enable(void*ins,char*name, int*enable);

//某一段BQF整体参数配置
DLL_API int net_audioaef_set_geq_bqf(void*ins,char*name, int bqfID, float gain);

//某一段BQF整体参数读取
DLL_API int net_audioaef_get_geq_bqf(void*ins,char*name, int bqfID, float *gain, float *freq);
DLL_API int net_audioaef_get_loudeq_option(void * ins, char*optionlist);
DLL_API int net_audioaef_set_loudeq_type(void*ins, char*name, char* type);

DLL_API int net_audioaef_set_loudeq_enable(void*ins, char*name, int enable);
DLL_API int net_audioaef_set_loudeq_time(void*ins, char*name, float time);
DLL_API int net_audioaef_set_loudeq(void*ins, char*name, int enable, char*type, float time);
DLL_API int net_audioaef_get_loudeq(void*ins, char*name, int *enable, char*type,  float*time);
/*FIR滤波器参数*/
DLL_API int net_audioaef_set_fir_enable(void*ins, char*name, int enable);

DLL_API int net_audioaef_get_fir_type_option(void*ins, char*typelist);
DLL_API int net_audioaef_set_fir_type(void*ins, char*name, char*type);
DLL_API int net_audioaef_set_fir(void*ins, char*name, int enable, char*type);
DLL_API int net_audioaef_get_fir(void*ins, char*name, int*enable, char*type); //api will strcpy xxx to type,so type memorysize should not small than 128;


DLL_API int net_audioaef_set_delay_enable(void*ins, char*name, int enable);
DLL_API int net_audioaef_set_delay_time(void*ins, char*name, float ms);
DLL_API int net_audioaef_set_delay(void*ins, char*name, int enable, float ms);
DLL_API int net_audioaef_get_delay(void*ins, char*name, int*enable, float*ms);

DLL_API int net_audioaef_set_noisegt_enable(void*ins, char*name, int enable);
DLL_API int net_audioaef_set_noisegt_threshold(void*ins, char*name, float db);
DLL_API int net_audioaef_set_noisegt_att(void*ins, char*name, float second);
DLL_API int net_audioaef_set_noisegt_rea(void*ins, char*name, float second);
DLL_API int net_audioaef_set_noisegt_avg(void*ins, char*name, float second);
DLL_API int net_audioaef_set_noisegt(void*ins, char*name, int enable, float threshold, float att_time, float rea_time, float avg_time);
DLL_API int net_audioaef_get_noisegt(void*ins, char*name, int *enable, float*threshold, float *att_time, float *rea_time, float*avg_time);


#ifdef __cplusplus
extern "C" {
#endif

#endif


