using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;



namespace QuickAndDirty
{
    public class VehicleQuery
    {
        public int queryType { get; set; }

        public string queryValue { get; set; }

        public int maxRecords { get; set; }

        public string login { get; set; }

        public string password { get; set; }

        public VehicleQuery(int queryType, string queryValue, int maxRecords, string login, string password)
        {
            this.queryType = queryType;

            this.queryValue = queryValue;

            this.maxRecords = maxRecords;

            this.login = login;

            this.password = password;
        }
    }

    public class VehicleQueryComplete
    {
        public int queryType { get; set; }

        public string queryValue { get; set; }

        public string login { get; set; }

        public string password { get; set; }

        public VehicleQueryComplete(int queryType, string queryValue, string login, string password)
        {
            this.queryType = queryType;

            this.queryValue = queryValue;

            this.login = login;

            this.password = password;
        }
    }
}