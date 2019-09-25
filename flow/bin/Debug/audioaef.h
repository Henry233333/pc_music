#ifndef _AUDIOAEF_H
#define _AUDIOAEF_H

#ifdef WIN32
#define DLL_API _declspec(dllexport)
#else
#define DLL_API  	
#endif
/*
定义-1
typedef enum _Biquad_Filter_Type_
{
	BiquadFilter_AP1 = 0,
	BiquadFilter_LP1 ,
	BiquadFilter_HP1 ,
	BiquadFilter_LS1 ,
	BiquadFilter_HS1 ,
	BiquadFilter_LP2 ,
	BiquadFilter_HP2 ,
	BiquadFilter_LS2 ,
	BiquadFilter_HS2 ,
	BiquadFilter_PEAK ,
	BiquadFilter_NOTCH,
	BiquadFilter_AP2 ,
	BiquadFilter_BP2,
	BiquadFilter_BP2_0GAIN
} eBiquadFilterType;
*/
/*定义-2
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
*/

typedef int (*savefileCb)(char*filename,void*private_data);

#ifndef _FILE_FUNC_FPTR
#define _FILE_FUNC_FPTR
typedef void* (*fopen_fptr)(const char*filename, const char*mode);
typedef int (*fsize_fptr)(void*stream);
typedef int (*fread_fptr)(void *buffer, int size, int count, void *stream);
typedef int (*fwrite_fptr)(void *buffer, int size, int count, void *stream);
typedef int (*fclose_fptr)(void*stream);
#endif

#ifndef _TIME_COMPUTE_FUNC
#define _TIME_COMPUTE_FUNC
typedef double (*time_ms_get_fptr)(void);
#endif

