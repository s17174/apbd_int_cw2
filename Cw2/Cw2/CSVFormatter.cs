using Cw2.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace Cw2
{
    internal class CSVFormatter
    {
        private readonly string pathIn;
        private readonly string pathOut;
        private readonly string format;

        public CSVFormatter()
        {
            this.pathIn = FileUtils.pathIn;
            this.pathOut = FileUtils.pathOut;
            this.format = FileUtils.format;
        }

        public void FormatAndSerialize()
        {
            HashSet<Student> studentsData = new HashSet<Student>(new StudentsComparator());
            var fileInfo = new FileInfo(pathIn);
            using (var streamReader = new StreamReader(fileInfo.OpenRead()))
            {
                string line = null;
                while (( line = streamReader.ReadLine()) != null)
                {
                    string[] columns = line.Split(',');
                    if(!TableChecker<string>.CheckLength(columns, 9))
                    {
                        Logger.SaveErrorMessageToFile(new ArgumentException(line));
                        continue;
                    }

                    for(int i=0; i < columns.Length; i++)
                    {
                        if (TableChecker<string>.CheckColumn(columns[i]))
                        {
                            Logger.SaveErrorMessageToFile(new ArgumentException("Puste kolumny w linii: " + line));
                            continue;
                        }

                    }
                    var student = new Student
                    {
                        Name = columns[0],
                        Surname = columns[1],
                        TypeOfStudy = columns[2],
                        NameOfStudy = columns[3],
                        Id = columns[4],
                        BirthDay = columns[5],
                        Email = columns[6],
                        MothersName = columns[7],
                        FathersName = columns[8]
                    };
                    if (!studentsData.Add(student))
                    {
                        Logger.SaveErrorMessageToFile(new DuplicateNameException("duplikat studenta!"));
                    }
                }
                var studentList = new List<Student>(studentsData);

                if (format.Equals("xml"))
                {
                    Writer<Student>.WriteDataToXML(pathOut, studentList, "uczelnia");
                }
                else if (format.Equals("json"))
                {
                    Writer<Student>.WriteDataToJson(pathOut, studentList);
                }
                else
                {
                    Logger.SaveErrorMessageToFile(new FormatException("Format nieobsługiwany"));
                }
 
            }

        }

    }
}