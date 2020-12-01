using CourseApi.DbContexts;
using CourseApi.Entities;
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
            var SingleAuthor = _context.Authors.FirstOrDefault(a => a.ID == authorId);
            if (SingleAuthor == null)
            {
                throw new ArgumentNullException(nameof(authorId));
            }
            return SingleAuthor;
        }

        public IEnumerable<Author> GetAuthors()
        {
            return _context.Authors.ToList()
                               .OrderBy(a => a.FirstName);
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
           
                var author = _context.Authors.FirstOrDefault(a => a.ID == authorId);
                var course = _context.Courses.FirstOrDefault(c => c.ID == courseId);
                if (author == null && course == null)
                {
                    throw new ArgumentNullException("AuthorId or courseId is Invalid");
                }

                return course;
        }

        public IEnumerable<Course> GetCourses(int authorId)
        {
            //grab single author
            var author = _context.Authors.FirstOrDefault(a => a.ID == authorId);
            if(author == null)
            {
                throw new ArgumentNullException(nameof(authorId)); // nameof() is used to capture name of a variable
            }

            var courses = _context.Courses
                                .Where(c => c.AuthorId == authorId)
                                .OrderBy(c => c.Title).ToList();
            return courses;
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
            var singleCourse = _context.Courses.FirstOrDefault(c => c.ID == course.ID);

            singleCourse.Title = course.Title;
            singleCourse.Description = course.Description;
           // singleCourse.AuthorId = course.AuthorId;
        }
    }
}
