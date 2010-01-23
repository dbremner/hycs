using System;
using System.IO;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;

public enum Majors
{
    English,
    Nursing,
    Accounting,
    ComputerSciences,
    BusinessManagement,
    MathematicalSciences,
    HumanResourceDevelopment
}

[Serializable]
public class Student
{
    public string FullName;
    public DateTime DateOfBirth;
    public Majors Major;
}

public static class Program
{
    public static int Main(string[] args)
    {
        Queue que = new Queue();
        Student std = null;

        std = new Student();
        std.FullName = "Donald Palau";
        std.DateOfBirth = new DateTime(1988, 5, 12);
        std.Major = Majors.ComputerSciences;
        que.Enqueue(std);

        std = new Student();
        std.FullName = "Arlene Kafka";
        std.DateOfBirth = new DateTime(1992, 8, 4);
        std.Major = Majors.BusinessManagement;
        que.Enqueue(std);

        std = new Student();
        std.FullName = "Hortense Moons";
        std.DateOfBirth = new DateTime(1994, 10, 7);
        std.Major = Majors.MathematicalSciences;
        que.Enqueue(std);

        SaveStudents(que);
        return 0;
    }

    public static void SaveStudents(Queue q)
    {
        FileStream fsStudent = new FileStream("Students.roh",
                                            FileMode.Create,
                                            FileAccess.Write);
        BinaryFormatter bfStudent = new BinaryFormatter();

        bfStudent.Serialize(fsStudent, q);
        fsStudent.Close();
    }

    public static Queue OpenStudents()
    {
        FileStream fsStudent = new FileStream("Students.roh",
                                            FileMode.Open,
                                            FileAccess.Read);
        BinaryFormatter bfStudent = new BinaryFormatter();

        Queue pupils = (Queue)bfStudent.Deserialize(fsStudent);
        fsStudent.Close();

        return pupils;
    }
}