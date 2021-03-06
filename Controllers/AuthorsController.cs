﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using CourseApi.Helpers;
using CourseApi.ReadDTO;
using CourseApi.Service;
using CourseApi.WriteDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourseApi.Controllers
{
   // [Route("api/[controller]")]
    [Route("api/Authors")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly ICourseLibraryRepository _courseLibrary;
        private readonly IMapper _mapper;

        public AuthorsController(ICourseLibraryRepository courseLibrary, IMapper mapper)
        {
            _courseLibrary = courseLibrary;
            _mapper = mapper;
        }

        [HttpGet("GetAllAuthors", Name ="GetAuthors")]
        public ActionResult<IEnumerable<AuhtorDTO>> GetAuthors([FromQuery] AuhtorResourceParameters auhtorResourceParameters)
        {
            try
            {
                var GetAllAuthors = _courseLibrary.GetAuthors(auhtorResourceParameters);

                //checking if there is a previous link, if there is calle dthe method, if not set to null
                var previousPageLink = GetAllAuthors.HasPrevious ? CreateAuthorsResourceUris(auhtorResourceParameters, ResourceUriType.PreviousPage) : null;

                var nextPageLink = GetAllAuthors.HasNext ? CreateAuthorsResourceUris(auhtorResourceParameters, ResourceUriType.NextPage) : null;

                //then we create the MetaData we want to return to the user for guide 

                var paginationMetaData = new
                {
                    totalCount = GetAllAuthors.Totalcount,
                    pageSize = GetAllAuthors.PageSize,
                    currentPage = GetAllAuthors.CurrentPage,
                    previousPageLink,
                    nextPageLink
                };

                //Adding to the header 
                Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(paginationMetaData));
               

                //using Automapper for cleaner code instead of select Query,(seee below)
                //the return type first(destination), then the source
                var auhtors = _mapper.Map<IEnumerable<AuhtorDTO>>(GetAllAuthors);

                //var auhtors = GetAllAuthors
                //    .Select(a => new AuhtorDTO
                //    {
                //        ID = a.ID,
                //        Name =$"{a.FirstName} {a.LastName}",
                //        //An extention method written to grab the Authors age
                //        Age = DateTimeOffSetExtensions.GetCurrentAge(a.DateOfBirth),
                //        MainCategory = a.MainCategory,
                //        Courses = a.Courses,
                //    });


                // return body format for the Api with right statusCode
                return Ok(new JsonResponse<AuhtorDTO>()
                {
                    Success = true,
                    Results = auhtors
                });
            }

            catch(Exception ex)
            {
                //log ex
                var path = HttpContext.Request.Path;
                var query = HttpContext.Request.QueryString;
                var pathAndQuery = path + query;
                var messg = _courseLibrary.LogErrorMessage(ex.Message, pathAndQuery);
                return Ok(new JsonResponse<string>()
                {
                    Success = false,
                    ErrorMessage = "Sorry, something just went wrong while processing your request! Pls Try Again."
                });


                //return StatusCode(500, messg);
            }

           // return Ok(GetAllAuthors);
        }

        [HttpGet("GetSingleAuthor/{authorId}", Name = "getAuhtors")]
        public IActionResult GetSingleAuthor(int authorId)
        {
            try
            {
                var singleAuthor = _courseLibrary.GetAuthor(authorId);

                if (singleAuthor == null)
                {
                    return NotFound(new JsonResponse<string>()
                    {
                        Success = false,
                        ErrorMessage = "Author Not found, Invalid Id."
                    });

                }

                //using Automapper instead for cleaner code
                //the return type first(destination), then the source
                var auhtor = _mapper.Map<AuhtorDTO>(singleAuthor);

                //var SingleAuthorDTO = new AuhtorDTO()
                //{
                //    ID = singleAuthor.ID,
                //    Name = $"{singleAuthor.FirstName} {singleAuthor.LastName}",
                //    Age = DateTimeOffSetExtensions.GetCurrentAge(singleAuthor.DateOfBirth),
                //    MainCategory = singleAuthor.MainCategory,
                //    Courses = singleAuthor.Courses
                //};

                return Ok(new JsonResponses<AuhtorDTO>()
                {
                    Success = true,
                    Result = new List<AuhtorDTO>() {
                    auhtor
                }
                });
            }

            catch(Exception ex)
            {
                //log ex
                var messg = "Something went wrong, pls try again later";
                return StatusCode(500, messg);
            } 

        }

        [HttpPost("CreateAuthor")]
        public ActionResult<AuhtorDTO> CreateAuthor(AuthorDTOW author)
        {
           
            var auhtorr = _mapper.Map<Entities.Author>(author);
            _courseLibrary.AddAuthor(auhtorr);
            _courseLibrary.Save();

            var createdAuthor = _mapper.Map<AuhtorDTO>(auhtorr);

            return CreatedAtRoute("getAuhtors", new { authorId = createdAuthor.ID }, createdAuthor);
            //return Ok(new JsonResponses<AuhtorDTO>()
            //{
            //    Success = true,
            //    Result = new List<AuhtorDTO>() {
            //        createdAuthor
            //    }
            //});
        }

        //this methods helps to create a Url link to previous Resource
        private string CreateAuthorsResourceUris(AuhtorResourceParameters auhtorResourceParameters, ResourceUriType type)
        {
            switch (type)
            {
                case ResourceUriType.PreviousPage:
                    return Url.Link("GetAuthors",
                        new
                        {
                            PageNumber = auhtorResourceParameters.PageNumber - 1,
                            PageSize = auhtorResourceParameters.pageSize,
                            MainCategory = auhtorResourceParameters.mainCategory,
                            SearchQuery = auhtorResourceParameters.searchQuery
                        });

                case ResourceUriType.NextPage:
                    return Url.Link("GetAuthors",
                       new
                       {
                           PageNumber = auhtorResourceParameters.PageNumber + 1,
                           PageSize = auhtorResourceParameters.pageSize,
                           MainCategory = auhtorResourceParameters.mainCategory,
                           SearchQuery = auhtorResourceParameters.searchQuery
                       });
                default:
                    return Url.Link("GetAuthors",
                       new
                       {
                           PageNumber = auhtorResourceParameters.PageNumber,
                           PageSize = auhtorResourceParameters.pageSize,
                           MainCategory = auhtorResourceParameters.mainCategory,
                           SearchQuery = auhtorResourceParameters.searchQuery
                       });

            }

        }

    }
}