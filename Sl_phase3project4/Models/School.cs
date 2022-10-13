using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sl_phase3project4.Models
{
    public class School
    {
        private int _marks;

        public int Marks
        {
            get { return _marks; }
            set { _marks = value; }
        }
        private int _studentid;

        public int Studentid
        {
            get { return _studentid; }
            set { _studentid = value; }
        }
        private int _subjectid;

        public int Subjectid
        {
            get { return _subjectid; }
            set { _subjectid = value; }
        }
    }
}