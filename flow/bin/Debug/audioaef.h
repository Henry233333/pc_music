#ifndef _AUDIOAEF_H
#define _AUDIOAEF_H

#ifdef WIN32
#define DLL_API _declspec(dllexport)
#else
#define DLL_API  	
#endif
/*
����-1
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
/*����-2
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
	//fs,�㷨ϵͳ������
	//conf_file, ��Ч�����ļ���
	// outbits��process�������ÿ������bit��(�з�����)��֧��16��24�� ���������ݵ�bit���޹�
	//maxFrameLen,������������֡��
	DLL_API void* audioaef_create(char*flowtopo_str, char*aefparam_str, int maxInFrameLen, int inchs, int outchs, int infs, int outfs);
	DLL_API int audioaef_destroy(void*ins);
	DLL_API int audioaef_register_fops(fopen_fptr fopen, fsize_fptr fsize, fread_fptr fread, fwrite_fptr fwrite, fclose_fptr fclose);
	DLL_API int audioaef_register_timeFops(time_ms_get_fptr time_ms_get);
	//�޸Ĳ�����
	DLL_API int audioaef_set_fs(void*ins,int infs, int outfs);
	//���ý������籣�����õĻص���������������Ӧ���籣������
	DLL_API int audioaef_set_saveFileCb(void*ins,savefileCb func,void*private_data);
	
	//��Ӧ���籣������ָ�file������
	DLL_API int aduioaef_net_saveconfig(void*ins,char*file);
	//��Ӧ���籣������ָ�file�����ԣ�sizeΪbuffer�ڴ��С,�ɹ�����д��buffer��С�����ַ�����������
	DLL_API int audioaef_save_config2Buffer(void*ins,char*buffer, int size);
	//��������֡������������֡����
	//���������������ʲ�ͬ����processÿ�η��ؽ���᲻�̶����ȣ��˽ӿڷ�����󳤶ȣ�����buffer�Ͳ��Ź���
	DLL_API int audioaef_getMaxOutFrame(void*ins,int inFrameLen);

	//return samples
	DLL_API int audioaef_process(void*ins, float*indata[], float*outdata[], int samples);
	DLL_API int audioaef_process_v2(void*ins, char*indata, char*outdata, int samples);
	
	DLL_API int audioaef_save_config(void*ins,char*file);

	//net-server init for audio config api
	DLL_API void* audioRPC_init(int mport, int tcp_port);//return rpc handle
	DLL_API int audioRPC_registerAefIns(void*handle, void*aefIns, char*ins_name);
	DLL_API void audioRPC_close(void* handle);

	//����Ϊ��Ч�����������API�ӿ�,�ӿ�������ز������㣬�ʲ������½ӿڵĵ�����process�ӿ�ʹ���ǲ�ͬ���̴߳���������Ƶ���ݵ�������
	//��������ģ�鹦��ʹ��
	DLL_API int audioaef_set_collection_enable(void*ins, char*name, int enable);
	DLL_API int audioaef_get_collection_enable(void*ins, char*name, int*enable);
	
	
	//��ȡlevel�ֱ�ֵ
	DLL_API int audioaef_get_level(void*ins, char*name, float*leveldB);
	// ���� level enable
	DLL_API int audioaef_set_level_enable(void*ins, char*name, int enable);
	//����level attack time
	DLL_API int audioaef_set_level_att(void*ins, char*name, float second);
	//����level release time
	DLL_API int audioaef_set_level_rea(void*ins, char*name, float second);
	//levelģ�������������
	DLL_API int audioaef_set_level(void*ins, char*name, int enable, float att_time, float rea_time);
	//levelģ�����������ȡ
	DLL_API int audioaef_get_levelConfig(void*ins, char*name, int *enable, float *att_time, float *rea_time);
	
	// compressor��������
	DLL_API int audioaef_set_compressor_enable(void*ins, char*name, int enable);
	DLL_API int audioaef_set_compressor_att(void*ins, char*name, float second);
	DLL_API int audioaef_set_compressor_rea(void*ins, char*name, float second);
	DLL_API int audioaef_set_compressor_threshold(void*ins, char*name, float dB);
	DLL_API int audioaef_set_compressor_ratio(void*ins, char*name, float ratio);
	//�����������
	DLL_API int audioaef_set_compressor(void*ins, char*name,int enable, float att_time, float rea_time, float threashold, float ratio);
	//���������ȡ
	DLL_API int audioaef_get_compressor(void*ins, char*name,int *enable, float *att_time, float *rea_time, float *threashold, float *ratio);
	DLL_API float audioaef_get_compressor_level(void*ins, char*name);
	
	// ���� limiter enable
	DLL_API int audioaef_set_limiter_enable(void*ins, char*name, int enable);
	DLL_API int audioaef_set_limiter_threshold(void*ins, char*name, float threshold);	//��������ֵ
	DLL_API int audioaef_set_limiter_att(void*ins, char*name, float second);
	DLL_API int audioaef_set_limiter_rea(void*ins, char*name, float second);	
	//�����������
	DLL_API int audioaef_set_limiter(void*ins, char*name, int enable, float att_time, float rea_time, float threashold);
	//���������ȡ
	DLL_API int audioaef_get_limiter(void*ins, char*name, int *enable, float *att_time, float *rea_time, float *threashold);
	
	//��������
	DLL_API int audioaef_set_gain_gain(void*ins, char*name, float dB);
	DLL_API int audioaef_set_gain_mute(void*ins, char*name, int mute);
	////�����������
	DLL_API int audioaef_set_gain(void*ins, char*name, int enable, float gaindB, int mute);
	//���������ȡ
	DLL_API int audioaef_get_gain(void*ins, char*name, int *enable, float *gaindB, int *mute);
	
	//����xover 
	DLL_API int audioaef_set_xover_enable(void*ins, char*name, int enable);
	//0-LP, 1-HP
	DLL_API int audioaef_set_xover_type(void*ins, char*name, int type); 
	DLL_API int audioaef_set_xover_freq(void*ins, char*name, float fc);
	//�����˲������� 0 -butterwoth,1 - bessel ��2- Linkwitz-Reily
	DLL_API int audioaef_set_xover_func(void*ins, char*name, int func);
	//�����˲���б�ʣ�ȡֵ����
	//slope ����ο�����-2
	DLL_API int audioaef_set_xover_slope(void*ins, char*name, int slope);
	//�����������
	DLL_API int audioaef_set_xover(void*ins, char*name, int enable, int type, int func, float fc, int slope);
	//���������ȡ
	DLL_API int audioaef_get_xover(void*ins, char*name, int *enable, int *type, int *func, float *fc, int *slope);
	

	/*PEQ �˲���������*/
	DLL_API int audioaef_set_peq_enable(void*ins, char*name, int enable);
	//��ȡpeqʹ�ܲ���
	DLL_API int audioaef_get_peq_enable(void*ins, char*name, int*enable);	
	//�˲���BQFʹ�� bqf-N��BQF��ţ� 0-5
	DLL_API int audioaef_set_peq_bqf_enable(void*ins, char*name, int bqfID, int enable);
	//�����˲���BQF���ͣ�������ǰ��ע���еġ�����-1��
	DLL_API int audioaef_set_peq_bqf_type(void*ins, char*name, int bqfID, int type);
	DLL_API int audioaef_set_peq_bqf_gain(void*ins, char*name, int bqfID, float gain);
	DLL_API int audioaef_set_peq_bqf_q(void*ins, char*name, int bqfID, float q);
	DLL_API int audioaef_set_peq_bqf_freq(void*ins, char*name, int bqfID, float freq);
	//ĳһ��BQF�����������
	DLL_API int audioaef_set_peq_bqf(void*ins, char*name, int bqfID, int enable, int type, float gain, float q, float freq);
	//ĳһ��BQF���������ȡ
	DLL_API int audioaef_get_peq_bqf(void*ins, char*name, int bqfID, int *enable, int *type, float *gain, float *q, float *freq);

	DLL_API int audioaef_set_geq_enable(void*ins,char*name, int enable);
	DLL_API int audioaef_get_geq_enable(void*ins,char*name, int*enable);
	DLL_API int audioaef_set_geq_bqf(void*ins,char*name, int bqfID, float gain);
	DLL_API int audioaef_get_geq_bqf(void*ins,char*name, int bqfID, float *gain, float *freq);
	
	/*FIR�˲�������*/
	//optionlist string like "gene:idea:gene1024", caller should make sure typelist already alloc memroy larg enough
	DLL_API int audioaef_get_fir_type_option(void*ins,         char*optionlist);
	DLL_API int audioaef_set_fir_enable(void*ins, char*name, int enable);
	DLL_API int audioaef_set_fir_type(void*ins, char*name, char*type);
	DLL_API int audioaef_set_fir(void*ins, char*name, int enable, char*type);
	DLL_API int audioaef_get_fir(void*ins, char*name, int*enable, char*type); //api will strcpy xxx to type,so type memorysize should not small than 128;

	/*��ȡdeq*/
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
