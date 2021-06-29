using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jespers_slutprojekt.Models
{
    public class CoursesAndTreatments
    {
        public int Id { get; set; }

        /* info only for courses */
        public DateTime CourseStartDate { get; set; }
        public DateTime BirthDate { get; set; }
        public string StreetAddress { get; set; }
        public int ZipCode { get; set; }
        public string CoursePrice { get; set; }

        /* common info for courses and treatments */
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public long PhoneNumber { get; set; }
        public DateTime SignedUpDate { get; set; }

        /* info only for treatments */
        public DateTime TreatmentDate { get; set; }
        public string TreatmentMethod { get; set; }
        public string TreatmentPrice { get; set; }    
    }
}

