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

        public static bool parsRegistrationLoader(String login, String password) 
        {
            XmlDocument xDoc = new XmlDocument();
            XmlNodeList list = xDoc.GetElementsByTagName("user"); // Создаем и заполняем лист по тегу "user"
            xDoc.Load("loader.xml");
            XmlElement? xRoot = xDoc.DocumentElement;

            // создаем новый элемент person
            XmlElement userElem = xDoc.CreateElement("user");

            // создаем атрибут name
            XmlAttribute idAttr = xDoc.CreateAttribute("id");

            // создаем элементы company и age
            XmlElement loginElem = xDoc.CreateElement("login");
            XmlElement passwordElem = xDoc.CreateElement("password");

            // создаем текстовые значения для элементов и атрибута
            XmlText idText = xDoc.CreateTextNode($"{list.Count+1}"); // здесь располагается номер пользователя
            XmlText loginText = xDoc.CreateTextNode($"{login}");
            XmlText passwordText = xDoc.CreateTextNode($"{password}");

            //добавляем узлы
            idAttr.AppendChild(idText);
            loginElem.AppendChild(loginText);
            passwordElem.AppendChild(passwordText);

            // добавляем атрибут name
            userElem.Attributes.Append(idAttr);
            // добавляем элементы company и age
            userElem.AppendChild(loginElem);
            userElem.AppendChild(passwordElem);
            // добавляем в корневой элемент новый элемент person
            xRoot?.AppendChild(userElem);
            // сохраняем изменения xml-документа в файл
            xDoc.Save("loader.xml");

            return true;
        }

        public static void parsRegistrationStatistics(String login)
        {
            XmlDocument xDoc = new XmlDocument();
            XmlNodeList list = xDoc.GetElementsByTagName("user"); // Создаем и заполняем лист по тегу "user"
            xDoc.Load("records.xml");
            XmlElement? xRoot = xDoc.DocumentElement;

            // создаем новый элемент person
            XmlElement userElem = xDoc.CreateElement("user");

            // создаем атрибут name
            XmlAttribute idAttr = xDoc.CreateAttribute("id");

            // создаем элементы company и age
            XmlElement loginElem = xDoc.CreateElement("login");
            XmlElement maxtimeElem = xDoc.CreateElement("maxtime");
            XmlElement mintimeElem = xDoc.CreateElement("mintime");
            XmlElement totalgamesElem = xDoc.CreateElement("totalgames");
            XmlElement levelElem = xDoc.CreateElement("level");

            // создаем текстовые значения для элементов и атрибута
            XmlText idText = xDoc.CreateTextNode($"{list.Count + 1}"); // здесь располагается номер пользователя
            XmlText loginText = xDoc.CreateTextNode($"{login}");
            XmlText maxtimeText = xDoc.CreateTextNode($"{0}");
            XmlText mintimeText = xDoc.CreateTextNode($"{60}");
            XmlText totalgamesText = xDoc.CreateTextNode($"{0}");
            XmlText levelText = xDoc.CreateTextNode($"{1}");

            //добавляем узлы
            idAttr.AppendChild(idText);
            loginElem.AppendChild(loginText);
            maxtimeElem.AppendChild(maxtimeText);
            mintimeElem.AppendChild(mintimeText);
            totalgamesElem.AppendChild(totalgamesText);
            levelElem.AppendChild(levelText);

            // добавляем атрибут name
            userElem.Attributes.Append(idAttr);
            // добавляем элементы company и age
            userElem.AppendChild(loginElem);
            userElem.AppendChild(maxtimeElem);
            userElem.AppendChild(mintimeElem);
            userElem.AppendChild(totalgamesElem);
            userElem.AppendChild(levelElem);
            // добавляем в корневой элемент новый элемент person
            xRoot?.AppendChild(userElem);
            // сохраняем изменения xml-документа в файл
            xDoc.Save("records.xml");

        }

        public static void parsChangeValue(String nameElem, String userName) 
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("records.xml");
            XmlNodeList list = xDoc.GetElementsByTagName("user"); // Создаем и заполняем лист по тегу "user"  
            for (int i = 0; i < list.Count; i++)
            {
                if (userName == xDoc.GetElementsByTagName("login")[i].FirstChild.Value.ToString()) 
                {
                    int count = int.Parse(xDoc.GetElementsByTagName($"{nameElem}")[i].FirstChild.Value);
                    xDoc.GetElementsByTagName($"{nameElem}")[i].FirstChild.Value = $"{count + 1}";
                }             
            }
            xDoc.Save("records.xml");
        }

        public static void parsChangeValue(String nameElem, String userName, int newValue)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("records.xml");
            XmlNodeList list = xDoc.GetElementsByTagName("user"); // Создаем и заполняем лист по тегу "user"  
            for (int i = 0; i < list.Count; i++)
            {
                if (userName == xDoc.GetElementsByTagName("login")[i].FirstChild.Value.ToString())
                {
                    int count = int.Parse(xDoc.GetElementsByTagName($"{nameElem}")[i].FirstChild.Value);
                    xDoc.GetElementsByTagName($"{nameElem}")[i].FirstChild.Value = $"{newValue}";
                }
            }
            xDoc.Save("records.xml");
        }

        public static int parsGettingValue(String nameElem, String userName)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("records.xml");
            int count = 0;
            XmlNodeList list = xDoc.GetElementsByTagName("user"); // Создаем и заполняем лист по тегу "user"  
            for (int i = 0; i < list.Count; i++)
            {
                if (userName == xDoc.GetElementsByTagName("login")[i].FirstChild.Value.ToString())
                {
                    count = int.Parse(xDoc.GetElementsByTagName($"{nameElem}")[i].FirstChild.Value);
                }
            }
            return count;
        }


        public static int parsPos(char ch, String str)
        {
            int pos = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == ch)
                {
                    pos = i;
                }
            }
            return pos;
        }
    }
}
