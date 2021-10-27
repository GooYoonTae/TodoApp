using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TodoApp.Models
{
    public class TodoRepositoryFile : ITodoRepository
    {
        //[1]데이터베이스 역할을 하는 ,InMemory collection Field를 만들어 보겠습니다.
        //하나이상의 메서드에서 공유할 수 있는 목적으로
        private static List<Todo> _todos = new List<Todo>(); //초기화

        private readonly string _filePath ; //파일 전역 패스 변수

        //public TodoRepositoryFile() //생성자 , 3개의 데이터가 기본값으로 채워집니다.
        //{
        //    _todos = new List<Todo>
        //   {
        //        new Todo { Id = 1 , Title = "ASP.NET Core 학습" , IsDone = false},
        //        new Todo { Id = 2 , Title = "Blazor 학습" , IsDone = false},
        //        new Todo { Id = 3 , Title = "C# 학습" , IsDone = true},
        //   };
        //}
        public TodoRepositoryFile(string filePath= @"D:\6.GIT\Temp\Todos.txt")
        {
            this._filePath = filePath;
            //D:\6.GIT\Temp\Todos.txt
            //using System.IO; 추가 , using System.Text; 추가
            string[] todos = File.ReadAllLines(filePath, Encoding.Default); //윈도우즈에 맞게 읽어 와라
            foreach (var t in todos)
            {
                string[] line = t.Split(',');
                _todos.Add(new Todo { Id = Convert.ToInt32(line[0]), 
                                      Title = line[1],
                                      IsDone = Convert.ToBoolean(line[2])});
                    
            }
        }
        //인 - 메모리 데이터베이스 사용 영역
        public void Add(Todo model) //[2] 입력
        {
            //가장큰 id를 읽어 옵니다.
            //Systemj.Linq를 사용하여 Max를 사용합니다.
            model.Id = _todos.Max(t => t.Id) + 1;
            _todos.Add(model);

            //파일 저장
            string data = "";
            foreach (var t in _todos)
            {
                //현재시점에서
                //저장한 형식으로 만들어 준다. ,줄바꿈으로 저장
                data += $"{t.Id},{t.Title},{t.IsDone}{Environment.NewLine}";
            }

            using (StreamWriter sw = new StreamWriter(_filePath))
            {
                sw.Write(data);
                sw.Close();
                sw.Dispose(); //메서드에서 메모리를 해제해라 , using에서는 않써도 됩니다.
            }
        }

        public List<Todo> GetAll() //출력
        {
            //todos 전체 반환
            return _todos.ToList();
        }
    }

}
