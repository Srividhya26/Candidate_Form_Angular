using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace FeedbackDAL.Model
{
    [Table("Session")]
    public partial class Session
    {
        public Session()
        {
            Feedbacks = new HashSet<Feedback>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(25)]
        public string SessionName { get; set; }
        public int ConductorId { get; set; }
        public int SpeakerId { get; set; }
        public TimeSpan? Duration { get; set; }
        [Column(TypeName = "date")]
        public DateTime? Date { get; set; }

        [ForeignKey(nameof(ConductorId))]
        [InverseProperty(nameof(Users.SessionConductors))]
        public virtual Users Conductor { get; set; }
        [ForeignKey(nameof(SpeakerId))]
        [InverseProperty(nameof(Users.SessionSpeakers))]
        public virtual Users Speaker { get; set; }
        [InverseProperty(nameof(Feedback.Session))]
        public virtual ICollection<Feedback> Feedbacks { get; set; }
    }
}
