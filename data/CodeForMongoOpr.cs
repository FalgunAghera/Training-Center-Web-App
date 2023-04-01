using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations; // Import necessary packages

namespace api_test_with_mongo.data
{

    public class Address // Define a class for Address
    {
        // Define a property for the detailed address, City, State, Pincode
        [Required(ErrorMessage = "Detailed address is required")]
        public string? detailedAddress { get; set; }

        [Required(ErrorMessage = "City is required")]
        public string? city { get; set; }

        [Required(ErrorMessage = "State is required")]
        public string? state { get; set; }

        [Required(ErrorMessage = "Pin code is required")]
        [RegularExpression(@"^\d{6}$", ErrorMessage = "Invalid pin code")]
        public string? pinCode { get; set; }
    }


    public class CodeForMongoOpr // Define a class for the code related to MongoDB operations
    {
        [BsonId] // This attribute marks a property as the document's primary key
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)] // This attribute specifies the BSON type for the primary key
        public ObjectId Id { get; set; } // Define a property for the primary key



        [Required(ErrorMessage = "Center name is required")] // This attribute marks a property as required and sets an error message if it is not provided
        [StringLength(40, ErrorMessage = "Center name should be less than 40 characters")] // This attribute sets a maximum length for the property and an error message if it is exceeded
        public string? CenterName { get; set; } // Define a property for the center name

        [Required(ErrorMessage = "Center code is required")] // This attribute marks a property as required and sets an error message if it is not provided
        [RegularExpression("^[a-zA-Z0-9]{12}$", ErrorMessage = "Center code should be exactly 12 alphanumeric characters")] // This attribute sets a regular expression pattern that the property must match and an error message if it doesn't
        public string? CenterCode { get; set; } // Define a property for the center code

        [Required(ErrorMessage = "Address is required")] // This attribute marks a property as required and sets an error message if it is not provided
        public Address? Address { get; set; } = new Address();// Define a property for the address

        [Range(0, int.MaxValue, ErrorMessage = "Student capacity should be a non-negative number")] // This attribute sets a range for the property and an error message if it is exceeded
        public int StudentCapacity { get; set; } // Define a property for the student capacity

        [MinLength(1, ErrorMessage = "At least one course must be offered")]
        public List<string>? coursesOffered { get; set; } = new List<string>(); // Define a property for the courses offered

        public long CreatedOn { get; set; } = DateTimeOffset.UtcNow.ToUnixTimeSeconds();// Define a property for the creation timestamp

        [Required(ErrorMessage = "Center code is required")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[cC][oO][mM]$", ErrorMessage = "Invalid email address")]
        public string? contactEmail { get; set; }

        [Required(ErrorMessage = "Contact phone number is required")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Invalid phone number")]
        public string? contactPhone { get; set; }
    }
}
