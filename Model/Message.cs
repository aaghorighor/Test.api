using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Test.Logger.Services.Common;

namespace Test.Logger.Services.Model
{
    public class Message
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Date is required")]
        public DateTime? CreatedAt { get; set; } = null;

        [Required(ErrorMessage = "Message is required")]
        [StringLength(225)]
        public string Messages { get; set; }
    }
}
