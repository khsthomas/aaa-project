using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YEZZ.Model
{
    public class DefaultDataModel : AbstractDataModel
    {
        public DefaultDataModel() : this(SystemConstants.DATABASE_NAME)
        {
        }

        public DefaultDataModel(string strDatabase)
        {
            SetDatabaseName(strDatabase);
        }

        public override IDataModel CreateInstance()
        {
            return new DefaultDataModel();
        }
    }
}
