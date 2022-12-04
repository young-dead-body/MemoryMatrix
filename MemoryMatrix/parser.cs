using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Xml;

namespace MemoryMatrix
{
    class parser
    {
        public static bool parsLoader(String login, String password)
        {
            var filepath = "loader.xml";
            string name, pwd; // Новые переменные имени и пароля  

            // Объявляем и забиваем файл в документ  
            XmlDocument xd = new XmlDocument();
            FileStream fs = new FileStream(filepath, FileMode.Open);
            xd.Load(fs);

            XmlNodeList list = xd.GetElementsByTagName("user"); // Создаем и заполняем лист по тегу "user"  
            for (int i = 0; i < list.Count; i++)
            {
                // XmlElement id = (XmlElement)xd.GetElementsByTagName("user")[i];         // Забиваем id в переменную  
                XmlElement user = (XmlElement)xd.GetElementsByTagName("login")[i];      // Забиваем login в переменную  
                XmlElement pass = (XmlElement)xd.GetElementsByTagName("password")[i];   // Забиваем password в переменную  

                name = user.InnerText;
                if (name == login)
                {
                    pwd = pass.InnerText;
                    if (pwd == password)
                    {
                        fs.Close();
                        return true;
                    }
                }
            }
            // Закрываем поток  
            fs.Close();
            return false;
        }

        public static List<Statistics> parsStatistic()
        {
            var filepath = "records.xml";

            // Объявляем и забиваем файл в документ  
            XmlDocument xd = new XmlDocument();
            FileStream fs = new FileStream(filepath, FileMode.Open);
            xd.Load(fs);

            List<Statistics> statiscicsList = new List<Statistics>();
            XmlNodeList list = xd.GetElementsByTagName("user"); // Создаем и заполняем лист по тегу "user"  
            for (int i = 0; i < list.Count; i++)
            {
                XmlElement user = (XmlElement)xd.GetElementsByTagName("login")[i];      // Забиваем login в переменную  
                XmlElement maxtime = (XmlElement)xd.GetElementsByTagName("maxtime")[i];   // Забиваем maxtime в переменную  
                XmlElement mintime = (XmlElement)xd.GetElementsByTagName("mintime")[i];      // Забиваем mintime в переменную  
                XmlElement totalgames = (XmlElement)xd.GetElementsByTagName("totalgames")[i];
                XmlElement level = (XmlElement)xd.GetElementsByTagName("level")[i];

                Statistics statistics = new Statistics();
                statistics.login = user.FirstChild.Value.ToString();
                statistics.maxtime = int.Parse(maxtime.FirstChild.Value.ToString());
                statistics.mintime = int.Parse(mintime.FirstChild.Value.ToString());
                statistics.totalgames = int.Parse(totalgames.FirstChild.Value.ToString());
                statistics.level = int.Parse(level.FirstChild.Value.ToString());

                statiscicsList.Add(statistics);
                //statistics.mattime = maxtime;


            }
            // Закрываем поток  
            fs.Close();
            return statiscicsList;
        }

        public static String parserText(String str1)
        {
            String str2 = "";
            for (int i = 0; i < str1.Length; i++)
            {
                if (str1[i] == '\'')
                {
                    str2 += "\\\"";
                }
                else
                {
                    str2 += str1[i];
                }
            }
            return str2;
        }
    }
}
