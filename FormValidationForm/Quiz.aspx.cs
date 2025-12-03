using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FormValidationForm
{
    public partial class Quiz : System.Web.UI.Page
    {
        static List<Question> questions;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                questions = new List<Question>
            {
                new Question { Text = "What is the capital of Nepal?", Options = new[] { "Pokhara", "Kathmandu", "Lalitpur", "Biratnagar" }, CorrectIndex = 1 },
                new Question { Text = "Which planet is known as the Red Planet?", Options = new[] { "Venus", "Earth", "Mars", "Jupiter" }, CorrectIndex = 2 },
                new Question { Text = "What is 2 + 2?", Options = new[] { "3", "4", "5", "6" }, CorrectIndex = 1 }
            };

                ViewState["index"] = 0;
                ViewState["score"] = 0;
                DisplayQuestion(0);
            }
        }

        private void DisplayQuestion(int index)
        {
            if (index >= questions.Count)
            {
                Response.Redirect("Result.aspx");
            }

            lblQuestion.Text = $"Q{index + 1}: {questions[index].Text}";
            rblOptions.Items.Clear();

            foreach (string opt in questions[index].Options)
            {
                rblOptions.Items.Add(opt);
            }
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            int currentIndex = (int)ViewState["index"];
            int score = (int)ViewState["score"];

            if (rblOptions.SelectedIndex == questions[currentIndex].CorrectIndex)
            {
                score++;
            }

            currentIndex++;
            ViewState["index"] = currentIndex;
            ViewState["score"] = score;

            if (currentIndex == questions.Count)
            {
                Session["finalScore"] = score;
                Response.Redirect("Result.aspx");
            }
            else
            {
                DisplayQuestion(currentIndex);
            }
        }

        public class Question
        {
            public string Text { get; set; }
            public string[] Options { get; set; }
            public int CorrectIndex { get; set; }
        }
    }
}