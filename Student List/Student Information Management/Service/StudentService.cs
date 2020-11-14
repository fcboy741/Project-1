
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace Student_Information_Management.ViewModel
{
    public class StudentService 
    {
        private List<Student> _data;
        public StudentService()
        {
            _data = LoadDataFromXml().Students;
        }

        private static Dataset LoadDataFromXml()
        {
            XmlSerializer reader = new XmlSerializer(typeof(Dataset));
            StreamReader file = new StreamReader(@"D:\New folder (2)\Student List\Student Information Management\student_sample_data.xml");

            Dataset data = (Dataset)reader.Deserialize(file);
            file.Close();
            return data;
        }

        public Student Add(Student student)
        {
            _data.Add(student);

            return student;
        }

        public List<string> GetAllClasses()
        {
            // TODO: Retrieve listt class from list student
            return _data.Select(s => s.Class).Distinct().ToList();
        }

        public void Remove(int studentId)
        {
            var removedStudent = _data.FirstOrDefault(s => s.Id == studentId);

            _data.Remove(removedStudent);
        }

        public List<Student> SearchStudent(StudentSearchCriteria criteria)
        {
            // TODO: Implement filter criteria, search students which first name, last name and email contain criteria.SearchText

            return _data.Where(i => string.IsNullOrEmpty(criteria.SearchText) ||
                i.StudentId.ToString().Contains(criteria.SearchText) ||
                i.FirstName.ToString().Contains(criteria.SearchText) ||
                i.LastName.ToString().Contains(criteria.SearchText)
                &&
                (string.IsNullOrEmpty(criteria.ClassName) ||
                i.Class.Contains(criteria.ClassName))).ToList();
        }

        public Student Update(Student student)
        {
            var updateStudent = _data.FirstOrDefault(s => s.Id == student.Id);

            // TODO: Copy data from student to updateStudent
            updateStudent.FirstName = student.FirstName;

            return updateStudent;
        }

    }
}
