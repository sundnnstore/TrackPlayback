using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrackPlayback
{
    public class CLineList
    {
        private static List<LineInfo> lineInfo = new List<LineInfo>();

        public static List<LineInfo> LineInfo
        {
            get { return lineInfo; }
            set { lineInfo = value; }
        }

        private static List<LineInfo> grpInfo = new List<LineInfo>();

        public static List<LineInfo> GrpInfo
        {
            get { return grpInfo; }
            set { grpInfo = value; }
        }
    }
}
