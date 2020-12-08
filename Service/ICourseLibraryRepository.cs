using CourseApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseApi.Service
{
    public interface ICourseLibraryRepository
    {
        IEnumerable<Course> GetCourses(int authorId);
        Course GetCourse(int authorId, int courseId);
        void AddCourse(int authorId, Course course);
        void UpdateCourse(Course course);
        void DeleteCourse(Course course);
        //List<Author> GetAuthors()

        //bulk authors
        void AddAuthors(List<Author> authors);
        List<SystemErrorLog> LogErrorMessage(string errorMessage, string errorSource);

        IEnumerable<Author> GetAuthors();
        IEnumerable<Author> GetAuthors(string mainCategory, string searchQuery);
        Author GetAuthor(int authorId);
        IEnumerable<Author> GetAuthors(IEnumerable<int> authorIds);
        void AddAuthor(Author author);
        void DeleteAuthor(Author author);
        void UpdateAuthor(Author author);
        bool AuthorExists(int authorId);
        bool Save();
    }
}
