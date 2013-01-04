using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ITSharp.ScheDEX.Common
{
    [Serializable()]
    public class ScheduleEventList : ArrayList
    {
        private String fileName;

        public ScheduleEventList()
        {
            this.fileName = null;
        }

        public ScheduleEventList(String fileName)
        {
            this.fileName = fileName;
        }

        public void Save()
        {
            if (this.fileName != null)
            {
                Stream fileStream = File.Create(this.fileName);
                BinaryFormatter serializer = new BinaryFormatter();
                serializer.Serialize(fileStream, this);
                fileStream.Close();
            }
        }

        public static ScheduleEventList Load(string fileName)
        {
            ScheduleEventList events;

            if (File.Exists(fileName))
            {
                Stream fileStream = File.OpenRead(fileName);
                BinaryFormatter deserializer = new BinaryFormatter();
                events = (ScheduleEventList)deserializer.Deserialize(fileStream);
                events.fileName = fileName;
                fileStream.Close();
            }
            else
            {
                events = new ScheduleEventList(fileName);
            }

            return events;
        }
    }
}
