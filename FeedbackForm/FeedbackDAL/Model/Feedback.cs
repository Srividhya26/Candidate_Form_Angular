using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace FeedbackDAL.Model
{
    [Table("Feedback")]
    public partial class Feedback
    {
        [Key]
        public int Id { get; set; }
        public int SessionId { get; set; }
        [StringLength(25)]
        public string Email { get; set; }
        [StringLength(10)]
        public string MobileNumber { get; set; }
        [StringLength(200)]
        public string Comment { get; set; }
        public bool? IsInformative { get; set; }
        public int? SpeakerRating { get; set; }
        public int? OverrallRating { get; set; }

        [ForeignKey(nameof(SessionId))]
        [InverseProperty("Feedbacks")]
        public virtual Session Session { get; set; }
    }
}
