using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ITSharp.DBExtractor.Common
{
    [Serializable()]
    public class DBExtractorSettings
    {
        public TimeSpan timeSpan;

        public DBExtractorSettings()
        {
            this.timeSpan = TimeSpan.Zero;
        }
    }
}
