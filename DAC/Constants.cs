using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DAC
{
    public class Constants
    {
        //creating a variables that i can use to connect to the Database
        public string connectionServer;
        public string connectionUsername;
        public string connectionPassword;
        public string connectionAuthType;
        public string connectionTimeout;
        public string connectionString;
        public string dbMrEOnline;
       
        public Constants()
        {
            XmlDocument config = new XmlDocument();
            config.Load(AppDomain.CurrentDomain.BaseDirectory + "Config.xml");

            connectionServer = config.GetElementsByTagName("").Item(0).InnerXml;
            connectionUsername = config.GetElementsByTagName("").Item(0).InnerXml;
            connectionPassword = config.GetElementsByTagName("").Item(0).InnerXml;
            connectionAuthType = config.GetElementsByTagName("").Item(0).InnerXml;
            connectionTimeout = config.GetElementsByTagName("").Item(0).InnerXml;
            dbMrEOnline = config.GetElementsByTagName("").Item(0).InnerXml;

            if (connectionString == "SA") 
            {
                connectionString = System.String.Format("Initial Catalog={0}; Data Source={1}; user id={2}; password={3}; timeout={4]",
                    dbMrEOnline, connectionServer,connectionUsername,connectionPassword,connectionTimeout);
            }
            else
            {
                //connectionString = System.String.Format("Initial Catalog={0}; Data Source={1}; Integrated Security=true",
                //    dbMrEOnline, connectionServer);

                connectionString = System.String.Format("Initial Catalog={0}; Data Source={1}; user id={2}; password={3}; timeout={4]",
                    dbMrEOnline, connectionServer, connectionUsername, connectionPassword, connectionTimeout);
            }


        }

    }
}
