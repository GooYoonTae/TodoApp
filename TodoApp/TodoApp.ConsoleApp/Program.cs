﻿using System;
using System.Collections.Generic;
using TodoApp.Models;

namespace TodoApp.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ITodoRepository _repository = new TodoRepositoryInMemory();
            //[1]전체 출력
            List<Todo> todos = new List<Todo>();
            todos = _repository.GetAll();
            //기본 데이터 출력
            foreach (var t in todos)
            {
                Console.WriteLine($"{t.Id},{t.Title},{t.IsDone}");
            }
            Console.WriteLine();
            //[2] 데이터입력
            Todo todo = new Todo { Title = "DataBase 학습", IsDone = true };
            _repository.Add(todo);

            //[3] 추가 데이터 출력
            todos = _repository.GetAll(); //다시 가져옵니다. 
            foreach (var t in todos)
            {
                Console.WriteLine($"{t.Id},{t.Title},{t.IsDone}");
            }
        }
    }
}
