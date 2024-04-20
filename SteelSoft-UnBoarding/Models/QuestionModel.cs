using SteelSoft_UnBoarding.Data;

namespace SteelSoft_UnBoarding.Models
{
    public class QuestionModel : UserModel
    {
        public QuestionModel(int ID, User user) : base(user)
        {
            this.ID = ID;
        }

        public int ID { get; set; }
        private Question question = null;

        public Question GetInformation()
        {
            if(question != null) { 
                return question;
            }
            var resQuery = PostgreSQL.Query($"SELECT * FROM questions  WHERE id = {ID}");

            var qs = new Question()
            {
                ID = ID,
                Number = int.Parse( resQuery[0]["number"]),
                Title = resQuery[0]["title"],
                Content = resQuery[0]["content"],
                score = int.Parse( resQuery[0]["score"]),
                id_task = int.Parse(resQuery[0]["id_task"]),
            };
            question = qs;
            return question;
        }

        public (int last, int next) GetSosedi()
        {
            int last = -1, next = -1;
            var resQuery = PostgreSQL.Query($"SELECT count(*) as count FROM question WHERE number < {GetInformation().Number} WHERE id = {ID}") ?? null;
            if (int.Parse(resQuery[0]["count"]) > 0)
            {
                last = GetInformation().Number - 1;
            }
             resQuery = PostgreSQL.Query($"SELECT count(*) as count FROM question WHERE number > {GetInformation().Number} WHERE id = {ID}") ?? null;
            if (int.Parse(resQuery[0]["count"]) > 0)
            {
                next = GetInformation().Number + 1;
            }

            return (last, next);
        }
        public TaskItem GetThisTask()
        {
            var model = new TaskModel(GetInformation().id_task, this.User);
            return model.Task();
        }
    }
    public class Question
    {
        public int ID { get; set; }
        public int Number { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int score { get; set; }
        public int id_task { get; set; }
    }
}
