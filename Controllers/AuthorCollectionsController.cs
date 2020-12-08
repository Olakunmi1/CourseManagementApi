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
    [Route("api/Authors")]
    [ApiController]
    public class AuthorCollectionsController : ControllerBase
    {
        private readonly ICourseLibraryRepository _courseLibrary;
        private readonly IMapper _mapper;

        public AuthorCollectionsController(ICourseLibraryRepository courseLibrary, IMapper mapper)
        {
            _courseLibrary = courseLibrary;
            _mapper = mapper;
        }

        [HttpPost("CreateAuthorCollections")]
        public ActionResult<IEnumerable<AuhtorDTO>> CreateAuthorCollection(IEnumerable<AuthorDTOW> author)
        {

            var auhtorrs = _mapper.Map<IEnumerable<Entities.Author>>(author);
            foreach (var authorr in auhtorrs)
            {
                //A bulk insert with iteration before calling SaveChnages Once
                _courseLibrary.AddAuthor(authorr);
            }

            _courseLibrary.Save();

            var createdAuthors = _mapper.Map<IEnumerable<AuhtorDTO>>(auhtorrs);

           // return CreatedAtRoute("getAuhtors", new { authorId = createdAuthor.ID }, createdAuthors);
            return Ok(new JsonResponse<AuhtorDTO>()
            {
                Success = true,
                Results = createdAuthors
            });
        }

        [HttpPost("CreateAuthorCollection")]
        public ActionResult<IEnumerable<AuhtorDTO>> CreateAuthorCollection(List<AuthorDTOW> authors)
        {

            var auhtorrs = _mapper.Map<List<Entities.Author>>(authors);
            //A bulk insert with BULK insert efcore extension
            _courseLibrary.AddAuthors(auhtorrs);
            //calling SvaeChnages not needed

            var createdAuthors = _mapper.Map<IEnumerable<AuhtorDTO>>(auhtorrs);

            return Ok(new JsonResponse<AuhtorDTO>()
            {
                Success = true,
                Results = createdAuthors
            });
        }


    }
}
