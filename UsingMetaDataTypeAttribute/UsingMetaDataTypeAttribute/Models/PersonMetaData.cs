using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UsingMetaDataTypeAttribute.Models
{

    [MetadataType(typeof(PersonMetaData))]
    public partial class Person
    {

    }
    public class PersonMetaData
    {
        [Required(ErrorMessage = "First Name is Required")]
        [StringLength(15, ErrorMessage = "First Name cannot be more than 15 characters")]
        public string FirstName { get; set; }
    }
}