using PersonEmployeeManager;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonEmployeeManager;

public interface IUserStore
{
    List<Person> Load();
    void Save(List<Person> people);
    Person? FindByUsername(string username);
    bool Create(Person person);
}
