using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace flow
{
    public delegate int DllCallback(int device_id, int _seq, int _CMDType,
    int _ChannelCode, int _ChannelNumber,
    int _FunctionCode, int _FunctionNumber,
    int _ParameterCode, string data_msg);
    public delegate int DllCallback2(int device_id, int type_info, string ParameterData);
    class mydll
    {
        [DllImport("effectorRespCurv.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "effectRespCurv_create")]
        public static extern IntPtr effectRespCurv_create(int node_num, int linePointNum, int fs, int viewmode); //n+1 hpf; ;系统采样率48000

        [DllImport("effectorRespCurv.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "effectRespCurv_get_axisX")]
        public static extern int effectRespCurv_get_axisX(IntPtr ins, float[] axisX);


        [DllImport("effectorRespCurv.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "effectRespCurv_add_bqf")]
        public static extern int effectRespCurv_add_bqf(IntPtr ins, int ID);

        [DllImport("effectorRespCurv.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "effectRespCurv_add_xover")]
        public static extern int effectRespCurv_add_xover(IntPtr ins, int ID);

        [DllImport("effectorRespCurv.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "effectRespCurv_set_bqf_enable")]
        public static extern int effectRespCurv_set_bqf_enable(IntPtr ins, int ID, int enable);

        [DllImport("effectorRespCurv.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "effectRespCurv_set_xover_enable")]
        public static extern int effectRespCurv_set_xover_enable(IntPtr ins, int ID, int enable);

        [DllImport("effectorRespCurv.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "effectRespCurv_set_bqf")]
        public static extern int effectRespCurv_set_bqf(IntPtr ins, int ID, int enable, int type, float gain, float q, float freq);

        [DllImport("effectorRespCurv.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "effectRespCurv_set_xover")]
        public static extern int effectRespCurv_set_xover(IntPtr ins, int ID, int enable, int type, int func, float fc, int slope);

        [DllImport("effectorRespCurv.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "effectRespCurv_get_line")]
        public static extern int effectRespCurv_get_line(IntPtr ins,  float[] ResponseMagdB);

        [DllImport("effectorRespCurv.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "effectRespCurv_get_nodeline")]
        public static extern int effectRespCurv_get_nodeline(IntPtr ins, int ID, float[] ResponseMagdB);

        [DllImport("effectorRespCurv.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "effectRespCurv_destroy")]
        public static extern IntPtr effectRespCurv_destroy(IntPtr ins); //n+1 hpf; ;系统采样率48000
    }
}
