using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace flow
{
    public delegate int DllCallback5(int device_id, int _seq, int _CMDType,
    int _ChannelCode, int _ChannelNumber,
    int _FunctionCode, int _FunctionNumber,
    int _ParameterCode, string data_msg);
    public delegate int DllCallback6(int device_id, int type_info, string ParameterData);
    class audioaef_net_dll
    {
        /*[DllImport("libAudioSmartFlow.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "net_sddp_client_open")]
        public static extern int net_sddp_client_open(int local_port,sddp_req_cb cb);
  
        [DllImport("libAudioSmartFlow.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "net_sddp_client_send_req")]
        public static extern int net_sddp_client_send_req();
 
        [DllImport("libAudioSmartFlow.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "net_sddp_client_close")]
        public static extern void net_sddp_client_close();*/


        [DllImport("libAudioSmartFlow.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "net_audioaef_create")]
        public static extern IntPtr net_audioaef_create(string uri, int local_port);

        
        [DllImport("libAudioSmartFlow.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "net_audioaef_get_callInsNameList")]
        public static extern int net_audioaef_get_callInsNameList(IntPtr ins, IntPtr[] cptr);
        
        [DllImport("libAudioSmartFlow.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "net_audioaef_set_callInsName")]
        public static extern int net_audioaef_set_callInsName(IntPtr ins, string callInsName);

        //关闭音效处理并且释放资源
        [DllImport("libAudioSmartFlow.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "net_audioaef_destroy")]
        public static extern int net_audioaef_destroy(IntPtr ins);
        [DllImport("libAudioSmartFlow.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "net_audioaef_save_config")]
        public static extern int net_audioaef_save_config(IntPtr ins, char file);
        [DllImport("libAudioSmartFlow.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "net_audioaef_set_collection_enable")]
        public static extern int net_audioaef_set_collection_enable(IntPtr ins, string name, int enable);
        [DllImport("libAudioSmartFlow.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "net_audioaef_get_collection_enable")]
        public static extern int net_audioaef_get_collection_enable(IntPtr ins, string name, int enable);

        //获取level分贝值
        [DllImport("libAudioSmartFlow.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "net_audioaef_get_level")]
        public static extern int net_audioaef_get_level(IntPtr ins, string name, float leveldB);
// 设置 level enable

        [DllImport("libAudioSmartFlow.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "net_audioaef_set_level_enable")]
        public static extern int net_audioaef_set_level_enable(IntPtr ins, string name, int enable);

//设置level attack time

        [DllImport("libAudioSmartFlow.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "net_audioaef_set_level_att")]
        public static extern int net_audioaef_set_level_att(IntPtr ins, string name, float second);

//设置level release time

        [DllImport("libAudioSmartFlow.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "net_audioaef_set_level_rea")]
        public static extern int net_audioaef_set_level_rea(IntPtr ins, string name, float second);

//level模块整体参数配置

        [DllImport("libAudioSmartFlow.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "net_audioaef_set_level")]
        public static extern int net_audioaef_set_level(IntPtr ins,string name, int enable, float att_time, float rea_time);

//level模块整体参数读取

        [DllImport("libAudioSmartFlow.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "net_audioaef_get_levelConfig")]
        public static extern int net_audioaef_get_levelConfig(IntPtr ins, string name,ref int  enable,ref float  att_time,ref float  rea_time);
	
// compressor参数设置

        [DllImport("libAudioSmartFlow.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "net_audioaef_set_compressor_enable")]
        public static extern int net_audioaef_set_compressor_enable(IntPtr ins, string name, int enable);


        [DllImport("libAudioSmartFlow.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "net_audioaef_set_compressor_att")]
        public static extern int net_audioaef_set_compressor_att(IntPtr ins, string name, float second);


        [DllImport("libAudioSmartFlow.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "net_audioaef_set_compressor_rea")]
        public static extern int net_audioaef_set_compressor_rea(IntPtr ins, string name, float second);


        [DllImport("libAudioSmartFlow.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "net_audioaef_set_compressor_threshold")]
        public static extern int net_audioaef_set_compressor_threshold(IntPtr ins,string name, float dB);

        [DllImport("libAudioSmartFlow.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "net_audioaef_set_compressor_ratio")]
        public static extern int net_audioaef_set_compressor_ratio(IntPtr ins, string name, float ratio);

//整体参数配置

        [DllImport("libAudioSmartFlow.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "net_audioaef_set_compressor")]
        public static extern int net_audioaef_set_compressor(IntPtr ins,string name,int enable, float att_time, float rea_time, float threshold, float ratio);
//整体参数读取

        [DllImport("libAudioSmartFlow.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "net_audioaef_get_compressor")]
        public static extern int net_audioaef_get_compressor(IntPtr ins, string name,ref int  enable,ref float  att_time,ref float  rea_time,ref float  threashold,ref float  ratio);

        [DllImport("libAudioSmartFlow.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "net_audioaef_get_compressor_level")]
        public static extern int net_audioaef_get_compressor_level(IntPtr ins, string name);

// 设置 limiter enable

        [DllImport("libAudioSmartFlow.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "net_audioaef_set_limiter_enable")]
        public static extern int net_audioaef_set_limiter_enable(IntPtr ins, string name, int enable);
//设置门限值

        [DllImport("libAudioSmartFlow.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "net_audioaef_set_limiter_threshold")]
        public static extern int net_audioaef_set_limiter_threshold(IntPtr ins, string name, float threshold);
//设置limiter attack time
        [DllImport("libAudioSmartFlow.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "net_audioaef_set_limiter_att")]
        public static extern int net_audioaef_set_limiter_att(IntPtr ins,string name, float second);
//设置limiter release time

        [DllImport("libAudioSmartFlow.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "net_audioaef_set_limiter_rea")]
        public static extern int net_audioaef_set_limiter_rea(IntPtr ins,string name, float second);
//整体参数配置

        [DllImport("libAudioSmartFlow.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "net_audioaef_set_limiter")]
        public static extern int net_audioaef_set_limiter(IntPtr ins,string name, int enable, float att_time, float rea_time, float threshold);
//整体参数读取

        [DllImport("libAudioSmartFlow.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "net_audioaef_get_limiter")]
        public static extern int net_audioaef_get_limiter(IntPtr ins,string name,ref int  enable,ref float  att_time,ref float  rea_time,ref float  threshold);

//设置输入增益

        [DllImport("libAudioSmartFlow.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "net_audioaef_set_gain_enable")]
        public static extern int net_audioaef_set_gain_enable(IntPtr ins, string name, int enable);


        [DllImport("libAudioSmartFlow.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "net_audioaef_set_gain_gain")]
        public static extern int net_audioaef_set_gain_gain(IntPtr ins, string name, float dB);


        [DllImport("libAudioSmartFlow.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "net_audioaef_set_gain_mute")]
        public static extern int net_audioaef_set_gain_mute(IntPtr ins, string name, int mute);

////整体参数配置

        [DllImport("libAudioSmartFlow.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "net_audioaef_set_gain")]
        public static extern int net_audioaef_set_gain(IntPtr ins,string name, int enable, float gaindB, int mute);
//整体参数读取

        [DllImport("libAudioSmartFlow.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "net_audioaef_get_gain")]
        public static extern int net_audioaef_get_gain(IntPtr ins,string name,ref int  enable,ref float  gaindB,ref int  mute);
//设置xover 

        [DllImport("libAudioSmartFlow.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "net_audioaef_set_xover_enable")]
        public static extern int net_audioaef_set_xover_enable(IntPtr ins,string name, int enable);

//0-LP, 1-HP
        [DllImport("libAudioSmartFlow.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "net_audioaef_set_xover_type")]
        public static extern int net_audioaef_set_xover_type(IntPtr ins,string name, int type);


        [DllImport("libAudioSmartFlow.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "net_audioaef_set_xover_freq")]
        public static extern int net_audioaef_set_xover_freq(IntPtr ins,string name, float fc);
//设置滤波器类型 0 -butterwoth,1 - bessel ；2- Linkwitz-Reily

        [DllImport("libAudioSmartFlow.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "net_audioaef_set_xover_func")]
        public static extern int net_audioaef_set_xover_func(IntPtr ins, string name, int func);
//设置滤波器斜率，取值如下
//slope 定义参考定义-2

        [DllImport("libAudioSmartFlow.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "net_audioaef_set_xover_slope")]
        public static extern int net_audioaef_set_xover_slope(IntPtr ins, string name, int slope);

//整体参数配置

        [DllImport("libAudioSmartFlow.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "net_audioaef_set_xover")]
        public static extern int net_audioaef_set_xover(IntPtr ins,string name, int enable, int type, int func, float fc, int slope);
//整体参数读取

        [DllImport("libAudioSmartFlow.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "net_audioaef_get_xover")]
        public static extern int net_audioaef_get_xover(IntPtr ins, string name, ref int enable, ref int type, ref int func, ref float fc, ref int slope);

/*PEQ 滤波器组设置 */

        [DllImport("libAudioSmartFlow.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "net_audioaef_set_peq_enable")]
        public static extern int net_audioaef_set_peq_enable(IntPtr ins, string name, int enable);

/* PEQ 滤波器组设置 */

        [DllImport("libAudioSmartFlow.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "net_audioaef_get_peq_enable")]
        public static extern int net_audioaef_get_peq_enable(IntPtr ins, string name,ref int enable);


//滤波器BQF使能 bqf-N段BQF序号： 0-5

        [DllImport("libAudioSmartFlow.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "net_audioaef_set_peq_bqf_enable")]
        public static extern int net_audioaef_set_peq_bqf_enable(IntPtr ins,string name, int bqfID, int enable);
//设置滤波器BQF类型，定义如前面注释中的“定义-1”

        [DllImport("libAudioSmartFlow.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "net_audioaef_set_peq_bqf_type")]
        public static extern int net_audioaef_set_peq_bqf_type(IntPtr ins,string name, int bqfID, int type);


        [DllImport("libAudioSmartFlow.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "net_audioaef_set_peq_bqf_gain")]
        public static extern int net_audioaef_set_peq_bqf_gain(IntPtr ins,string name, int bqfID, float gain);

        [DllImport("libAudioSmartFlow.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "net_audioaef_set_peq_bqf_q")]
        public static extern int net_audioaef_set_peq_bqf_q(IntPtr ins,string name, int bqfID, float q);


        [DllImport("libAudioSmartFlow.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "net_audioaef_set_peq_bqf_freq")]
        public static extern int net_audioaef_set_peq_bqf_freq(IntPtr ins,string name, int bqfID, float freq);
//某一段BQF整体参数配置

        [DllImport("libAudioSmartFlow.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "net_audioaef_set_peq_bqf")]
        public static extern int net_audioaef_set_peq_bqf(IntPtr ins,string name, int bqfID, int enable,  int type, float gain, float q, float freq);
//某一段BQF整体参数读取

        [DllImport("libAudioSmartFlow.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "net_audioaef_get_peq_bqf")]
        public static extern int net_audioaef_get_peq_bqf(IntPtr ins,string name,int bqfID,ref int  enable,ref int  type,ref float  gain,ref float  q,ref float  freq);


// GEQ 滤波器组设置 

        [DllImport("libAudioSmartFlow.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "net_audioaef_set_geq_enable")]
        public static extern int net_audioaef_set_geq_enable(IntPtr ins, string name, int enable);

        [DllImport("libAudioSmartFlow.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "net_audioaef_get_geq_enable")]
        public static extern int net_audioaef_get_geq_enable(IntPtr ins, string name, int enable);

//某一段BQF整体参数配置

        [DllImport("libAudioSmartFlow.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "net_audioaef_set_geq_bqf")]
        public static extern int net_audioaef_set_geq_bqf(IntPtr ins, string name, int bqfID, float gain);

//某一段BQF整体参数读取

        [DllImport("libAudioSmartFlow.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "net_audioaef_get_geq_bqf")]
        public static extern int net_audioaef_get_geq_bqf(IntPtr ins,string name, int bqfID, float  gain, float  freq);

        [DllImport("libAudioSmartFlow.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "net_audioaef_get_loudeq_option")]
        public static extern int net_audioaef_get_loudeq_option(IntPtr ins, ref String optionlist);

        [DllImport("libAudioSmartFlow.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "net_audioaef_set_loudeq_type")]
        public static extern int net_audioaef_set_loudeq_type(IntPtr ins, string name, string type);


        [DllImport("libAudioSmartFlow.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "net_audioaef_set_loudeq_enable")]
        public static extern int net_audioaef_set_loudeq_enable(IntPtr ins,string name, int enable);

        [DllImport("libAudioSmartFlow.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "net_audioaef_set_loudeq_time")]
        public static extern int net_audioaef_set_loudeq_time(IntPtr ins, string name, float time);

        [DllImport("libAudioSmartFlow.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "net_audioaef_set_loudeq")]
        public static extern int net_audioaef_set_loudeq(IntPtr ins, string name, int enable, char type, float time);

        [DllImport("libAudioSmartFlow.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "net_audioaef_get_loudeq")]
        public static extern int net_audioaef_get_loudeq(IntPtr ins,string name,ref int  enable,ref string type,ref  float time);
// FIR滤波器参数 

        [DllImport("libAudioSmartFlow.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "net_audioaef_set_fir_enable")]
        public static extern int net_audioaef_set_fir_enable(IntPtr ins,string name, int enable);


        [DllImport("libAudioSmartFlow.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "net_audioaef_get_fir_type_option")]
        public static extern int net_audioaef_get_fir_type_option(IntPtr ins,ref string [] typelist);

        [DllImport("libAudioSmartFlow.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "net_audioaef_set_fir_type")]
        public static extern int net_audioaef_set_fir_type(IntPtr ins, string name, string type);

        [DllImport("libAudioSmartFlow.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "net_audioaef_set_fir")]
        public static extern int net_audioaef_set_fir(IntPtr ins, string name, int enable, string type);
 //api will strcpy xxx to type,so type memorysize should not small than 128;
        [DllImport("libAudioSmartFlow.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "net_audioaef_get_fir")]
        public static extern int net_audioaef_get_fir(IntPtr ins,string name,ref int enable,ref string type);


        [DllImport("libAudioSmartFlow.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "net_audioaef_set_delay_enable")]
        public static extern int net_audioaef_set_delay_enable(IntPtr ins,string name, int enable);

        [DllImport("libAudioSmartFlow.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "net_audioaef_set_delay_time")]
        public static extern int net_audioaef_set_delay_time(IntPtr ins,string name, float ms);

        [DllImport("libAudioSmartFlow.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "net_audioaef_set_delay")]
        public static extern int net_audioaef_set_delay(IntPtr ins,string name, int enable, float ms);

        [DllImport("libAudioSmartFlow.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "net_audioaef_get_delay")]
        public static extern int net_audioaef_get_delay(IntPtr ins, string name,ref int enable,ref float ms);


        [DllImport("libAudioSmartFlow.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "net_audioaef_set_noisegt_enable")]
        public static extern int net_audioaef_set_noisegt_enable(IntPtr ins,string name, int enable);

        [DllImport("libAudioSmartFlow.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "net_audioaef_set_noisegt_threshold")]
        public static extern int net_audioaef_set_noisegt_threshold(IntPtr ins, string name, float db);

        [DllImport("libAudioSmartFlow.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "net_audioaef_set_noisegt_att")]
        public static extern int net_audioaef_set_noisegt_att(IntPtr ins,string name, float second);

        [DllImport("libAudioSmartFlow.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "net_audioaef_set_noisegt_rea")]
        public static extern int net_audioaef_set_noisegt_rea(IntPtr ins, string name, float second);

        [DllImport("libAudioSmartFlow.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "net_audioaef_set_noisegt_avg")]
        public static extern int net_audioaef_set_noisegt_avg(IntPtr ins, string name, float second);

        [DllImport("libAudioSmartFlow.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "net_audioaef_set_noisegt")]
        public static extern int net_audioaef_set_noisegt(IntPtr ins,string name, int enable, float threshold, float att_time, float rea_time, float avg_time);

        [DllImport("libAudioSmartFlow.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "net_audioaef_get_noisegt")]
        public static extern int net_audioaef_get_noisegt(IntPtr ins,string name,ref int  enable,ref float threshold,ref float  att_time,ref float  rea_time,ref float avg_time);

    }
}
