using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewFeaturesofDotnetNETSix
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class ClassRoom : IEnumerable<Student>, IAsyncEnumerable<Student>
    {
        public List<Student> Students { get; set; } = new List<Student>()
        {
             new Student(){ Id=1, Name="Erol" },
             new Student(){ Id=2, Name="Necati" },
             new Student(){ Id=3, Name="Osman" },


        };

        public async IAsyncEnumerator<Student> GetAsyncEnumerator(CancellationToken cancellationToken = default)
        {


            foreach (var item in Students.AsEnumerable())
            {
                yield return item;
            }


        }

        public IEnumerator<Student> GetEnumerator()
        {
            foreach (var student in Students)
            {
                yield return student;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
