using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace KankoreMahoutsukai.utils
{
    class OutResource
    {
        //filename 资源文件里面的文件名称

        //path 保存的磁盘路径
        public static void Out(string filename)
        {
            string path = System.AppDomain.CurrentDomain.BaseDirectory + "assets\\" + filename + ".bmp";
            System.Resources.ResourceManager rm = Properties.Resources.ResourceManager;
            FileStream Stream = new FileStream(path, FileMode.OpenOrCreate);
            BinaryFormatter bin = new BinaryFormatter();
            try
            {
                bin.Serialize(Stream, rm.GetObject(filename, null));
                Stream.Close();
            }
            catch (InvalidOperationException)
            {
                throw;
            }

        }
    }
}
