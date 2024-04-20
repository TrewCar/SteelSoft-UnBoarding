using SteelSoft_UnBoarding.Data;

namespace SteelSoft_UnBoarding.Models
{
    public class TaskListModel : UserModel
    {
        public TaskListModel(User user) : base(user)
        { }
        public List<TaskItem> GetTasks() {
            var resQuery = PostgreSQL.Query(
                " SELECT " +
                " tl.*," +
                " (SELECT sum(score) FROM questions where id_task = tl.id) as total," +
               $" (SELECT sum(qs.score) FROM infousers as iu LEFT JOIN questions as qs on qs.id = iu.id_task WHERE id_user = {User.ID} and qs.id_task = tl.id) as complite " +
                " FROM tasklist as tl "
                );

            List<TaskItem> res = new();

            foreach( var item in resQuery )
            {
                var row = new TaskItem()
                {
                    Id = int.Parse(item["id"]),
                    Name = item["name"],
                    Description = item["description"],
                    ScoreTotal = int.Parse(item["total"]),
                    ScoreComplite = int.Parse(item["complite"])
                };
                res.Add(row);   
            }
            return res;
        }
    }
}
