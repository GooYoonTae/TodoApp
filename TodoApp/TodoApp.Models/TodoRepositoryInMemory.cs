using System;
using System.Collections.Generic;
using System.Linq;

namespace TodoApp.Models
{
    public class TodoRepositoryInMemory : ITodoRepository
    {
        //[1]데이터베이스 역할을 하는 ,InMemory collection Field를 만들어 보겠습니다.
        //하나이상의 메서드에서 공유할 수 있는 목적으로
        private static List<Todo> _todos = new List<Todo>(); //초기화

        public TodoRepositoryInMemory() //생성자 , 3개의 데이터가 기본값으로 채워집니다.
        {
            _todos = new List<Todo>
           { 
                new Todo { Id = 1 , Title = "ASP.NET Core 학습" , IsDone = false},
                new Todo { Id = 2 , Title = "Blazor 학습" , IsDone = false},
                new Todo { Id = 3 , Title = "C# 학습" , IsDone = true},
           };
        }

        //인 - 메모리 데이터베이스 사용 영역
        public void Add(Todo model) //[2] 입력
        {
            //가장큰 id를 읽어 옵니다.
            //Systemj.Linq를 사용하여 Max를 사용합니다.
            model.Id = _todos.Max(t => t.Id) + 1;
            _todos.Add(model);
        }

        public List<Todo> GetAll() //출력
        {
            //todos 전체 반환
            return _todos.ToList();
        }
    }

}
