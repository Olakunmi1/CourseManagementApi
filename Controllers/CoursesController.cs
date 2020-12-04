using AutoMapper;
using CourseApi.ReadDTO;
using CourseApi.Service;
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

        [HttpGet("{courseId}")]
        public ActionResult<CoursesDTO> GetCourseForAuthor(int authorId, int courseId)
        {
            try
            {
                var AuthorsCourse = _courseLibrary.GetCourse(authorId, courseId);
                if (AuthorsCourse == null)
                {
                    return NotFound(new JsonResponse<string>()
                    {
                        Success = false,
                        ErrorMessage = "AuthorId is Invalid."
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
    }
}
