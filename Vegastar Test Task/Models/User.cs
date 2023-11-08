using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vegastar_Test_Task.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }
        public DateTime CreatedDate { get; set; }
        public UserGroup? UserGroup { get; set; }
        public UserState? UserState { get; set; }
    }
}
