using Microsoft.AspNetCore.Mvc;

namespace StudentApi;

[ApiController]
[Route("api/[controller]")]
public class StudentController : ControllerBase
{
    private static readonly List<Student> students = new List<Student>
    {
        new Student
        {
            ID = 1,
            Name = "Mercury",
            Age = 21,
            Course = "Science"
        },

        new Student
        {
            ID = 2,
            Name = "Venus",
            Age = 18,
            Course = "Maths"
        },

        new Student
        {
            ID = 3,
            Name = "Earth",
            Age = 20,
            Course = "Environment"
        },

        new Student
        {
            ID = 4,
            Name = "Mars",
            Age = 24,
            Course = "English"
        }
    };

    //  all da students
    [HttpGet]
    [Route("getAll")]
    public ActionResult<List<Student>> Get()
    {
        return Ok(students);
    }


    [HttpGet("{id}")]
    public ActionResult<Student> Get(int id)
    {
        var studentABC = students.FirstOrDefault(p => p.ID == id);

        if (studentABC == null)
        {
            return NotFound();
        }

        return Ok(studentABC);
    }

    [HttpPost]
    public ActionResult<Student> Post(Student newstudent)
    {
        newstudent.ID = students.Max(p => p.ID) + 1;
        students.Add(newstudent);

        return CreatedAtAction(nameof(Get), new { id = newstudent.ID }, newstudent);
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var student = students.FirstOrDefault(p => p.ID == id);

        if (student == null)
        {
            return NotFound();
        }

        students.Remove(student);

        return NoContent();
    }

    [HttpPut("{id}")]
    public ActionResult Put(int id, Student student)
    {
        var existingStudent = students.FirstOrDefault(p => p.ID == id);

        if (existingStudent == null)
        {
            return NotFound();
        }

        students.Remove(existingStudent);
        student.ID = id;  
        students.Add(student);

        return Ok(student);
    }
}