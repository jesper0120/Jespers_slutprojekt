using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Jespers_slutprojekt.Models
{
    public class CoursesAndTreatments
    {
        public int Id { get; set; }

        /* info only for courses */
		[DisplayName("Course date")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        [Required]
        public DateTime CourseStartDate { get; set; }

        [DisplayName("Birth date")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        [Required(ErrorMessage = "When booking a class birth date is necessary to add.")]
        public DateTime BirthDate { get; set; }

        [DisplayName("Street Address")]
        [Required]
        public string StreetAddress { get; set; }

        [DisplayName("Zip Code")]
        [Required]
        public int ZipCode { get; set; }

        [DisplayName("Price of class / treatment")]
        public string? CoursePrice { get; set; }

        /* common info for courses and treatments */
        [DisplayName("First name")]
        [Required]
        public string FirstName { get; set; }

        [DisplayName("Last name")]
        [Required]
        public string LastName { get; set; }

        [DisplayName("Email Address")]
        [Required]
        public string EmailAddress { get; set; }

        [DisplayName("Phone Number (only digits allowed)")]
        [Required]
        public long PhoneNumber { get; set; }

        [DisplayName("Booking date")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime? SignedUpDate { get; set; }

        /* info only for treatments */
        [DisplayName("Treatment date")]
        /*[DisplayFormat(DataFormatString = "{0:YYMMMDD HH:mm}")]*/
        [Required]
        public DateTime TreatmentDate { get; set; }

        [DisplayName("Treatment time")]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:H:mm}")]
        public DateTime TreatmentTime { get; set; }

        [DisplayName("Treatment (write '-' if you do not know)")]
        [Required]
        public string TreatmentMethod { get; set; }

        [DisplayName("Price")]
        public string? TreatmentPrice { get; set; }    
    }
}

