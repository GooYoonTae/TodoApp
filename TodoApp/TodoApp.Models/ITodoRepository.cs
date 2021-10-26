using System.Collections.Generic;

namespace TodoApp.Models
{
    public interface ITodoRepository
    {
        //반드시 오버라이드 해서 구현해줘야한다.
        void Add(Todo model);//데이터 입력 시그니처
        List<Todo> GetAll();// 데이터 출력
    }

}
