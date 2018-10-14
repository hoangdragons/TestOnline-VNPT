using System;
using System.Collections.Generic;
using System.Text;

namespace TestOnline.Models
{
    public class QuestionModel
    {
        public int mabailam { get; set; }
        public int id { get; set; }
        public string content { get; set; }
        public List<AnswerModel> listAnswer { get; set; }
    }
}
