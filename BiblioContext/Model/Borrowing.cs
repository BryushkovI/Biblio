using AuthAppLib.Model;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioContext.Model
{
    public class Borrowing
    {
        public int Id { get; set; }
        public int BookId {  get; set; }
        public string ReaderId { get; set; }
        [NotMapped]
        public User Reader { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
