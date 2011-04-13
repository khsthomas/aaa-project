using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AAA.AGS.DataStore.Writer
{
    public interface IWriter
    {
        void Init();
        void Start();
        void Stop();
        void Close();
    }
}
