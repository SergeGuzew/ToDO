using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Ru.KpXX.Tests.Test02.ToDoApi.Models
{
    public class ToDoInitializer: DropCreateDatabaseAlways<ToDoDB>
    {
        protected override void Seed(ToDoDB context)
        {
            base.Seed(context);
            var tasks=new List<Task>()
            {
                new Task
                {
                    Name="Test task 1",
                    Done=false
                }
                , new Task
                {
                    Name="Test task 2",
                    Done=true
                }
                , new Task
                {
                    Name="Test task 3",
                    Done=false
                }
            };
            tasks.ForEach(s => context.Tasks.Add(s));
            context.SaveChanges();

        }
    }
}