using Nancy;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace C3Server
{
    public class UserModule:NancyModule
    {

        public UserModule()
        {
            Get("/reservation/{format}/{login}", param => ReturnReservation(param.format,param.login));           
        }

        public string ReturnReservation(String format, String login)
        {
            format = format.ToLower();
            ReservationData reservationData = new ReservationData(login);
            if(format == "xml")
            {
                return ConvertToXml(reservationData);
            }
            else
            {
                return ConvertToJson(reservationData);
            }
        }

        private static string ConvertToXml(ReservationData reservationData)
        {
            StringWriter textWriter = new StringWriter();
            XmlSerializer x = new XmlSerializer(reservationData.GetType());
            x.Serialize(textWriter, reservationData);
            return textWriter.ToString();
        }

        private static string ConvertToJson(ReservationData reservationData)
        {
            string returnJson = JsonConvert.SerializeObject(reservationData);
            return returnJson;
        }

    }
}
