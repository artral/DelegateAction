using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using System.Data.OleDb;

namespace DelegateAction
{
    public class EntityMaps
    {
        public static List<T> getObjectFromStore<T>(string FileName,Action<IDbCommand> CmdParam,Func<StreamReader,T> GetfromReader)
        {
            StreamReader reader = new StreamReader(FileName);

            OleDbConnection connection = new OleDbConnection("Provider=SQLOLEDB.1;Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=RBAC;Data Source=ARTRAL-PC");
            IDbCommand command = connection.CreateCommand();
            CmdParam(command);

            var result = new List<T>();
            T item = GetfromReader(reader);
            result.Add(item);
            return result;
        }
    }
}
