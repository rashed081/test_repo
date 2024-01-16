using YourAcademy.DAL.Entity;
using YourAcademy.DAL.UnitOfWork;
using YourAcademy.Services.Interface;

namespace YourAcademy.Services.Services
{
    public class CourseService :ICourseService
    {
        private readonly IApplicationUnitOfWork _unitOfWork;

        public CourseService(IApplicationUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddCourse(Course course)
        {
            try
            {
                _unitOfWork.BeginTransaction();
                _unitOfWork.Courses.Add(course);
                _unitOfWork.Commit();
            }
            catch (Exception)
            {
                _unitOfWork.Rollback();
                throw;
            }
            finally
            {
                _unitOfWork.Dispose();
            }
        }

        public IList<Course> GetAllCourses()
        {
            try
            {
                _unitOfWork.BeginTransaction();

                var courses = _unitOfWork.Courses.GetAll();

                _unitOfWork.Commit();

                return courses;
            }
            catch (Exception)
            {
                _unitOfWork.Rollback();
                throw;
            }
            finally
            {
                _unitOfWork.Dispose();
            }
        }

        public Course GetCourse(Guid id)
        {
            try
            {
                _unitOfWork.BeginTransaction();

                var course = _unitOfWork.Courses.GetById(id);

                _unitOfWork.Commit();

                return course;
            }
            catch (Exception)
            {
                _unitOfWork.Rollback();
                throw;
            }
            finally
            {
                _unitOfWork.Dispose();
            }
        }
    }
}