#ifdef __cplusplus
extern "C" {
#endif
	//fs,算法系统采样率
	//conf_file, 音效配置文件；
	// outbits，process输出数据每个样点bit数(有符号数)，支持16，24； 与输入数据的bit数无关
	//maxFrameLen,允许的最大输入帧长
	DLL_API void* audioaef_create(char*flowtopo_str, char*aefparam_str, int maxInFrameLen, int inchs, int outchs, int infs, int outfs);
	DLL_API int audioaef_destroy(void*ins);
	DLL_API int audioaef_register_fops(fopen_fptr fopen, fsize_fptr fsize, fread_fptr fread, fwrite_fptr fwrite, fclose_fptr fclose);
	DLL_API int audioaef_register_timeFops(time_ms_get_fptr time_ms_get);
	//修改采样率
	DLL_API int audioaef_set_fs(void*ins,int infs, int outfs);
	//设置接收网络保存配置的回调函数，如无则不相应网络保存命令
	DLL_API int audioaef_set_saveFileCb(void*ins,savefileCb func,void*private_data);
	
	//相应网络保存配置指令，file被忽略
	DLL_API int aduioaef_net_saveconfig(void*ins,char*file);
	//相应网络保存配置指令，file被忽略，size为buffer内存大小,成功返回写入buffer大小（含字符串结束符）
	DLL_API int audioaef_save_config2Buffer(void*ins,char*buffer, int size);
	//根据输入帧长计算最大输出帧长；
	//如果输入输出采样率不同，则process每次返回结果会不固定长度，此接口返回最大长度，便于buffer和播放管理
	DLL_API int audioaef_getMaxOutFrame(void*ins,int inFrameLen);

	//return samples
	DLL_API int audioaef_process(void*ins, float*indata[], float*outdata[], int samples);
	DLL_API int audioaef_process_v2(void*ins, char*indata, char*outdata, int samples);
	
	DLL_API int audioaef_save_config(void*ins,char*file);

	//net-server init for audio config api
	DLL_API void* audioRPC_init(int mport, int tcp_port);//return rpc handle
	DLL_API int audioRPC_registerAefIns(void*handle, void*aefIns, char*ins_name);
	DLL_API void audioRPC_close(void* handle);

	//如下为音效参数设置相关API接口,接口中有相关参数运算，故参数如下接口的调用与process接口使用是不同的线程处理，便于音频数据的流程性
	//设置虚拟模块功能使能
	DLL_API int audioaef_set_collection_enable(void*ins, char*name, int enable);
	DLL_API int audioaef_get_collection_enable(void*ins, char*name, int*enable);
	
	
	//获取level分贝值
	DLL_API int audioaef_get_level(void*ins, char*name, float*leveldB);
	// 设置 level enable
	DLL_API int audioaef_set_level_enable(void*ins, char*name, int enable);
	//设置level attack time
	DLL_API int audioaef_set_level_att(void*ins, char*name, float second);
	//设置level release time
	DLL_API int audioaef_set_level_rea(void*ins, char*name, float second);
	//level模块整体参数配置
	DLL_API int audioaef_set_level(void*ins, char*name, int enable, float att_time, float rea_time);
	//level模块整体参数读取
	DLL_API int audioaef_get_levelConfig(void*ins, char*name, int *enable, float *att_time, float *rea_time);
	
	// compressor参数设置
	DLL_API int audioaef_set_compressor_enable(void*ins, char*name, int enable);
	DLL_API int audioaef_set_compressor_att(void*ins, char*name, float second);
	DLL_API int audioaef_set_compressor_rea(void*ins, char*name, float second);
	DLL_API int audioaef_set_compressor_threshold(void*ins, char*name, float dB);
	DLL_API int audioaef_set_compressor_ratio(void*ins, char*name, float ratio);
	//整体参数配置
	DLL_API int audioaef_set_compressor(void*ins, char*name,int enable, float att_time, float rea_time, float threashold, float ratio);
	//整体参数读取
	DLL_API int audioaef_get_compressor(void*ins, char*name,int *enable, float *att_time, float *rea_time, float *threashold, float *ratio);
	DLL_API float audioaef_get_compressor_level(void*ins, char*name);
	
	// 设置 limiter enable
	DLL_API int audioaef_set_limiter_enable(void*ins, char*name, int enable);
	DLL_API int audioaef_set_limiter_threshold(void*ins, char*name, float threshold);	//设置门限值
	DLL_API int audioaef_set_limiter_att(void*ins, char*name, float second);
	DLL_API int audioaef_set_limiter_rea(void*ins, char*name, float second);	
	//整体参数配置
	DLL_API int audioaef_set_limiter(void*ins, char*name, int enable, float att_time, float rea_time, float threashold);
	//整体参数读取
	DLL_API int audioaef_get_limiter(void*ins, char*name, int *enable, float *att_time, float *rea_time, float *threashold);
	
	//设置增益
	DLL_API int audioaef_set_gain_gain(void*ins, char*name, float dB);
	DLL_API int audioaef_set_gain_mute(void*ins, char*name, int mute);
	////整体参数配置
	DLL_API int audioaef_set_gain(void*ins, char*name, int enable, float gaindB, int mute);
	//整体参数读取
	DLL_API int audioaef_get_gain(void*ins, char*name, int *enable, float *gaindB, int *mute);
	
	//设置xover 
	DLL_API int audioaef_set_xover_enable(void*ins, char*name, int enable);
	//0-LP, 1-HP
	DLL_API int audioaef_set_xover_type(void*ins, char*name, int type); 
	DLL_API int audioaef_set_xover_freq(void*ins, char*name, float fc);
	//设置滤波器类型 0 -butterwoth,1 - bessel ；2- Linkwitz-Reily
	DLL_API int audioaef_set_xover_func(void*ins, char*name, int func);
	//设置滤波器斜率，取值如下
	//slope 定义参考定义-2
	DLL_API int audioaef_set_xover_slope(void*ins, char*name, int slope);
	//整体参数配置
	DLL_API int audioaef_set_xover(void*ins, char*name, int enable, int type, int func, float fc, int slope);
	//整体参数读取
	DLL_API int audioaef_get_xover(void*ins, char*name, int *enable, int *type, int *func, float *fc, int *slope);
	

	/*PEQ 滤波器组设置*/
	DLL_API int audioaef_set_peq_enable(void*ins, char*name, int enable);
	//获取peq使能参数
	DLL_API int audioaef_get_peq_enable(void*ins, char*name, int*enable);	
	//滤波器BQF使能 bqf-N段BQF序号： 0-5
	DLL_API int audioaef_set_peq_bqf_enable(void*ins, char*name, int bqfID, int enable);
	//设置滤波器BQF类型，定义如前面注释中的“定义-1”
	DLL_API int audioaef_set_peq_bqf_type(void*ins, char*name, int bqfID, int type);
	DLL_API int audioaef_set_peq_bqf_gain(void*ins, char*name, int bqfID, float gain);
	DLL_API int audioaef_set_peq_bqf_q(void*ins, char*name, int bqfID, float q);
	DLL_API int audioaef_set_peq_bqf_freq(void*ins, char*name, int bqfID, float freq);
	//某一段BQF整体参数配置
	DLL_API int audioaef_set_peq_bqf(void*ins, char*name, int bqfID, int enable, int type, float gain, float q, float freq);
	//某一段BQF整体参数读取
	DLL_API int audioaef_get_peq_bqf(void*ins, char*name, int bqfID, int *enable, int *type, float *gain, float *q, float *freq);

	DLL_API int audioaef_set_geq_enable(void*ins,char*name, int enable);
	DLL_API int audioaef_get_geq_enable(void*ins,char*name, int*enable);
	DLL_API int audioaef_set_geq_bqf(void*ins,char*name, int bqfID, float gain);
	DLL_API int audioaef_get_geq_bqf(void*ins,char*name, int bqfID, float *gain, float *freq);
	
	/*FIR滤波器参数*/
	//optionlist string like "gene:idea:gene1024", caller should make sure typelist already alloc memroy larg enough
	DLL_API int audioaef_get_fir_type_option(void*ins,         char*optionlist);
	DLL_API int audioaef_set_fir_enable(void*ins, char*name, int enable);
	DLL_API int audioaef_set_fir_type(void*ins, char*name, char*type);
	DLL_API int audioaef_set_fir(void*ins, char*name, int enable, char*type);
	DLL_API int audioaef_get_fir(void*ins, char*name, int*enable, char*type); //api will strcpy xxx to type,so type memorysize should not small than 128;

	/*获取deq*/
	DLL_API int audioaef_get_loudeq_option(void * ins, char* optionlist);
	DLL_API int audioaef_set_loudeq_type(void*ins, char*name, char* type);
	DLL_API int audioaef_set_loudeq_enable(void*ins, char*name, int enable);
	DLL_API int audioaef_set_loudeq_time(void*ins, char*name, float time);
	DLL_API int audioaef_set_loudeq(void*ins, char*name, int enable, char*type, float time);
	DLL_API int audioaef_get_loudeq(void*ins, char*name, int *enable, char*type, float*time);//api will strcpy xxx to type,so type memorysize should not small than 128;

	DLL_API int audioaef_set_delay_enable(void*ins, char*name, int enable);
	DLL_API int audioaef_set_delay_time(void*ins, char*name, float ms);
	DLL_API int audioaef_set_delay(void*ins, char*name, int enable, float ms);
	DLL_API int audioaef_get_delay(void*ins, char*name, int*enable, float*ms);


	DLL_API int audioaef_set_noisegt_enable(void*ins, char*name, int enable);
	DLL_API int audioaef_set_noisegt_threshold(void*ins, char*name, float db);
	DLL_API int audioaef_set_noisegt_att(void*ins, char*name, float second);
	DLL_API int audioaef_set_noisegt_rea(void*ins, char*name, float second);
	DLL_API int audioaef_set_noisegt_avg(void*ins, char*name, float second);
	DLL_API int audioaef_set_noisegt(void*ins, char*name, int enable, float threshold, float att_time, float rea_time, float avg_time);
	DLL_API int audioaef_get_noisegt(void*ins, char*name, int *enable, float*threshold, float *att_time, float *rea_time, float*avg_time);	
	
	DLL_API char* audioaef_get_vendor(void*ins);


#ifdef __cplusplus
}
#endif

#endif
