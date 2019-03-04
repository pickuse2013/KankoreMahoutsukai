using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KankoreMahoutsukai.process
{
    class Fix
    {
        public static bool Execution()
        {
            return true;
        }

        private static void End()
        {

        }
    }

    class FixException : Exception
    {
        private string error;

        public FixException(string msg) : base(msg)
        {
            error = msg;
        }
    }
}
