using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator
{
    class Program
    {
        static void Main(string[] args)
        {
            Mediator mediator = new Mediator();
            Teacher engin = new Teacher(mediator) {Name="Engin" };

            mediator.Teacher = engin;

            Student derin = new Student(mediator) { Name="Derin"};
            Student baris = new Student(mediator) { Name = "Barış" };
            mediator.Students = new List<Student>() { derin,baris};

            engin.SendNewImageUrl("slide1.jpg");
            engin.RecieveQuestion("is it true", baris);

        }
    }

    abstract class CourseMember
    {
        protected Mediator Mediator;
        public CourseMember(Mediator _mediator)
        {
            Mediator = _mediator;
        }
    }

    class Teacher : CourseMember
    {
        

        public Teacher(Mediator _mediator) : base(_mediator)
        {
        }
        public string Name { get; set; }
        public void RecieveQuestion(string question, Student student)
        {
            Console.WriteLine("Teacher recieved a quesiton from {0} ,{1}",student.Name,question);
        }

        public void SendNewImageUrl(string url)
        {
            Console.WriteLine("Teacher changed slide:{0} ",url);
            Mediator.UpdateImage(url);
        }

        public void AnswerQuestion(string answer,Student student)
        {
            Console.WriteLine("Teacher answered quesiton {0} {1}",answer,student.Name);
            Mediator.SendAnswer(answer,student);
        }

    }

    class Student : CourseMember
    {
        public Student(Mediator _mediator) : base(_mediator)
        {
        }

        public string Name { get; set; }

        public void RecieveIamge(string url)
        {
            Console.WriteLine("{1} Recieved Image: {0}",url,Name);
        }

        public void RecieveAnswer(string answer)
        {
            Console.WriteLine("{1} recieved answer {0}",answer,Name);
        }
    }

    class Mediator
    {
        public Teacher Teacher { get; set; }
        public List<Student> Students { get; set; }

        public void UpdateImage(string url)
        {
            foreach (var student in Students)
            {
                student.RecieveIamge(url);
            }
        }

        public void SendQuestion(string question,Student student)
        {
            Teacher.RecieveQuestion(question, student);
        }

        public void SendAnswer(string answer,Student student)
        {
            student.RecieveAnswer(answer);
        }
    
    }


}
