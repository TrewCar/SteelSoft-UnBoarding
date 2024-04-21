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
            var resQuery = PostgreSQL.Query($"SELECT questions.*, CASE WHEN ui.id_user IS NULL THEN '-' ELSE '+' END AS condition_result FROM questions LEFT JOIN infousers AS ui on ui.id_user = {User.ID} and ui.id_task = {ID} WHERE id = {ID}");

            var qs = new Question()
            {
                ID = int.Parse(resQuery[0]["id"]),
                Number = int.Parse( resQuery[0]["number"]),
                Title = resQuery[0]["title"],
                Content = resQuery[0]["content"],
                score = int.Parse( resQuery[0]["score"]),
                id_task = int.Parse(resQuery[0]["id_task"]),
                complite = resQuery[0]["condition_result"]
            };
            question = qs;
            return question;
        }

        public (int last, int next) GetSosedi()
        {
            int last = -1, next = -1;
            var resQuery = PostgreSQL.Query($"SELECT count(*) as count FROM questions WHERE number < {GetInformation().Number} AND id_task = {GetInformation().id_task}") ?? null;
            if (int.Parse(resQuery[0]["count"]) > 0)
            {
                last = GetInformation().Number - 1;
            }
             resQuery = PostgreSQL.Query($"SELECT count(*) as count FROM questions WHERE number > {GetInformation().Number} AND id_task = {GetInformation().id_task}") ?? null;
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
        public string complite { get; set; }
    }
}
