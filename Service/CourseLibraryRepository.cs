using CourseApi.DbContexts;
using CourseApi.Entities;
using CourseApi.Helpers;
using CourseApi.ReadDTO;
using EFCore.BulkExtensions;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseApi.Service
{
    public class CourseLibraryRepository : ICourseLibraryRepository, IDisposable
    {
        private readonly CourseLibraryContext _context;

        public CourseLibraryRepository(CourseLibraryContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context)); //throw a nullException if context is null,
                                                                                      // nameof() is used to capture name of a variable
        }
        public void AddAuthor(Author author)
        {
            try
            {
                if (author == null)
                {
                    throw new ArgumentNullException(nameof(author));
                }
                _context.Authors.Add(author);
            }
            catch (Exception ex)
            {
                var exceptn = ex;
                //--- log to db
                
            }
        }

        //uisng EfCore Bulk Extension to add bulk records to DB
        public void AddAuthors(List<Author> authors)
        {
            //var auhtorssss = new List<Author>();
            //auhtorssss.Add(new Author()
            //{
            //     FirstName = "joe",
            //      LastName = "kafff",
            //       MainCategory = "Ment"

            //});
            try
            {
                if (authors == null)
                {
                    throw new ArgumentNullException(nameof(authors));
                }
                _context.BulkInsert(authors);
            }
            catch (Exception ex)
            {
                var exceptn = ex;
                //--- log to db

            }
        }


        public void AddCourse(int authorId, Course course)
        {
            try
            {
                //grab single author
                var singleAuthor = _context.Authors.FirstOrDefault(a => a.ID == authorId);
                if (singleAuthor == null)
                {
                    throw new ArgumentNullException(nameof(authorId)); // nameof() is used to capture name of a variable
                }

                course.AuthorId = authorId;
                _context.Courses.Add(course);
            }

            catch(Exception ex)
            {
                var exceptn = ex;
                //--- log to db
            }
            
          
        }

        public bool AuthorExists(int authorId)
        {
            var authorExist = _context.Authors.Any(a => a.ID == authorId);
            //if(authorExist == null)
            //{
            //    return false;
            //}

            //return true;
            return authorExist;
        }

        public void DeleteAuthor(Author author)
        {
            _context.Authors.Remove(author);
        }

        public void DeleteCourse(Course course)
        {
            _context.Courses.Remove(course);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                //dispose resources when needed...
            }
        }

        public Author GetAuthor(int authorId)
        {
            try
            {
                var SingleAuthor = _context.Authors.FirstOrDefault(a => a.ID == authorId);
                if (SingleAuthor == null)
                {
                    throw new ArgumentNullException(nameof(authorId));
                }
                return SingleAuthor;
            }

            catch (Exception ex)
            {
                //log exception
                //var excptn = ex;
                return null;
            }
        }

        //public List<Author> GetAuthors()
        //{
        //    return _context.Authors.ToList()
        //                       .OrderBy(a => a.FirstName);
        //}

        public IEnumerable<Author> GetAuthors()
        {
            return _context.Authors
                                //.Include(c => c.Courses)
                               .OrderBy(a => a.FirstName)
                               .ToList();
        }

        public List<SystemErrorLog> LogErrorMessage(string errorMessage, string errorSource)
        {
            //string param1 = errorMessage;
            //string param2 = errorSource;

           
            var errormessageParam = new SqlParameter("errormessage", errorMessage);
            var errorsourceParam = new SqlParameter("errorsource", errorSource);

            var exLog = _context.systemErrorLogs.FromSqlRaw("[dbo].[LOG_ERROR_TO_SYS_ERR_TABLE_1] @errormessage, @errorsource", errormessageParam, errorsourceParam).ToList();

            // var result = dbContext.Database.SqlQuery<int>("[dbo].[SPH_LOG_ERROR_TO_SYS_ERR_TABLE] @username, @errormessage, @errorsource", usernameParam, errormessageParam, errorsourceParam).SingleOrDefaultAsync();

           return exLog;
        }

        //get Auhtors wth mainCategory for filtering purpose and searching
        public PagedList<Author> GetAuthors(AuhtorResourceParameters auhtorResourceParameters)
        {
            //throw new ArgumentNullException();

            //if (string.IsNullOrWhiteSpace(auhtorResourceParameters.mainCategory) && string.IsNullOrWhiteSpace(auhtorResourceParameters.searchQuery))
            //{
            //    return GetAuthors();
            //}

            var collections = _context.Authors as IQueryable<Author>;

            if (!string.IsNullOrWhiteSpace(auhtorResourceParameters.mainCategory))
            {
                auhtorResourceParameters.mainCategory = auhtorResourceParameters.mainCategory.Trim();

                collections = collections.Where(m => m.MainCategory == auhtorResourceParameters.mainCategory);
              //  return collections;
            }

            //implemenent searching 
            if (!string.IsNullOrWhiteSpace(auhtorResourceParameters.searchQuery))
            {
                auhtorResourceParameters.searchQuery = auhtorResourceParameters.searchQuery.Trim();

                collections = collections.Where(m => m.MainCategory.Contains(auhtorResourceParameters.searchQuery)
                || m.FirstName.Contains(auhtorResourceParameters.searchQuery)
                || m.LastName.Contains(auhtorResourceParameters.searchQuery));
               
            }

            //apply the paging here before TOList is called

            return PagedList<Author>.Create(collections, auhtorResourceParameters.PageNumber, auhtorResourceParameters.pageSize);
               //return collections
               // .Skip(auhtorResourceParameters.pageSize * (auhtorResourceParameters.PageNumber - 1)) // ths 
               // .Take(auhtorResourceParameters.pageSize)
               // .ToList();
        }


        public IEnumerable<Author> GetAuthors(IEnumerable<int> authorIds)
        {
           var authors = _context.Authors.Where(a => authorIds.Contains(a.ID))
                                .OrderBy(a => a.FirstName)
                                .OrderBy(a => a.LastName)
                                .ToList();
            return authors;
        }

        public Course GetCourse(int authorId, int courseId)
        {
            try
            {
                var author = _context.Authors.FirstOrDefault(a => a.ID == authorId);
                var course = _context.Courses.FirstOrDefault(c => c.ID == courseId && c.AuthorId == authorId);
                if (author == null)
                {
                    throw new ArgumentNullException("AuthorId is Invalid");
                }

                if (course == null)
                {
                    throw new ArgumentNullException("No course found for this Author");
                }

                return course;
            }
            catch(Exception ex)
            {
                //log the ex
                return null;
            }
        }

        public IEnumerable<Course> GetCourses(int authorId)
        {
            try
            {
                //grab single author
                var AuhtorCheck = _context.Authors.FirstOrDefault(a => a.ID == authorId);
                if (AuhtorCheck == null)
                {
                    throw new ArgumentNullException(nameof(authorId)); // nameof() is used to capture name of a variable
                }

                var courses = _context.Courses
                              // .Include(a => a.Author)
                               .Where(c => c.AuthorId == authorId)
                               .OrderBy(c => c.Title).ToList();
                return courses;
            }

            catch (Exception ex)
            {
                //log the ex
                return null;
            }

           
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateAuthor(Author author)
        {
            var singleAuthor = _context.Authors.FirstOrDefault(a => a.ID == author.ID);

            singleAuthor.DateOfBirth = author.DateOfBirth;
            singleAuthor.FirstName = author.FirstName;
            singleAuthor.LastName = author.LastName;
            singleAuthor.MainCategory = author.MainCategory;
        }

        public void UpdateCourse(Course course)
        {
            try
            {
                var singleCourse = _context.Courses.FirstOrDefault(c => c.ID == course.ID);
                if(singleCourse == null)
                {
                    throw new ArgumentNullException(nameof(course));
                }
                singleCourse.Title = course.Title;
                singleCourse.Description = course.Description;
            }
            catch(Exception ex)
            {
               // return ArgumentNullException();
            }
           // singleCourse.AuthorId = course.AuthorId;
        }
    }
}
