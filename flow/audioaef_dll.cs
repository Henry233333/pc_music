using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace flow
{
    public delegate int DllCallback3(int device_id, int _seq, int _CMDType,
    int _ChannelCode, int _ChannelNumber,
    int _FunctionCode, int _FunctionNumber,
    int _ParameterCode, string data_msg);
    public delegate int DllCallback4(int device_id, int type_info, string ParameterData);
    class audioaef_dll
    {
        [DllImport("libAudioSmartFlow.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "audioaef_create")]
        public static extern IntPtr audioaef_create(char flowtopo_str, char aefparam_str, int maxInFrameLen, int inchs, int outchs, int infs, int outfs);

        [DllImport("libAudioSmartFlow.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "audioaef_destroy")]
        public static extern int audioaef_destroy(IntPtr ins);

    }
}
