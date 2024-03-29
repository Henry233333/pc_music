﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace flow
{
    class alluse_data
    {
        public static IntPtr create_net_create;
        public static int caiyang = 48000;
        public static int create_net_audioaef(string url)
        {
           
            create_net_create = audioaef_net_dll.net_audioaef_create("tcp://" + url + ":10842", 0);
           
            if (create_net_create == null)
            {
                return 0;
            }
            IntPtr[] cptr = new IntPtr[6];
            int namelist = audioaef_net_dll.net_audioaef_get_callInsNameList(create_net_create, cptr);
            if (namelist == -1)
            {
                return 0;
            }
            string call_name = Marshal.PtrToStringAnsi(cptr[0]);
            int set_name_to_serve = audioaef_net_dll.net_audioaef_set_callInsName(create_net_create, call_name);
            if (set_name_to_serve == -1)
            {
                return 0;
            }
            
            return 1;
        }
        public static int destroy_net_audioaef()
        {
            int destroy = audioaef_net_dll.net_audioaef_destroy(create_net_create);
            if (destroy == 0) {
                return 1;   
            }
            return 0;
        }
        public static List<string> flow_config_list = new List<string>();
        private static string config_end_text = "\r\n" + "";
        public static string flow_config_text_end() {
            return config_end_text;
        }
        public static string flow_item()
        {
            

            string text = "[";
           
            for (int i = 0; i < flow_config_list.Count; i++)
            {               
                if (flow_config_list[i].Substring(0, 1) == "@")
                { 
                    config_end_text += flow_config_list[i]+"\r\n";
                        continue;
                    }
                string[] sArray = flow_config_list[i].Split(',');
                if (sArray[1] == "COLLECTION")
                {

                    config_end_text += flow_config_list[i] + "\r\n"; ;
                    continue;
                }
                string loc_x = "";
                string loc_y = "";
               
                
                if (sArray[4] != "") {
                    string loctext = sArray[4].Replace("[","");
                    string loctext1 = loctext.Replace("]", "");
                    string[] sloc = loctext1.Split(' ');
                    loc_x = sloc[0];
                    loc_y = sloc[1];
                }
                  text += "{'name':'" + sArray[1] + "','key':'" + sArray[0] + "','loc':'" + loc_x + " " + loc_y + "'},";    
      
            }
            text += "]";
            
            return text;
        }
        public static string flow_line()
        {
            string text = "[";
            for (int i = 0; i < flow_config_list.Count; i++)
            {

                if (flow_config_list[i].Substring(0, 1) == "@")
                {
                    continue;
                }                       
                string[] sArray = flow_config_list[i].Split(',');
                if (sArray[1] == "COLLECTION")
                {
                    continue;
                }
                
                string to_list_s = sArray[3];
                string to_list_s1 = to_list_s.Replace("[", "");
                string to_list_s2 = to_list_s1.Replace("]", ""); ;
                string[] to_list = to_list_s2.Split(' ');
               
                for (int k = 0; k < to_list.Length; k++)
                {
                    if (to_list[k] != " " || to_list[k] != null)
                    {
                        text += "{'from':'" + sArray[0] + "','to':'" + to_list[k] + "'},";
                    }
                }
                
            }
            
            
            text += "]";
           
            return text;
        }
   
    }
}
