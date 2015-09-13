using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace DelegateAction
{
    class Program
    {
        static void Main(string[] args)
        {

            string filename = @"c:\temp\test.txt";
            //Create your own entity and use it as needed this is just a sample for string...
            List<string> Result = EntityMaps.getObjectFromStore<string>(filename,
                 (CmdParam) =>
                 {
                     CmdParam.CreateParameter().ParameterName = "@addurparam";
                 }
                 , Program.ReadFromFile);
        }

        public static string ReadFromFile(StreamReader fileReader)
        {
            string filename = @"c:\temp\test.txt";
            fileReader = new StreamReader(filename);
            return fileReader.ReadLine();
        }
    }
}

