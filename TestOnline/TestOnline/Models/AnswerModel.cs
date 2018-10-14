using System;
using System.Collections.Generic;
using System.Text;

namespace TestOnline.Models
{
    public class AnswerModel
    {
        public int id { get; set; }
        public string content { get; set; }
        public int questionID { get; set; }
        public bool isAnswering { get; set; }
    }
}
