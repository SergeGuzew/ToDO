using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Ru.KpXX.Tests.Test02.ToDoApi.Models
{
    public class Task
    {
        public int TaskId { get; set; }
        [Required]
        public string Name { get; set; }
        public bool Done { get; set; }
    }
}