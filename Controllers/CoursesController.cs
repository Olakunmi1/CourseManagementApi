using AutoMapper;
using CourseApi.ReadDTO;
using CourseApi.Service;
using CourseApi.WriteDTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseApi.Controllers
{
    [ApiController]
    [Route("api/authors/{authorId}/courses")]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseLibraryRepository _courseLibrary;
        private readonly IMapper _mapper;

        public CoursesController(ICourseLibraryRepository courseLibrary, IMapper mapper)
        {
            _courseLibrary = courseLibrary;
            _mapper = mapper;
        }

        [HttpGet()]
        public ActionResult<IEnumerable<CoursesDTO>> GetCoursesForAuthor(int authorId)
        {
            try
            {
                var AuthorsCourses = _courseLibrary.GetCourses(authorId);
                if (AuthorsCourses == null)
                {
                    return NotFound(new JsonResponse<string>()
                    {
                        Success = false,
                        ErrorMessage = "Author does Not exist, Invalid Id."
                    });
                }


                var CoursesforAuthor = _mapper.Map<IEnumerable<CoursesDTO>>(AuthorsCourses);

                // return body format for the Api with right statusCode
                return Ok(new JsonResponse<CoursesDTO>()
                {
                    Success = true,
                    Results = CoursesforAuthor
                });
            }

            catch (Exception ex)
            {
                //log ex
                return StatusCode(500, "Something went wrong, pls try again later");
            }
        }

        [HttpGet("{courseId}", Name = "getCourseForAnAuthor")]
        public ActionResult<CoursesDTO> GetCourseForAuthor(int authorId, int courseId)
        {
            try
            {
                var AuthorExist = _courseLibrary.AuthorExists(authorId);
                if (!AuthorExist)
                {
                    return NotFound(new JsonResponse<string>()
                    {
                        Success = false,
                        ErrorMessage = "AuthorId is Invalid."
                    });
                }
                var AuthorsCourse = _courseLibrary.GetCourse(authorId, courseId);
                if (AuthorsCourse == null)
                {
                    return NotFound(new JsonResponse<string>()
                    {
                        Success = false,
                        ErrorMessage = "CourseId is Invalid."
                    });
                }


                var CourseforAuthor = _mapper.Map<CoursesDTO>(AuthorsCourse);

                // return body format for the Api with right statusCode
                return Ok(new JsonResponses<CoursesDTO>()
                {
                    Success = true,
                    Result = new List<CoursesDTO>() {
                        CourseforAuthor
                    }
                });
            }

            catch (Exception ex)
            {
                //log ex
                return StatusCode(500, "Something went wrong, pls try again later");
            }

        }


        [HttpPost("createCourseForAuthor")]
        public ActionResult<CoursesDTO> CreateCourseForAuthor(int authorId, createCourseForAuthorDTOW createCourse)
        {
            //check if the author exists
            var singleauthor = _courseLibrary.GetAuthor(authorId);
            if(singleauthor == null)
            {
                return NotFound(new JsonResponse<string>()
                {
                    Success = false,
                    ErrorMessage = "AuthorId is Invalid."
                });
            }
            var course = _mapper.Map<Entities.Course>(createCourse);
            //course.ID = authorId;
            _courseLibrary.AddCourse(authorId, course);
            _courseLibrary.Save();

            var createdCourse = _mapper.Map<CoursesDTO>(course);

            return CreatedAtRoute("getCourseForAnAuthor", new { authorId = authorId, courseId = createdCourse.ID }, createdCourse);
            //return Ok(new JsonResponses<AuhtorDTO>()
            //{
            //    Success = true,
            //    Result = new List<AuhtorDTO>() {
            //        createdAuthor
            //    }
            //});
        }

        [HttpPut("{courseId}")]
        public IActionResult UpdateCourseForAuthor(int authorId, int courseId, CourseForUpdateDTO courseForUpdate)
        {
            var AuthorExist = _courseLibrary.AuthorExists(authorId);
            if (!AuthorExist)
            {
                return NotFound(new JsonResponse<string>()
                {
                    Success = false,
                    ErrorMessage = "AuthorId is Invalid."
                });
            }
            var AuthorsCourse = _courseLibrary.GetCourse(authorId, courseId);
            if (AuthorsCourse == null)
            {
                return NotFound(new JsonResponse<string>()
                {
                    Success = false,
                    ErrorMessage = "CourseId is Invalid."
                });
            }

            var CourseforAuthor = _mapper.Map<Entities.Course>(courseForUpdate);
            _courseLibrary.UpdateCourse(CourseforAuthor);
            _courseLibrary.Save();
            return NoContent();

           // return null;
        }
    }
}
