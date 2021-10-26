using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace FeedbackDAL.Model
{
    public partial class Users
    {
        public Users()
        {
            SessionConductors = new HashSet<Session>();
            SessionSpeakers = new HashSet<Session>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(25)]
        public string Role { get; set; }

        [InverseProperty(nameof(Session.Conductor))]
        public virtual ICollection<Session> SessionConductors { get; set; }
        [InverseProperty(nameof(Session.Speaker))]
        public virtual ICollection<Session> SessionSpeakers { get; set; }
    }
}
