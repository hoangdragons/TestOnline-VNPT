using System;
using System.Linq;
using System.Collections.Generic;
using Xamarin.Forms;
using TestOnline.Models;
using System.Threading.Tasks;


using System.Collections.ObjectModel;

namespace TestOnline.ViewModels
{
    public class ExamViewModel : BaseViewModel
    {
        public global::Xamarin.Forms.ListView ListView_Radio { get; set; }

        private ObservableCollection<Grouping<string, RadioOption>> RadioOptionsList = new ObservableCollection<Grouping<string, RadioOption>>();

        private List<QuestionModel> ListQuestion;

        public ExamViewModel()
        {
            ListQuestion = new List<QuestionModel>();

            for (int i = 0; i < 5; i++)
            {
                QuestionModel question = new QuestionModel();
                question.listAnswer = new List<AnswerModel>();
                question.id = i;
                question.mabailam = i;
                question.content = "Câu hỏi " + i.ToString();

                AnswerModel answer = new AnswerModel();
                answer.content = "Cau " + i.ToString() + " - tra loi 1";
                answer.id = 1;
                answer.questionID = i;
                question.listAnswer.Add(answer);

                answer = new AnswerModel();
                answer.content = "Cau " + i.ToString() + " - tra loi 2";
                answer.id = 2;
                answer.questionID = i;
                question.listAnswer.Add(answer);

                answer = new AnswerModel();
                answer.content = "Cau " + i.ToString() + " - tra loi 3";
                answer.id = 3;
                answer.questionID = i;
                question.listAnswer.Add(answer);

                ListQuestion.Add(question);
            }

        }

        public void Initialize()
        {
            // Build a list of items
            var items = new List<RadioOption>();

            for(int idxQ = 0; idxQ < ListQuestion.Count(); idxQ++)
            {
                bool isSelect = true;
                for (int idxA = 0; idxA < ListQuestion[idxQ].listAnswer.Count(); idxA++)
                {
                    RadioOption rd = new RadioOption(ListQuestion[idxQ].id, ListQuestion[idxQ].content,
                                                     ListQuestion[idxQ].listAnswer[idxA].id,
                                                     ListQuestion[idxQ].listAnswer[idxA].content , isSelect);
                    items.Add(rd);
                    isSelect = false;
                }
            }


            // Copy items into a grouping
            var sorted = from item in items
                         group item by item.IdCategory into radioGroups
                         select new Grouping<string, RadioOption>(radioGroups.Key.ToString(), radioGroups);

            // Add to list
            RadioOptionsList = new ObservableCollection<Grouping<string, RadioOption>>(sorted);
            ListView_Radio.ItemsSource = RadioOptionsList;
        }

        public void Handle_ItemTapped(RadioOption item)
        {
            foreach (var group in RadioOptionsList)
            {
                if (group.Contains(item))
                {
                    foreach (var s in group.Where(x => x.IsSelected))
                    {
                        s.IsSelected = false;
                    }

                    item.IsSelected = true;
                }
            }
        }
        public async void Handle_Clicked()
        {
            string SendRes = "";
            foreach (var group in RadioOptionsList)
            {
                foreach (var s in group)
                {
                    if (s.IsSelected)
                    {
                        SendRes += "|" + s.IdCategory.ToString() + "_" + s.IdContent.ToString();
                    }
                }
            }

            await CurrentPage.DisplayAlert("Bài làm", SendRes, "OK");
           // await Navigation.PushModalAsync(new NavigationPage(new ExamPage()));
        }
    }
}
