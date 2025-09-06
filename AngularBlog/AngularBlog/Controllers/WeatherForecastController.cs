using AngularBlog;
using Microsoft.AspNetCore.Mvc;

namespace AngularBlog
{
	[ApiController]
	[Route("api/[controller]")]
	public class AngularController : ControllerBase
	{
		private readonly dal _dal;

		public AngularController(dal dal)
		{
			_dal = dal;
		}

		[HttpGet("getall")]
		public IActionResult GetAll()
		{
			var students = _dal.GetAll();
			return Ok(students); // returns JSON
		}

		[HttpGet("{id}")]
		public IActionResult GetById(int id)
		{
			var student = _dal.GetbyId(id);
			if (student == null) return NotFound();
			return Ok(student);
		}

		[HttpPost]
		public IActionResult AddEdit(Students student)
		{
			_dal.AddEditUpdte(student);
			return Ok(student);
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			_dal.DeleteStudent(id);
			return NoContent();
		}
	}
}
