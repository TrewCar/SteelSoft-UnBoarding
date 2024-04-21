using SteelSoft_UnBoarding.Data;

namespace SteelSoft_UnBoarding.Models
{
    public class TaskModel : UserModel
    {
        public TaskModel(int id, User user) : base(user)
        {
            this.Id = id;
        }
        public int Id { get; set; }
        public List<Question> GetQuestions()
        {
            var resQuery = PostgreSQL.Query($"SELECT questions.*, CASE WHEN iu.id_user IS NULL THEN '-' ELSE '+' END AS condition_result FROM questions LEFT JOIN infousers  AS iu ON iu.id_user = {User.ID} AND iu.id_task = questions.id WHERE questions.id_task = {this.Id} ORDER BY number");
            List<Question> res = new List<Question>();
            foreach( var item in resQuery )
            {
                var qs = new Question()
                {
                    ID = int.Parse(item["id"]),
                    Number = int.Parse(item["number"]),
                    Title = item["title"],
                    Content = item["content"],
                    score = int.Parse(item["score"]),
                    id_task = int.Parse(item["id_task"]),
                    complite = item["condition_result"]
                };
                res.Add(qs);
            }
            return res;
        }
        public TaskItem Task()
        {
            var resQuery = PostgreSQL.Query(" SELECT " +
                " tl.*," +
                " (SELECT sum(score) FROM questions where id_task = tl.id) as total," +
               $" (SELECT sum(qs.score) FROM infousers as iu LEFT JOIN questions as qs on qs.id = iu.id_task WHERE id_user = {User.ID} and qs.id_task = tl.id) as complite " +
                " FROM tasklist as tl " +
                $" WHERE tl.id = {Id}"
                );
            return new TaskItem()
            {
                Id = int.Parse(resQuery[0]["id"]),
                Name = resQuery[0]["name"],
                Description = resQuery[0]["description"],
                ScoreTotal = int.Parse(resQuery[0]["total"]),
                ScoreComplite = int.Parse(resQuery[0]["complite"])
            };
        }
    }
    public class TaskItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } 
        public int ScoreTotal { get; set; }
        public int ScoreComplite { get; set; }

    }
}
