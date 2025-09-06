using System.ComponentModel.DataAnnotations;

namespace AngularBlog
{
	public class Students
	{

		[Key]
		public int ID { get; set; }

		[Required(ErrorMessage = "Valid Name Required")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Valid Class Required")]
		public string Class { get; set; }

		public string? DropDownNAme { get; set; }
	}
}
