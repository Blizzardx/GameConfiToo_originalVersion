using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Auto;

namespace GameConfigTools.Util
{
    public class VaildUtil
    {
        public static bool TryConvertInt(string s, out int n)
        {
            return TryConvertInt(s, out n, 0, int.MaxValue);
        }
        public static bool TryConvertInt(string s, out int n, int min, int max)
        {
            int a;
            n = 0;
            if (!int.TryParse(s, out a))
            {
                return false;
            }
            if (a < min)
            {
                return false;
            }
            if (a > max)
            {
                return false;
            }
            n = a;
            return true;
        }

        public static bool TryConvertFloat(string s, out float f)
        {
            return TryConvertFloat(s, out f, 0, float.MaxValue);
        }
        public static bool TryConvertFloat(string s, out float n, float min, float max)
        {
            float a;
            n = 0;
            if (!float.TryParse(s, out a))
            {
                return false;
            }
            if (a < min)
            {
                return false;
            }
            if (a > max)
            {
                return false;
            }
            n = a;
            return true;
        }

        public static List<int> SplitToList(string str)
        {
            return SplitToList(str, '|');
        }

        public static List<int> SplitToList(string str, char c)
        {
            string[] ss = str.Split(c);
            List<int> list = new List<int>();
            foreach (string s in ss)
            {
                int n;
                if (!int.TryParse(s, out n))
                {
                    return null;
                }
                list.Add(n);
            }
            return list;
        }

        public static List<float> SplitToFloatList(string str, char c)
        {
            string[] ss = str.Split(c);
            List<float> list = new List<float>();
            foreach (string s in ss)
            {
                float n;
                if (!float.TryParse(s, out n))
                {
                    return null;
                }
                list.Add(n);
            }
            return list;
        }

        public static ThriftVector3 ConvertVector3(List<float> pos)
        {
            ThriftVector3 vector3 = new ThriftVector3();
            vector3.X = (int)(pos[0] * 100);
            vector3.Y = (int)(pos[1] * 100);
            vector3.Z = (int)(pos[2] * 100);
            return vector3;
        }
    }
}
