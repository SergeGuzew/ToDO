using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

using Ru.KpXX.Tests.Test02.ToDoApi.Models;

namespace Ru.KpXX.Tests.Test02.ToDoApi.Controllers
{
    //
    // Для упрощения сериализации
    //
    public class TasksInfo
    {
        public int InWork { get; set; }
        public int All { get; set; }
    }

    //
    // Получить информацию о том, сколько задач осталось сделать и сколько всего
    // По хорошему - повесить на основнй API, скажем через HEAD, но WebApi плохо реагирует на команду HEAD
    // Надо подумать - как
    //
    public class InfoController: ApiController
    {
        // GET api/Info
        public TasksInfo Get()
        {
            ToDoDB db = new ToDoDB();
            var res=new TasksInfo { InWork = db.Tasks.Where(x => !x.Done).Count(), All = db.Tasks.Count() };
            db.Dispose();
            return res;
        }

    }

    //
    // Основной API
    //
    // Пока работают
    //
    // GET api/ToDo - получить список всех задач
    // POST api/ToDo - создать новую задачу
    // PUT api/ToDo/5 - переключить сделанность задачи с TaskId
    //
    public class ToDoController: ApiController
    {
        private ToDoDB db = new ToDoDB();
        // GET api/ToDo
        public IEnumerable<Task> Get()
        {
            return db.Tasks;
        }

        //// GET api/ToDo/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/ToDo
        public Task Post([FromBody] Task value)
        {
            db.Tasks.Add(value);
            db.SaveChanges();
            return value;
        }

        // PUT api/ToDo/5
        public Task Put(int id)
        {
            Task task=db.Tasks.Find(id);
            task.Done = !task.Done;
            db.SaveChanges();
            return task;
        }

        //// DELETE api/ToDo/5
        //public void Delete(int id)
        //{
        //}
    }
}
